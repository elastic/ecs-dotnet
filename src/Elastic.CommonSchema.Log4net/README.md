# Elastic Common Schema log4net Layout

This Layout implementation formats a log4net event into a JSON representation that adheres to the Elastic Common Schema specification.

## Packages

The .NET assemblies are published to NuGet under the package name [Elastic.CommonSchema.Log4net](http://nuget.org/packages/Elastic.CommonSchema.Log4net)

## How to use from configuration

Specify layout type in appender's configuration:

```xml
<log4net>
    <root>
        <level value="INFO" />
        <appender-ref ref="ConsoleAppender" />
    </root>
    <appender name="ConsoleAppender" type="log4net.Appender.ConsoleAppender">
        <layout type="Elastic.CommonSchema.Log4net.EcsLayout, Elastic.CommonSchema.Log4net" />
    </appender>
</log4net>
```

## How to use from API

```csharp
var hierarchy = (Hierarchy)LogManager.CreateRepository(Guid.NewGuid().ToString());
var appender = new ConsoleAppender { Layout = new EcsLayout() }; // Use the ECS layout.
hierarchy.Root.AddAppender(appender);
hierarchy.Root.Level = Level.All;
hierarchy.Configured = true;
```

The `Layout = new EcsLayout()` line then instructs log4net to use ECS layout.
The sample above uses the console appender, but you are free to use any appender of your choice, perhaps consider using a
filesystem target and [Elastic Filebeat](https://www.elastic.co/downloads/beats/filebeat) for durable and reliable ingestion.

### ECS Aware Properties

Any valid ECS log template properties that is available under `LogTemplateProperties.*` e.g `LogTemplateProperties.TraceId`
is supported and will directly set the appropriate ECS field.

## Output

Apart from [mandatory fields](https://www.elastic.co/guide/en/ecs/current/ecs-guidelines.html#_general_guidelines), the output contains additional data:

- `labels` is taken from `metadata` (string and boolean properties)
- `log.origin.file.name` is taken from `LocationInformation`
- `log.origin.file.line` is taken from `LocationInformation`
- `log.origin.function` is taken from `LocationInformation`
- `event.created` is taken from timestamp
- `event.timezone` is equal to local timezone
- `host.hostname` is taken from `HostName` property
- `process.thread.id` is taken from `ThreadName` if it has numeric value
- `process.thread.name` is taken from `ThreadName` if it doesn't have numeric value
- `service.name` is taken from entry or calling assembly
- `service.version` is taken from entry or calling assembly
- `error.message` is taken from `ExceptionObject`
- `error.type` is taken from `ExceptionObject`
- `error.stacktrace` is taken from `ExceptionObject`
- `metadata` is taken from properties. It also contains message template and arguments in case a formatted message was logged

Sample log event output (formatted for readability):

```json
{
    "@timestamp": "2022-08-28T14:06:28.5121651+02:00",
    "log.level": "INFO",
    "message": "Hi! Welcome to example!",
    "ecs.version": "9.0.0",
    "log": {
        "logger": "Elastic.CommonSchema.Log4net.Example.Program",
        "original": null,
        "origin": {
            "file": {
                "name": "C:\\Development\\Elastic.CommonSchema.Log4net.Example\\Program.cs",
                "line": 17
            },
            "function": "Main"
        }
    },
    "labels": {
        "MessageTemplate": "{0}! Welcome to example!"
        "0": "Hi"
    },
    "agent": {
        "type": "Elastic.CommonSchema.Log4net.Example",
        "version": "1.0.0.0"
    },
    "event": {
        "created": "2024-04-02T17:43:55.3829964+02:00",
        "timezone": "W. Europe Standard Time"
    },
    "host": {
        "os": {
            "full": "Microsoft Windows 10.0.22631",
            "platform": "Win32NT",
            "version": "10.0.22631.0"
        },
        "architecture": "X64",
        "hostname": "HGU780D3",
        "name": "HGU780D3"
    },
    "process": {
        "name": "Elastic.CommonSchema.Log4net.Example",
        "pid": 39652,
        "thread.id": 17,
        "thread.name": ".NET Long Running Task",
        "title": ""
    },
    "service": {
        "name": "Elastic.CommonSchema.Log4net.Example",
        "type": "dotnet",
        "version": "1.0.0.0"
    },
    "user": {
        "domain": "company",
        "name": "user"
    },
    "metadata": {
        "GlobalAmountProperty": 3.14
    }
}
```

## Copyright and License

This software is Copyright (c) 2014-2020 by Elasticsearch BV.

This is free software, licensed under: [The Apache License Version 2.0](https://github.com/elastic/ecs-dotnet/blob/main/license.txt).
