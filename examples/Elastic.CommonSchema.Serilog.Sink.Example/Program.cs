// See https://aka.ms/new-console-template for more information

using Elastic.Channels;
using Elastic.Clients.Elasticsearch;
using Elastic.CommonSchema.Serilog;
using Elastic.CommonSchema.Serilog.Sink;
using Elastic.CommonSchema.Serilog.Sink.Example;
using Elastic.Elasticsearch.Ephemeral;
using Elastic.Ingest.Elasticsearch;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using DataStreamName = Elastic.Ingest.Elasticsearch.DataStreams.DataStreamName;
using Host = Microsoft.Extensions.Hosting.Host;
using Log = Serilog.Log;

// -- Start an Elasticsearch Instance --
using var cluster = new EphemeralCluster("8.4.0");
var client = CreateClient(cluster);
//check if an instance is already running before starting
if (!(await client.InfoAsync()).IsValidResponse)
	cluster.Start(TimeSpan.FromMinutes(1));
else Console.WriteLine("Using already running Elasticsearch instance");


// -- Setup Serilog --
var nodes = new[] { new Uri("http://localhost:9200") };
Log.Logger = new LoggerConfiguration()
	.MinimumLevel.Debug()
	.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
	.Enrich.FromLogContext()
	.WriteTo.Elasticsearch(nodes, opts =>
	{
		opts.BootstrapMethod = BootstrapMethod.Failure;
		opts.DataStream = new DataStreamName("logs", "console-example");
		opts.ConfigureChannel = channelOpts => {
			channelOpts.BufferOptions = new BufferOptions { ExportMaxConcurrency = 10 };
		};
	}, transport =>
	{
		//transport.Authentication();
	})
	// This is the bit that Elastic.CommonSchema.Serilog.Sink introduces
	.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(client.Transport)
	{
		BootstrapMethod = BootstrapMethod.Failure,
		DataStream = new DataStreamName("logs", "console-example"),
		TextFormatting = new EcsTextFormatterConfiguration
		{
			MapCustom = (e, _) => e
		},
		ConfigureChannel = channelOpts =>  {
			channelOpts.BufferOptions = new BufferOptions { ExportMaxConcurrency = 10 };
		}
	})
	.CreateLogger();

// -- Setup Console Host --
var consoleHost = CreateHostBuilder(args, client).Build();
await consoleHost.RunAsync();

static ElasticsearchClient CreateClient(EphemeralCluster cluster)
{
	var settings = new ElasticsearchClientSettings(cluster.NodesUris().First())
		.EnableDebugMode();
	return new ElasticsearchClient(settings);
}

static IHostBuilder CreateHostBuilder(string[] args, ElasticsearchClient client)
{
	return Host.CreateDefaultBuilder(args)
		.UseConsoleLifetime()
		.ConfigureAppConfiguration((_, configurationBuilder) =>
		{
			configurationBuilder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
		})
		.ConfigureServices((_, services) =>
		{
			services.AddHostedService<HighVolumeWorkSimulation>();
			services.AddSingleton(client);
		})
		.UseSerilog();
}
