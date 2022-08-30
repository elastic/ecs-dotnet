using Elastic.Clients.Elasticsearch;
using Elastic.Elasticsearch.Xunit;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Elastic.Transport;

namespace Serilog.Sinks.Elasticsearch.IntegrationTests
{
	public abstract class SerilogTestBase : IClusterFixture<SerilogCluster>
	{
        protected ElasticsearchClient Client { get; }

		protected SerilogTestBase(SerilogCluster cluster) =>
			Client = cluster.GetOrAddClient(c =>
			{
				var nodes = cluster.NodesUris();
				var connectionPool = new StaticNodePool(nodes);
				var settings = new ElasticsearchClientSettings(connectionPool)
					.EnableDebugMode();
				return new ElasticsearchClient(settings);
			});
	}

}
