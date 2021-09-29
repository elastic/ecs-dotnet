// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Elastic.Ingest
{
	public interface IIngestChannel<in TEvent> : IDisposable
	{
		bool TryWrite(TEvent item);
	}

	public abstract class ChannelBase<TChannelOptions, TBuffer, TEvent, TResponse>
		: IIngestChannel<TEvent>
		where TChannelOptions : ChannelOptionsBase<TEvent, TBuffer, TResponse>
		where TBuffer : BufferOptions<TEvent>, new()
		where TResponse : class, new()
	{
		private readonly List<Task> _backgroundTasks = new();

		protected ChannelBase(TChannelOptions options)
		{
			Options = options;
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

		public TChannelOptions Options { get; }
		protected Channel<TEvent> Channel { get; }
		protected ChannelWriter<TEvent> Writer => Channel.Writer;
		protected TBuffer BufferOptions => Options.BufferOptions;


		public virtual bool TryWrite(TEvent item)
		{
			if (Writer.TryWrite(item)) return true;

			Options.PublishRejectionCallback?.Invoke(item);
			return false;
		}

		protected abstract Task<TResponse> Send(List<TEvent> page);

		protected virtual List<TEvent> RetryBuffer(TResponse response, List<TEvent> currentBuffer, IConsumedBufferStatistics statistics) => currentBuffer;

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
					Options.BulkAttemptCallback?.Invoke(i, items.Count);
					TResponse response = null!;
					try
					{
						response = await Send(items).ConfigureAwait(false);
						Options.ResponseCallback(response, buffer);
					}
					catch (Exception e)
					{
						Options.ExceptionCallback?.Invoke(e);
						break;
					}

					items = RetryBuffer(response, items, buffer);

					// delay if we still have items and we are not at the end of the max retry cycle
					var atEndOfRetries = i == maxRetries;
					if (items.Count > 0 && !atEndOfRetries)
					{
						await Task.Delay(Options.BufferOptions.BackoffPeriod(i)).ConfigureAwait(false);
						Options.RetryCallBack?.Invoke(items);
					}
					// otherwise if retryable items still exist and the user wants to be notified notify the user
					else if (items.Count > 0 && atEndOfRetries)
						Options.MaxRetriesExceededCallback?.Invoke(items);

				}
				buffer.Reset();
				Options.BufferOptions.BufferFlushCallback?.Invoke();
				countdown?.Signal();
			}
		}

		public virtual void Dispose()
		{
			try
			{
				// TODO cancellation
				foreach (var t in _backgroundTasks) t.Dispose();
			}
			catch { }
		}

	}

	public abstract class ChannelBase<TChannelOptions, TBuffer, TEvent, TResponse, TBulkResponseItem>
		: ChannelBase<TChannelOptions, TBuffer, TEvent, TResponse>
		where TChannelOptions : ChannelOptionsBase<TEvent, TBuffer, TResponse, TBulkResponseItem>
		where TBuffer : BufferOptions<TEvent>, new()
		where TResponse : class, new()
	{
		protected ChannelBase(TChannelOptions options) : base(options) { }

		protected abstract bool BackOffRequest(TResponse response);
		protected abstract List<(TEvent, TBulkResponseItem)> Zip(TResponse response, List<TEvent> page);
		protected abstract bool RetryEvent((TEvent, TBulkResponseItem) @event);
		protected abstract bool RejectEvent((TEvent, TBulkResponseItem) @event);

		protected override List<TEvent> RetryBuffer(TResponse response, List<TEvent> events, IConsumedBufferStatistics consumedBufferStatistics)
		{
			Options.ResponseCallback?.Invoke(response, consumedBufferStatistics);
			var backOffWholeRequest = BackOffRequest(response);
			// if we are not retrying the whole request find out if individual items need retrying
			if (!backOffWholeRequest)
			{
				// TODO https://github.com/elastic/elasticsearch/issues/60442
				// allows us to check for `207` before doing expensive LINQ/array manipulations

				//TODO handle retries?
				var zipped = Zip(response, events);
				//ApmChannelStatics.RetryStatusCodes.Contains(t.item.Status))
				//(t.item.Status < 200 || t.item.Status > 300)

				// retry any 429,502,503,504
				events = zipped
					.Where(t => RetryEvent(t))
					.Select(t => t.Item1)
					.ToList();

				// report any events that are going to be dropped
				if (Options.ServerRejectionCallback != null)
				{
					var rejected = zipped
						.Where(t => RejectEvent(t) && !RetryEvent(t))
						.ToList();
					if (rejected.Count > 0) Options.ServerRejectionCallback(rejected);
				}
			}
			return events;
		}
	}
}
