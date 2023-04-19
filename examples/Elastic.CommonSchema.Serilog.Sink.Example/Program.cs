// See https://aka.ms/new-console-template for more information

using Elastic.Channels;
using Elastic.Channels.Diagnostics;
using Elastic.Clients.Elasticsearch;
using Elastic.CommonSchema;
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
using BulkResponse = Elastic.Ingest.Elasticsearch.Serialization.BulkResponse;
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

var waitHandle = new CountdownEvent(1);
IChannelDiagnosticsListener? listener = null;

// -- Setup Serilog --
var nodes = new[] { new Uri("http://localhost:9200") };
Log.Logger = new LoggerConfiguration()
	.MinimumLevel.Debug()
	.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
	.Enrich.FromLogContext()
	.WriteTo.Elasticsearch(nodes, opts =>
	{
		opts.BootstrapMethod = BootstrapMethod.None;
		opts.DataStream = new DataStreamName("logs", "console-example");
		opts.ConfigureChannel = channelOpts => {
			channelOpts.BufferOptions = new BufferOptions
			{
				ExportMaxConcurrency = 1,
				OutboundBufferMaxSize = 2,
				WaitHandle = waitHandle
			};
		};
		opts.ChannelDiagnosticsCallback = l => listener = l;

	})
	.CreateLogger();

// -- Log 2 items and wait for flush --
Log.Logger.Information("Writing event 1");
Log.Logger.Information("Writing event 2");

if (!waitHandle.WaitHandle.WaitOne(TimeSpan.FromSeconds(10)))
	throw new Exception($"No flush occurred in 10 seconds: {listener}", listener?.ObservedException);
else
{
	Console.WriteLine("Successfully indexed data to Elasticsearch");
	Console.WriteLine(listener);
}


// -- Setup Console Host --
/*
var consoleHost = CreateHostBuilder(args, client).Build();
await consoleHost.RunAsync();


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
*/
static ElasticsearchClient CreateClient(EphemeralCluster cluster)
{
	var settings = new ElasticsearchClientSettings(cluster.NodesUris().First())
		.EnableDebugMode();
	return new ElasticsearchClient(settings);
}

