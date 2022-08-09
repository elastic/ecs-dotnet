using Elastic.Elasticsearch.Xunit;
using Xunit;

[assembly: TestFramework("Elastic.Elasticsearch.Xunit.Sdk.ElasticTestFramework", "Elastic.Elasticsearch.Xunit")]

namespace Elastic.Ingest.IntegrationTests
{
	/// <summary> Declare our cluster that we want to inject into our test classes </summary>
	public class IngestionCluster : XunitClusterBase
	{
		public IngestionCluster() : base(new XunitClusterConfiguration("8.3.1") { StartingPortNumber = 9202 }) { }

	}
}
