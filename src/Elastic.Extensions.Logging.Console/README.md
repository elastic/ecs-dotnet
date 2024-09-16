# Elastic.Extensions.Logging.Console

This package includes formatters and extension methods for `Microsoft.Extensions.Logging.Console` to make it easy to write ECS formatted logs to consoleoutput.

May be used with `Elastic.Extensions.Logging` to write ECS documents directly to Elasticsearch / Elastic Cloud. 


## Usage

The console logging provider and formatter can be setup using a simple extension method.

```csharp
.ConfigureLogging((_, loggingBuilder) => loggingBuilder.AddEcsConsole())
```

Or indirectly using the types provided in this package:

```csharp
.ConfigureLogging((_, loggingBuilder) =>
{
	loggingBuilder.AddConsole(c=> c.FormatterName = "ecs");
	loggingBuilder.AddConsoleFormatter<EcsConsoleFormatter, EcsConsoleFormatterOptions>();
})
```