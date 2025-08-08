using Elastic.Channels;
using Elastic.Channels.Diagnostics;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Serilog.Sinks;
using Elastic.Transport;
using Serilog;
using Serilog.Core;

public class SerilogExporter(ITransport<ITransportConfiguration> transport)
{
	public Logger CreateSerilogLogger(out WaitHandle waitHandle, out IChannelDiagnosticsListener listener)
	{
		var countdown = new CountdownEvent(1);
		waitHandle = countdown.WaitHandle;

		IChannelDiagnosticsListener? listen = null;
		var options = new ElasticsearchSinkOptions(transport)
		{
			DataStream = new DataStreamName("logs", "serilog", "tests"),
			ConfigureChannel = c =>
			{
				c.BufferOptions = new BufferOptions
				{
					WaitHandle = countdown,
					OutboundBufferMaxSize = 1
				};
			},
			ChannelDiagnosticsCallback = l => listen = l
		};
		listener = listen ?? throw new Exception("No listener");

		var loggerConfig = new LoggerConfiguration()
			.MinimumLevel.Information()
			.WriteTo.Elasticsearch(options);

		var logger = loggerConfig.CreateLogger();
		return logger;
	}
}
