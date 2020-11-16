// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Elastic.Ingest.Serialization;
using Elasticsearch.Net;

namespace Elastic.Ingest
{
	internal static class ElasticsearchChannelStatics
	{
		public static readonly byte[] LineFeed = { (byte)'\n' };

		public static readonly BulkRequestParameters RequestParams =
			new BulkRequestParameters { QueryString = { { "filter_path", "error, items.*.status,items.*.error" } } };

		public static readonly HashSet<int> RetryStatusCodes = new HashSet<int>(new[] { 502, 503, 504, 429 });

		public static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
		{
			IgnoreNullValues = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
		};
	}

	public class ElasticsearchChannel<TEvent> : IDisposable
	{
		private readonly List<Task> _backgroundTasks = new List<Task>();

		private IElasticLowLevelClient _lowLevelClient = default!;

		private ElasticsearchChannelOptions<TEvent> _options;

		public ElasticsearchChannel(ElasticsearchChannelOptions<TEvent> options)
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

			Task ConsumeMessages()
			{
				return Consume(BufferOptions.MaxConsumerBufferSize, BufferOptions.MaxConsumerBufferLifetime, waitHandle);
			}

			// TODO I Think Task.Run is actually fine here, also allows us to box and capture this in the lambda to StartNew.
			// could be a config option
			for (var i = 0; i < maxConsumers; i++)
				_backgroundTasks.Add(Task.Factory.StartNew(async () => await ConsumeMessages().ConfigureAwait(false), TaskCreationOptions.LongRunning)
					.Unwrap());
		}

		public BufferOptions<TEvent> BufferOptions => _options.BufferOptions;

		public Channel<TEvent> Channel { get; }

		public ElasticsearchChannelOptions<TEvent> Options
		{
			get => _options;
			set
			{
				_options = value;
				UpdateClient();
			}
		}

		public ChannelWriter<TEvent> Writer => Channel.Writer;

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


		public bool TryWrite(TEvent item)
		{
			if (Writer.TryWrite(item)) return true;

			Options.BufferOptions.PublishRejectionCallback?.Invoke(item);
			return false;
		}

		private async Task Consume(int maxQueuedMessages, TimeSpan maxInterval, ManualResetEventSlim? bufferOptionsWaitHandle)
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
					// TODO https://github.com/elastic/elasticsearch/pull/55088
					// Allows to happy flow to return no items on the response
					BulkResponse response = null!;
					try
					{
						response = await _lowLevelClient.BulkAsync<BulkResponse>(
								PostData.StreamHandler(items,
									(b, stream) =>
									{
										/* NOT USED */
									},
									async (b, stream, ctx) => { await WriteBufferToStreamAsync(b, stream, ctx).ConfigureAwait(false); })
								, ElasticsearchChannelStatics.RequestParams)
							.ConfigureAwait(false);
					}
					catch (Exception e)
					{
						Options.BufferOptions.ExceptionCallback?.Invoke(e);
						break;
					}

					// TODO to callback receives buffer but only sees IBufferChannel values which could
					// get updated when the callback executes, not thread safe. Sent an isolated copy and decouple
					// IChannelBuffer from ChannelBuffer
					Options.BufferOptions.ElasticsearchResponseCallback?.Invoke(response, buffer);

					// TODO https://github.com/elastic/elasticsearch/issues/60442
					// allows us to check for `207` before doing expensive LINQ/array manipulations

					var zipped = items.Zip(response.Items, (doc, item) => (doc, item)).ToList();

					// retry any 429,502,503,504
					items = zipped
						.Where(t => ElasticsearchChannelStatics.RetryStatusCodes.Contains(t.item.Status))
						.Select(t => t.doc)
						.ToList();

					// report any events that are going to be dropped
					if (Options.BufferOptions.ServerRejectionCallback != null)
					{
						var rejected = zipped
							.Where(t =>
								(t.item.Status < 200 || t.item.Status > 300)
								&& !ElasticsearchChannelStatics.RetryStatusCodes.Contains(t.item.Status))
							.ToList();
						if (rejected.Count > 0) Options.BufferOptions.ServerRejectionCallback(rejected);
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
				bufferOptionsWaitHandle?.Set();
			}
		}

		private void UpdateClient()
		{
			if (_options.ShipTo.Client != null)
			{
				_lowLevelClient = _options.ShipTo.Client;
				return;
			}

			// TODO: Check if Uri has changed before recreating
			// TODO: Injectable factory? Or some way of testing.
			var nodes = _options.ShipTo.NodeUris?.ToArray() ?? Array.Empty<Uri>();

			ConnectionConfiguration settings;
			var serializer = new SystemTextJsonSerializer();

			if (nodes.Length == 0 && _options.ShipTo.ConnectionPool != ConnectionPoolType.Cloud)
			{
				// This is SingleNode with "http://localhost:9200"
				var singleNodePool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
				settings = new ConnectionConfiguration(singleNodePool, serializer);
			}
			else if (_options.ConnectionPoolType == ConnectionPoolType.SingleNode
				|| _options.ConnectionPoolType == ConnectionPoolType.Unknown && nodes.Length == 1)
			{
				var singleNodePool = new SingleNodeConnectionPool(nodes[0]);
				settings = new ConnectionConfiguration(singleNodePool, serializer);
			}
			else
			{
				var connectionPool = _options.ShipTo.CreateConnectionPool();
				settings = new ConnectionConfiguration(connectionPool, serializer);
			}

			settings = settings.Proxy(new Uri("http://localhost:8080"), "", "");
			settings = settings.EnableDebugMode();

			var lowlevelClient = new ElasticLowLevelClient(settings);

			_ = Interlocked.Exchange(ref _lowLevelClient, lowlevelClient);
		}

		private async Task WriteBufferToStreamAsync(List<TEvent> b, Stream stream, CancellationToken ctx)
		{
			foreach (var @event in b)
			{
				if (@event == null) continue;

				var indexTime = Options.TimestampLookup?.Invoke(@event) ?? DateTimeOffset.Now;
				if (_options.IndexOffset.HasValue) indexTime = indexTime.ToOffset(_options.IndexOffset.Value);

				var index = string.Format(_options.Index, indexTime);
				var indexHeader = new { index = new { _index = index } };
				await JsonSerializer.SerializeAsync(stream, indexHeader, indexHeader.GetType(), ElasticsearchChannelStatics.SerializerOptions, ctx)
					.ConfigureAwait(false);
				await stream.WriteAsync(ElasticsearchChannelStatics.LineFeed, 0, 1, ctx).ConfigureAwait(false);
				if (Options.WriteEvent != null)
					await Options.WriteEvent(stream, ctx, @event).ConfigureAwait(false);
				else
				{
					await JsonSerializer.SerializeAsync(stream, @event, typeof(TEvent), ElasticsearchChannelStatics.SerializerOptions, ctx)
						.ConfigureAwait(false);
				}

				await stream.WriteAsync(ElasticsearchChannelStatics.LineFeed, 0, 1, ctx).ConfigureAwait(false);
			}
		}
	}
}
