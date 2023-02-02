using System;
using System.Linq;
using Elastic.Clients.Elasticsearch;
using Elastic.Elasticsearch.Xunit;
using Elastic.Transport;
using Elasticsearch.IntegrationDefaults;
using Xunit;
using Xunit.Abstractions;

[assembly: TestFramework("Elastic.Elasticsearch.Xunit.Sdk.ElasticTestFramework", "Elastic.Elasticsearch.Xunit")]

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.IntegrationTests
{
	/// <summary> Declare our cluster that we want to inject into our test classes </summary>
	public class BenchmarkCluster : TestClusterBase
	{
		public BenchmarkCluster() : base(9203) { }

	}
}
