using System;
using System.Collections.Generic;
using Elastic.Clients.Elasticsearch;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Elasticsearch.IntegrationDefaults;
using Xunit.Abstractions;

namespace Elastic.Serilog.Sinks.IntegrationTests;

public abstract class SerilogTestBase<TCluster> : IClusterFixture<TCluster>
	where TCluster : TestClusterBase, new()
{
	protected ElasticsearchClient Client { get; }

	protected SerilogTestBase(SerilogCluster cluster, ITestOutputHelper output, Func<ICollection<Uri>, ICollection<Uri>>? alterNodes = null) =>
		Client = cluster.CreateClient(output, alterNodes);
}

public abstract class SerilogTestBase : SerilogTestBase<SerilogCluster>
{
	protected SerilogTestBase(SerilogCluster cluster, ITestOutputHelper output, Func<ICollection<Uri>, ICollection<Uri>>? alterNodes = null)
		: base(cluster, output, alterNodes) { }
}
