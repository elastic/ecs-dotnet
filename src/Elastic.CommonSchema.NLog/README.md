# Elastic Common Schema NLog Layout

This Layout implementation formats an NLog event into a JSON representation that adheres to the Elastic Common Schema specification.

## Packages

The .NET assemblies are published to NuGet under the package name [Elastic.CommonSchema.NLog](http://nuget.org/packages/Elastic.CommonSchema.NLog)

## How to use from API

```csharp
var config = new LoggingConfiguration();
var consoleTarget = new ConsoleTarget("console") { Layout = new EcsLayout() };  // Use the ECS layout.
config.AddRule(LogLevel.Debug, LogLevel.Fatal, consoleTarget);
LogManager.Configuration = config;
var logger = LogManager.GetCurrentClassLogger();
```

The sample above uses `EcsLayout`  with the NLog console target, but you are free to use any target of your choice, perhaps consider
the NLog FileTarget and [Elastic Filebeat](https://www.elastic.co/downloads/beats/filebeat) for durable and reliable ingestion.

## How to use from NLog.config

```xml
<nlog>
  <extensions>
    <add assembly="Elastic.CommonSchema.NLog"/>
  </extensions>
  <targets>
    <target name="console" xsi:type="console">
      <layout xsi:type="EcsLayout">
        <metadata name="MyProperty" layout="MyPropertyValue" /> <!-- repeated, optional -->
        <label name="MyLabel" layout="MyLabelValue" />          <!-- repeated, optional -->
        <tag layout="MyTagValue" />                             <!-- repeated, optional -->
      </layout>
    </target>
  </targets>
  <rules>
    <logger name="*" minLevel="Debug" writeTo="Console" />
  </rules>
</nlog>
```

## EcsLayout Parameter Options

* **Metadata Options**
  - _IncludeEventProperties_ - Include LogEvent properties as metadata. Default: `true`
  - _IncludeScopeProperties_ - Include NLog Scope Context Properties as metadata. Default: `false`
  - _ExcludeProperties_ - Comma separated string with names which properties to exclude.

* **Event Options**
  - _EventAction_ - 
  -	_EventCategory_ - 
  -	_EventId_ - 
  -	_EventKind_ - 
  -	_EventSeverity_ - 

* **Agent Options**
  - _AgentId_ - 
  - _AgentName_ - 
  - _AgentType_ - 
  - _AgentVersion_ - 

* **Process Options**
  - _ProcessExecutable_ - Default: `${processname:FullName=true}`
  - _ProcessId_ - Default: `${processid}`
  - _ProcessName_ - Default: `${processname:FullName=false}`
  - _ProcessTitle_ - Default: `${processinfo:MainWindowTitle}`
  - _ProcessThreadId_ - Default: `${threadid}`
  - _ProcessThreadName_ -

* **Server Options**
  -	_ServerAddress_ -
  -	_ServerIp_ -
  -	_ServerUser_ - Default: `${environment-user}`

* **Host Options**
  -	_HostId_ -
  -	_HostIp_ - 
  -	_HostName_ - Default: `${machinename}`

* **Log Origin Options**
  - _LogOriginCallSiteMethod_ - Default: `${exception:format=method}`
  - _LogOriginCallSiteFile_ - Default: `${exception:format=source}`
  - _LogOriginCallSiteLine_ -

* **Http Options**
  - _HttpRequestId_ - Default: `${aspnet-trace-identifier}`
  - _HttpRequestMethod_ - Default: `${aspnet-request-method}`
  - _HttpRequestBytes_ - Default: `${aspnet-request-contentlength}`
  - _HttpRequestReferrer_ - Default: `${aspnet-request-referrer}`
  - _HttpResponseStatusCode_ - Default: `${aspnet-response-statuscode}`

* **Url Options**
  - _UrlScheme_ - Default: `${aspnet-request-url:IncludeScheme=true:IncludeHost=false:IncludePath=false}`
  - _UrlDomain_ - Default: `${aspnet-request-url:IncludeScheme=false:IncludeHost=true:IncludePath=false}`
  - _UrlPath_ - Default: `${aspnet-request-url:IncludeScheme=false:IncludeHost=false:IncludePath=true}`
  - _UrlPort_ - Default: `${aspnet-request-url:IncludeScheme=false:IncludeHost=false:IncludePath=false:IncludePort=true}`
  - _UrlQuery_ - Default: `${aspnet-request-url:IncludeScheme=false:IncludeHost=false:IncludePath=false:IncludeQueryString=true}`
  - _UrlUserName_ - Default: `${aspnet-user-identity}`

* **Trace Options**
  - _ApmTraceId_ - Default: `System.Diagnostics.Activity.Current.TraceId`
  - _ApmSpanId_ - Default: `System.Diagnostics.Activity.Current.SpanId`

* **Transaction Options**
  - _ApmTransactionId_ - Default: `${ElasticApmTransactionId}`
  - 
### ECS Aware Message Templates

Additionally any valid ECS log template properties that is available under `LogTemplateProperties.*` e.g `LogTemplateProperties.TraceId`
is supported and will directly set the appropriate ECS fields.

```chsarp
logger.Info("The time is {TraceId}", "my-trace-id");
```

Will override `trace.id` on the resulting ECS json document.


## Example output from EcsLayout
An example of the output is given below:

```json
{
  "@timestamp": "2020-02-20T16:07:06.7109766+11:00",
  "log.level": "Info",
  "message": "Info \"X\" 2.2",
  "ecs.version": "9.0.0",
  "log": {
    "logger": "Elastic.CommonSchema.NLog.Tests.LogTestsBase"
  },
  "labels": {
    "ValueX": "X"
  },
  "agent": {
    "type": "Elastic.CommonSchema.NLog",
    "version": "1.6.0"
  },
  "event": {
    "created": "2020-02-20T16:07:06.7109766+11:00",
    "severity": 6,
    "timezone": "Romance Standard Time"
  },
  "host": {
    "ip": [ "127.0.0.1" ],
    "name": "LOCALHOST"
  },
  "process": {
    "executable": "C:\\Program Files\\dotnet\\dotnet.exe",
    "name": "dotnet",
    "pid": 17592,
    "thread.id": 17592,
    "title": "15.0.0.0"
  },
  "server": { "user": { "name": "MyUser" } },
  "service": {
    "name": "Elastic.CommonSchema",
    "type": "dotnet",
    "version": "1.6.0"
  },
  "metadata": {
    "SomeY": 2.2
  },
  "MessageTemplate": "Info {ValueX} {SomeY} {NotX}"
}
```

## Copyright and License

This software is Copyright (c) 2014-2020 by Elasticsearch BV.

This is free software, licensed under: [The Apache License Version 2.0](https://github.com/elastic/ecs-dotnet/blob/main/license.txt).
