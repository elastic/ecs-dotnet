using Elastic.Channels;
using Elastic.CommonSchema;
using Elastic.CommonSchema.Serialization;
using Elastic.Elasticsearch.Ephemeral;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.CommonSchema;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Serilog.Sinks;
using Elastic.Transport;
using Serilog;
using Serilog.Events;
using Log = Serilog.Log;

var testSerilog = true;

var random = new Random();
var ctxs = new CancellationTokenSource();
var parallelOpts = new ParallelOptions { MaxDegreeOfParallelism = Environment.ProcessorCount, CancellationToken = ctxs.Token };
const int numDocs = 1_000_000;
var bufferOptions = new BufferOptions { };
var config = new EphemeralClusterConfiguration("9.0.0");
using var cluster = new EphemeralCluster(config);
using var channel = SetupElasticsearchChannel();

Console.CancelKeyPress += (sender, eventArgs) =>
{
	ctxs.Cancel();
	cluster.Dispose();
	eventArgs.Cancel = true;
};


using var started = cluster.Start();

if (testSerilog)
	await PushToSerilog();
else
	await PushToChannel(channel);

Console.WriteLine($"Press any key...");
Console.ReadKey();


async Task PushToSerilog()
{
	SetupSerilog();

	Parallel.For(0, numDocs, parallelOpts, i =>
	{
		var randomData = $"Logging information {i} - Random value: {random.NextDouble()}";
		Log.Information(randomData);
	});

	/*
	foreach (var i in Enumerable.Range(0, numDocs))
	{
		var randomData = $"Logging information {i} - Random value: {random.NextDouble()}";
		Log.Information(randomData);
	}
	*/

	Log.CloseAndFlush();
	await Task.Delay(TimeSpan.FromMinutes(1), ctxs.Token);

	void SetupSerilog()
	{
		Serilog.Debugging.SelfLog.Enable(s => Console.WriteLine(s));
		Log.Logger = new LoggerConfiguration()
			.WriteTo.Elasticsearch(new[] { new Uri("http://localhost:9200") }, o =>
			{
				o.ConfigureChannel = c =>
				{
					c.BufferOptions = bufferOptions;
				};
				o.BootstrapMethod = BootstrapMethod.Failure;
				o.MinimumLevel = LogEventLevel.Verbose;
				o.DataStream = new DataStreamName("logs");
			})
			.CreateLogger();
	}
}


async Task PushToChannel(EcsDataStreamChannel<EcsDocument> c)
{
	if (c == null) throw new ArgumentNullException(nameof(c));

	await c.BootstrapElasticsearchAsync(BootstrapMethod.Failure);

	foreach (var i in Enumerable.Range(0, numDocs))
		await DoChannelWrite(i, ctxs.Token);

	/*
	await Parallel.ForEachAsync(Enumerable.Range(0, numDocs), parallelOpts, async (i, ctx) =>
	{
		await DoChannelWrite(i, ctx);
	});
	*/


	async Task DoChannelWrite(int i, CancellationToken cancellationToken)
	{
		var message = $"Logging information {i} - Random value: {random.NextDouble()}";
		var doc = EcsDocument.CreateNewWithDefaults<EcsDocument>();
		doc.Message = message;
		if (await c.WaitToWriteAsync(cancellationToken) && c.TryWrite(doc))
			return;

		Console.WriteLine("Failed To write");
		await Task.Delay(TimeSpan.FromSeconds(5), cancellationToken);
	}
}

EcsDataStreamChannel<EcsDocument> SetupElasticsearchChannel()
{
	var transportConfiguration = new TransportConfiguration(new Uri("http://localhost:9200"));
	var c = new EcsDataStreamChannel<EcsDocument>(
		new DataStreamChannelOptions<EcsDocument>(new DistributedTransport(transportConfiguration))
		{
			BufferOptions = bufferOptions,
			SerializerContext = EcsJsonContext.Default
		});

	return c;
}
