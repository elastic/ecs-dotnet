using Elastic.Channels.Diagnostics;
using Elastic.Transport;
using NLog.Targets;

public class NLogExporter(ITransport<ITransportConfiguration> transport)
{
	public IDisposable CreateNLogLogger(
		out NLog.Logger logger,
		out NLog.LogFactory logFactory,
		out string @namespace,
		out WaitHandle waitHandle,
		out IChannelDiagnosticsListener listener
	)
	{
		var slim = new CountdownEvent(1);
		waitHandle = slim.WaitHandle;
		@namespace = Guid.NewGuid().ToString("N").ToLowerInvariant().Substring(0, 6);

		logFactory = new NLog.LogFactory();
		var logConfig = new NLog.Config.LoggingConfiguration(logFactory);
		var logTarget = new ElasticsearchTarget { Name = "elastic" };
		logTarget.RequestInvoker = transport.Configuration.RequestInvoker;
		logTarget.DataStreamNamespace = @namespace;
		logTarget.OutboundBufferMaxSize = 1;
		logTarget.OutboundBufferMaxLifetimeSeconds = 1;
		logTarget.ExportMaxRetries = 0;
		logTarget.ExportMaxConcurrency = 1;
		logTarget.ConfigureChannel = (cfg) => cfg.BufferOptions.WaitHandle = slim;

		logTarget.DataStreamType = "x";
		logTarget.DataStreamSet = "dotnet";
		var nodesUris = string.Join(",", transport.Configuration.NodePool.Nodes.Select(n => n.Uri.ToString()).ToArray());
		logTarget.NodeUris = nodesUris;
		logTarget.NodePoolType = ElasticPoolType.Static;
		logConfig.AddRuleForAllLevels(logTarget);
		logFactory.Configuration = logConfig;
		listener = logTarget.DiagnosticsListener!;
		logger = logFactory.GetLogger("TestLogger");
		return logFactory;
	}
}
