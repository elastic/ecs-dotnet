using System;
using System.IO;
using Elastic.Apm.SerilogEnricher;
using Elastic.CommonSchema.Serilog;
using Elastic.Serilog.Enrichers.Web;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace AspnetCoreExample
{
	public class Program
	{
		public static IConfiguration Configuration { get; } = new ConfigurationBuilder()
			.SetBasePath(Directory.GetCurrentDirectory())
			.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
			.AddEnvironmentVariables()
			.Build();

		public static IHost BuildWebHost(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHost(webBuilder =>
				{
					webBuilder
						.UseStartup<Startup>()
						.UseKestrel();
				})
				.UseSerilog((ctx, config) =>
				{
					// Ensure HttpContextAccessor is accessible
					var httpAccessor = ctx.Configuration.Get<IHttpContextAccessor>();

					config
						.ReadFrom.Configuration(ctx.Configuration)
						.Enrich.WithElasticApmCorrelationInfo()
						.Enrich.WithEcsHttpContext(httpAccessor);

					//config.WriteTo.Console(formatter);
					config.WriteTo.Async(a => a.Console(new EcsTextFormatter()));
				})
				.Build();

		public static void Main(string[] args)
		{
			Log.Logger = new LoggerConfiguration()
				.ReadFrom.Configuration(Configuration)
				.Enrich.WithProperty("App Name", "Example Elastic.CommonSchema.Serilog application with AspnetCore and Serilog")
				.CreateLogger();
			try
			{
				BuildWebHost(args).Run();
			}
			catch (Exception ex)
			{
				Log.Fatal(ex, "Host terminated unexpectedly");
			}
			finally
			{
				Log.CloseAndFlush();
			}
		}
	}
}
