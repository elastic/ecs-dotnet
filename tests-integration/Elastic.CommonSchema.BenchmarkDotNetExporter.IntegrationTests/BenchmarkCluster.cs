using Elasticsearch.IntegrationDefaults;
using Xunit;

[assembly: TestFramework("Elastic.Elasticsearch.Xunit.Sdk.ElasticTestFramework", "Elastic.Elasticsearch.Xunit")]

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.IntegrationTests
{
	/// <summary> Declare our cluster that we want to inject into our test classes </summary>
	public class BenchmarkCluster() : TestClusterBase(9203);
}
