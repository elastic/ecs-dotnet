using Elastic.Elasticsearch.Xunit;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.IntegrationTests
{
	/// <summary> Declare our cluster that we want to inject into our test classes </summary>
	public class BenchmarkCluster : XunitClusterBase
	{
		public BenchmarkCluster() : base(new XunitClusterConfiguration("7.5.0")) { }
	}
}
