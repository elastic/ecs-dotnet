# Elastic APM Serilog Enricher


This enricher adds transaction id and trace id to every serilog log message that is created during a transaction. 


## How to enable it

```
var logger = new LoggerConfiguration()
   .Enrich.WithElasticApmCorrelationInfo()
   .WriteTo.Console(outputTemplate: "[{TraceId} {TransactionId} {Message:lj} {NewLine}{Exception}")
   .CreateLogger();
```

In the code snippet above `Enrich.WithElasticApmCorrelationInfo()` enables the enricher from this project, which will set 2 properties for log lines that are created during a transaction:
- `TransactionId`
- `TraceId`

As you can see, in the `outputTemplate` of the Console sink these two properties are printed. Of course they can be used with any other sink.

## Prerequisite

The prerequisite for this to work is a configured [Elastic APM Agent](https://github.com/elastic/apm-agent-dotnet). If the agent is not configured the enricher won't add anything to the logs.