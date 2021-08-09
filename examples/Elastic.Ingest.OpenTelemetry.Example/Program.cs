using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Elastic.Ingest.OpenTelemetry;
using OpenTelemetry.Exporter;

if (args.Length != 2)
{
	Console.Error.WriteLine("Program needs two arguments: <url> <secret_token>");
	Environment.Exit(1);
}

var o = new OtlpExporterOptions();
o.Endpoint = new Uri(args[0]);
o.Headers = $"Authorization=Bearer {args[1]}";
var x = new CustomOtlpTraceExporter(o);

using var xx = new CustomActivityExporter(x, maxExportBatchSize: 20);

var random = new Random();
long numTraces = 0;
while (true)
{
	var outerActivity = new Activity("outer");
	outerActivity.Start();
	await Task.Delay(TimeSpan.FromMilliseconds(random.Next(20, 200))).ConfigureAwait(false);

	for (var i = 0; i < random.Next(1, 5); i++)
	{
		var innerActivity = new Activity($"inner {i}");
		innerActivity.Start();
		await Task.Delay(TimeSpan.FromMilliseconds(random.Next(5, 50))).ConfigureAwait(false);
		innerActivity.SetStatus(ActivityStatusCode.Ok);
		innerActivity.Stop();
		xx.Add(innerActivity);
	}
	outerActivity.SetStatus(ActivityStatusCode.Ok);
	outerActivity.Stop();
	xx.Add(outerActivity);
	Interlocked.Increment(ref numTraces);
	Console.Write($"\r Queued {numTraces} traces");
}
