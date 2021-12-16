# Elastic Common Schema NLog Layout

This Layout implementation formats an NLog event into a JSON representation that adheres to the Elastic Common Schema specification.

## Packages

The .NET assemblies are published to NuGet under the package name [Elastic.CommonSchema.NLog](http://nuget.org/packages/Elastic.CommonSchema.NLog)

## How to use from API

```csharp
Layout.Register<EcsLayout>("EcsLayout"); // Register the ECS layout.
var config = new LoggingConfiguration();
var consoleTarget = new ConsoleTarget("console") { Layout = new EcsLayout() };  // Use the ECS layout.
config.AddRule(LogLevel.Debug, LogLevel.Fatal, consoleTarget);
LogManager.Configuration = config;
var logger = LogManager.GetCurrentClassLogger();
```

In the code snippet above `Layout.Register<EcsLayout>("EcsLayout")` registers the `EcsLayout` with NLog.
The `Layout = new EcsLayout()` line then instructs NLog to use the registered layout.
The sample above uses the console target, but you are free to use any target of your choice, perhaps consider using a
filesystem target and [Elastic Filebeat](https://www.elastic.co/downloads/beats/filebeat) for durable and reliable ingestion.

## How to use from NLog.config

```xml
<nlog>
  <extensions>
    <add assembly="Elastic.Apm.NLog"/>
    <add assembly="Elastic.CommonSchema.NLog"/>
  </extensions>
  <targets>
    <target name="console" type="console">
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
  - _IncludeAllProperties_ - Include LogEvent properties as metadata. Default: `true`
  - _IncludeMdlc_ - Include NLog Scope Context Properties as metadata. Default: `false`
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
  - _ProcessThreadId_ - Default: `${threadid}`
  - _ProcessTitle_ - Default: `${processinfo:MainWindowTitle}`

* **Server Options**
  -	_ServerAddress_ -
  -	_ServerIp_ -
  -	_ServerUser_ - Default: `${environment-user}`

* **Host Options**
  -	_HostId_ -
  -	_HostIp_ - Default: `${local-ip:cachedSeconds=60}`
  -	_HostName_ - Default: `${machinename}`

* **Log Origin Options**
  - _LogOriginCallSiteMethod_ - Default: `${exception:format=method}`
  - _LogOriginCallSiteFile_ - Default: `${exception:format=source}`
  - _LogOriginCallSiteLine_ -

* **Trace Options**
  - _ApmTraceId_ - Default: `${ElasticApmTraceId}`

* **Transaction Options**
  - _ApmTransactionId_ - Default: `${ElasticApmTransactionId}`

## Example output from EcsLayout
An example of the output is given below:

```json
{
   "@timestamp":"2020-02-20T16:07:06.7109766+11:00",
   "log.level":"Info",
   "message":"Info \"X\" 2.2",
   "metadata":{
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

This is free software, licensed under: [The Apache License Version 2.0](https://github.com/elastic/ecs-dotnet/blob/main/license.txt).
