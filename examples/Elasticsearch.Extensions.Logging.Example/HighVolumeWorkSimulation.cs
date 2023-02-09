using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Elasticsearch.Extensions.Logging.Example
{

	/// <summary> Simulate work that logs in low volume with some time in between each log call </summary>
	public class HighVolumeWorkSimulation : BackgroundService
	{
		private readonly ILogger<HighVolumeWorkSimulation> _logger;

		public HighVolumeWorkSimulation(ILogger<HighVolumeWorkSimulation> logger) => _logger = logger;

		protected override async Task ExecuteAsync(CancellationToken ctx)
		{
			for (var i = 0; i < 100_000; i++)
			{
				_logger.LogWarning($"We are logging way too much: {i}");
				if (i % 100 == 0)
					await Task.Delay(1, ctx);
			}
		}
	}
}
