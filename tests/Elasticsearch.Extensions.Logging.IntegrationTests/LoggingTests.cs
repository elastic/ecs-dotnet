using System;
using System.Linq;
using System.Threading.Tasks;
using Elastic.CommonSchema;
using Elastic.Elasticsearch.Xunit;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Elasticsearch.Net;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nest;
using Xunit;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Elasticsearch.Extensions.Logging.IntegrationTests
{
	public class LoggingTests : IClusterFixture<LoggingCluster>
	{
		private ElasticClient Client { get; }

		public LoggingTests(LoggingCluster cluster) =>
			Client = cluster.GetOrAddClient(c =>
			{
				var nodes = cluster.NodesUris();
				var connectionPool = new StaticConnectionPool(nodes);
				var settings = new ConnectionSettings(connectionPool)
					.EnableDebugMode();
				return new ElasticClient(settings);
			});

		private IDisposable CreateLogger(out ILogger logger, out string indexPrefix)
		{
			var pre = $"logs-{Guid.NewGuid().ToString("N").ToLowerInvariant().Substring(0, 6)}";
			var options = new ConfigureOptions<ElasticsearchLoggerOptions>(
				o =>
				{
					o.Index = $"{pre}-{{0:yyyy.MM.dd}}";
					o.NodeUris = Client.ConnectionSettings.ConnectionPool.Nodes.Select(n => n.Uri).ToArray();
				});

			var optionsFactory = new OptionsFactory<ElasticsearchLoggerOptions>(
				new []{ options }, Enumerable.Empty<IPostConfigureOptions<ElasticsearchLoggerOptions>>());
			var optionsMonitor = new OptionsMonitor<ElasticsearchLoggerOptions>(
				optionsFactory, Enumerable.Empty<IOptionsChangeTokenSource<ElasticsearchLoggerOptions>>(), new OptionsCache<ElasticsearchLoggerOptions>());
			var loggerFactory = new LoggerFactory(
				new[] { new ElasticsearchLoggerProvider(optionsMonitor) }, new LoggerFilterOptions { MinLevel = LogLevel.Information });
			logger = loggerFactory.CreateLogger<ElasticsearchLogger>();
			indexPrefix = pre;
			return loggerFactory;
		}

		[Fact]
		public async Task LogsEndUpInCluster()
		{
			using var _ = CreateLogger(out var logger, out var indexPrefix);

			logger.LogError("an error occured");

			// TODO make sure we can await something here on ElasticsearchDataShipper
			await Task.Delay(TimeSpan.FromSeconds(5));

			var response = Client.Search<LogEvent>(new SearchRequest($"{indexPrefix}-*"));

			response.IsValid.Should().BeTrue("{0}", response.DebugInformation);
			response.Total.Should().BeGreaterThan(0);

			var loggedError = response.Documents.First();
			loggedError.Message.Should().Be("an error occured");
			loggedError.Ecs.Version.Should().Be(Base.Version);

		}
	}
}
