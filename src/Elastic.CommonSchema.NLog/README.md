# Elastic Common Schema NLog Layout

This Layout implementation formats an NLog event into a JSON representation that adheres to the Elastic Common Schema specification.

## Packages

The .NET assemblies are published to NuGet under the package name [Elastic.CommonSchema.NLog](http://nuget.org/packages/Elastic.CommonSchema.NLog)

## How to Enable

```csharp
Layout.Register<EcsLayout>("EcsLayout"); // Register the ECS layout.
var config = new Config.LoggingConfiguration();
var memoryTarget = new EventInfoMemoryTarget { Layout = Layout.FromString("EcsLayout") }; // Use the layout.
config.AddRule(LogLevel.Debug, LogLevel.Fatal, memoryTarget);
var factory = new LogFactory(config);
var logger = factory.GetCurrentClassLogger();
```

In the code snippet above `Layout.Register<EcsLayout>("EcsLayout")` registers the `EcsLayout` with NLog.
The `Layout = Layout.FromString("EcsLayout")` line then instructs NLog to use the registered layout.
The sample above uses the memory target, but you are free to use any target of your choice, perhaps consider using a
filesystem target and [Elastic Filebeat](https://www.elastic.co/downloads/beats/filebeat) for durable and reliable ingestion.

An example of the output is given below:

```json
{
   "@timestamp":"2020-02-20T16:07:06.7109766+11:00",
   "log.level":"Info",
   "message":"Info \"X\" 2.2",
   "_metadata":{
      "value_x":"X",
      "some_y":2.2
   },
   "ecs":{
      "version":"1.4.0"
   },
   "event":{
      "severity":6,
      "timezone":"AUS Eastern Standard Time",
      "created":"2020-02-20T16:07:06.7109766+11:00"
   },
   "host":{
      "name":"LAPTOP"
   },
   "log":{
      "logger":"Elastic.CommonSchema.NLog",
      "original":"Info {ValueX} {SomeY}"
   },
   "process":{
      "thread":{
         "id":17592
      },
      "pid":17592,
      "name":"dotnet",
      "executable":"C:\\Program Files\\dotnet\\dotnet.exe"
   }
}
```

## Copyright and License

This software is Copyright (c) 2014-2020 by Elasticsearch BV.

This is free software, licensed under: [The Apache License Version 2.0](https://github.com/elastic/ecs-dotnet/blob/master/license.txt).
