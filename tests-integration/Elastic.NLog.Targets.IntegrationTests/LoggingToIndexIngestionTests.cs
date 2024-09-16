using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Elastic.Channels.Diagnostics;
using Elastic.Clients.Elasticsearch.IndexManagement;
using Elastic.CommonSchema;
using Elastic.Ingest.Elasticsearch;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace NLog.Targets.Elastic.IntegrationTests
{
	public class LoggingToIndexIngestionTests : TestBase
	{
		public LoggingToIndexIngestionTests(LoggingCluster cluster, ITestOutputHelper output) : base(cluster, output) { }

		[Fact]
		public async Task EnsureDocumentsEndUpInIndex()
		{
			var indexPrefix = "catalog-data-";
			var indexFormat = indexPrefix + "{0:yyyy.MM.dd}";

			using var _ = CreateLogger(out var logger, out var provider, out var @namespace, out var waitHandle, out var listener, (cfg) =>
			{
				cfg.IndexFormat = indexFormat;
				cfg.DataStreamType = "x";
				cfg.DataStreamSet = "dotnet";
				var nodesUris = string.Join(",", Client.ElasticsearchClientSettings.NodePool.Nodes.Select(n => n.Uri.ToString()).ToArray());
				cfg.NodeUris = nodesUris;
				cfg.NodePoolType = ElasticPoolType.Static;
			});

			var date = DateTimeOffset.Now;
			var indexName = string.Format(indexFormat, date);

			var index = await Client.Indices.GetAsync(new GetIndexRequest(indexName));
			index.Indices.Should().BeNullOrEmpty();

			logger.Error("an error occurred!");

			if (!waitHandle.WaitOne(TimeSpan.FromSeconds(10)))
				throw new Exception($"No flush occurred in 10 seconds: {listener}", listener.ObservedException);

			listener.PublishSuccess.Should().BeTrue("{0}", listener);
			listener.ObservedException.Should().BeNull();

			var refreshResult = await Client.Indices.RefreshAsync(indexName);
			refreshResult.IsValidResponse.Should().BeTrue("{0}", refreshResult.DebugInformation);
			var searchResult = await Client.SearchAsync<EcsDocument>(s => s.Indices(indexName));
			searchResult.Total.Should().Be(1);

			var storedDocument = searchResult.Documents.First();
			storedDocument.Message.Should().Be("an error occurred!");

			var hit = searchResult.Hits.First();
			hit.Index.Should().Be(indexName);
		}
	}
}
