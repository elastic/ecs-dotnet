using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Elastic.Clients.Elasticsearch;
using Elastic.CommonSchema;
using Elastic.Elasticsearch.Xunit;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Elastic.Transport;
using Elasticsearch.Extensions.Logging.Options;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Xunit;
using Xunit.Abstractions;
using LogLevel = Microsoft.Extensions.Logging.LogLevel;

namespace Elasticsearch.Extensions.Logging.IntegrationTests
{
	public class LoggingToDataStreamTests : IClusterFixture<LoggingCluster>
	{
		public LoggingToDataStreamTests(LoggingCluster cluster, ITestOutputHelper output) =>
			Client = cluster.CreateClient(output);

		private ElasticsearchClient Client { get; }
		private Exception ObservedException { get; set; }

		[Fact]
		public async Task LogsEndUpInCluster()
		{
			using var _ = CreateLogger(out var logger, out var provider, out var @namespace, out var waitHandle);
			var dataStream = $"x-dotnet-{@namespace}";

			logger.LogError("an error occurred");

			if (!waitHandle.WaitOne(TimeSpan.FromSeconds(10)))
				throw new Exception($"No flush occurred in 10 seconds: {ObservedException?.Message}", ObservedException);

			provider.LastSeenException.Should().BeNull();

			var refresh = await Client.Indices.RefreshAsync(dataStream);

			var response = Client.Search<EcsDocument>(new SearchRequest(dataStream));

			response.IsValidResponse.Should().BeTrue("{0}", response.DebugInformation);
			response.Total.Should().BeGreaterThan(0);

			var loggedError = response.Documents.First();
			loggedError.Message.Should().Be("an error occurred");
			loggedError.Log.Should().NotBeNull();
			loggedError.Log.Level.Should().Be("Error");
			loggedError.Ecs.Version.Should().Be(EcsDocument.Version);
			loggedError.Ecs.Version.Should().NotStartWith("v");
		}

		[Fact]
		public async Task SerializesAndDeserializesMessageTemplateAndScope()
		{
			using var _ = CreateLogger(out var logger, out var provider, out var @namespace, out var waitHandle);
			var dataStream = $"x-dotnet-{@namespace}";
			using (logger.BeginScope("custom scope"))
			{
				var userId = 1;
				logger.LogError("an error occurred for userId {UserId}", userId);

				if (!waitHandle.WaitOne(TimeSpan.FromSeconds(10)))
					throw new Exception("Logs were not written to Elasticsearch within margin of 10 seconds");

				provider.LastSeenException.Should().BeNull();

				var refresh = await Client.Indices.RefreshAsync(dataStream);

				var response = Client.Search<LogEvent>(new SearchRequest(dataStream));

				response.IsValidResponse.Should().BeTrue("{0}", response.DebugInformation);
				response.Total.Should().BeGreaterThan(0);

				var loggedError = response.Documents.First();
				loggedError.Message.Should().Be("an error occurred for userId 1");
				loggedError.MessageTemplate.Should().Be("an error occurred for userId {UserId}");
				loggedError.Scopes.Should().ContainSingle(s => s == "custom scope");
			}
		}

		private IDisposable CreateLogger(out ILogger logger, out ElasticsearchLoggerProvider provider, out string @namespace, out WaitHandle waitHandle)
		{
			@namespace = Guid.NewGuid().ToString("N").ToLowerInvariant().Substring(0, 6);
			var slim = new CountdownEvent(1);
			waitHandle = slim.WaitHandle;
			var s = @namespace;
			var options = new ConfigureOptions<ElasticsearchLoggerOptions>(
				o =>
				{
					o.DataStream = new DataStreamNameOptions { Type = "x", Namespace = s, DataSet = "dotnet" };
					var nodes = Client.ElasticsearchClientSettings.NodePool.Nodes.Select(n => n.Uri).ToArray();
					o.ShipTo = new ShipToOptions() { NodeUris = nodes, ConnectionPoolType = ConnectionPoolType.Static };
				});

			var channelSetup = new IChannelSetup[] { new ChannelSetup(c =>
			{
				c.BufferOptions.MaxRetries = 0;
				c.BufferOptions.MaxConsumerBufferSize = 1;
				c.BufferOptions.WaitHandle = slim;
				c.BufferOptions.ConcurrentConsumers = 1;
				c.ExceptionCallback = e => ObservedException ??= e;
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
			return loggerFactory;
		}
	}
}
