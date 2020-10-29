// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;
using Elastic.Ingest.Apm.Model;
using Elastic.Transport;

namespace Elastic.Ingest.Apm
{
	internal static class ApmChannelStatics
	{
		public static readonly byte[] LineFeed = { (byte)'\n' };

		public static readonly RequestParameters RequestParams = new RequestParameters(HttpMethod.POST, supportsBody: true)
		{
			RequestConfiguration = new RequestConfiguration
			{
				ContentType = "application/x-ndjson"
			}
		};

		public static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions
		{
			IgnoreNullValues = true,
			MaxDepth = 64,
			Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
		};

		public static readonly HashSet<int> RetryStatusCodes = new HashSet<int>(new[] { 502, 503, 504, 429 });
	}

	public class ApmChannel : IDisposable
	{
		private readonly List<Task> _backgroundTasks = new List<Task>();

		public ApmChannel(ApmChannelOptions options)
		{
			_options = options;
			UpdateClient();

			var maxConsumers = Math.Max(1, BufferOptions.ConcurrentConsumers);
			Channel = System.Threading.Channels.Channel.CreateBounded<IIntakeObject>(new BoundedChannelOptions(BufferOptions.MaxInFlightMessages)
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

		private ITransport<ITransportConfigurationValues> _transport = default!;

		public Channel<IIntakeObject> Channel { get; }
		public ChannelWriter<IIntakeObject> Writer => Channel.Writer;
		public BufferOptions<IIntakeObject, EventIntakeResponse, IntakeErrorItem> BufferOptions => _options.BufferOptions;

		private ApmChannelOptions _options;
		public ApmChannelOptions Options
		{
			get => _options;
			set
			{
				_options = value;
				UpdateClient();
			}
		}



		public bool TryWrite(IIntakeObject item)
		{
			if (Writer.TryWrite(item)) return true;

			Options.BufferOptions.PublishRejectionCallback?.Invoke(item);
			return false;
		}

		private async Task Consume(int maxQueuedMessages, TimeSpan maxInterval, ManualResetEventSlim? bufferOptionsWaitHandle)
		{
			using var buffer = new ChannelBuffer<IIntakeObject>(maxQueuedMessages, maxInterval);

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
					EventIntakeResponse response = null!;
					try
					{
						response = await _transport.RequestAsync<EventIntakeResponse>(HttpMethod.POST, "/intake/v2/events",
								default,
								PostData.StreamHandler(items,
									(b, stream) =>
									{
										/* NOT USED */
									},
									async (b, stream, ctx) => { await WriteBufferToStreamAsync(b, stream, ctx).ConfigureAwait(false); })
								, ApmChannelStatics.RequestParams)
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

					//TODO handle retries?
					var zipped = items.Zip(response.Errors, (doc, item) => (doc, item)).ToList();

					// // retry any 429,502,503,504
					// items = zipped
					// 	.Where(t => ApmChannelStatics.RetryStatusCodes.Contains(t.item.Status))
					// 	.Select(t => t.doc)
					// 	.ToList();

					// report any events that are going to be dropped
					if (Options.BufferOptions.ServerRejectionCallback != null)
					{
						// var rejected = zipped
						// 	.Where(t =>
						// 		(t.item.Status < 200 || t.item.Status > 300)
						// 		&& !ApmChannelStatics.RetryStatusCodes.Contains(t.item.Status))
						// 	.ToList();
						// if (rejected.Count > 0) Options.BufferOptions.ServerRejectionCallback(rejected);
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

		private async Task WriteStanzaToStreamAsync(Stream stream, CancellationToken ctx)
		{
			// {"metadata":{"process":{"pid":1234,"title":"/usr/lib/jvm/java-10-openjdk-amd64/bin/java","ppid":1,"argv":["-v"]},
			// "system":{"architecture":"amd64","detected_hostname":"8ec7ceb99074","configured_hostname":"host1","platform":"Linux","container":{"id":"8ec7ceb990749e79b37f6dc6cd3628633618d6ce412553a552a0fa6b69419ad4"},
			// "kubernetes":{"namespace":"default","pod":{"uid":"b17f231da0ad128dc6c6c0b2e82f6f303d3893e3","name":"instrumented-java-service"},"node":{"name":"node-name"}}},
			// "service":{"name":"1234_service-12a3","version":"4.3.0","node":{"configured_name":"8ec7ceb990749e79b37f6dc6cd3628633618d6ce412553a552a0fa6b69419ad4"},"environment":"production","language":{"name":"Java","version":"10.0.2"},
			// "agent":{"version":"1.10.0","name":"java","ephemeral_id":"e71be9ac-93b0-44b9-a997-5638f6ccfc36"},"framework":{"name":"spring","version":"5.0.0"},"runtime":{"name":"Java","version":"10.0.2"}},"labels":{"group":"experimental","ab_testing":true,"segment":5}}}
			var p = Process.GetCurrentProcess();

			var metadata = new { metadata = new { process = new { pid = p.Id, title = p.ProcessName }, service = new { name = p.ProcessName, version = "1.0.0", agent = new { name = "dotnet", version = "0.0.1"} } } };
			await JsonSerializer.SerializeAsync(stream, metadata, metadata.GetType(), ApmChannelStatics.SerializerOptions, ctx)
					.ConfigureAwait(false);
			await stream.WriteAsync(ApmChannelStatics.LineFeed, 0, 1, ctx).ConfigureAwait(false);

		}

		private async Task WriteBufferToStreamAsync(List<IIntakeObject> b, Stream stream, CancellationToken ctx)
		{
			await WriteStanzaToStreamAsync(stream, ctx).ConfigureAwait(false);
			foreach (var @event in b)
			{
				if (@event == null) continue;

				var indexTime = Options.TimestampLookup?.Invoke(@event) ?? DateTimeOffset.Now;
				if (_options.IndexOffset.HasValue) indexTime = indexTime.ToOffset(_options.IndexOffset.Value);

				if (Options.WriteEvent != null)
					await Options.WriteEvent(stream, ctx, @event).ConfigureAwait(false);
				else
				{
					var type = @event switch
					{
						Transaction t => "transaction",
						_ => "unknown"
					};
					var dictionary = new Dictionary<string, object>() { { type, @event } };


					await JsonSerializer.SerializeAsync(stream, dictionary, dictionary.GetType(), ApmChannelStatics.SerializerOptions, ctx)
						.ConfigureAwait(false);
				}

				await stream.WriteAsync(ApmChannelStatics.LineFeed, 0, 1, ctx).ConfigureAwait(false);
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
