using System;
using System.Linq;
using System.Threading;
using Elastic.Clients.Elasticsearch;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Elasticsearch.Extensions.Logging.Options;
using Elasticsearch.IntegrationDefaults;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Xunit.Abstractions;

namespace Elasticsearch.Extensions.Logging.IntegrationTests;

public abstract class TestBase : IClusterFixture<LoggingCluster>
{
	protected ElasticsearchClient Client { get; }

	protected TestBase(LoggingCluster cluster, ITestOutputHelper output) =>
		Client = cluster.CreateClient(output);

	protected IDisposable CreateLogger(
		out ILogger logger,
		out ElasticsearchLoggerProvider provider,
		out string @namespace,
		out WaitHandle waitHandle,
		out ChannelListener<LogEvent> listener,
		Action<ElasticsearchLoggerOptions, string> setupLogger
	)
	{
		listener = new ChannelListener<LogEvent>();
		var l = listener;
		@namespace = Guid.NewGuid().ToString("N").ToLowerInvariant().Substring(0, 6);
		var slim = new CountdownEvent(1);
		waitHandle = slim.WaitHandle;
		var s = @namespace;
		var options = new ConfigureOptions<ElasticsearchLoggerOptions>(o => setupLogger(o, s));

		var channelSetup = new IChannelSetup[]
		{
			new ChannelSetup(c =>
			{
				c.BufferOptions.MaxRetries = 0;
				c.BufferOptions.MaxConsumerBufferSize = 1;
				c.BufferOptions.MaxConsumerBufferLifetime = TimeSpan.FromSeconds(1);
				c.BufferOptions.WaitHandle = slim;
				c.BufferOptions.ConcurrentConsumers = 1;
				l.Register(c);
			})
		};

		var optionsFactory = new OptionsFactory<ElasticsearchLoggerOptions>(
			new[] { options }, Enumerable.Empty<IPostConfigureOptions<ElasticsearchLoggerOptions>>());
		var optionsMonitor = new OptionsMonitor<ElasticsearchLoggerOptions>(
			optionsFactory, Enumerable.Empty<IOptionsChangeTokenSource<ElasticsearchLoggerOptions>>(),
			new OptionsCache<ElasticsearchLoggerOptions>());
		provider = new ElasticsearchLoggerProvider(optionsMonitor, channelSetup);
		var loggerFactory = new LoggerFactory(
			new[] { provider },
			new LoggerFilterOptions { MinLevel = LogLevel.Information }
		);
		logger = loggerFactory.CreateLogger<ElasticsearchLogger>();
		return loggerFactory;
	}
}
