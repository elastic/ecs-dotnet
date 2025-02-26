---
mapped_pages:
  - https://www.elastic.co/guide/en/ecs-logging/dotnet/current/apm-nlog-enricher.html
---

# APM NLog layout [apm-nlog-enricher]

Allows you to add the following place holders in your NLog templates:

* `ElasticApmTraceId`
* `ElasticApmTransactionId`
* `ElasticApmSpanId`
* `ElasticApmServiceName`
* `ElasticApmServiceNodeName`
* `ElasticApmServiceVersion`

Which will be replaced with the appropriate Elastic APM variables if available

## Installation [_installation_10]

Add a reference to the [Elastic.Apm.NLog](http://nuget.org/packages/Elastic.Apm.NLog) package:

```xml
<PackageReference Include="Elastic.Apm.NLog" Version="8.6.0" />
```


## Usage [_usage_10]

### How to use from API [_how_to_use_from_api]

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


### How to use from NLog.config [_how_to_use_from_nlog_config]

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



## Prerequisite [_prerequisite_2]

The prerequisite for this to work is a configured [Elastic APM Agent](https://github.com/elastic/apm-agent-dotnet). If the agent is not configured the APM place holders will be empty.


