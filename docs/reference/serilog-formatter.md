---
applies_to:
  stack: ga
  serverless: ga
mapped_pages:
  - https://www.elastic.co/guide/en/ecs-logging/dotnet/current/serilog-formatter.html
---

# Serilog formatter [serilog-formatter]

This Serilog `ITextFormatter` implementation formats Serilog log events as JSON documents adhering to the Elastic Common Schema (ECS) specification.

## Installation [_installation_2]

Add a reference to the [Elastic.CommonSchema.Serilog](http://nuget.org/packages/Elastic.CommonSchema.Serilog) package:

```xml
<PackageReference Include="Elastic.CommonSchema.Serilog" Version="8.6.0" />
```


## Usage [_usage_2]

```csharp
var logger = new LoggerConfiguration()
    .WriteTo.Console(new EcsTextFormatter())
    .CreateLogger();
```

In the example above, `new EcsTextFormatter()` enables the ECS text formatter and instructs Serilog to format log events as JSON.

The example uses the Console sink, but you can use any sink of your choice. For durable and reliable log ingestion, consider using a file system sink together with [Elastic Filebeat](https://www.elastic.co/downloads/beats/filebeat) to ship the resulting log files.

### ASP.NET Core Applications

In ASP.NET Core applications, you can configure the formatter and enrich log events with HTTP context information as follows:

```csharp
.UseSerilog((ctx, config) =>
{
    // Ensure HttpContextAccessor is accessible
    var httpAccessor = ctx.Configuration.Get<HttpContextAccessor>();

    config
        .ReadFrom.Configuration(ctx.Configuration)
        .Enrich.WithEcsHttpContext(httpAccessor)
        .WriteTo.Async(a => a.Console(new EcsTextFormatter()));
})
```

The `WithEcsHttpContext` enricher adds information from the current `HttpContext` to log events, enriching them with relevant ECS fields.

The following is an example of the JSON output produced by the formatter:

```json
{
  "@timestamp": "2019-11-22T14:59:02.5903135+11:00",
  "log.level": "Information",
  "message": "Info \"X\" 2.2",
  "ecs.version": "9.0.0",
  "log": { "logger": "Elastic.CommonSchema.Serilog.Tests.MessageTests" },
  "labels": {
    "MessageTemplate": "Info {ValueX} {SomeY}",
    "ValueX": "X",
    "ThreadName": ".NET Long Running Task"
  },
  "agent": {
    "type": "Elastic.CommonSchema.Serilog",
    "version": "1.6.0"
  },
  "event": {
    "created": "2019-11-22T14:59:02.5903135+11:00",
    "severity": 2,
    "timezone": "Romance Standard Time"
  },
  "host": {
    "os": {
      "full": "Microsoft Windows 10.0.19045",
      "platform": "Win32NT",
      "version": "10.0.19045.0"
    },
    "architecture": "X64",
    "hostname": "LOCALHOST",
    "name": "LOCALHOST"
  },
  "process": {
    "name": "dotnet",
    "pid": 1440,
    "thread.id": 15,
    "thread.name": ".NET Long Running Task",
    "title": ""
  },
  "server": { "user": { "name": "MyDomain\\MyUserName" } },
  "service": {
    "name": "Elastic.CommonSchema",
    "type": "dotnet",
    "version": "1.6.0"
  },
  "user": {
    "domain": "MyDomain",
    "name": "MyUserName"
  },
  "metadata": {
    "SomeY": 2.2
  }
}
```

## Configuration [_configuration]

| Option                        | Description                                                                            |
|-------------------------------|----------------------------------------------------------------------------------------|
| `MapHttpAdapter` | Allows you to map an `HttpContextAccessor` to ECS fields. Defaults to `null`.                       |
| `LogEventsPropertiesToFilter` | A `Set<string>` containing property names that should be excluded from `labels.*` and `metadata.*` in the resulting JSON document. |
| `MapCustom` | A `Func` that allows you to modify the `EcsDocument` before it is serialized.                            |

## ECS aware message templates [_ecs_aware_message_templates_2]

This formatter also allows you to set ECS fields directly through message templates using properties that follow the [Message Templates](https://messagetemplates.org/) format.

The available ECS message template properties are listed under `LogTemplateProperties.*` e.g `LogTemplateProperties.TraceId`

```csharp
Log.Information("The time is {TraceId}", "my-trace-id");
```

This overrides `trace.id` in the resulting ECS JSON document.


