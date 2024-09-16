using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Elastic.Extensions.Logging.Console.Example;

/// <summary> Simulate work that logs in low volume with some time in between each log call </summary>
public class ExampleService : BackgroundService
{
	private readonly ILogger<ExampleService> _logger;

	public ExampleService(ILogger<ExampleService> logger) => _logger = logger;

	protected override async Task ExecuteAsync(CancellationToken ctx)
	{
		for (var i = 0; i < 100; i++)
		{
			_logger.LogWarning("We are logging way too much: {CustomData}", i);
			if (i % 100 == 0)
				await Task.Delay(1, ctx);
		}
	}
}
