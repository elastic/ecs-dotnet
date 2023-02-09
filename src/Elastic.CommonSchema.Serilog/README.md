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

In ASP.NET (core) applications 

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

The `WithEcsHttpContext` ensures logs will be enriched with `HttpContext` data.

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

### Configuration

| Option                        | Description                                                                            |
|-------------------------------|----------------------------------------------------------------------------------------|
| `MapCurrentThead`             | `true` map `ecs.process` by looking up the `Process` from the current thread           |                                              |
| `MapHttpAdapter`              | `null` a way to map `HttpContextAccessor` to ECS fields.                               | 
| `LogEventsPropertiesToFilter` | A `Set<string>` of properties that should not be emitted as `labels.*` or `metadata.*` |
| `MapCustom`                   | A Func that allows you to mutate the EcsDocument before its fully converted.           |


### ECS Aware Message Templates

This formatter also allows you to set ECS fields directly from the message template using properties that adhere to the
https://messagetemplates.org/ format. 

The available ECS message template properties are listed under `LogTemplateProperties.*` e.g `LogTemplateProperties.TraceId`

```chsarp
Log.Information("The time is {TraceId}", "my-trace-id");
```

Will override `trace.id` on the resulting ECS json document. 

## Copyright and License

This software is Copyright (c) 2014-2020 by Elasticsearch BV.

This is free software, licensed under: [The Apache License Version 2.0](https://github.com/elastic/ecs-dotnet/blob/main/license.txt).
