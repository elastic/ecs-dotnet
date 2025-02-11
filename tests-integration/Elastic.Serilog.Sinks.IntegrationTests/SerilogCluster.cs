using System.Text.Json.Serialization;
using Elastic.Clients.Elasticsearch;
using Elastic.Elasticsearch.Ephemeral;
using Elastic.Transport;
using Elastic.Transport.Products.Elasticsearch;
using Elasticsearch.IntegrationDefaults;
using Xunit;
using static Elastic.Elasticsearch.Ephemeral.ClusterAuthentication;

[assembly: TestFramework("Elastic.Elasticsearch.Xunit.Sdk.ElasticTestFramework", "Elastic.Elasticsearch.Xunit")]

namespace Elastic.Serilog.Sinks.IntegrationTests;

public class SerilogCluster : TestClusterBase
{
	public SerilogCluster() : base(9205) { }
	protected SerilogCluster(int port, ClusterFeatures features) : base(port, features) { }
}

public class SecurityCluster : SerilogCluster
{
	public SecurityCluster() : base(9206, ClusterFeatures.XPack | ClusterFeatures.Security | ClusterFeatures.SSL)
	{
	}

	protected override ElasticsearchClientSettings UpdateClientSettings(ElasticsearchClientSettings settings) =>
		settings.Authentication(new BasicAuthentication(Admin.Username, Admin.Password));

	public static ApiKeyResponse CreateApiKey(ElasticsearchClient client, string json)
	{
		var apiKey =  client.Transport.Request<ApiKeyResponse>(HttpMethod.POST, "/_security/api_key", PostData.String(json));
		return apiKey;
	}

	public class ApiKeyResponse : ElasticsearchResponse
	{
		[JsonPropertyName("id")]
		public string Id { get; init; } = default!;

		[JsonPropertyName("name")]
		public string Name { get; init; } = default!;

		[JsonPropertyName("api_key")]
		public string ApiKey { get; init; } = default!;

		[JsonPropertyName("encoded")]
		public string Encoded { get; init; } = default!;
	}
}
