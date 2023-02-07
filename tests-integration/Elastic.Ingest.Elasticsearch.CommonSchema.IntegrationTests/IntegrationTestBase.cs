// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elastic.Clients.Elasticsearch;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Xunit.Abstractions;

namespace Elastic.Ingest.Elasticsearch.CommonSchema.IntegrationTests;

public abstract class IntegrationTestBase : IClusterFixture<IngestionCluster>
{
	protected ElasticsearchClient Client { get; }

	protected IntegrationTestBase(IngestionCluster cluster, ITestOutputHelper output) =>
		Client = cluster.CreateClient(output);
}
