<img align="right" width="auto" height="auto" src="https://www.elastic.co/static-res/images/elastic-logo-200.png">

# Elastic Common Schema .NET

[![Build Status](https://apm-ci.elastic.co/buildStatus/icon?job=apm-agent-dotnet%2Fecs-dotnet-mbp%2Fmain)](https://apm-ci.elastic.co/job/apm-agent-dotnet/job/ecs-dotnet-mbp/job/main/)

This repository contains .NET integrations that use the Elastic Common Schema (ECS), including popular .NET logging frameworks. Read the [announcement post](https://www.elastic.co/blog/elastic-common-schema-dotnet-library-and-integrations-released-for-elasticsearch).

The Elastic Common Schema defines a common set of fields for ingesting data into Elasticsearch. A common schema helps you correlate data from sources like logs and metrics or IT operations analytics and security analytics. Further information on ECS can be found in the official [Elastic documentation](https://www.elastic.co/guide/en/ecs/current/index.html) or [github repository](https://github.com/elastic/ecs).

Contributions are welcome, please read our [guidelines](https://github.com/elastic/ecs-dotnet/tree/main/contributing.md).

---

### Versioning

Version components: `{major}.{minor}.{patch}`

These libraries are not versioned according to [SemVer](https://semver.org/) principles. Backwards compatibility is only guaranteed within *minor* versions, since ECS only makes this guarantee. Patch releases of this library will not seek to introduce breaking changes, but will be used to address bug fixes within that minor version.

Each assembly release indicates the ECS version that it is compatible with (see _releases_), but typically the minor version number of the assembly correlates to the compatible version of ECS; for example; all of `1.4.0`, `1.4.1`, `1.4.2` and `1.4.3` are compatible with ECS version `1.4.0`.

The assemblies are versioned using an assembly identity of `major.minor.*` as opposed to `major.*` as is common when following SemVer.

---

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

### [Elastic.CommonSchema](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.CommonSchema)

Foundational project that contains a full C# representation of ECS. [Learn more...](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.CommonSchema)

## Logging

### [Elasticsearch.Extensions.Logging](src/Elasticsearch.Extensions.Logging/ReadMe.md)

Elastic Stack (ELK) logger provider for `Microsoft.Extensions.Logging`.

Writes direct to Elasticsearch using the Elastic Common Schema, with semantic logging of structured data from message and scope values.

This logger provider can be added directly to Microsoft.Extensions.Logging:

```csharp
using Elasticsearch.Extensions.Logging;

// ...

    .ConfigureLogging((hostContext, loggingBuilder) =>
    {
        loggingBuilder.AddElasticsearch();
    })
```

### [Elastic.CommonSchema.Serilog](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.CommonSchema.Serilog)

Formats a Serilog event into a JSON representation that adheres to the Elastic Common Schema. [Learn more...](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.CommonSchema.Serilog)

```csharp
var logger = new LoggerConfiguration()
    .WriteTo.Console(new EcsTextFormatter())
    .CreateLogger();
```

### [Elastic.CommonSchema.NLog](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.CommonSchema.NLog)

Formats an NLog event into a JSON representation that adheres to the Elastic Common Schema. [Learn more...](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.CommonSchema.NLog)

```csharp
Layout.Register<EcsLayout>("EcsLayout"); // Register the ECS layout.
var config = new LoggingConfiguration();
var consoleTarget = new ConsoleTarget("console") { Layout = new EcsLayout() };  // Use the ECS layout.
config.AddRule(LogLevel.Debug, LogLevel.Fatal, consoleTarget);
LogManager.Configuration = config;
var logger = LogManager.GetCurrentClassLogger();
```

## APM

### [Elastic.Apm.SerilogEnricher](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.Apm.SerilogEnricher)

Adds transaction id and trace id to every Serilog log message that is created during a transaction. [Learn more...](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.Apm.SerilogEnricher)

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

### [Elastic.Apm.NLog](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.Apm.NLog)

Introduce two special place holder variables (`ElasticApmTraceId`, `ElasticApmTransactionId`) easily into your NLog templates.
[Learn more...](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.Apm.NLog)

```csharp
// Logged message will be in format of `trace-id|transation-id|InTransaction`
// or `||InTransaction` if the place holders are not available
var consoleTarget = new ConsoleTarget("console");
consoleTarget.Layout = "${ElasticApmTraceId}|${ElasticApmTransactionId}|${message}";
config.AddRule(LogLevel.Debug, LogLevel.Fatal, consoleTarget);
LogManager.Configuration = config;
var logger = LogManager.GetCurrentClassLogger();
```

When using EcsLayout from `Elastic.CommonSchema.NLog` then trace and transaction id will automatically appear in ECS.

## Benchmarking

### [Elastic.CommonSchema.BenchmarkDotNetExporter](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.CommonSchema.BenchmarkDotNetExporter)

An exporter for [BenchmarkDotnet](https://github.com/dotnet/BenchmarkDotNet) that can index benchmarking result output directly into Elasticsearch. [Learn more...](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.CommonSchema.BenchmarkDotNetExporter)

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

## Copyright and License

This software is Copyright (c) 2014-2020 by Elasticsearch BV.

This is free software, licensed under: [The Apache License Version 2.0](https://github.com/elastic/ecs-dotnet/blob/main/license.txt).
