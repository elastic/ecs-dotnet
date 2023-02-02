using System;
using System.Linq;
using Elastic.Clients.Elasticsearch;
using Elastic.Elasticsearch.Xunit;
using Elastic.Transport;
using Elasticsearch.IntegrationDefaults;
using Xunit;
using Xunit.Abstractions;

[assembly: TestFramework("Elastic.Elasticsearch.Xunit.Sdk.ElasticTestFramework", "Elastic.Elasticsearch.Xunit")]

namespace Elasticsearch.Extensions.Logging.IntegrationTests
{
	/// <summary> Declare our cluster that we want to inject into our test classes </summary>
	public class LoggingCluster : TestClusterBase
	{
		public LoggingCluster() : base(9201) { }

	}
}
