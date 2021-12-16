# Elastic APM Serilog Enricher

This enricher adds the transaction id and trace id to every Serilog log message that is created during a transaction. 

## Packages

The .NET assemblies are published to NuGet under the package name [Elastic.Apm.SerilogEnricher](http://nuget.org/packages/Elastic.Apm.SerilogEnricher)

## How to Enable

```csharp
var logger = new LoggerConfiguration()
   .Enrich.WithElasticApmCorrelationInfo()
   .WriteTo.Console(outputTemplate: "[{ElasticApmTraceId} {ElasticApmTransactionId} {ElasticApmSpanId} {Message:lj} {NewLine}{Exception}")
   .CreateLogger();
```

In the code snippet above `Enrich.WithElasticApmCorrelationInfo()` enables the enricher from this project, 
which will set 3 properties for log lines that are created during a transaction:

- `ElasticApmTraceId`
- `ElasticApmTransactionId`
- `ElasticApmSpanId`

These two properties are printed to the Console using the `outputTemplate` parameter, of course they can 
be used with any sink, you could consider using a filesystem sink and 
[Elastic Filebeat](https://www.elastic.co/downloads/beats/filebeat) for durable and reliable ingestion. 
This enricher is also compatible with the 
[Elastic.CommonSchema.Serilog](https://www.nuget.org/packages/Elastic.CommonSchema.Serilog) package.

## Prerequisite

The prerequisite for this to work is a configured [Elastic APM Agent](https://github.com/elastic/apm-agent-dotnet). 
If the agent is not configured the enricher won't add anything to the logs.

## Copyright and License

This software is Copyright (c) 2014-2020 by Elasticsearch BV.

This is free software, licensed under: [The Apache License Version 2.0](https://github.com/elastic/ecs-dotnet/blob/main/license.txt).
