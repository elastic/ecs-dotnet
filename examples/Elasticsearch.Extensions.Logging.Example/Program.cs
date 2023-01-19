﻿using System;
using System.Threading.Tasks;
using Elastic.Elasticsearch.Ephemeral;
using Elastic.Ingest.Elasticsearch;
using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Nest;

namespace Elasticsearch.Extensions.Logging.Example
{
	internal static class Program
	{
		// Configuration can be overriden from command line, e.g.
		// dotnet run --project ./examples/Elasticsearch.Extensions.Logging.Example/ --Logging:Elasticsearch:ShipTo:NodeUris:0 "http://ipv4.fiddler:9200"

		public static IHostBuilder CreateHostBuilder(string[] args)
		{
			var highLoadUseCase = args.Length == 0 || args[0] != "low";
			return Host.CreateDefaultBuilder(args)
				.UseConsoleLifetime()
				.ConfigureAppConfiguration((hostContext, configurationBuilder) =>
				{
					configurationBuilder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
				})
				.ConfigureLogging((hostContext, loggingBuilder) =>
				{
					// removing console logger when showcasing high traffic, too noisy otherwise
					if (highLoadUseCase)
						loggingBuilder.ClearProviders();

					loggingBuilder.AddElasticsearch(options => {}, channel =>
					{
						if (highLoadUseCase)
						{
							channel.BufferOptions = new ElasticsearchBufferOptions<LogEvent> { ConcurrentConsumers = 4 };
							channel.PublishRejectionCallback = e => Console.Write("!");
						}
						channel.ResponseCallback = (r, b) =>
							Console.WriteLine($"statusCode: {r.ApiCallDetails.HttpStatusCode} items: {b.Count} time since first read: {b.DurationSinceFirstRead}");
					});
				})
				.ConfigureServices((hostContext, services) =>
				{
					if (args.Length > 0 && args[0] == "low")
						services.AddHostedService<LowVolumeWorkSimulation>();
					else services.AddHostedService<HighVolumeWorkSimulation>();
				});
		}

		public static async Task Main(string[] args)
		{
			using var cluster = new EphemeralCluster("7.8.0");
			var client = CreateClient(cluster);
			if (!(await client.RootNodeInfoAsync()).IsValid)
				cluster.Start(TimeSpan.FromMinutes(1));
			else Console.WriteLine("Using already running Elasticsearch instance");

			await CreateHostBuilder(args).Build().RunAsync();
		}

		private static ElasticClient CreateClient(EphemeralCluster cluster)
		{
			var nodes = cluster.NodesUris();
			var connectionPool = new StaticConnectionPool(nodes);
			var settings = new ConnectionSettings(connectionPool)
				//.Proxy(new Uri("http://localhost:8080"), "", "")
				.EnableDebugMode();
			return new ElasticClient(settings);
		}
	}
}
