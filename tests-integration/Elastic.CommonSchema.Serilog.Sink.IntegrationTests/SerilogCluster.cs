using Elasticsearch.IntegrationDefaults;
using Xunit;

[assembly: TestFramework("Elastic.Elasticsearch.Xunit.Sdk.ElasticTestFramework", "Elastic.Elasticsearch.Xunit")]

namespace Elastic.CommonSchema.Serilog.Sinks.IntegrationTests
{
	public class SerilogCluster : TestClusterBase
	{
		public SerilogCluster() : base(9205) { }

	}
}
