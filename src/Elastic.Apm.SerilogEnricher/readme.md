# Elastic APM Serilog Enricher

This enricher adds the transaction id and trace id to every Serilog log message that is created during a transaction. 

## How to Enable

```csharp
var logger = new LoggerConfiguration()
   .Enrich.WithElasticApmCorrelationInfo()
   .WriteTo.Console(outputTemplate: "[{ElasticApmTraceId} {ElasticApmTransactionId} {Message:lj} {NewLine}{Exception}")
   .CreateLogger();
```

In the code snippet above `Enrich.WithElasticApmCorrelationInfo()` enables the enricher from this project, which will set 2 properties for log lines that are created during a transaction:

- `ElasticApmTransactionId`
- `ElasticApmTraceId`

In the `outputTemplate` of the Console sink these two properties are printed, of course they can be used with any sink.

## Prerequisite

The prerequisite for this to work is a configured [Elastic APM Agent](https://github.com/elastic/apm-agent-dotnet). If the agent is not configured the enricher won't add anything to the logs.

## Copyright and License

This software is Copyright (c) 2014-2020 by Elasticsearch BV.

This is free software, licensed under: [The Apache License Version 2.0](https://github.com/elastic/ecs-dotnet/blob/master/license.txt).
