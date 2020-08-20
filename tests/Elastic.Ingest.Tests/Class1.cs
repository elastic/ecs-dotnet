using System;
using System.Threading;
using Elastic.CommonSchema;
using Elastic.Ingest.Serialization;
using Elasticsearch.Net;
using Elasticsearch.Net.VirtualizedCluster;
using Elasticsearch.Net.VirtualizedCluster.Rules;
using FluentAssertions;
using Xunit;

namespace Elastic.Ingest.Tests
{
	public class Class1
	{
		[Fact]
		public void X()
		{
			var connection = VirtualClusterWith.Nodes(1)
				.Ping(c=>c.SucceedAlways())
				.ClientCalls(c => c.Succeeds(TimesHelper.Once).ReturnResponse(BulkResponseBuilder.CreateResponse(400, 400)))
				.ClientCalls(c => c.Succeeds(TimesHelper.Once).ReturnResponse(BulkResponseBuilder.CreateResponse(200, 200)))
				.StaticConnectionPool()
				.AllDefaults();

			var serializer = new SystemTextJsonSerializer();
			var settings = new ConnectionConfiguration(connection.ConnectionPool, connection.Connection, serializer);
			var client = new ElasticLowLevelClient(settings.EnableDebugMode());

			var waitHandle = new ManualResetEventSlim();

			int rejections = 0, responses = 0, retries = 0;
			var channelOptions = new ElasticsearchChannelOptions<Base>(client)
			{
				BufferOptions = new BufferOptions<Base>()
				{
					ConcurrentConsumers = 1,
					MaxConsumerBufferSize = 2,
					MaxConsumerBufferLifetime = TimeSpan.FromSeconds(1),
					WaitHandle = waitHandle,
					ServerRejectionCallback = (list) =>
					{
						Interlocked.Increment(ref rejections);
					},
					ElasticsearchResponseCallback = (r, b) =>
					{
						Interlocked.Increment(ref responses);

					},
					RetryRejectionCallback = (list) =>
					{
						Interlocked.Increment(ref retries);
					}
				}
			};
			using var channel = new ElasticsearchChannel<Base>(channelOptions);

			channel.TryWrite(new Base() { Timestamp = DateTimeOffset.UtcNow });
			channel.TryWrite(new Base() { Timestamp = DateTimeOffset.UtcNow });
			waitHandle.Wait(TimeSpan.FromSeconds(30));
			waitHandle.Reset();

			rejections.Should().Be(1);
			responses.Should().Be(1);

			channel.TryWrite(new Base() { Timestamp = DateTimeOffset.UtcNow });
			channel.TryWrite(new Base() { Timestamp = DateTimeOffset.UtcNow });
			waitHandle.Wait(TimeSpan.FromSeconds(30));

			rejections.Should().Be(1);
			responses.Should().Be(2);

			//await Task.Delay(TimeSpan.FromMinutes(3));




		}
	}
}
