using System;
using System.IO;
using Elastic.CommonSchema.Serilog;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
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

		public static IWebHost BuildWebHost(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>()
				.UseSerilog((ctx, config) =>
				{
					config.ReadFrom.Configuration(ctx.Configuration);

					// Ensure HttpContextAccessor is accessible
					var httpAccessor = ctx.Configuration.Get<HttpContextAccessor>();
					
					// Create a formatter configuration to se this accessor
					var formatterConfig = new EcsTextFormatterConfiguration();
					formatterConfig.MapHttpContext(httpAccessor);
					
					// Write events to the console using this configration
					var formatter = new EcsTextFormatter(formatterConfig);

					config.WriteTo.Console(formatter);
				})
				.UseKestrel()
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
				return;
			}
			catch (Exception ex)
			{
				Log.Fatal(ex, "Host terminated unexpectedly");
				return;
			}
			finally
			{
				Log.CloseAndFlush();
			}
		}
	}
}