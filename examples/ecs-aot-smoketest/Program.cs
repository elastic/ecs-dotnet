// See https://aka.ms/new-console-template for more information

using Elastic.CommonSchema;
using Elastic.Transport;
using Microsoft.Extensions.Logging;
using Log = Elastic.CommonSchema.Log;
using LogLevel = NLog.LogLevel;

Console.WriteLine("Hello, World!");

var serialized = @$"{{}}";
var deserialized = EcsDocument.Deserialize(serialized);
if (deserialized == null) throw new Exception("deserialized is null");

serialized = @$"{{ ""agent"": {{ ""unknown"": ""value"" }} }}";
deserialized = EcsDocument.Deserialize(serialized);
if (deserialized == null) throw new Exception("deserialized is null");
if (deserialized.Agent == null) throw new Exception("deserialized agent is null");

var d = new EcsDocument { Agent = new Agent { Name = "some-agent" }, Log = new Log { Level = "debug" } };

serialized = d.Serialize();
if (string.IsNullOrEmpty(serialized)) throw new Exception("serialized is null");
Console.WriteLine(serialized);

var invoker = new InMemoryRequestInvoker();
var pool = new StaticNodePool([new Node(new Uri("http://localhost:9200"))]);
var configuration = new TransportConfiguration(pool, invoker);
var transport = new DistributedTransport(configuration);

var extension = new ExtensionsLogger(transport);
LogInMemoryExtensionsLogger(extension);

var nlog = new NLogExporter(transport);
LogInMemoryNLog(nlog);

/*
var serilog = new SerilogExporter(transport);
LogInMemorySerilog(serilog);

void LogInMemorySerilog(SerilogExporter serilogExporter)
{
	using var logger = serilogExporter.CreateSerilogLogger(out var waitHandle, out var listener);
	logger.Information("an error occurred {Status}", "failure");

	if (!waitHandle.WaitOne(TimeSpan.FromSeconds(10)))
		throw new Exception($"No flush occurred in 10 seconds: {listener}", listener.ObservedException);

	if (!listener.PublishSuccess)
		throw new Exception("Serilog Logger did not export correctly");
	if (listener.ObservedException != null)
		throw new Exception("Serilog Logger received exception", listener.ObservedException);
	Console.WriteLine("Serilog Logger export success");
}
*/

void LogInMemoryExtensionsLogger(ExtensionsLogger extensionsLogger)
{
	using var _ = extensionsLogger.CreateExtensionsLogger(out var logger, out var provider, out var @namespace, out var waitHandle, out var listener);
	logger.LogError("an error occurred {Status}", "failure");

	if (!waitHandle.WaitOne(TimeSpan.FromSeconds(10)))
		throw new Exception($"No flush occurred in 10 seconds: {listener}", listener.ObservedException);

	if (!listener.PublishSuccess)
		throw new Exception("Extensions Logger did not export correctly");
	if (listener.ObservedException != null)
		throw new Exception("Extensions Logger received exception", listener.ObservedException);
	Console.WriteLine("Extensions Logger export success");
}

void LogInMemoryNLog(NLogExporter serilogExporter)
{
	using var _ = serilogExporter.CreateNLogLogger(out var logger, out var _, out var _, out var waitHandle, out var listener);
	logger.Log(LogLevel.Error, "an error occurred {Status}", "failure");

	if (!waitHandle.WaitOne(TimeSpan.FromSeconds(10)))
		throw new Exception($"No flush occurred in 10 seconds: {listener}", listener.ObservedException);

	if (!listener.PublishSuccess)
		throw new Exception("NLog did not export correctly");
	if (listener.ObservedException != null)
		throw new Exception("NLog export received exception", listener.ObservedException);
	Console.WriteLine("NLog export success");
}
