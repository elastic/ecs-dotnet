using Elastic.Channels.Diagnostics;
using Elastic.Extensions.Logging;
using Elastic.Extensions.Logging.Options;
using Elastic.Transport;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

public class ExtensionsLogger(ITransport<ITransportConfiguration> transport)
{
	public IDisposable CreateExtensionsLogger(
		out ILogger logger,
		out ElasticsearchLoggerProvider provider,
		out string @namespace,
		out WaitHandle waitHandle,
		out IChannelDiagnosticsListener listener
	)
	{
		@namespace = Guid.NewGuid().ToString("N").ToLowerInvariant().Substring(0, 6);
		var slim = new CountdownEvent(1);
		waitHandle = slim.WaitHandle;
		var s = @namespace;
		var options = new ConfigureOptions<ElasticsearchLoggerOptions>(o =>
		{
			o.Transport = transport;
			o.DataStream = new DataStreamNameOptions { Type = "x", Namespace = s, DataSet = "dotnet" };
			var nodes = transport.Configuration.NodePool.Nodes.Select(n => n.Uri).ToArray();
			o.ShipTo = new ShipToOptions { NodeUris = nodes, NodePoolType = NodePoolType.Static };
		});

		var channelSetup = new IChannelSetup[]
		{
			new ChannelSetup(c =>
			{
				c.BufferOptions.WaitHandle = slim;
				c.BufferOptions.OutboundBufferMaxSize = 1;
				c.BufferOptions.OutboundBufferMaxLifetime = TimeSpan.FromSeconds(1);
				c.BufferOptions.ExportMaxRetries = 0;
				c.BufferOptions.ExportMaxConcurrency = 1;
			})
		};

		var optionsFactory = new OptionsFactory<ElasticsearchLoggerOptions>([options], []);
		var optionsMonitor = new OptionsMonitor<ElasticsearchLoggerOptions>(optionsFactory, [], new OptionsCache<ElasticsearchLoggerOptions>());
		provider = new ElasticsearchLoggerProvider(optionsMonitor, channelSetup);
		var loggerFactory = new LoggerFactory( [provider], new LoggerFilterOptions { MinLevel = LogLevel.Information });
		logger = loggerFactory.CreateLogger<ElasticsearchLogger>();
		listener = provider.DiagnosticsListener!;
		return loggerFactory;
	}
}
