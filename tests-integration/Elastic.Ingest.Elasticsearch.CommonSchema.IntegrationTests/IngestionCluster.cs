// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elastic.Clients.Elasticsearch;
using Elastic.Elasticsearch.Xunit;
using Elastic.Transport;
using Xunit;
using Xunit.Abstractions;

[assembly: TestFramework("Elastic.Elasticsearch.Xunit.Sdk.ElasticTestFramework", "Elastic.Elasticsearch.Xunit")]

namespace Elastic.Ingest.Elasticsearch.CommonSchema.IntegrationTests
{
	/// <summary> Declare our cluster that we want to inject into our test classes </summary>
	public class IngestionCluster : XunitClusterBase
	{
		public IngestionCluster() : base(new XunitClusterConfiguration("8.4.0") { StartingPortNumber = 9202 }) { }

		public ElasticsearchClient CreateClient(ITestOutputHelper output) =>
			this.GetOrAddClient(_ =>
			{
				var hostName = (System.Diagnostics.Process.GetProcessesByName("mitmproxy").Any()
					? "ipv4.fiddler"
					: "localhost");
				var nodes = NodesUris(hostName);
				var connectionPool = new StaticNodePool(nodes);
				var settings = new ElasticsearchClientSettings(connectionPool)
					.Proxy(new Uri("http://ipv4.fiddler:8080"), null!, null!)
					.OnRequestCompleted(d =>
					{
						try { output.WriteLine(d.DebugInformation);}
						catch
						{
							// ignored
						}
					})
					.EnableDebugMode();
				return new ElasticsearchClient(settings);
			});
	}
}
