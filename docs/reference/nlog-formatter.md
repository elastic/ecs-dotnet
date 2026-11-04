---
applies_to:
  stack: ga
  serverless: ga
mapped_pages:
  - https://www.elastic.co/guide/en/ecs-logging/dotnet/current/nlog-formatter.html
---

# NLog layout [nlog-formatter]

This NLog Layout implementation formats NLog log events as JSON documents adhering to the Elastic Common Schema (ECS) specification.

## Installation [_installation_3]

Add a reference to the Elastic.CommonSchema.NLog package:

```xml
<PackageReference Include="Elastic.CommonSchema.NLog" Version="8.6.0" />
```

## Usage [_usage_3]

### Setup programatically [_setup_programatically]

```csharp
var config = new LoggingConfiguration();
var consoleTarget = new ConsoleTarget("console") { Layout = new EcsLayout() };  // Use the ECS layout.
config.AddRule(LogLevel.Debug, LogLevel.Fatal, consoleTarget);
LogManager.Configuration = config;
var logger = LogManager.GetCurrentClassLogger();
```

The example above uses `EcsLayout` with the NLog console target, but you can use any target of your choice.

For durable and reliable log ingestion, consider using NLog's `FileTarget` together with [Elastic Filebeat](https://www.elastic.co/downloads/beats/filebeat) to ship the resulting log files.

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
  - *IncludeEventProperties* - Determines whether NLog event properties are included as metadata. Default: `true`.
  - *IncludeScopeProperties* - Determines whether NLog scope context properties are included as metadata. Default: `false`.
  - *ExcludeProperties* - A comma-separated list of property names to exclude from the output.

* **Event Options**
  - *EventAction* -
  - *EventCategory* -
  - *EventId* -
  - *EventKind* -
  - *EventSeverity* -

* **Agent Options**
  - *AgentId* -
  - *AgentName* -
  - *AgentType* -
  - *AgentVersion* -

* **Process Options**
  - *ProcessExecutable* - Default: `${processname:FullName=true}`
  - *ProcessId* - Default: `${processid}`
  - *ProcessName* - Default: `${processname:FullName=false}`
  - *ProcessTitle* - Default: `${processinfo:MainWindowTitle}`
  - *ProcessThreadId* - Default: `${threadid}`
  - *ProcessThreadName* -

* **Server Options**
  - *ServerAddress* -
  - *ServerIp* -
  - *ServerUser* - Default: `${environment-user}`

* **Host Options**
  - *HostId* -
  - *HostIp* -
  - *HostName* - Default: `${machinename}`

* **Log Origin Options**
  - *LogOriginCallSiteMethod* - Default: `${exception:format=method}`
  - *LogOriginCallSiteFile* - Default: `${exception:format=source}`
  - *LogOriginCallSiteLine* -

* **HTTP Options**
  - *HttpRequestId* - Default: `${aspnet-trace-identifier}`
  - *HttpRequestMethod* - Default: `${aspnet-request-method}`
  - *HttpRequestBytes* - Default: `${aspnet-request-contentlength}`
  - *HttpRequestReferrer* - Default: `${aspnet-request-referrer}`
  - *HttpResponseStatusCode* - Default: `${aspnet-response-statuscode}`

* **URL Options**
  - *UrlScheme* - Default: `${aspnet-request-url:IncludeScheme=true:IncludeHost=false:IncludePath=false}`
  - *UrlDomain* - Default: `${aspnet-request-url:IncludeScheme=false:IncludeHost=true:IncludePath=false}`
  - *UrlPath* - Default: `${aspnet-request-url:IncludeScheme=false:IncludeHost=false:IncludePath=true}`
  - *UrlPort* - Default: `${aspnet-request-url:IncludeScheme=false:IncludeHost=false:IncludePath=false:IncludePort=true}`
  - *UrlQuery* - Default: `${aspnet-request-url:IncludeScheme=false:IncludeHost=false:IncludePath=false:IncludeQueryString=true}`
  - *UrlUserName* - Default: `${aspnet-user-identity}`

* **Trace Options**
  - *ApmTraceId* - Default: `System.Diagnostics.Activity.Current.TraceId`
  - *ApmSpanId* - Default: `System.Diagnostics.Activity.Current.SpanId`

* **Transaction Options**
  - *ApmTransactionId* - Default: `${ElasticApmTransactionId}`

## ECS Aware Message Templates [_ecs_aware_message_templates_3]

The layout also supports valid ECS message template properties listed under `LogTemplateProperties.*`, such as `LogTemplateProperties.TraceId`.

These properties allow you to set ECS fields directly through message templates.

```csharp
logger.Info("The time is {TraceId}", "my-trace-id");
```

This overrides `trace.id` in the resulting ECS JSON document.

## Example output from EcsLayout [_example_output_from_ecslayout]

The following is an example of the JSON output produced by `EcsLayout` (formatted for readability):

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
