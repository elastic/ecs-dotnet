# Elastic Common Schema .NET

This repository contains .NET integrations that use the Elastic Common Schema (ECS), including popular .NET logging frameworks.

The Elastic Common Schema defines a common set of fields for ingesting data into Elasticsearch. A common schema helps you correlate data from sources like logs and metrics or IT operations analytics and security analytics. Further information on ECS can be found in the official [Elastic documentation](https://www.elastic.co/guide/en/ecs/current/index.html) or [github repository](https://github.com/elastic/ecs).

Contributions are welcome, please read our [guidelines](https://github.com/elastic/ecs-dotnet/tree/master/contributing.md).

## Integrations

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

## Copyright and License

This software is Copyright (c) 2014-2020 by Elasticsearch BV.

This is free software, licensed under: [The Apache License Version 2.0](https://github.com/elastic/ecs-dotnet/blob/master/license.txt).