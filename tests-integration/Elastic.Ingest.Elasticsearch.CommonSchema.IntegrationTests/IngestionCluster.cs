// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elasticsearch.IntegrationDefaults;
using Xunit;

[assembly: TestFramework("Elastic.Elasticsearch.Xunit.Sdk.ElasticTestFramework", "Elastic.Elasticsearch.Xunit")]

namespace Elastic.Ingest.Elasticsearch.CommonSchema.IntegrationTests;

/// <summary> Declare our cluster that we want to inject into our test classes </summary>
public class IngestionCluster : TestClusterBase
{
	public IngestionCluster() : base(9202) { }
}
