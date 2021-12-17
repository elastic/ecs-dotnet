# Elastic Common Schema Serilog Text Formatter

This `ITextFormatter` implementation formats a Serilog event into a JSON representation that adheres to the Elastic Common Schema specification.

## Packages

The .NET assemblies are published to NuGet under the package name [Elastic.CommonSchema.Serilog](http://nuget.org/packages/Elastic.CommonSchema.Serilog)

## How to Enable

```csharp
var logger = new LoggerConfiguration()
                .WriteTo.Console(new EcsTextFormatter())
                .CreateLogger();
```

In the code snippet above `new EcsTextFormatter()` enables the text formatter and instructs Serilog to format the event as JSON. The sample above uses the Console sink, but you are free to use any sink of your choice, perhaps consider using a filesystem sink and [Elastic Filebeat](https://www.elastic.co/downloads/beats/filebeat) for durable and reliable ingestion.

An example of the output is given below:

```json
{
  "@timestamp": "2019-11-22T14:59:02.5903135+11:00",
  "log.level": "Information",
  "message": "Log message",
  "ecs": {
    "version": "1.4.0"
  },
  "event": {
    "severity": 0,
    "timezone": "AUS Eastern Standard Time",
    "created": "2019-11-22T14:59:02.5903135+11:00"
  },
  "log": {
    "logger": "Elastic.CommonSchema.Serilog"
  },
  "process": {
    "thread": {
      "id": 1
    },
    "executable": "System.Threading.ExecutionContext"
  }
}
```

## Copyright and License

This software is Copyright (c) 2014-2020 by Elasticsearch BV.

This is free software, licensed under: [The Apache License Version 2.0](https://github.com/elastic/ecs-dotnet/blob/main/license.txt).
