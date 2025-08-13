// See https://aka.ms/new-console-template for more information

using Elastic.CommonSchema;
using Elastic.Extensions.Logging.Console;
using Elastic.Extensions.Logging.Console.Example;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Host = Microsoft.Extensions.Hosting.Host;

await Host.CreateDefaultBuilder(args)
	.UseConsoleLifetime()
	.ConfigureAppConfiguration((_, configurationBuilder) =>
	{
		configurationBuilder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
	})
	.ConfigureLogging((_, loggingBuilder) => loggingBuilder.AddEcsConsole(configure: c =>
	{
		c.MapCustom = l => l.Organization = new Organization { Name = "my-organization" };
	}))
	.ConfigureServices((_, services) =>
	{
		services.AddHostedService<ExampleService>();
	})
	.Build()
	.RunAsync();
