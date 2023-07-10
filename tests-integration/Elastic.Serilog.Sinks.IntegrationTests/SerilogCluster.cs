using Elastic.Elasticsearch.Ephemeral;
using Elastic.Elasticsearch.Xunit;
using Elasticsearch.IntegrationDefaults;
using Xunit;

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
}
