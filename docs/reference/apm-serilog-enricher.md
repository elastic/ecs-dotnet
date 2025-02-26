---
mapped_pages:
  - https://www.elastic.co/guide/en/ecs-logging/dotnet/current/apm-serilog-enricher.html
---

# APM serilog enricher [apm-serilog-enricher]

This enricher adds the transaction id and trace id to every Serilog log message that is created during a transaction.

## Installation [_installation_9]

Add a reference to the [Elastic.Apm.SerilogEnricher](http://nuget.org/packages/Elastic.Apm.SerilogEnricher) package:

```xml
<PackageReference Include="Elastic.Apm.SerilogEnricher" Version="8.6.0" />
```


## Usage [_usage_9]

```csharp
var logger = new LoggerConfiguration()
   .Enrich.WithElasticApmCorrelationInfo()
   .WriteTo.Console(outputTemplate: "[{ElasticApmTraceId} {ElasticApmTransactionId} {ElasticApmSpanId} {Message:lj} {NewLine}{Exception}")
   .CreateLogger();
```


## Properties [_properties]

In the code snippet above `Enrich.WithElasticApmCorrelationInfo()` enables the enricher from this project, which will set 3 properties for log lines that are created during a transaction:

* `ElasticApmTraceId`
* `ElasticApmTransactionId`
* `ElasticApmSpanId`

These two properties are printed to the Console using the `outputTemplate` parameter, of course they can be used with any sink, you could consider using a filesystem sink and [Elastic Filebeat](https://www.elastic.co/downloads/beats/filebeat) for durable and reliable ingestion. This enricher is also compatible with the [Elastic.CommonSchema.Serilog](https://www.nuget.org/packages/Elastic.CommonSchema.Serilog) package.


## Prerequisite [_prerequisite]

The prerequisite for this to work is a configured [Elastic APM Agent](https://github.com/elastic/apm-agent-dotnet). If the agent is not configured the enricher won’t add anything to the logs.


