using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.IndexManagement;
using Elastic.CommonSchema;
using Elastic.CommonSchema.Serilog.Sink;
using Elastic.Elasticsearch.Xunit.XunitPlumbing;
using Elastic.Ingest.Elasticsearch;
using FluentAssertions;
using Serilog.Core;
using DataStreamName = Elastic.Ingest.Elasticsearch.DataStreamName;

namespace Serilog.Sinks.Elasticsearch.IntegrationTests
{
	public class Serilog : SerilogTestBase, IClusterFixture<SerilogCluster>
	{
		private readonly CountdownEvent _waitHandle;
		private ElasticsearchSchemaSinkOptions SinkOptions { get; }

		public Serilog(SerilogCluster cluster) : base(cluster)
		{
			var logs = new List<Action<Logger>>
			{
				l => l.Information("Hello Information"),
				l => l.Debug("Hello Debug"),
				l => l.Warning("Hello Warning"),
				l => l.Error("Hello Error"),
				l => l.Fatal("Hello Fatal")
			};

			_waitHandle = new CountdownEvent(1);
			SinkOptions = new ElasticsearchSchemaSinkOptions(Client.Transport)
			{
				DataStream = new DataStreamName("logs", "serilog", "tests"),
				ConfigureChannel = c =>
				{
					c.BufferOptions = new ElasticsearchBufferOptions<EcsDocument>
					{
						WaitHandle = _waitHandle,
						MaxConsumerBufferSize = logs.Count
					};
				}
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
				throw new Exception("ecs document was not persisted within 10 seconds");

			var indexName = SinkOptions.DataStream.ToString();
			var refreshed = await Client.Indices.RefreshAsync(new RefreshRequest(indexName));
			refreshed.IsValid.Should().BeTrue("{0}", refreshed.DebugInformation);

			var search = await Client.SearchAsync<EcsDocument>(new SearchRequest(indexName));

			// Informational should be filtered
			search.Documents.Count().Should().Be(4);

			var messages = search.Documents.Select(e => e.Message);
			messages.Should().Contain("Hello Error");
		}

	}
}
