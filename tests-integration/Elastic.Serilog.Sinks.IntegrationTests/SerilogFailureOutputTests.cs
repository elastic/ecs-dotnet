using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Elastic.Channels;
using Elastic.Channels.Diagnostics;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using FluentAssertions;
using Serilog;
using Serilog.Sinks.TestCorrelator;
using Xunit.Abstractions;
using DataStreamName = Elastic.Ingest.Elasticsearch.DataStreams.DataStreamName;

namespace Elastic.Serilog.Sinks.IntegrationTests
{
	public class SerilogFailureOutputTests : SerilogTestBase
	{
		private readonly CountdownEvent _waitHandle;
		private IChannelDiagnosticsListener? _listener;
		private ElasticsearchSinkOptions SinkOptions { get; }

		private static ICollection<Uri> AlterNodes(ICollection<Uri> uris) => uris.Select(u =>
			{
				var builder = new UriBuilder(u)
				{
					Scheme = "https"
				};
				return builder.Uri;
			})
			.ToList();

		public SerilogFailureOutputTests(SerilogCluster cluster, ITestOutputHelper output) : base(cluster, output, AlterNodes)
		{
			_waitHandle = new CountdownEvent(1);
			SinkOptions = new ElasticsearchSinkOptions(Client.Transport)
			{
				DataStream = new DataStreamName("logs", "serilog", "tests"),
				ConfigureChannel = c =>
				{
					c.BufferOptions = new BufferOptions
					{
						ExportMaxRetries = 0,
						WaitHandle = _waitHandle,
						OutboundBufferMaxSize = 1
					};
				},
				ChannelDiagnosticsCallback = (l) => _listener = l
			};
		}

		[I] public void AssertLogs()
		{
			var loggerConfig = new LoggerConfiguration()
				.MinimumLevel.Information()
				.WriteTo.ColoredConsole()
				.WriteTo.FallbackChain(
					fc => fc.Elasticsearch(SinkOptions),
					fc => fc.TestCorrelator()
				);

			using var logger = loggerConfig.CreateLogger();
			logger.Information("Hello world");

			if (!_waitHandle.WaitHandle.WaitOne(TimeSpan.FromSeconds(10)))
				throw new Exception($"No flush occurred in 10 seconds: {_listener}", _listener?.ObservedException);

			TestCorrelator.GetLogEventsFromCurrentContext()
				.Should().ContainSingle()
				.Should().Be("My log message!");
		}
	}
}
