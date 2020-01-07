# Elastic Common Schema .NET

This repository contains .NET integrations that use the Elastic Common Schema (ECS), including popular .NET logging frameworks.

The Elastic Common Schema defines a common set of fields for ingesting data into Elasticsearch. A common schema helps you correlate data from sources like logs and metrics or IT operations analytics and security analytics. Further information on ECS can be found in the official [github repository](https://github.com/elastic/ecs) or [Elastic documentation](https://www.elastic.co/guide/en/ecs/current/index.html).

Contributions are welcome, please read our [guidelines](https://github.com/elastic/ecs-dotnet/tree/master/contributing.md).

## Integrations

### [Elastic.CommonSchema](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.CommonSchema)

Foundational project that contains a full C# representation of the ECS schema. [Learn more...](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.CommonSchema)

## Logging

### [Elastic.CommonSchema.Serilog](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.CommonSchema.Serilog)

Formats a Serilog event into a JSON representation that adheres to the Elastic Common Schema specification. [Learn more...](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.CommonSchema.Serilog)

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

When combined with `Elastic.CommonSchema.Serilog` the trace and transaction id will automatically appear in ECS format as well.

```csharp
var logger = new LoggerConfiguration()
    .Enrich.WithElasticApmCorrelationInfo()
    // will have APM information persisted in ECS format
    .WriteTo.Console(new EcsTextFormatter())
    .CreateLogger();
```

### [Elastic.Apm.NLog](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.Apm.NLog)

Introduce two special place holder variables (`ElasticApmTraceId`, `ElasticApmTransactionId`) easily into your NLog templates.
[Learn more...](https://github.com/elastic/ecs-dotnet/tree/master/src/Elastic.Apm.NLog)

## Copyright and License

This software is Copyright (c) 2014-2020 by Elasticsearch BV.

This is free software, licensed under: [The Apache License Version 2.0](https://github.com/elastic/ecs-dotnet/blob/master/license.txt).