using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Elastic.CommonSchema;
using Elastic.Elasticsearch.Xunit;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Elasticsearch.Extensions.Logging.Options;
using Elasticsearch.Net;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Nest;
using Xunit;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Elasticsearch.Extensions.Logging.IntegrationTests
{
	public class LoggingToIndexTests : IClusterFixture<LoggingCluster>
	{
		public LoggingToIndexTests(LoggingCluster cluster) =>
			Client = cluster.GetOrAddClient(c =>
			{
				var nodes = cluster.NodesUris();
				var connectionPool = new StaticConnectionPool(nodes);
				var settings = new ConnectionSettings(connectionPool)
					.EnableDebugMode();
				return new ElasticClient(settings);
			});

		private ElasticClient Client { get; }

		[Fact]
		public async Task LogsEndUpInCluster()
		{
			using var _ = CreateLogger(out var logger, out var provider, out var indexPrefix, out var waitHandle);
			logger.LogError("an error occurred");

			if (!waitHandle.WaitOne(TimeSpan.FromSeconds(10)))
				throw new Exception("Logs were not written to Elasticsearch within margin of 10 seconds");

			provider.LastSeenException.Should().BeNull();

			var refresh = await Client.Indices.RefreshAsync($"{indexPrefix}-*");

			var response = Client.Search<LogEvent>(new SearchRequest($"{indexPrefix}-*"));

			response.IsValid.Should().BeTrue("{0}", response.DebugInformation);
			response.Total.Should().BeGreaterThan(0);

			var loggedError = response.Documents.First();
			loggedError.Message.Should().Be("an error occurred");
			loggedError.Ecs.Version.Should().Be(EcsDocument.Version);
		}

		[Fact]
		public async Task SerializesAndDeserializesMessageTemplateAndScope()
		{
			using var _ = CreateLogger(out var logger, out var provider, out var indexPrefix, out var waitHandle);
			using (logger.BeginScope("custom scope"))
			{
				var userId = 1;
				logger.LogError("an error occurred for userId {UserId}", userId);

				if (!waitHandle.WaitOne(TimeSpan.FromSeconds(10)))
					throw new Exception("Logs were not written to Elasticsearch within margin of 10 seconds");

				provider.LastSeenException.Should().BeNull();

				var refresh = await Client.Indices.RefreshAsync($"{indexPrefix}-*");

				var response = Client.Search<LogEvent>(new SearchRequest($"{indexPrefix}-*"));

				response.IsValid.Should().BeTrue("{0}", response.DebugInformation);
				response.Total.Should().BeGreaterThan(0);

				var loggedError = response.Documents.First();
				loggedError.Message.Should().Be("an error occurred for userId 1");
				loggedError.MessageTemplate.Should().Be("an error occurred for userId {UserId}");
				loggedError.Scopes.Should().ContainSingle(s => s == "custom scope");
			}
		}

		private IDisposable CreateLogger(out ILogger logger, out ElasticsearchLoggerProvider provider, out string indexPrefix, out WaitHandle waitHandle)
		{
			var pre = $"logs-{Guid.NewGuid().ToString("N").ToLowerInvariant().Substring(0, 6)}";
			var slim = new CountdownEvent(1);
			waitHandle = slim.WaitHandle;
			var options = new ConfigureOptions<ElasticsearchLoggerOptions>(
				o =>
				{
					o.TrackExceptions = true;
					o.Index = new IndexNameOptions { Format = $"{pre}-{{0:yyyy.MM.dd}}" };
					var nodes = Client.ConnectionSettings.ConnectionPool.Nodes.Select(n => n.Uri).ToArray();
					o.ShipTo = new ShipToOptions() { NodeUris = nodes, ConnectionPoolType = ConnectionPoolType.Static };
				});

			var channelSetup = new IChannelSetup[] { new ChannelSetup(c =>
			{
				c.BufferOptions.MaxRetries = 0;
				c.BufferOptions.MaxConsumerBufferSize = 1;
				c.BufferOptions.WaitHandle = slim;
				c.BufferOptions.ConcurrentConsumers = 1;
			}) };

			var optionsFactory = new OptionsFactory<ElasticsearchLoggerOptions>(
				new[] { options }, Enumerable.Empty<IPostConfigureOptions<ElasticsearchLoggerOptions>>());
			var optionsMonitor = new OptionsMonitor<ElasticsearchLoggerOptions>(
				optionsFactory, Enumerable.Empty<IOptionsChangeTokenSource<ElasticsearchLoggerOptions>>(),
				new OptionsCache<ElasticsearchLoggerOptions>());
			provider = new ElasticsearchLoggerProvider(optionsMonitor, channelSetup);
			var loggerFactory = new LoggerFactory(
				new[] { provider},
				new LoggerFilterOptions { MinLevel = LogLevel.Information }
			);
			logger = loggerFactory.CreateLogger<ElasticsearchLogger>();
			indexPrefix = pre;
			return loggerFactory;
		}
	}
}
