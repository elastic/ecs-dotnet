using Elastic.Clients.Elasticsearch;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Serilog.Sinks.IntegrationTests
{
	public abstract class SerilogTestBase : IClusterFixture<SerilogCluster>
	{
        protected ElasticsearchClient Client { get; }

		protected SerilogTestBase(SerilogCluster cluster, ITestOutputHelper output) =>
			Client = cluster.CreateClient(output);
	}

}
