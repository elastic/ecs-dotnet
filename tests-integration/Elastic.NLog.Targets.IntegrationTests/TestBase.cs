using System;
using System.Linq;
using System.Threading;
using Elastic.Channels.Diagnostics;
using Elastic.Clients.Elasticsearch;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Xunit.Abstractions;

namespace NLog.Targets.Elastic.IntegrationTests;

public abstract class TestBase : IClusterFixture<LoggingCluster>
{
	protected ElasticsearchClient Client { get; }

	protected TestBase(LoggingCluster cluster, ITestOutputHelper output) =>
		Client = cluster.CreateClient(output);

	protected IDisposable CreateLogger(
		out NLog.Logger logger,
		out NLog.LogFactory logFactory,
		out string @namespace,
		out WaitHandle waitHandle,
		out IChannelDiagnosticsListener listener,
		Action<NLog.Targets.ElasticsearchTarget> setupTarget
	)
	{
		var slim = new CountdownEvent(1);
		waitHandle = slim.WaitHandle;
		@namespace = Guid.NewGuid().ToString("N").ToLowerInvariant().Substring(0, 6);

		logFactory = new NLog.LogFactory();
		var logConfig = new NLog.Config.LoggingConfiguration(logFactory);
		var logTarget = new NLog.Targets.ElasticsearchTarget() { Name = "elastic" };
		logTarget.DataStreamNamespace = @namespace;
		logTarget.OutboundBufferMaxSize = 1;
		logTarget.OutboundBufferMaxLifetimeSeconds = 1;
		logTarget.ExportMaxRetries = 0;
		logTarget.ExportMaxConcurrency = 1;
		logTarget.ConfigureChannel = (cfg) => cfg.BufferOptions.WaitHandle = slim;
		setupTarget?.Invoke(logTarget);
		logConfig.AddRuleForAllLevels(logTarget);
		logFactory.Configuration = logConfig;
		listener = logTarget.DiagnosticsListener;
		logger = logFactory.GetLogger("TestLogger");
		return logFactory;
	}
}
