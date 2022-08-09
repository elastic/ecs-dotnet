using Elastic.Elasticsearch.Xunit;
using Xunit;

[assembly: TestFramework("Elastic.Elasticsearch.Xunit.Sdk.ElasticTestFramework", "Elastic.Elasticsearch.Xunit")]

namespace Elasticsearch.Extensions.Logging.IntegrationTests
{
	/// <summary> Declare our cluster that we want to inject into our test classes </summary>
	public class LoggingCluster : XunitClusterBase
	{
		public LoggingCluster() : base(new XunitClusterConfiguration("8.3.1")
		{
			StartingPortNumber = 9201
		}) { }
	}
}
