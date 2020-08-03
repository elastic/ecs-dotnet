// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Elasticsearch.Net;

namespace Elasticsearch.Extensions.Logging
{
	internal class ElasticsearchDataShipper : IDisposable
	{
		private readonly List<Task<Task>> _backgroundTasks =  new List<Task<Task>>();

		public ElasticsearchDataShipper(ElasticsearchLoggerOptions options)
		{
			_options = options;
			var maxConsumers = Math.Max(1, options.Throttles.ConcurrentConsumers);
			PubSub = Channel.CreateBounded<LogEvent>(new BoundedChannelOptions(options.Throttles.MaxInFlightMessages)
			{
				SingleReader = maxConsumers == 1,
				AllowSynchronousContinuations = true,
				// wait does not block it simply signals that Writer.TryWrite should return false and be retried
				// DropWrite will make `TryWrite` always return true, which is not what we want.
				FullMode = BoundedChannelFullMode.Wait
			});
			async Task ConsumeMessages() =>
				await Consume(options.Throttles.MaxConsumerBufferSize, options.Throttles.MaxConsumerBufferLifetime).ConfigureAwait(false);
			for (var i = 0; i < maxConsumers; i++)
				_backgroundTasks.Add(Task.Factory.StartNew(() => ConsumeMessages(), TaskCreationOptions.LongRunning));
		}


		private IElasticLowLevelClient _lowLevelClient = default!;

		private ElasticsearchLoggerOptions _options;
		public Channel<LogEvent> PubSub { get; }
		public ChannelWriter<LogEvent> Writer => PubSub.Writer;

		public void Enqueue(LogEvent item)
		{
			if (!Writer.TryWrite(item))
				Options.Throttles.PublishRejectionCallback?.Invoke(item);
		}

		private static readonly byte[] LineFeed = { (byte)'\n' };


		private async Task Consume(int maxQueuedMessages, TimeSpan maxInterval)
		{
			using var buffer = new ConsumerBuffer(maxQueuedMessages, maxInterval);

			while (await buffer.WaitToReadAsync(PubSub.Reader).ConfigureAwait(false))
			{
				while (buffer.Count < maxQueuedMessages && PubSub.Reader.TryRead(out LogEvent item))
				{
					if (buffer.DurationSinceFirstRead > maxInterval) break;

					buffer.Add(item);
				}

				if (buffer.NoThresholdsHit) continue;

				var response = await _lowLevelClient.BulkAsync<DynamicResponse>(
						PostData.StreamHandler(buffer,
							(@event, stream) =>
							{
								/* NOT USED */
							},
							async (@event, stream, ctx) =>
							{
								foreach (var logEvent in buffer.Buffer)
								{
									var indexTime = logEvent.Timestamp ?? ElasticsearchLoggerProvider.LocalDateTimeProvider();
									if (_options.IndexOffset.HasValue) indexTime = indexTime.ToOffset(_options.IndexOffset.Value);

									var index = string.Format(_options.Index, indexTime);
									var indexHeader = new { index = new { _index = index } };
									await JsonSerializer.SerializeAsync(stream, indexHeader, indexHeader.GetType(), SerializerOptions, ctx)
										.ConfigureAwait(false);
									await stream.WriteAsync(LineFeed, 0, 1, ctx).ConfigureAwait(false);
									await logEvent.SerializeAsync(stream, ctx).ConfigureAwait(false);
									await stream.WriteAsync(LineFeed, 0, 1, ctx).ConfigureAwait(false);
								}
							})
					)
					.ConfigureAwait(false);

				// TODO retries, backoff, response failure callbacks

				Options.Throttles.ElasticsearchResponseCallback?.Invoke(response, buffer);

				buffer.Reset();
			}
		}

		private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
		{
			IgnoreNullValues = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
		};

		internal ElasticsearchLoggerOptions Options
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

			if (nodes.Length == 0 && _options.ShipTo.ConnectionPoolType != ConnectionPoolType.Cloud)
			{
				// This is SingleNode with "http://localhost:9200"
				settings = new ConnectionConfiguration();
			}
			else if (_options.ConnectionPoolType == ConnectionPoolType.SingleNode
				|| _options.ConnectionPoolType == ConnectionPoolType.Unknown && nodes.Length == 1)
				settings = new ConnectionConfiguration(nodes[0]);
			else
			{
				settings = new ConnectionConfiguration(connectionPool);
			}
			settings = settings.EnableDebugMode();
			var lowlevelClient = new ElasticLowLevelClient(settings);

			_ = Interlocked.Exchange(ref _lowLevelClient, lowlevelClient);
		}
	}
}
