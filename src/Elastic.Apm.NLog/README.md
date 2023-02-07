# Elastic APM NLog Layout Renderer

Allows you to add the following place holders in your NLog templates:

* `ElasticApmTraceId`
* `ElasticApmTransactionId`
* `ElasticApmSpanId`
* `ElasticApmServiceName`
* `ElasticApmServiceNodeName`
* `ElasticApmServiceVersion`

Which will be replaced with the appropriate Elastic APM variables if available

## Packages

The .NET assemblies are published to NuGet under the package name [Elastic.Apm.NLog](http://nuget.org/packages/Elastic.Apm.NLog)

## How to use from API

```csharp
// Logged message will be in format of `trace-id|transation-id|span-id|InTransaction`
// or `|||InTransaction` if the place holders are not available
var consoleTarget = new ConsoleTarget("console");
consoleTarget.Layout = 
    "${ElasticApmServiceName}|${ElasticApmTraceId}|${ElasticApmTransactionId}|${ElasticApmSpanId}|${message}";
config.AddRule(LogLevel.Debug, LogLevel.Fatal, consoleTarget);
LogManager.Configuration = config;
var logger = LogManager.GetCurrentClassLogger();
```

## How to use from NLog.config

```xml
<nlog>
  <extensions>
    <add assembly="Elastic.Apm.NLog"/>
  </extensions>
  <targets>
    <target name="console" 
        type="console" 
        layout="${ElasticApmTraceId}|${ElasticApmTransactionId}|${ElasticApmSpanId}|${message}" />
  </targets>
  <rules>
    <logger name="*" minLevel="Debug" writeTo="Console" />
  </rules>
</nlog>
```

## Prerequisite

The prerequisite for this to work is a configured [Elastic APM Agent](https://github.com/elastic/apm-agent-dotnet). If the agent is not configured the APM place holders will be empty.

## Copyright and License

This software is Copyright (c) 2014-2020 by Elasticsearch BV.

This is free software, licensed under: [The Apache License Version 2.0](https://github.com/elastic/ecs-dotnet/blob/main/license.txt).
