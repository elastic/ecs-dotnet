using Elastic.Channels;
using Elastic.Channels.Diagnostics;
using Elastic.Transport;
using Serilog;
using Xunit;
using DataStreamName = Elastic.Ingest.Elasticsearch.DataStreams.DataStreamName;

namespace Elastic.Serilog.Sinks.Tests
{
	public class SerilogFailureOutputTests
	{
		private readonly CountdownEvent _waitHandle;
		private IChannelDiagnosticsListener? _listener;
		private ElasticsearchSinkOptions SinkOptions { get; }

		public SerilogFailureOutputTests()
		{
			_waitHandle = new CountdownEvent(1);
			SinkOptions = new ElasticsearchSinkOptions(new DistributedTransport(new TransportConfiguration()))
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

		[Fact] public void AssertLogs()
		{
			var loggerConfig = new LoggerConfiguration()
				.MinimumLevel.Information()
				.WriteTo.FallbackChain(
					fc => fc.Elasticsearch(SinkOptions),
					fc => fc.Console()
				);

			using var logger = loggerConfig.CreateLogger();
			logger.Information("Hello world");

			if (!_waitHandle.WaitHandle.WaitOne(TimeSpan.FromSeconds(10)))
				throw new Exception($"No flush occurred in 10 seconds: {_listener}", _listener?.ObservedException);

		}
	}
}
