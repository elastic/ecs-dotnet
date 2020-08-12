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

namespace Elastic.Ingest
{
	public class ElasticsearchChannel<TEvent> : IDisposable
	{
		private readonly List<Task<Task>> _backgroundTasks =  new List<Task<Task>>();

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

		private static readonly byte[] LineFeed = { (byte)'\n' };


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

				var response = await _lowLevelClient.BulkAsync<DynamicResponse>(
						PostData.StreamHandler(buffer.Buffer,
							(b, stream) => { /* NOT USED */ },
							async (b, stream, ctx) =>
							{
								foreach (var @event in b)
								{
									if (@event == null) continue;
									var indexTime = Options.TimestampLookup?.Invoke(@event) ?? DateTimeOffset.Now;
									if (_options.IndexOffset.HasValue) indexTime = indexTime.ToOffset(_options.IndexOffset.Value);

									var index = string.Format(_options.Index, indexTime);
									var indexHeader = new { index = new { _index = index } };
									await JsonSerializer.SerializeAsync(stream, indexHeader, indexHeader.GetType(), SerializerOptions, ctx)
										.ConfigureAwait(false);
									await stream.WriteAsync(LineFeed, 0, 1, ctx).ConfigureAwait(false);
									if (Options.WriteEvent != null)
										await Options.WriteEvent(stream, ctx, @event).ConfigureAwait(false);
									else
									{
										await JsonSerializer.SerializeAsync(stream, @event, typeof(TEvent), SerializerOptions, ctx)
											.ConfigureAwait(false);
									}

									await stream.WriteAsync(LineFeed, 0, 1, ctx).ConfigureAwait(false);
								}
							})
					)
					.ConfigureAwait(false);

				// TODO retries, backoff, response failure callbacks

				Options.BufferOptions.ElasticsearchResponseCallback?.Invoke(response, buffer);

				buffer.Reset();
			}
		}

		private static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
		{
			IgnoreNullValues = true, Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
		};

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

			if (nodes.Length == 0 && _options.ShipTo.ConnectionPool != ConnectionPoolType.Cloud)
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
			var lowlevelClient = new ElasticLowLevelClient(settings);

			_ = Interlocked.Exchange(ref _lowLevelClient, lowlevelClient);
		}
	}
}
