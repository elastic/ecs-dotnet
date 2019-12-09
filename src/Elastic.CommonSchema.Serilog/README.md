# Elastic Serilog Text Formatter

This `ITextFormatter` implementation formats a Serilog event into a JSON representation that adheres to the Elastic Common Schema specification.

## How to enable it

```
var logger = new LoggerConfiguration()
                .WriteTo.Console(new EcsTextFormatter())
                .CreateLogger();
```

In the code snippet above `new EcsTextFormatter()` enables the text formatter and instructs Serilog to format the event as JSON. The sample above uses the Console sink, but you are free to use any.

An example of the output is given below:

```
{
  "@timestamp": "2019-11-22T14:59:02.5903135+11:00",
  "message": "Log message",
  "log.level": "Information",
  "ecs": {
    "version": "1.3.0"
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