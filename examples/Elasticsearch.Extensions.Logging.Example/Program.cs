﻿using System;
using System.Threading.Tasks;
using Elastic.Elasticsearch.Ephemeral;
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
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.UseConsoleLifetime()
				.ConfigureAppConfiguration((hostContext, configurationBuilder) =>
				{
					configurationBuilder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
				})
				.ConfigureLogging((hostContext, loggingBuilder) =>
				{
					// removing console logger when showcasing high traffic, too noisy otherwise
					if (args.Length > 0 && args[0] == "high")
						loggingBuilder.ClearProviders();

					loggingBuilder.AddElasticsearch(c =>
					{
						if (args.Length > 0 && args[0] == "high")
						{
							c.Throttles = new DrainThrottles
							{
								ConcurrentConsumers = 4,
								PublishRejectionCallback = e => Console.Write("!")
							};
						}

						c.Throttles.ElasticsearchResponseCallback = (r, b) =>
							Console.WriteLine($"Indexed: {r.ApiCall.Success} items: {b.Count} time since first read: {b.DurationSinceFirstRead}");
					});
				})
				.ConfigureServices((hostContext, services) =>
				{
					if (args.Length > 0 && args[0] == "high")
						services.AddHostedService<HighVolumeWorkSimulation>();
					else services.AddHostedService<LowVolumeWorkSimulation>();
				});

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
				.EnableDebugMode();
			return new ElasticClient(settings);
		}
	}
}
