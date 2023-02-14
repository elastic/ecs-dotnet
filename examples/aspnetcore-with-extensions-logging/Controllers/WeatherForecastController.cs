using Microsoft.AspNetCore.Mvc;

namespace aspnetcore_with_extensions_logging.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
	private static readonly string[] Summaries = new[]
	{
		"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
	};

	private readonly ILogger<WeatherForecastController> _logger;

	public WeatherForecastController(ILogger<WeatherForecastController> logger) => _logger = logger;

	[HttpGet(Name = "GetWeatherForecast")]
	public IEnumerable<WeatherForecast> Get()
	{
		_logger.LogInformation("Attempting to generate fake weather forecasts");
		return Enumerable.Range(1, 5)
			.Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
	}

	[HttpPost(Name = "PostWeatherForecast")]
	public IEnumerable<WeatherForecast> Post()
	{

		using var scope = _logger.BeginScope("POST scope");
		using var innerScope = _logger.BeginScope("{Template}", "templated scope");
		_logger.LogInformation("Attempting to generate fake weather forecasts");
		return Enumerable.Range(1, 5)
			.Select(index => new WeatherForecast
			{
				Date = DateTime.Now.AddDays(index),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
	}
}
