using Elastic.Elasticsearch.Xunit;
using Xunit;

[assembly: TestFramework("Elastic.Elasticsearch.Xunit.Sdk.ElasticTestFramework", "Elastic.Elasticsearch.Xunit")]

namespace Serilog.Sinks.Elasticsearch.IntegrationTests
{
	public class SerilogCluster : XunitClusterBase
	{
		public SerilogCluster() : base(CreateConfiguration()) { }

		private static XunitClusterConfiguration CreateConfiguration() =>
			new ("8.3.1")
			{
				StartingPortNumber = 9205,
			};

		protected override void SeedCluster() { }
	}
}
