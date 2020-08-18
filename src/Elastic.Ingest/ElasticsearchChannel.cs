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

		public static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
		{
			IgnoreNullValues = true,
			Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
		};

		public static readonly HashSet<int> RetryStatusCodes = new HashSet<int>(new[] { 502, 503, 504, 429 });
	}

	public class ElasticsearchChannel<TEvent> : IDisposable
	{
		private readonly List<Task<Task>> _backgroundTasks = new List<Task<Task>>();

		public ElasticsearchChannel(ElasticsearchChannelOptions<TEvent> options)
		{
			_options = options;
			var maxConsumers = Math.Max(1, options.BufferOptions.ConcurrentConsumers);
			Channel = System.Threading.Channels.Channel.CreateBounded<TEvent>(new BoundedChannelOptions(options.BufferOptions.MaxInFlightMessages)
			{
				SingleReader = maxConsumers == 1,
				AllowSynchronousContinuations = true,
				// wait does not block it simply signals that Writer.TryWrite should return false and be retried
				// DropWrite will make `TryWrite` always return true, which is not what we want.
				FullMode = BoundedChannelFullMode.Wait
			});

			async Task ConsumeMessages() =>
				await Consume(options.BufferOptions.MaxConsumerBufferSize, options.BufferOptions.MaxConsumerBufferLifetime).ConfigureAwait(false);

			for (var i = 0; i < maxConsumers; i++)
				_backgroundTasks.Add(Task.Factory.StartNew(() => ConsumeMessages(), TaskCreationOptions.LongRunning));
		}

		private IElasticLowLevelClient _lowLevelClient = default!;

		private ElasticsearchChannelOptions<TEvent> _options;
		public Channel<TEvent> Channel { get; }
		public ChannelWriter<TEvent> Writer => Channel.Writer;

		public bool TryWrite(TEvent item)
		{
			if (Writer.TryWrite(item)) return true;

			Options.BufferOptions.PublishRejectionCallback?.Invoke(item);
			return false;
		}

		private async Task Consume(int maxQueuedMessages, TimeSpan maxInterval)
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
				BulkResponse? response = null;
				for (var i = 0; i < 3 && items.Count > 0; i++)
				{
					// TODO https://github.com/elastic/elasticsearch/pull/55088
					// Allows to happy flow to return no items on the response
					response = await _lowLevelClient.BulkAsync<BulkResponse>(
							PostData.StreamHandler(items,
								(b, stream) => { /* NOT USED */ },
								async (b, stream, ctx) => { await WriteBufferToStreamAsync(b, stream, ctx).ConfigureAwait(false); })
							, ElasticsearchChannelStatics.RequestParams)
						.ConfigureAwait(false);

					// TODO to callback receives buffer but only sees IBufferChannel values which could
					// get updated when the callback executes, not thread safe. Sent an isolated copy and decouple
					// IChannelBuffer from ChannelBuffer
					Options.BufferOptions.ElasticsearchResponseCallback?.Invoke(response, buffer);

					// TODO https://github.com/elastic/elasticsearch/issues/60442
					// allows us to check for `207` before doing expensive LINQ/array manipulations
					items = items
						.Zip(response.Items, (doc, item) => (doc, item))
						.Where(t => ElasticsearchChannelStatics.RetryStatusCodes.Contains(t.item.Status))
						.Select(t => t.doc)
						.ToList();

					// TODO callback for rejected items

					// TODO make backoff configurable as lambda on options
					if (items.Count > 0)
						await Task.Delay(TimeSpan.FromSeconds(2 * (i + 1))).ConfigureAwait(false);
				}
				if (items.Count > 0 && response != null)
				{
					// TODO callback for items which could potentially still be retried
				}
				buffer.Reset();
			}
		}

		private async Task WriteBufferToStreamAsync(List<TEvent> b, Stream stream, CancellationToken ctx)
		{
			foreach (var @event in b)
			{
				if (@event == null) continue;

				var indexTime = Options.TimestampLookup?.Invoke(@event) ?? DateTimeOffset.Now;
				if (_options.IndexOffset.HasValue) indexTime = indexTime.ToOffset(_options.IndexOffset.Value);

				var index = string.Format(_options.Index, indexTime);
				var indexHeader = new { index = new { _index = "H" + index } };
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

		// TODO private, make reload support very explicit (change shipto only?)

		public ElasticsearchChannelOptions<TEvent> Options
		{
			get => _options;
			set
			{
				_options = value;
				UpdateClient();
			}
		}

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
			// TODO: Check if Uri has changed before recreating
			// TODO: Injectable factory? Or some way of testing.
			var connectionPool = _options.ShipTo.CreateConnectionPool();
			var nodes = _options.ShipTo.NodeUris.ToArray();

			ConnectionConfiguration settings;
			var serializer = new SystemTextJsonSerializer();

			if (nodes.Length == 0 && _options.ShipTo.ConnectionPool != ConnectionPoolType.Cloud)
			{
				// This is SingleNode with "http://localhost:9200"
				var singleNodePool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
				settings = new ConnectionConfiguration(singleNodePool, serializer: serializer);
			}
			else if (_options.ConnectionPoolType == ConnectionPoolType.SingleNode
				|| _options.ConnectionPoolType == ConnectionPoolType.Unknown && nodes.Length == 1)
			{
				var singleNodePool = new SingleNodeConnectionPool(nodes[0]);
				settings = new ConnectionConfiguration(singleNodePool, serializer: serializer);
			}
			else
			{
				settings = new ConnectionConfiguration(connectionPool, serializer: serializer);
			}

			settings = settings.Proxy(new Uri("http://localhost:8080"), "", "");
			settings = settings.EnableDebugMode();

			var lowlevelClient = new ElasticLowLevelClient(settings);

			_ = Interlocked.Exchange(ref _lowLevelClient, lowlevelClient);
		}
	}
}
