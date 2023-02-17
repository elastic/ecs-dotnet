// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elastic.Channels;
using Elastic.Channels.Diagnostics;
using Elastic.Clients.Elasticsearch.IndexManagement;
using Elastic.Ingest.Elasticsearch.Indices;
using Elastic.Ingest.Elasticsearch.Serialization;
using Elastic.Transport;
using Elasticsearch.IntegrationDefaults;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using HttpMethod = Elastic.Transport.HttpMethod;

namespace Elastic.Ingest.Elasticsearch.CommonSchema.IntegrationTests
{
	public class IndexIngestionTests : IntegrationTestBase
	{
		public IndexIngestionTests(IngestionCluster cluster, ITestOutputHelper output) : base(cluster, output)
		{
		}

		[Fact]
		public async Task EnsureDocumentsEndUpInIndex()
		{
			var indexPrefix = "catalog-data-";
			var slim = new CountdownEvent(1);
			var options = new IndexChannelOptions<CatalogDocument>(Client.Transport)
			{
				IndexFormat = indexPrefix + "{0:yyyy.MM.dd}",
				BulkOperationIdLookup = c => c.Id!,
				TimestampLookup = c => c.Created,
				BufferOptions = new BufferOptions
				{
					WaitHandle = slim, ExportMaxConcurrency = 1,
				},
			};
			var listener = new ChannelListener<CatalogDocument, BulkResponse>().Register(options);
			var channel = new EcsIndexChannel<CatalogDocument>(options);
			var bootstrapped = await channel.BootstrapElasticsearchAsync(BootstrapMethod.Failure, "7-days-default");
			bootstrapped.Should().BeTrue("Expected to be able to bootstrap index channel");

			var date = DateTimeOffset.Now;
			var indexName = string.Format(options.IndexFormat, date);

			var index = await Client.Indices.GetAsync(new GetIndexRequest(indexName));
			index.Indices.Should().BeNullOrEmpty();

			channel.TryWrite(new CatalogDocument { Created = date, Title = "Hello World!", Id = "hello-world" });
			if (!slim.WaitHandle.WaitOne(TimeSpan.FromSeconds(10)))
				throw new Exception($"No flush occurred in 10 seconds: {listener}", listener.ObservedException);

			var refreshResult = await Client.Indices.RefreshAsync(indexName);
			refreshResult.IsValidResponse.Should().BeTrue("{0}", refreshResult.DebugInformation);
			var searchResult = await Client.SearchAsync<CatalogDocument>(s => s.Indices(indexName));
			searchResult.Total.Should().Be(1);

			var storedDocument = searchResult.Documents.First();
			storedDocument.Id.Should().Be("hello-world");
			storedDocument.Title.Should().Be("Hello World!");

			var hit = searchResult.Hits.First();
			hit.Index.Should().Be(indexName);

			// bug in client
			// https://github.com/elastic/elasticsearch-net/issues/7221
			var indexResponse =
				await Client.Transport.RequestAsync<StringResponse>(HttpMethod.GET, $"/{indexName}");

			indexResponse.ApiCallDetails.HasSuccessfulStatusCode.Should().BeTrue("{0}", indexResponse.ApiCallDetails.DebugInformation);

			// Bug in client, for now assume template was applied because the ILM policy is set on the index.
			indexResponse.ApiCallDetails.DebugInformation.Should().Contain(@"""7-days-default""");

		}
	}
}
