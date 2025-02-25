---
mapped_pages:
  - https://www.elastic.co/guide/en/ecs-logging/dotnet/current/nlog-formatter.html
---

# NLog layout [nlog-formatter]

This Layout implementation formats an NLog event into a JSON representation that adheres to the Elastic Common Schema specification.

## Installation [_installation_3]

Add a reference to the Elastic.CommonSchema.NLog package:

```xml
<PackageReference Include="Elastic.CommonSchema.NLog" Version="8.6.0" />
```


## Usage [_usage_3]

### Setup programatically [_setup_programatically]

```csharp
Layout.Register<EcsLayout>("EcsLayout"); // Register the ECS layout.
var config = new LoggingConfiguration();
var consoleTarget = new ConsoleTarget("console") { Layout = new EcsLayout() };  // Use the ECS layout.
config.AddRule(LogLevel.Debug, LogLevel.Fatal, consoleTarget);
LogManager.Configuration = config;
var logger = LogManager.GetCurrentClassLogger();
```

In the code snippet above `Layout.Register<EcsLayout>("EcsLayout")` registers the `EcsLayout` with NLog. The `Layout = new EcsLayout()` line then instructs NLog to use the registered layout. The sample above uses the console target, but you are free to use any target of your choice; perhaps consider using a filesystem target and [Elastic Filebeat](https://www.elastic.co/downloads/beats/filebeat) for durable and reliable ingestion.


### Setup using NLog.config [_setup_using_nlog_config]

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



## EcsLayout Parameter Options [_ecslayout_parameter_options]

* **Metadata Options**
* *IncludeEventProperties* - Include LogEvent properties as metadata. Default: `true`
* *IncludeScopeProperties* - Include NLog Scope Context Properties as metadata. Default: `false`
* *ExcludeProperties* - Comma separated string with names which properties to exclude.
* **Event Options**
* *EventAction* -
* *EventCategory* -
* *EventId* -
* *EventKind* -
* *EventSeverity* -
* **Agent Options**
* *AgentId* -
* *AgentName* -
* *AgentType* -
* *AgentVersion* -
* **Process Options**
* *ProcessExecutable* - Default: `${processname:FullName=true}`
* *ProcessId* - Default: `${processid}`
* *ProcessName* - Default: `${processname:FullName=false}`
* *ProcessThreadId* - Default: `${threadid}`
* *ProcessTitle* - Default: `${processinfo:MainWindowTitle}`
* **Server Options**
* *ServerAddress* -
* *ServerIp* -
* *ServerUser* - Default: `${environment-user}`
* **Host Options**
* *HostId* -
* *HostIp* - Default: `${local-ip:cachedSeconds=60}`
* *HostName* - Default: `${machinename}`
* **Log Origin Options**
* *LogOriginCallSiteMethod* - Default: `${exception:format=method}`
* *LogOriginCallSiteFile* - Default: `${exception:format=source}`
* *LogOriginCallSiteLine* -
* **Http Options**
* *HttpRequestId* - Default: `${aspnet-trace-identifier}`
* *HttpRequestMethod* - Default: `${aspnet-request-method}`
* *HttpRequestBytes* - Default: `${aspnet-request-contentlength}`
* *HttpRequestReferrer* - Default: `${aspnet-request-referrer}`
* *HttpResponseStatusCode* - Default: `${aspnet-response-statuscode}`
* **Url Options**
* *UrlScheme* - Default: `${aspnet-request-url:IncludeScheme=true:IncludeHost=false:IncludePath=false}`
* *UrlDomain* - Default: `${aspnet-request-url:IncludeScheme=false:IncludeHost=true:IncludePath=false}`
* *UrlPath* - Default: `${aspnet-request-url:IncludeScheme=false:IncludeHost=false:IncludePath=true}`
* *UrlPort* - Default: `${aspnet-request-url:IncludeScheme=false:IncludeHost=false:IncludePath=false:IncludePort=true}`
* *UrlQuery* - Default: `${aspnet-request-url:IncludeScheme=false:IncludeHost=false:IncludePath=false:IncludeQueryString=true}`
* *UrlUserName* - Default: `${aspnet-user-identity}`
* **Trace Options**
* *ApmTraceId* - Default: `${ElasticApmTraceId}`
* **Transaction Options**
* *ApmTransactionId* - Default: `${ElasticApmTransactionId}` *


## ECS Aware Message Templates [_ecs_aware_message_templates_3]

Additionally any valid ECS log template properties that is available under `LogTemplateProperties.*` e.g `LogTemplateProperties.TraceId` is supported and will directly set the appropriate ECS fields.

```csharp
logger.Info("The time is {TraceId}", "my-trace-id");
```

Will override `trace.id` on the resulting ECS json document.


## Example output from EcsLayout [_example_output_from_ecslayout]

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


