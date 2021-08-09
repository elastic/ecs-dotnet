// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Elastic.Transport;

namespace Elastic.Ingest
{
	public abstract class TransportChannelBase<TChannelOptions, TBuffer, TEvent, TResponse, TBulkResponseItem> : IDisposable
		where TChannelOptions : ChannelOptionsBase<TEvent, TResponse, TBulkResponseItem, TBuffer>
		where TBuffer : BufferOptions<TEvent, TResponse, TBulkResponseItem>, new()
		where TResponse : class, ITransportResponse, new()

	{
		private readonly List<Task> _backgroundTasks = new();

		protected TransportChannelBase(TChannelOptions options)
		{
			_options = options;
			UpdateClient();

			var maxConsumers = Math.Max(1, BufferOptions.ConcurrentConsumers);
			Channel = System.Threading.Channels.Channel.CreateBounded<TEvent>(new BoundedChannelOptions(BufferOptions.MaxInFlightMessages)
			{
				SingleReader = maxConsumers == 1,
				// Stephen Toub comment: https://github.com/dotnet/runtime/issues/26338#issuecomment-393720727
				// AFAICT this is fine since we run in a dedicated long running task.
				AllowSynchronousContinuations = true,
				// wait does not block it simply signals that Writer.TryWrite should return false and be retried
				// DropWrite will make `TryWrite` always return true, which is not what we want.
				FullMode = BoundedChannelFullMode.Wait
			});

			var waitHandle = maxConsumers == 1 ? BufferOptions.WaitHandle : null;
			Task ConsumeMessages() => Consume(BufferOptions.MaxConsumerBufferSize, BufferOptions.MaxConsumerBufferLifetime, waitHandle);

			// TODO I Think Task.Run is actually fine here, also allows us to box and capture this in the lambda to StartNew.
			// could be a config option
			for (var i = 0; i < maxConsumers; i++)
				_backgroundTasks.Add(Task.Factory.StartNew(async () => await ConsumeMessages().ConfigureAwait(false), TaskCreationOptions.LongRunning).Unwrap());
		}

		private ITransport<ITransportConfiguration> _transport = default!;

		protected Channel<TEvent> Channel { get; }
		protected ChannelWriter<TEvent> Writer => Channel.Writer;
		protected BufferOptions<TEvent, TResponse, TBulkResponseItem> BufferOptions => _options.BufferOptions;

		private TChannelOptions _options;
		public TChannelOptions Options
		{
			get => _options;
			set
			{
				_options = value;
				UpdateClient();
			}
		}

		public virtual bool TryWrite(TEvent item)
		{
			if (Writer.TryWrite(item)) return true;

			Options.BufferOptions.PublishRejectionCallback?.Invoke(item);
			return false;
		}

		/// <summary> Implement sending the current <paramref name="page"/> of the buffer to the output. </summary>
		/// <param name="transport"></param>
		/// <param name="page">Active page of the buffer that needs to be send to the output</param>
		/// <returns><see cref="TResponse"/></returns>
		protected abstract Task<TResponse> Send(ITransport<ITransportConfiguration> transport, List<TEvent> page);


		protected abstract bool BackOffRequest(TResponse response);
		protected abstract List<(TEvent, TBulkResponseItem)> Zip(TResponse response, List<TEvent> page);
		protected abstract bool RetryEvent((TEvent, TBulkResponseItem) @event);
		protected abstract bool RejectEvent((TEvent, TBulkResponseItem) @event);

		private async Task Consume(int maxQueuedMessages, TimeSpan maxInterval, CountdownEvent? countdown)
		{
			using var buffer = new ChannelBuffer<TEvent>(maxQueuedMessages, maxInterval);

			while (await buffer.WaitToReadAsync(Channel.Reader).ConfigureAwait(false))
			{
				while (buffer.Count < maxQueuedMessages && Channel.Reader.TryRead(out var item))
				{
					if (buffer.DurationSinceFirstRead > maxInterval) break;

					buffer.Add(item);
				}

				if (buffer.NoThresholdsHit) continue;

				var items = buffer.Buffer;
				var maxRetries = Options.BufferOptions.MaxRetries;
				for (var i = 0; i <= maxRetries && items.Count > 0; i++)
				{
					Options.BufferOptions.BulkAttemptCallback?.Invoke(i, items.Count);
					TResponse response = null!;
					try
					{
						response = await Send(_transport, items).ConfigureAwait(false);
					}
					catch (Exception e)
					{
						Options.BufferOptions.ExceptionCallback?.Invoke(e);
						break;
					}

					// TODO to callback receives buffer but only sees IBufferChannel values which could
					// get updated when the callback executes, not thread safe. Sent an isolated copy and decouple
					// IChannelBuffer from ChannelBuffer
					Options.BufferOptions.ResponseCallback?.Invoke(response, buffer);
					var backOffWholeRequest = BackOffRequest(response);
					// if we are not retrying the whole request find out if individual items need retrying
					if (!backOffWholeRequest)
					{
						// TODO https://github.com/elastic/elasticsearch/issues/60442
						// allows us to check for `207` before doing expensive LINQ/array manipulations

						//TODO handle retries?
						var zipped = Zip(response, items);
						//ApmChannelStatics.RetryStatusCodes.Contains(t.item.Status))
						//(t.item.Status < 200 || t.item.Status > 300)

						// retry any 429,502,503,504
						items = zipped
						 	.Where(t => RetryEvent(t))
						 	.Select(t => t.Item1)
						 	.ToList();

						// report any events that are going to be dropped
						if (Options.BufferOptions.ServerRejectionCallback != null)
						{
							var rejected = zipped
								.Where(t => RejectEvent(t) && !RetryEvent(t))
								.ToList();
							if (rejected.Count > 0) Options.BufferOptions.ServerRejectionCallback(rejected);
						}
					}

					// delay if we still have items and we are not at the end of the max retry cycle
					var atEndOfRetries = i == maxRetries;
					if (items.Count > 0 && !atEndOfRetries)
					{
						await Task.Delay(Options.BufferOptions.BackoffPeriod(i)).ConfigureAwait(false);
						Options.BufferOptions.RetryCallBack?.Invoke(items);
					}
					// otherwise if retryable items still exist and the user wants to be notified notify the user
					else if (items.Count > 0 && atEndOfRetries)
						Options.BufferOptions.MaxRetriesExceededCallback?.Invoke(items);

				}
				buffer.Reset();
				Options.BufferOptions.BufferFlushCallback?.Invoke();
				countdown?.Signal();
			}
		}

		// TODO private, make reload support very explicit (change shipto only?)

		public void Dispose()
		{
			try
			{
				// TODO cancellation
				foreach (var t in _backgroundTasks) t.Dispose();
			}
			catch { }
		}

		private void UpdateClient()
		{
			if (_options.ShipTo.Transport != null)
			{
				_transport = _options.ShipTo.Transport;
				return;
			}


			// TODO: Check if Uri has changed before recreating
			// TODO: Injectable factory? Or some way of testing.
			var connectionPool = _options.ShipTo.CreateConnectionPool();
			var nodes = _options.ShipTo.NodeUris?.ToArray() ?? Array.Empty<Uri>();

			TransportConfiguration config;
			if (nodes.Length == 0 && _options.ShipTo.ConnectionPool != ConnectionPoolType.Cloud)
			{
				// This is SingleNode with "http://localhost:9200"
				var singleNodePool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
				config = new TransportConfiguration(singleNodePool);
			}
			else if (_options.ConnectionPoolType == ConnectionPoolType.SingleNode
				|| _options.ConnectionPoolType == ConnectionPoolType.Unknown && nodes.Length == 1)
			{
				var singleNodePool = new SingleNodeConnectionPool(nodes[0]);
				config = new TransportConfiguration(singleNodePool);
			}
			else
			{
				config = new TransportConfiguration(connectionPool);
			}

			config = config.Proxy(new Uri("http://localhost:8080"), "", "");
			config = config.EnableDebugMode();

			var transport = new Transport<TransportConfiguration>(config);

			_ = Interlocked.Exchange(ref _transport, transport);
		}
	}
}
