# Elastic.NLog.Targets

A [NLog](https://nlog-project.org/) target that writes logs directly to [Elasticsearch](https://www.elastic.co/elasticsearch/) or [Elastic Cloud](https://www.elastic.co/cloud/)

## Packages

The .NET assemblies are published to NuGet under the package name [Elastic.NLog.Targets](http://nuget.org/packages/Elastic.NLog.Targets)

## How to use from API

```csharp
var config = new LoggingConfiguration();
var elasticTarget = new ElasticsearchTarget("elastic") { Layout = new EcsLayout(), NodesUri = "http://localhost:9200" };
config.AddRule(LogLevel.Debug, LogLevel.Fatal, elasticTarget);
LogManager.Configuration = config;
var logger = LogManager.GetCurrentClassLogger();
```

## How to use from NLog.config

```xml
<nlog>
  <extensions>
    <add assembly="Elastic.Apm.NLog"/>
    <add assembly="Elastic.CommonSchema.NLog"/>
    <add assembly="Elastic.NLog.Targets"/>
  </extensions>
  <targets>
    <target name="elastic" type="ElasticSearch" nodeUris="http://localhost:9200">
      <layout xsi:type="EcsLayout">
        <metadata name="MyProperty" layout="MyPropertyValue" /> <!-- repeated, optional -->
        <label name="MyLabel" layout="MyLabelValue" />          <!-- repeated, optional -->
        <tag layout="MyTagValue" />                             <!-- repeated, optional -->
      </layout>
    </target>
  </targets>
  <rules>
    <logger name="*" minLevel="Debug" writeTo="elastic" />
  </rules>
</nlog>
```


## ElasticsearchTarget Parameter Options

* **Export Destination**
  - _NodePoolType_ - Connection pool type
    - SingleNode - Pool with single node or endpoint
    - Sniffing - Pool with Supports-Reseeding
    - Static - Pool without Supports-Reseeding
    - Sticky - Pool without Supports-Reseeding and stays on the first node.
    - StickySniffing - Pool with Supports-Reseeding and stays on the first node.
    - Cloud - Pool seeded with CloudId
  - _NodeUris_ - URIs of the Elasticsearch nodes in the connection pool (comma delimited)
  - _CloudId_ - When using NodePoolType = Cloud

* **Export Authentication**
  - _ApiKey_ - When using NodePoolType = Cloud and authentication via API key.
  - _Username_ - When basic authenticating via username/password.
  - _Password_ - When basic authenticating via username/password.

* **Export Buffering**
  - _InboundBufferMaxSize_ - Max number of in flight instances that can be queued in memory. Default = 100000
  - _OutboundBufferMaxSize_ - Max size to export. Default = 1000
  - _OutboundBufferMaxLifetimeSeconds_ - Maximum lifetime of a buffer to export in seconds. Default = 5 sec
  - _ExportMaxConcurrency_ - Max number of consumers allowed to poll for new events on the channel. Default = 1
  - _ExportMaxRetries_ - Max number of times to retry an export. Default = 3

* **Export DataStream**
  - _DataStreamType_ - Generic type describing the data. Defaults = 'logs'
  - _DataStreamSet_ - Describes the data ingested and its structure. Default = 'dotnet'
  - _DataStreamNamespace_ - User-configurable arbitrary grouping. Default = 'default'

Notice that export depends on in-memory queue, that is lost on application-crash / -exit.
If higher gurantee of delivery is required, then consider using [Elastic.CommonSchema.NLog](https://www.nuget.org/packages/Elastic.CommonSchema.NLog)
together with NLog FileTarget and use [filebeat](https://www.elastic.co/beats/filebeat) to ship these logs.

Check out [Elastic Agent & Fleet](https://www.elastic.co/guide/en/fleet/current/fleet-overview.html) to simplify collecting logs and metrics on the edge.

## ElasticsearchTarget Layout Configuration

NLog Layout allows one to configure NLog Target options from environment.

**Lookup NodeUris from appsettings.json**
```xml
  <target name="elastic" type="ElasticSearch" nodeUris="${configsetting:ConnectionStrings.ElasticSearch}">
```

Example appsettings.json on .NET Core:
```json
  {
    "ConnectionStrings": {
      "ElasticSearch": "http://localhost:9200"
    }
  }
```

**Lookup NodeUris from app.config**
```xml
  <target name="elastic" type="ElasticSearch" nodeUris="${appsetting:ConnectionStrings.ElasticSearch}">
```

Example app.config on .NET Framework:
```xml
  <configuration>
    <connectionStrings>
      <add name="ElasticSearch" connectionString="http://localhost:9200"/>
    </connectionStrings>
  </configuration>
```

**Lookup ConnectionString from environment-variable**
```xml
  <target name="elastic" type="ElasticSearch" nodeUris="${environment:ELASTIC_SERVER_URL}">
```