// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Net.Security;
using Elastic.Clients.Elasticsearch;
using Elastic.Elasticsearch.Ephemeral;
using Elastic.Elasticsearch.Xunit;
using Elastic.Transport;
using Xunit;
using Xunit.Abstractions;
using static Elastic.Elasticsearch.Managed.DetectedProxySoftware;

[assembly: TestFramework("Elastic.Elasticsearch.Xunit.Sdk.ElasticTestFramework", "Elastic.Elasticsearch.Xunit")]

namespace Elasticsearch.IntegrationDefaults;

public static class TestClusterExtensions
{
	public static ElasticsearchClient CreateElasticsearchClient(
		this IEphemeralCluster cluster,
		ITestOutputHelper output,
		Func<ElasticsearchClientSettings, ElasticsearchClientSettings> updateSettings,
		Func<ICollection<Uri>, ICollection<Uri>>? alterNodes = null
	)
	{
		var isCi = !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CI"));
		var nodes = cluster.NodesUris();
		if (alterNodes != null) nodes = alterNodes(nodes);
		var connectionPool = new StaticNodePool(nodes);
		var settings = new ElasticsearchClientSettings(connectionPool)
			.RequestTimeout(TimeSpan.FromSeconds(5))
			.ServerCertificateValidationCallback(CertificateValidations.AllowAll)
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
			.EnableDebugMode();
		if (cluster.DetectedProxy != None)
		{
			var proxyUrl = cluster.DetectedProxy == Fiddler ? "ipv4.fiddler" : "localhost";
			settings = settings.Proxy(new Uri($"http://{proxyUrl}:8080"), null!, null!);
		}

		return new ElasticsearchClient(updateSettings(settings));
	}
}

/// <summary> Declare our cluster that we want to inject into our test classes </summary>
public abstract class TestClusterBase : XunitClusterBase
{
	protected TestClusterBase(int port = 9200, ClusterFeatures features = ClusterFeatures.None)
		: base(new XunitClusterConfiguration("8.4.0", features) { StartingPortNumber = port, AutoWireKnownProxies = true }) { }

	protected virtual ElasticsearchClientSettings UpdateClientSettings(ElasticsearchClientSettings settings) => settings;

	public ElasticsearchClient CreateClient(ITestOutputHelper output, Func<ICollection<Uri>, ICollection<Uri>>? alterNodes = null) =>
		this.GetOrAddClient(cluster => cluster.CreateElasticsearchClient(output, UpdateClientSettings, alterNodes));
}
