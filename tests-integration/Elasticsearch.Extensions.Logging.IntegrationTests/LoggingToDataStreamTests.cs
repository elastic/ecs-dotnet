using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Elastic.Channels.Diagnostics;
using Elastic.Clients.Elasticsearch;
using Elastic.CommonSchema;
using Elasticsearch.Extensions.Logging.Options;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Xunit;
using Xunit.Abstractions;
using BulkResponse = Elastic.Ingest.Elasticsearch.Serialization.BulkResponse;

namespace Elasticsearch.Extensions.Logging.IntegrationTests
{
	public class LoggingToDataStreamTests : TestBase
	{
		public LoggingToDataStreamTests(LoggingCluster cluster, ITestOutputHelper output) : base(cluster, output) { }

		private IDisposable CreateLogger(
			out ILogger logger,
			out ElasticsearchLoggerProvider provider,
			out string @namespace,
			out WaitHandle waitHandle,
			out ChannelListener<LogEvent, BulkResponse> listener
		) =>
			base.CreateLogger(out logger, out provider, out @namespace, out waitHandle, out listener, (o, s) =>
			{
				o.DataStream = new DataStreamNameOptions { Type = "x", Namespace = s, DataSet = "dotnet" };
				var nodes = Client.ElasticsearchClientSettings.NodePool.Nodes.Select(n => n.Uri).ToArray();
				o.ShipTo = new ShipToOptions { NodeUris = nodes, NodePoolType = NodePoolType.Static };
			});

		// ReSharper disable once UnusedMember.Local
		private enum MyEnum { Success, Failure }

		[Fact]
		public async Task LogsEndUpInCluster()
		{
			using var _ = CreateLogger(out var logger, out var provider, out var @namespace, out var waitHandle, out var listener);
			var dataStream = $"x-dotnet-{@namespace}";

			logger.LogError("an error occurred {Status}", MyEnum.Failure);

			if (!waitHandle.WaitOne(TimeSpan.FromSeconds(10)))
				throw new Exception($"No flush occurred in 10 seconds: {listener}", listener.ObservedException);

			listener.PublishSuccess.Should().BeTrue("{0}", listener);
			listener.ObservedException.Should().BeNull();

			await Client.Indices.RefreshAsync(dataStream);

			var response = Client.Search<EcsDocument>(new SearchRequest(dataStream));

			response.IsValidResponse.Should().BeTrue("{0}", response.DebugInformation);
			response.Total.Should().BeGreaterThan(0);

			var loggedError = response.Documents.First();
			loggedError.Message.Should().Be("an error occurred Failure");
			loggedError.Log.Should().NotBeNull();
			loggedError.Log.Level.Should().Be("Error");
			loggedError.Ecs.Version.Should().Be(EcsDocument.Version);
			loggedError.Ecs.Version.Should().NotStartWith("v");

			loggedError.Labels.Should().ContainKey("Status");
			loggedError.Labels["Status"].Should().Be("Failure");
		}

		[Fact]
		public async Task SerializesAndDeserializesMessageTemplateAndScope()
		{
			using var _ = CreateLogger(out var logger, out var provider, out var @namespace, out var waitHandle, out var listener);
			using var scope = logger.BeginScope("custom scope");
			var dataStream = $"x-dotnet-{@namespace}";
			var userId = 1;
			logger.LogError("an error occurred for userId {UserId}", userId);

			if (!waitHandle.WaitOne(TimeSpan.FromSeconds(10)))
				throw new Exception($"No flush occurred in 10 seconds: {listener}", listener.ObservedException);

			listener.PublishSuccess.Should().BeTrue("{0}", listener);
			listener.ObservedException.Should().BeNull();

			await Client.Indices.RefreshAsync(dataStream);

			var response = Client.Search<LogEvent>(new SearchRequest(dataStream));

			response.IsValidResponse.Should().BeTrue("{0}", response.DebugInformation);
			response.Total.Should().BeGreaterThan(0);

			var loggedError = response.Documents.First();
			loggedError.Message.Should().Be("an error occurred for userId 1");
			loggedError.MessageTemplate.Should().Be("an error occurred for userId {UserId}");
			loggedError.Scopes.Should().ContainSingle(s => s == "custom scope");
		}

	}
}
