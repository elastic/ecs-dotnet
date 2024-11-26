using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Elastic.Channels;
using Elastic.Channels.Diagnostics;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.IndexManagement;
using Elastic.CommonSchema;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using FluentAssertions;
using Serilog;
using Serilog.Core;
using Xunit.Abstractions;
using DataStreamName = Elastic.Ingest.Elasticsearch.DataStreams.DataStreamName;

namespace Elastic.Serilog.Sinks.IntegrationTests
{
	public class SerilogOutputTests : SerilogTestBase
	{
		private IChannelDiagnosticsListener? _listener = null;
		private readonly CountdownEvent _waitHandle;
		private ElasticsearchSinkOptions SinkOptions { get; }

		public SerilogOutputTests(SerilogCluster cluster, ITestOutputHelper output) : base(cluster, output)
		{
			var logs = new Action<Logger>[]
			{
				l => l.Information("Hello Information"),
				l => l.Debug("Hello Debug"),
				l => l.Warning("Hello Warning"),
				l => l.Error("Hello Error"),
				l => l.Fatal("Hello Fatal")
			};

			_waitHandle = new CountdownEvent(1);
			SinkOptions = new ElasticsearchSinkOptions(Client.Transport)
			{
				DataStream = new DataStreamName("logs", "serilog", "tests"),
				ConfigureChannel = c =>
				{
					c.BufferOptions = new BufferOptions
					{
						WaitHandle = _waitHandle,
						OutboundBufferMaxSize = logs.Length
					};
				},
				ChannelDiagnosticsCallback = (l) => _listener = l
			};

			var loggerConfig = new LoggerConfiguration()
				.MinimumLevel.Information()
				.WriteTo.ColoredConsole()
				.WriteTo.Elasticsearch(SinkOptions);

			using var logger = loggerConfig.CreateLogger();
			foreach (var a in logs) a(logger);
		}

		[I] public async Task AssertLogs()
		{
			if (!_waitHandle.WaitHandle.WaitOne(TimeSpan.FromSeconds(10)))
				throw new Exception($"No flush occurred in 10 seconds: {_listener}", _listener?.ObservedException);

			var indexName = SinkOptions.DataStream.ToString();
			var refreshed = await Client.Indices.RefreshAsync(new RefreshRequest(indexName));
			refreshed.IsValidResponse.Should().BeTrue("{0}", refreshed.DebugInformation);

			var search = await Client.SearchAsync<EcsDocument>(new SearchRequest(indexName));

			// Informational should be filtered
			search.Documents.Count.Should().Be(4);

			var messages = search.Documents.Select(e => e.Message);
			messages.Should().Contain("Hello Error");
		}
	}
}
