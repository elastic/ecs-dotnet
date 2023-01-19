using System;
using System.Linq;
using Elastic.Clients.Elasticsearch;
using Elastic.Elasticsearch.Xunit;
using Elastic.Transport;
using Xunit;
using Xunit.Abstractions;

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

		public ElasticsearchClient CreateClient(ITestOutputHelper output) =>
			this.GetOrAddClient(c =>
			{
				var hostName = (System.Diagnostics.Process.GetProcessesByName("mitmproxy").Any()
					? "ipv4.fiddler"
					: "localhost");
				var nodes = NodesUris(hostName);
				var connectionPool = new StaticNodePool(nodes);
				var settings = new ElasticsearchClientSettings(connectionPool)
					.Proxy(new Uri("http://ipv4.fiddler:8080"), (string)null, (string)null)
					.OnRequestCompleted(d =>
					{
						try { output.WriteLine(d.DebugInformation);}
						catch { }
					})
					.EnableDebugMode();
				return new ElasticsearchClient(settings);
			});
	}
}
