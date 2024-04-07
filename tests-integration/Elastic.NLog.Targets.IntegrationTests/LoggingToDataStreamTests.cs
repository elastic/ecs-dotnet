using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Elastic.Channels.Diagnostics;
using Elastic.Clients.Elasticsearch;
using Elastic.CommonSchema;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace NLog.Targets.Elastic.IntegrationTests
{
	public class LoggingToDataStreamTests : TestBase
	{
		public LoggingToDataStreamTests(LoggingCluster cluster, ITestOutputHelper output) : base(cluster, output) { }

		private IDisposable CreateLogger(
			out NLog.Logger logger,
			out NLog.LogFactory logFactory,
			out string @namespace,
			out WaitHandle waitHandle,
			out IChannelDiagnosticsListener listener
		) =>
			base.CreateLogger(out logger, out logFactory, out @namespace, out waitHandle, out listener, (cfg) =>
			{
				cfg.DataStreamType = "x";
				cfg.DataStreamSet = "dotnet";
				var nodesUris = string.Join(",", Client.ElasticsearchClientSettings.NodePool.Nodes.Select(n => n.Uri.ToString()).ToArray());
				cfg.NodeUris = nodesUris;
				cfg.NodePoolType = NodePoolType.Static;
			});

		// ReSharper disable once UnusedMember.Local
		private enum MyEnum { Success, Failure }

		[Fact]
		public async Task LogsEndUpInCluster()
		{
			using var _ = CreateLogger(out var logger, out var provider, out var @namespace, out var waitHandle, out var listener);
			var dataStream = $"x-dotnet-{@namespace}";

			logger.Error("an error occurred {Status}", MyEnum.Failure);

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
	}
}
