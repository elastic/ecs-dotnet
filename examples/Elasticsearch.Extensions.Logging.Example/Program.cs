using System;
using System.Threading.Tasks;
using Elastic.Elasticsearch.Ephemeral;
using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
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
					loggingBuilder.AddElasticsearch();
					// The default configuration section is "Elasticsearch"; if you want
					// a different section, you can manually configure:
					// loggingBuilder.AddElasticsearch(options =>
					//     hostContext.Configuration.Bind("Logging:CustomElasticsearch", options));
				})
				.ConfigureServices((hostContext, services) => { services.AddHostedService<Worker>(); });

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
