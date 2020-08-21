using System;
using System.Linq;
using System.Threading;
using Elastic.CommonSchema;
using Elastic.Ingest.Serialization;
using Elasticsearch.Net;
using Elasticsearch.Net.VirtualizedCluster;
using Elasticsearch.Net.VirtualizedCluster.Rules;

namespace Elastic.Ingest.Tests
{
	public static class Setup
	{
		public static SystemTextJsonSerializer Serializer { get; } = new SystemTextJsonSerializer();

		public static IElasticLowLevelClient CreateClient(Func<VirtualCluster, VirtualCluster> setup)
		{
			var cluster = VirtualClusterWith.Nodes(1).Ping(c=>c.SucceedAlways());
			var virtualSettings = setup(cluster)
				.StaticConnectionPool()
				.AllDefaults();

			var settings = new ConnectionConfiguration(virtualSettings.ConnectionPool, virtualSettings.Connection, Serializer)
				.DisablePing()
				.EnableDebugMode();
			return new ElasticLowLevelClient(settings);
		}

		public static ClientCallRule BulkResponse(this ClientCallRule rule, params int[] statusCodes) =>
			rule.Succeeds(TimesHelper.Once).ReturnResponse(BulkResponseBuilder.CreateResponse(statusCodes));

		public class TestSession : IDisposable
		{
			private int _rejections;
			private int _requests;
			private int _responses;
			private int _retries;
			private int _retryDepletions;

			public TestSession(IElasticLowLevelClient client)
			{
				Client = client;
				BufferOptions = new BufferOptions<Base>()
				{
					ConcurrentConsumers = 1,
					MaxConsumerBufferSize = 2,
					MaxConsumerBufferLifetime = TimeSpan.FromSeconds(10),
					WaitHandle = WaitHandle,
					MaxRetries = 3,
					BackoffPeriod = times => TimeSpan.FromMilliseconds(1),
					ServerRejectionCallback = (list) => Interlocked.Increment(ref _rejections),
					BulkAttemptCallback = (c, a) => Interlocked.Increment(ref _requests),
					ElasticsearchResponseCallback = (r, b) => Interlocked.Increment(ref _responses),
					RetryRejectionCallback = (list) => Interlocked.Increment(ref _retryDepletions),
					RetryCallBack = (list) => Interlocked.Increment(ref _retries),
					ExceptionCallback= (e) => LastException = e
				};
				ChannelOptions = new ElasticsearchChannelOptions<Base>(client) { BufferOptions = BufferOptions };
				Channel = new ElasticsearchChannel<Base>(ChannelOptions);
			}

			public ElasticsearchChannel<Base> Channel { get; }

			public IElasticLowLevelClient Client { get; }

			public ElasticsearchChannelOptions<Base> ChannelOptions { get; }

			public BufferOptions<Base> BufferOptions { get; }

			public ManualResetEventSlim WaitHandle { get; } = new ManualResetEventSlim();

			public int Rejections => _rejections;
			public int TotalBulkRequests => _requests;
			public int TotalBulkResponses => _responses;
			public int TotalRetries => _retries;
			public int RetryDepletions => _retryDepletions;
			public Exception LastException { get; private set; }

			public void Wait()
			{
				WaitHandle.Wait(TimeSpan.FromSeconds(10));
				WaitHandle.Reset();
			}

			public void Dispose()
			{
				Channel?.Dispose();
				WaitHandle?.Dispose();
			}
		}

		public static TestSession CreateTestSession(IElasticLowLevelClient client) =>
			new TestSession(client);

		public static void WriteAndWait(this TestSession session, int events = 1)
		{
			foreach (var b in Enumerable.Range(0, events))
				session.Channel.TryWrite(new Base { Timestamp = DateTimeOffset.UtcNow });
			session.Wait();
		}
	}
}
