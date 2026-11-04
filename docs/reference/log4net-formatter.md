---
applies_to:
  stack: ga
  serverless: ga
mapped_pages:
  - https://www.elastic.co/guide/en/ecs-logging/dotnet/current/log4net-formatter.html
---

# log4net [log4net-formatter]

This log4net Layout implementation formats log4net events as JSON documents adhering to the Elastic Common Schema (ECS) specification.

## Installation [_installation_4]

Add a reference to the [Elastic.CommonSchema.Log4net](http://nuget.org/packages/Elastic.CommonSchema.Log4net) package:

```xml
<PackageReference Include="Elastic.CommonSchema.Log4net" Version="8.6.0" />
```


## Usage [_usage_4]

### Setup using configuration [_setup_using_configuration]

Specify the layout type in the appender configuration:

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


### Setup programatically [_setup_programatically_2]

```csharp
var hierarchy = (Hierarchy)LogManager.CreateRepository(Guid.NewGuid().ToString());
var appender = new ConsoleAppender { Layout = new EcsLayout() }; // Use the ECS layout.
hierarchy.Root.AddAppender(appender);
hierarchy.Root.Level = Level.All;
hierarchy.Configured = true;
```

Setting `Layout = new EcsLayout()` instructs log4net to use the ECS layout.

The example above uses the console appender, but you can use any appender of your choice.

For durable and reliable log ingestion, consider using a file appender together with [Elastic Filebeat](https://www.elastic.co/downloads/beats/filebeat) to ship the resulting log files.

## ECS Aware Properties [_ecs_aware_properties]

The layout supports valid ECS message template properties listed under `LogTemplateProperties.*`, such as `LogTemplateProperties.TraceId`.

These properties allow you to set ECS fields directly through log messages.

## Output [_output]

In addition to the [mandatory ECS fields](https://www.elastic.co/guide/en/ecs/current/ecs-guidelines.html#_general_guidelines), the output contains the following information:

* `labels` - Populated from `metadata` (string and boolean properties).
* `log.origin.file.name` - Populated from `LocationInformation`.
* `log.origin.file.line` - Populated from `LocationInformation`.
* `log.origin.function` - Populated from `LocationInformation`.
* `event.created` - Populated from the log event timestamp.
* `event.timezone` - Set to the local time zone.
* `host.hostname` - Populated from the `HostName` property.
* `process.thread.id` - Populated from `ThreadName` if its value is numeric.
* `process.thread.name` - Populated from `ThreadName` if its value is non-numeric.
* `service.name` - Populated from the entry assembly or calling assembly.
* `service.version` - Populated from the entry assembly or calling assembly.
* `error.message` - Populated from `ExceptionObject`.
* `error.type` - Populated from `ExceptionObject`.
* `error.stacktrace` - Populated from `ExceptionObject`.
* `metadata` - Populated from log event properties. It also contains the message template and its arguments when a formatted message is logged.

The following is an example of a log event formatted as JSON (formatted for readability):

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
        "MessageTemplate": "{0}! Welcome to example!",
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

