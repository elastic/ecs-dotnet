using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.IndexManagement;
using Elastic.CommonSchema;
using Elastic.Elasticsearch.Xunit;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.CommonSchema;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Transport;
using FluentAssertions;
using Xunit;

namespace Elastic.Ingest.IntegrationTests
{
	public class CommonSchemaIngestionTests : IClusterFixture<IngestionCluster>
	{
		private ElasticsearchClient Client { get; }

		public CommonSchemaIngestionTests(IngestionCluster cluster) =>
			Client = cluster.GetOrAddClient(c =>
			{
				var nodes = cluster.NodesUris();
				var connectionPool = new StaticNodePool(nodes);
				var settings = new ElasticsearchClientSettings(connectionPool)
					.EnableDebugMode();
				return new ElasticsearchClient(settings);
			});


		[Fact]
		public async Task ChannelCanSetupElasticsearchTemplates()
		{
			var targetDataStream = new Elastic.Ingest.Elasticsearch.DataStreamName("hello", "world");
			var slim = new CountdownEvent(1);
			var options = new DataStreamChannelOptions<EcsDocument>(Client.Transport)
			{
				DataStream = targetDataStream,
				BufferOptions = new ElasticsearchBufferOptions<EcsDocument>
				{
					WaitHandle = slim,
					MaxConsumerBufferSize = 1,
				}
			};
			var ecsChannel = new CommonSchemaChannel<EcsDocument>(options);

			await ecsChannel.SetupElasticsearchTemplatesAsync();

			var prefix = $"{targetDataStream.Type}-{targetDataStream.DataSet}";
			var exists = await Client.Indices.ExistsIndexTemplateAsync(prefix);

			exists.Exists.Should().BeTrue("{0}", exists);

			var dataStream = await Client.Indices.GetDataStreamAsync(new DataStreamRequest(targetDataStream.ToString()));
			dataStream.DataStreams.Should().BeNullOrEmpty();

			ecsChannel.TryWrite(new EcsDocument { @Timestamp = DateTimeOffset.Now, Message = "hello-world" });
			if (!slim.WaitHandle.WaitOne(TimeSpan.FromSeconds(10)))
					throw new Exception("ecs document was not persisted within 10 seconds");

			// Client error
			// dataStream = await Client.Indices.GetDataStreamAsync(new DataStreamRequest(targetDataStream.ToString()));
			// dataStream.DataStreams.Should().NotBeNullOrEmpty();

		}

	}

}
