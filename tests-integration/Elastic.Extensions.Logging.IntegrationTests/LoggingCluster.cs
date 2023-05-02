using Elasticsearch.IntegrationDefaults;
using Xunit;

[assembly: TestFramework("Elastic.Elasticsearch.Xunit.Sdk.ElasticTestFramework", "Elastic.Elasticsearch.Xunit")]

namespace Elastic.Extensions.Logging.IntegrationTests;

/// <summary> Declare our cluster that we want to inject into our test classes </summary>
public class LoggingCluster : TestClusterBase
{
	public LoggingCluster() : base(9201) { }

}
