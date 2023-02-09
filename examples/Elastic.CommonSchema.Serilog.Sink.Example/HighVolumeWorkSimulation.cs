using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.Core.Search;
using Elastic.Clients.Elasticsearch.IndexManagement;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Elastic.CommonSchema.Serilog.Sink.Example;

/// <summary> Simulate work that logs in low volume with some time in between each log call </summary>
public class HighVolumeWorkSimulation : BackgroundService
{
	private readonly ILogger<HighVolumeWorkSimulation> _logger;
	private readonly ElasticsearchClient _client;

	public HighVolumeWorkSimulation(ILogger<HighVolumeWorkSimulation> logger, ElasticsearchClient client)
	{
		_logger = logger;
		_client = client;
	}

	protected override async Task ExecuteAsync(CancellationToken ctx)
	{
		Console.WriteLine("Starting Work!:");
		for (var i = 0; i < 100_000; i++)
		{
			_logger.LogWarning($"We are logging way too much: {i}");
			if (i % 100 == 0)
				await Task.Delay(1, ctx);
		}

		var _ = await _client.Indices.RefreshAsync(new RefreshRequest("logs-*"), ctx);
		var search = await _client.SearchAsync<EcsDocument>(new SearchRequest("logs-*") {  Size = 1, TrackTotalHits = new TrackHits(true) }, ctx);
		Console.WriteLine(search.ApiCallDetails.DebugInformation);
		Console.WriteLine();
		Console.WriteLine($"Indexed {search.Total} logs, this may be slightly off because we refresh before all buffers are flushed");
		Console.WriteLine();
		await base.StopAsync(ctx);
	}
}
