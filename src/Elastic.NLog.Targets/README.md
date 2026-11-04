# Elastic.NLog.Targets

A [NLog](https://nlog-project.org/) target that writes logs directly to [Elasticsearch](https://www.elastic.co/elasticsearch/) or [Elastic Cloud](https://www.elastic.co/cloud/) using the Elastic Common Schema (ECS).

**NOTE:** Version `9.0.0` of this package requires at least version `8.15.0` of the Elastic Stack.

## Packages

The .NET assemblies are published to NuGet under the package name [Elastic.NLog.Targets](https://www.nuget.org/packages/Elastic.NLog.Targets).

## How to Use the API

```csharp
var config = new LoggingConfiguration();
var elasticTarget = new ElasticsearchTarget("elastic") { Layout = new EcsLayout(), NodesUri = "http://localhost:9200" };
config.AddRule(LogLevel.Debug, LogLevel.Fatal, elasticTarget);
LogManager.Configuration = config;
var logger = LogManager.GetCurrentClassLogger();
```

## How to Use NLog.config

```xml
<nlog>
  <extensions>
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
  - _BootstrapMethod_ - Whether to configure / bootstrap the destination, which requires user has management capabilities (None, Silent, Failure). Default = None
  - _CertificateFingerprint_ - 	Fingerprint to validate the certificate sent by the server. Hex string representing the SHA256 public key fingerprint (optional)
  - _ProxyUrl_ - If your connection has to go through proxy, use this method to specify the proxy url (optional)
  - _ProxyUsername_ - If your connection has to go through proxy, use this method to specify the proxy-login username (optional)
  - _ProxyPassword_ - If your connection has to go through proxy, use this method to specify the proxy-login password (optional)

* **Export Authentication**
  - _ApiKey_ - When using NodePoolType = Cloud and authentication via API key.
  - _Username_ - When basic authenticating via username/password.
  - _Password_ - When basic authenticating via username/password.

* **Export Buffering**
  - _InboundBufferMaxSize_ - The maximum number of events that can be queued in memory. Default: `100000`.
  - _OutboundBufferMaxSize_ - The maximum number of events to include in a single export. Default: `1000`.
  - _OutboundBufferMaxLifetimeSeconds_ - The maximum lifetime of a buffer before it is exported, in seconds. Default: `5`.
  - _ExportMaxConcurrency_ - The maximum number of consumers allowed to poll for new events from the channel. Default: `1`.
  - _ExportMaxRetries_ - The maximum number of times an export operation is retried. Default: `3`.

* **Export DataStream**
  - _DataStreamType_ - The generic type describing the data. Default: `logs`.
  - _DataStreamSet_ - Describes the data being ingested and its structure. Default: `dotnet`.
  - _DataStreamNamespace_ - A user-configurable value used to group related data streams. Default: `default`.

* **Export Index**
  - _IndexFormat_ - The format string used to generate the Elasticsearch index name (e.g. `dotnet-{0:yyyy.MM.dd}`). Leave empty to disable index formatting. Default: empty.
  - _IndexOffsetHours_ - The time offset, in hours, used when generating the index name. Use `0` for UTC or leave empty to use the system's local time. Default: empty.
  - _IndexOperation_ - The operation type specified in the header of each bulk operation. Supported values are `Auto`, `Index`, and `Create`. Default: `Auto`.
  - _IndexEventId_ - An optional override for the document `_id`.

**Note:** Exporting relies on an in-memory queue. Any events still in the queue will be lost if the application crashes or exits before they are exported.

If you need stronger guarantees for log delivery, consider using [Elastic.CommonSchema.NLog](https://www.nuget.org/packages/Elastic.CommonSchema.NLog) together with NLog `FileTarget`, and use [Filebeat](https://www.elastic.co/beats/filebeat) to ship the resulting log files.

You can also check out [Elastic Agent and Fleet](https://www.elastic.co/guide/en/fleet/current/fleet-overview.html) to simplify the collection of logs and metrics at the edge.

## ElasticsearchTarget Layout Configuration

NLog layouts allow you to configure target options dynamically, for example, by looking up values from configuration files or environment variables.

### Look up NodeUris from appsettings.json

```xml
<target name="elastic" type="ElasticSearch" nodeUris="${configsetting:ConnectionStrings.ElasticSearch}">
```

Example `appsettings.json` for .NET Core:

```json
{
  "ConnectionStrings": {
    "ElasticSearch": "http://localhost:9200"
  }
}
```

### Look up NodeUris from app.config

```xml
<target name="elastic" type="ElasticSearch" nodeUris="${appsetting:ConnectionStrings.ElasticSearch}">
```

Example `app.config` for .NET Framework:

```xml
<configuration>
  <connectionStrings>
    <add name="ElasticSearch" connectionString="http://localhost:9200"/>
  </connectionStrings>
</configuration>
```

### Look up NodeUris from an environment variable

```xml
<target name="elastic" type="ElasticSearch" nodeUris="${environment:ELASTIC_SERVER_URL}">
```

## Copyright and License

This software is Copyright (c) 2014-2020 by Elasticsearch BV.

This is free software, licensed under: [The Apache License Version 2.0](https://github.com/elastic/ecs-dotnet/blob/main/license.txt).
