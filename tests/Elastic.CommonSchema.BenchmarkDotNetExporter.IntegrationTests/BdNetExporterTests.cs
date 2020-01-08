using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Cryptography;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Running;
using Elastic.CommonSchema.BenchmarkDotNetExporter.Domain;
using Elastic.Xunit;
using Elastic.Xunit.XunitPlumbing;
using Elasticsearch.Net;
using FluentAssertions;
using Xunit;
using Nest;
using Job = BenchmarkDotNet.Jobs.Job;

[assembly: TestFramework("Elastic.Xunit.Sdk.ElasticTestFramework", "Elastic.Xunit")]

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.IntegrationTests
{
	/// <summary> Declare our cluster that we want to inject into our test classes </summary>
	public class BenchmarkCluster : XunitClusterBase
	{
		public BenchmarkCluster() : base(new XunitClusterConfiguration("7.5.0")) { }
	}
	public class Md5VsSha256
	{
		private readonly SHA256 _sha256 = SHA256.Create();
		private readonly MD5 _md5 = MD5.Create();
		private byte[] _data;

		[Params(1000, 10000)]
		public int N;

		[GlobalSetup]
		public void Setup()
		{
			_data = new byte[N];
			new Random(42).NextBytes(_data);
		}

		[Benchmark]
		public byte[] Sha256() => _sha256.ComputeHash(_data);

		[Benchmark]
		public byte[] Md5() => _md5.ComputeHash(_data);
	}

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
			var config = CreateDefaultConfig()
				.With(exporter);
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
