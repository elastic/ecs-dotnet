using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Elastic.Channels;
using Elastic.Channels.Diagnostics;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.IndexManagement;
using Elastic.CommonSchema;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Elastic.Ingest.Elasticsearch;
using Elastic.Transport;
using Elasticsearch.IntegrationDefaults;
using FluentAssertions;
using Serilog;
using Serilog.Core;
using Xunit.Abstractions;
using DataStreamName = Elastic.Ingest.Elasticsearch.DataStreams.DataStreamName;

namespace Elastic.Serilog.Sinks.IntegrationTests;

public class BootstrapMinimumSecurityPrivilegesTests : SecurityPrivilegesTestsBase
{
	public BootstrapMinimumSecurityPrivilegesTests(SecurityCluster cluster, ITestOutputHelper output)
		: base(cluster, output)
	{
	}

	protected override BootstrapMethod Bootstrap => BootstrapMethod.Failure;
	protected override DataStreamName Target { get; } = new ("logs", "serilog.setup");

	protected override string ApiKeyJson => $@"{{
	""name"": ""ecs_setup"",
	""role_descriptors"": {{
		""ecs_setup"": {{
			""cluster"": [""monitor"", ""manage_ilm"", ""manage_index_templates"", ""manage_pipeline""],
			""index"": [{{
				""names"": [""{Target.GetNamespaceWildcard()}""],
				""privileges"": [""manage"", ""create_doc""]
			}}]
		}}
	}}
}}";
}

public class NoBootstrapMinimumSecurityPrivilegesTests : SecurityPrivilegesTestsBase
{
	public NoBootstrapMinimumSecurityPrivilegesTests(SecurityCluster cluster, ITestOutputHelper output)
		: base(cluster, output)
	{
	}

	protected override BootstrapMethod Bootstrap => BootstrapMethod.None;
	protected override DataStreamName Target { get; } = new ("logs", "serilog.write");

	protected override string ApiKeyJson => $@"{{
	""name"": ""ecs_write"",
	""role_descriptors"": {{
		""ecs_write"": {{
			""cluster"": [""monitor""],
			""index"": [{{
				""names"": [""{Target.GetNamespaceWildcard()}""],
				""privileges"": [""auto_configure"", ""create_doc""]
			}}]
		}}
	}}
}}";
}

public abstract class SecurityPrivilegesTestsBase : SerilogTestBase<SecurityCluster>
{
	private IChannelDiagnosticsListener? _listener;
	private readonly CountdownEvent _waitHandle = new(1);
	private ElasticsearchSinkOptions SinkOptions { get; }

	private ElasticsearchClient ApiScopedClient { get; }

	protected abstract string ApiKeyJson { get; }
	protected abstract DataStreamName Target { get; }
	protected abstract BootstrapMethod Bootstrap { get; }

	protected SecurityPrivilegesTestsBase(SecurityCluster cluster, ITestOutputHelper output) : base(cluster, output)
	{
		var logs = new List<Action<Logger>>
		{
			l => l.Information("Hello Information"),
			l => l.Debug("Hello Debug"),
			l => l.Warning("Hello Warning"),
			l => l.Error("Hello Error"),
			l => l.Fatal("Hello Fatal")
		};

		var apiKey = cluster.CreateApiKey(Client, ApiKeyJson);

		ApiScopedClient = cluster.CreateElasticsearchClient(output,
			s=>s.Authentication(new ApiKey(apiKey.Encoded))
		);

		SinkOptions = new ElasticsearchSinkOptions(ApiScopedClient.Transport)
		{
			BootstrapMethod = Bootstrap,
			DataStream = Target,
			ConfigureChannel = c =>
			{
				c.BufferOptions = new BufferOptions
				{
					WaitHandle = _waitHandle,
					OutboundBufferMaxSize = logs.Count
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
		search.Documents.Count().Should().Be(4);

		var messages = search.Documents.Select(e => e.Message);
		messages.Should().Contain("Hello Error");
	}


}
