# Elastic.Serilog.Sinks

A [Serilog](https://serilog.net/) sink that writes logs directly to [Elasticsearch](https://www.elastic.co/elasticsearch/) or [Elastic Cloud](https://www.elastic.co/cloud/) using the Elastic Common Schema (ECS).

**NOTE:** Version `9.0.0` of this sink requires at least version `8.15.0` of the Elastic Stack.

## Example

There are several ways to configure a `Serilog` `LoggerConfiguration`:

```csharp
Log.Logger = new LoggerConfiguration()
	.MinimumLevel.Debug()
	.Enrich.FromLogContext()
```

**NOTE:** Don't forget that we also publish an [`Elastic.Apm.SerilogEnricher`](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.Apm.SerilogEnricher) for the Elastic APM Agent!

### Writing to Elasticsearch

```csharp
.WriteTo.Elasticsearch(new [] { new Uri("http://localhost:9200") }, opts =>
{
	opts.DataStream = new DataStreamName("logs", "console-example", "demo");
	opts.BootstrapMethod = BootstrapMethod.Failure;
	opts.ConfigureChannel = channelOpts =>
	{
		channelOpts.BufferOptions = new BufferOptions
		{
			ConcurrentConsumers = 10
		};
	};
})
```

### Writing to Elastic Cloud

```csharp
.WriteTo.ElasticCloud("cloudId", "cloudUser", "cloudPass", opts =>
```

`opts` is an instance of `ElasticsearchSinkOptions` with the following options:

| Option | Description |
|-------|-------------|
| `Transport` | An instance of `Elastic.Transport` that determines where and how the sink communicates. Defaults to `http://localhost:9200`. |
| `DataStream` | The data stream to write to. Defaults to the `logs-dotnet-default` data stream. |
| `BootstrapMethod` | Determines whether the sink should attempt to install component and index templates to ensure the data stream has the correct ECS mappings. Can be set to `None` (the default), `Silent` (attempt to bootstrap but fail silently), or `Failure` (attempt to bootstrap and throw an exception if bootstrapping fails). |
| `TextFormatting` | Allows explicit control over the `EcsTextFormatterConfiguration` used to emit ECS JSON documents. See [`Elastic.CommonSchema.Serilog`](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.CommonSchema.Serilog) for available options. |
| `ConfigureChannel` | A callback that receives `DatastreamChannelOptions`, allowing you to control buffer sizing, backpressure, and other channel settings. See [`Elastic.Ingest.Elasticsearch`](https://github.com/elastic/elastic-ingest-dotnet/blob/main/src/Elastic.Ingest.Elasticsearch/README.md#elasticingestelasticsearch) for more information. |

Note that you can also pass `ElasticsearchSinkOptions` instance directly:

```csharp
.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(client.Transport))
```

This allows you to reuse the `Transport` configured for the Elasticsearch client.

### ECS Aware Message Templates

The formatter allows you to set ECS fields directly through message templates using properties that follow the [Message Templates](https://messagetemplates.org/) format.

The available ECS message template properties are listed under `LogTemplateProperties.*` e.g `LogTemplateProperties.TraceId`

```csharp
Log.Information("The time is {TraceId}", "my-trace-id");
```

This overrides `trace.id` in the resulting ECS JSON document.

### Application Settings Configuration

This sink can be configured through `appsettings.json` when used in combination with [`Serilog.Settings.Configuration`](https://github.com/serilog/serilog-settings-configuration).

#### Elasticsearch appsettings configuration

When configuring the sink through `appsettings.json`, only the `bootstrapMethod` setting is **required**.

```json5
{
  "Serilog": {
    "Using": [ "Elastic.Serilog.Sinks" ],
    "MinimumLevel": { "Default": "Information" },
    "WriteTo": [
      {
        "Name": "Elasticsearch",
        "Args": {
          "bootstrapMethod": "Silent",
          "nodes": [ "http://elastichost:9200" ],
          "useSniffing": true,
          "apiKey": "<apiKey>",
          "username": "<username>",
          "password": "<password>",

          "ilmPolicy": "my-policy",
          "dataStream": "logs-dotnet-default",
          "includeHost": true,
          "includeUser": true,
          "includeProcess": true,
          "includeActivity": true,
          "filterProperties": [ "prop1", "prop2" ],
          "proxy": "http://localhost:8200",
          "proxyUsername": "x",
          "proxyPassword": "y",
          "debugMode": false,

          // EXPERT settings. Only change these if needed.
          "maxRetries": 3,
          "maxConcurrency": 20,
          "maxInflight": 100000,
          "maxExportSize": 1000,
          "maxLifeTime": "00:00:05",
          "fullMode": "Wait"
        }
      }
    ]
  }
}
```

#### Elastic Cloud appsettings configuration

When configuring the sink through `appsettings.json`, only the `bootstrapMethod` configuration is **required**

You can specify either `endpoint` or `cloudId`. If both are specified, `cloudId` takes precedence.

You must also specify either an `apiKey` or both `username` and `password`.

```json5
{
  "Serilog": {
    "Using": [ "Elastic.Serilog.Sinks" ],
    "MinimumLevel": { "Default": "Information" },
    "WriteTo": [
      {
        "Name": "ElasticCloud",
        "Args": {
          "bootstrapMethod": "Silent",
          "endpoint": "https://<redacted>.es.us-central1.gcp.cloud.es.io",
          "cloudId": "<cloudId>",
          "apiKey": "<apiKey>",
          "username": "<username>",
          "password": "<password>",

          "ilmPolicy": "my-policy",
          "dataStream": "logs-dotnet-default",
          "includeHost": true,
          "includeUser": true,
          "includeProcess": true,
          "includeActivity": true,
          "filterProperties": [ "prop1", "prop2" ],
          "proxy": "http://localhost:8200",
          "proxyUsername": "x",
          "proxyPassword": "y",
          "debugMode": false,

          // EXPERT settings. Only change these if needed.
          "maxRetries": 3,
          "maxConcurrency": 20,
          "maxInflight": 100000,
          "maxExportSize": 1000,
          "maxLifeTime": "00:00:05",
          "fullMode": "Wait"
        }
      }
    ]
  }
}
```

### Comparison with [`Serilog.Sinks.Elasticsearch`](https://github.com/serilog-contrib/serilog-sinks-elasticsearch)

- `Serilog.Sinks.Elasticsearch` is an amazing community led sink with many configuration options and support for older Elasticsearch versions (`< 8.0`).
- `Serilog.Sinks.Elasticsearch` is not officially supported by Elastic, although members of the .NET team help maintain it.
- `Elastic.Serilog.Sinks` is **officially supported by Elastic** and was purpose-built to follow modern best practices for logging, datastreams and ILM.
- `Elastic.Serilog.Sinks` is intentionally designed to offer fewer configuration options and be more prescriptive than `Serilog.Sinks.Elasticsearch`.
  - This doesn't mean that `Elastic.Serilog.Sinks` lacks configuration hooks.

#### Notable absent features

- `Elastic.Serilog.Sinks` only supports Elasticsearch 8.x and later.
  - This is because the bootstrapping process (`BootstrapMethod`) attempts to install templates designed for Elasticsearch 8.0 and later.
- `Elastic.Serilog.Sinks` uses a single format for emitting data to Elasticsearch, following the [ECS logging specification](https://github.com/elastic/ecs-logging).
  - However, you can still add your own custom properties.
- `Elastic.Serilog.Sinks` does not support durable logging.
  - If you need stronger guarantees for log delivery, use [`Serilog.Sinks.File`](https://github.com/serilog/serilog-sinks-file) together with our [ECS log formatter](https://www.nuget.org/packages/Elastic.CommonSchema.Serilog/) for Serilog, and use [Filebeat](https://www.elastic.co/beats/filebeat) to ship the resulting logs.
  - You can also check out [Elastic Agent and Fleet](https://www.elastic.co/guide/en/fleet/current/fleet-overview.html) to simplify the collection of logs and metrics at the edge.

If you miss a particular feature from `Serilog.Sinks.Elasticsearch` in `Elastic.Serilog.Sinks`, please open a [feature request](https://github.com/elastic/ecs-dotnet/issues/new?assignees=&labels=enhancement&template=feature_request.md&title=%5BFEATURE%5D). We'd love to grow this sink organically moving forward!
