<img align="right" width="auto" height="auto" src="https://www.elastic.co/static-res/images/elastic-logo-200.png">

# Elastic Common Schema .NET

[![Build Status](https://apm-ci.elastic.co/buildStatus/icon?job=apm-agent-dotnet%2Fecs-dotnet-mbp%2Fmaster)](https://apm-ci.elastic.co/job/apm-agent-dotnet/job/ecs-dotnet-mbp/job/master/)

This repository contains .NET integrations that use the Elastic Common Schema (ECS), including popular .NET logging frameworks. Read the [announcement post](https://www.elastic.co/blog/elastic-common-schema-dotnet-library-and-integrations-released-for-elasticsearch).

The Elastic Common Schema defines a common set of fields for ingesting data into Elasticsearch. A common schema helps you correlate data from sources like logs and metrics or IT operations analytics and security analytics. Further information on ECS can be found in the official [Elastic documentation](https://www.elastic.co/guide/en/ecs/current/index.html) or [github repository](https://github.com/elastic/ecs).

Contributions are welcome, please read our [guidelines](https://github.com/elastic/ecs-dotnet/tree/master/contributing.md).

# Integrations

Official NuGet packages can be referenced from [NuGet.org](https://www.nuget.org).

| Package Name            | Purpose          | Download         |
| ----------------------- | ---------------- | -----------------|
| `Elastic.CommonSchema`  |  Foundational project that contains a full C# representation of ECS, used by the other integrations listed. | [![NuGet Release][ElasticCommonSchema-image]][ElasticCommonSchema-nuget-url]  |
| `Elastic.CommonSchema.Serilog`  |  Formats a Serilog log message into a JSON representation that can be indexed into Elasticsearch. | [![NuGet Release][ElasticCommonSchemaSerilog-image]][ElasticCommonSchemaSerilog-nuget-url]  |
| `Elastic.CommonSchema.NLog`  |  Formats an NLog message into a JSON representation that can be indexed into Elasticsearch. | [![NuGet Release][ElasticCommonSchemaNLog-image]][ElasticCommonSchemaNLog-nuget-url]  |
| `Elastic.Apm.SerilogEnricher`   |  Adds transaction id and trace id to every Serilog log message that is created during a transaction. This works in conjunction with the Elastic.CommonSchema.Serilog package and forms a solution to distributed tracing with Serilog. | [![NuGet Release][ElasticApmSerilogEnricher-image]][ElasticApmSerilogEnricher-nuget-url]  |
| `Elastic.Apm.NLog`              |  Introduces two special placeholder variables (ElasticApmTraceId and ElasticApmTransactionId) for use within your NLog templates. | [![NuGet Release][ElasticApmNLog-image]][ElasticApmNLog-nuget-url]  |
| `Elastic.CommonSchema.BenchmarkDotNetExporter`  |  An exporter for BenchmarkDotnet that can index benchmarking results directly into Elasticsearch, which can be helpful for detecting code-related performance problems over time. | [![NuGet Release][ElasticBenchmarkDotNetExporter-image]][ElasticBenchmarkDotNetExporter-nuget-url]  |

[ElasticCommonSchema-nuget-url]:https://www.nuget.org/packages/Elastic.CommonSchema/
[ElasticCommonSchema-image]:https://img.shields.io/nuget/v/Elastic.CommonSchema.svg

[ElasticCommonSchemaSerilog-nuget-url]:https://www.nuget.org/packages/Elastic.CommonSchema.Serilog/
[ElasticCommonSchemaSerilog-image]:https://img.shields.io/nuget/v/Elastic.CommonSchema.Serilog.svg

[ElasticCommonSchemaNLog-nuget-url]:https://www.nuget.org/packages/Elastic.CommonSchema.NLog/
[ElasticCommonSchemaNLog-image]:https://img.shields.io/nuget/v/Elastic.CommonSchema.NLog.svg

[ElasticApmSerilogEnricher-nuget-url]:https://www.nuget.org/packages/Elastic.Apm.SerilogEnricher/
[ElasticApmSerilogEnricher-image]:https://img.shields.io/nuget/v/Elastic.Apm.SerilogEnricher.svg

[ElasticApmNLog-nuget-url]:https://www.nuget.org/packages/Elastic.Apm.NLog/
[ElasticApmNLog-image]:https://img.shields.io/nuget/v/Elastic.Apm.NLog.svg

[ElasticBenchmarkDotNetExporter-nuget-url]:https://www.nuget.org/packages/Elastic.CommonSchema.BenchmarkDotNetExporter/
[ElasticBenchmarkDotNetExporter-image]:https://img.shields.io/nuget/v/Elastic.CommonSchema.BenchmarkDotNetExporter.svg

## Foundation Library

### [Elastic.CommonSchema](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.CommonSchema)

Foundational project that contains a full C# representation of ECS. [Learn more...](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.CommonSchema)

## Logging

### [Elastic.CommonSchema.Serilog](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.CommonSchema.Serilog)

Formats a Serilog event into a JSON representation that adheres to the Elastic Common Schema. [Learn more...](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.CommonSchema.Serilog)

```csharp
var logger = new LoggerConfiguration()
    .WriteTo.Console(new EcsTextFormatter())
    .CreateLogger();
```

### [Elastic.CommonSchema.NLog](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.CommonSchema.NLog)

Formats an NLog event into a JSON representation that adheres to the Elastic Common Schema. [Learn more...](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.CommonSchema.NLog)

```csharp
Layout.Register<EcsLayout>("EcsLayout"); // Register the ECS layout.
var config = new Config.LoggingConfiguration();
var memoryTarget = new EventInfoMemoryTarget { Layout = Layout.FromString("EcsLayout") }; // Use the layout.
config.AddRule(LogLevel.Debug, LogLevel.Fatal, memoryTarget);
var factory = new LogFactory(config);
var logger = factory.GetCurrentClassLogger();
```

## APM

### [Elastic.Apm.SerilogEnricher](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.Apm.SerilogEnricher)

Adds transaction id and trace id to every Serilog log message that is created during a transaction. [Learn more...](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.Apm.SerilogEnricher)

```csharp
var logger = new LoggerConfiguration()
    .Enrich.WithElasticApmCorrelationInfo()
    .WriteTo.Console(outputTemplate: "[{ElasticApmTraceId} {ElasticApmTransactionId} {Message:lj} {NewLine}{Exception}")
    .CreateLogger();
```

When combined with `Elastic.CommonSchema.Serilog` the trace and transaction id will automatically appear in ECS as well.

```csharp
var logger = new LoggerConfiguration()
    .Enrich.WithElasticApmCorrelationInfo()
    .WriteTo.Console(new EcsTextFormatter()) // APM information persisted in ECS as well
    .CreateLogger();
```

### [Elastic.Apm.NLog](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.Apm.NLog)

Introduce two special place holder variables (`ElasticApmTraceId`, `ElasticApmTransactionId`) easily into your NLog templates.
[Learn more...](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.Apm.NLog)

```csharp
var target = new MemoryTarget();
target.Layout = "${ElasticApmTraceId}|${ElasticApmTransactionId}|${message}";
Agent.Tracer.CaptureTransaction("TestTransaction", "Test", t =>
{
	traceId = "trace-id";
	transactionId = "transaction-id";
	logger.Debug("InTransaction");
});
// Logged message will be in format of `trace-id|transation-id|InTransaction`
// or `||InTransaction` if the place holders are not available
```

## Benchmarking

### [Elastic.CommonSchema.BenchmarkDotNetExporter](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.CommonSchema.BenchmarkDotNetExporter)

An exporter for [BenchmarkDotnet](https://github.com/dotnet/BenchmarkDotNet) that can index benchmarking result output directly into Elasticsearch. [Learn more...](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.CommonSchema.BenchmarkDotNetExporter)

```csharp
var options = new ElasticsearchBenchmarkExporterOptions(url)
{
	GitBranch = "externally-provided-branch",
	GitCommitMessage = "externally provided git commit message",
	GitRepositoryIdentifier = "repository"
};
var exporter = new ElasticsearchBenchmarkExporter(options);

var config = CreateDefaultConfig().With(exporter);
BenchmarkRunner.Run(typeof(Md5VsSha256), config);
```

# Examples

- [Elastic.CommonSchema.Serilog and ASP.NET Core](/examples/aspnetcore-with-serilog/)
- [Console application using stand alone ElasticsearchLoggerProvider](/examples/console-with-loggerprovider/)

## Copyright and License

This software is Copyright (c) 2014-2020 by Elasticsearch BV.

This is free software, licensed under: [The Apache License Version 2.0](https://github.com/elastic/ecs-dotnet/blob/master/license.txt).
