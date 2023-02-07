// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elastic.Clients.Elasticsearch;
using Elastic.Elasticsearch.Xunit;
using Elastic.Transport;
using Xunit;
using Xunit.Abstractions;

[assembly: TestFramework("Elastic.Elasticsearch.Xunit.Sdk.ElasticTestFramework", "Elastic.Elasticsearch.Xunit")]

namespace Elasticsearch.IntegrationDefaults
{
	/// <summary> Declare our cluster that we want to inject into our test classes </summary>
	public abstract class TestClusterBase : XunitClusterBase
	{
		protected TestClusterBase(int port = 9200) : base(new XunitClusterConfiguration("8.4.0")
		{
			StartingPortNumber = port
		}) { }

		public ElasticsearchClient CreateClient(ITestOutputHelper output) =>
			this.GetOrAddClient(_ =>
			{
				var hostName = (System.Diagnostics.Process.GetProcessesByName("mitmproxy").Any()
					? "ipv4.fiddler"
					: "localhost");
				var nodes = NodesUris(hostName);
				var connectionPool = new StaticNodePool(nodes);
				var isCi = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CI"));
				var settings = new ElasticsearchClientSettings(connectionPool)
					.Proxy(new Uri("http://ipv4.fiddler:8080"), null!, null!)
					.OnRequestCompleted(d =>
					{
						try
						{
							// ON CI only logged failed requests
							// Locally we just log everything for ease of development
							if (isCi)
							{
								if (!d.HasSuccessfulStatusCode)
									output.WriteLine(d.DebugInformation);
							}
							else output.WriteLine(d.DebugInformation);
						}
						catch
						{
							// ignored
						}
					})
					.EnableDebugMode()
					//do not request server stack traces on CI, too noisy
					.IncludeServerStackTraceOnError(!isCi);
				return new ElasticsearchClient(settings);
			});
	}
}
