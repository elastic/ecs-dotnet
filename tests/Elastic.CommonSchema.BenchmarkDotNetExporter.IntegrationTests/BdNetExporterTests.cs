// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Elastic.CommonSchema.BenchmarkDotNetExporter.Domain;
using Elastic.Elasticsearch.Xunit;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Elasticsearch.Net;
using FluentAssertions;
using Xunit;
using Nest;
using Job = BenchmarkDotNet.Jobs.Job;

[assembly: TestFramework("Elastic.Elasticsearch.Xunit.Sdk.ElasticTestFramework", "Elastic.Elasticsearch.Xunit")]

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.IntegrationTests
{
	public class BenchmarkIntegrationTests : IClusterFixture<BenchmarkCluster>
	{
		private ElasticClient Client { get; }

		public BenchmarkIntegrationTests(BenchmarkCluster cluster) =>
			Client = cluster.GetOrAddClient(c =>
			{
				var nodes = cluster.NodesUris();
				var connectionPool = new StaticConnectionPool(nodes);
				var settings = new ConnectionSettings(connectionPool)
					.EnableDebugMode();
				return new ElasticClient(settings);
			});

		private static IConfig CreateDefaultConfig()
		{
			var jobs = new List<Job>
			{
				Job.ShortRun.With(CoreRuntime.Core30).WithInvocationCount(4).WithUnrollFactor(2),
			};
			var config = DefaultConfig.Instance
				.KeepBenchmarkFiles()
				.With(jobs.ToArray())
				.With(MemoryDiagnoser.Default);
			return config;
		}

		[Fact]
		public void BenchmarkingPersistsResults()
		{
			var url = Client.ConnectionSettings.ConnectionPool.Nodes.First().Uri;
			var options = new ElasticsearchBenchmarkExporterOptions(url)
			{
				GitBranch = "externally-provided-branch",
				GitCommitMessage = "externally provided git commit message",
				GitRepositoryIdentifier = "repository"
			};
			var exporter = new ElasticsearchBenchmarkExporter(options);
			var config = CreateDefaultConfig().With(exporter);
			BenchmarkRunner.Run(typeof(Md5VsSha256), config);

			var pipeline = Client.Ingest.GetPipeline(p => p.Id(options.PipelineName));
			if (!pipeline.IsValid)
				throw new Exception(pipeline.DebugInformation);

			var template = Client.Indices.GetTemplate(options.TemplateName);
			if (!template.IsValid)
				throw new Exception(template.DebugInformation);

			var indexName = $"{options.IndexName}-{DateTime.UtcNow.Year}-01-01";
			var indexExists = Client.Indices.Exists(indexName);
			if (!indexExists.IsValid)
				throw new Exception(indexExists.DebugInformation);

			Client.Indices.Refresh(indexName);

			var searchResponse = Client.Search<BenchmarkDocument>(s => s.Index(indexName));
			if (!searchResponse.IsValid || searchResponse.Total == 0)
				throw new Exception(searchResponse.DebugInformation);

			var doc = searchResponse.Documents.First();

			doc.Timestamp.Should().NotBeNull().And.BeCloseTo(DateTimeOffset.Now, precision: 4000);

			doc.Benchmark.Should().NotBeNull();

			doc.Benchmark.Max.Should().BeGreaterThan(0);

			doc.Event.Duration.Should().BeGreaterThan(0);
		}
	}
}
