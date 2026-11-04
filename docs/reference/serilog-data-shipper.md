---
applies_to:
  stack: ga
  serverless: ga
mapped_pages:
  - https://www.elastic.co/guide/en/ecs-logging/dotnet/current/serilog-data-shipper.html
---

# Elastic.Serilog.Sinks [serilog-data-shipper]

A [Serilog](https://serilog.net/) sink that writes logs directly to [Elasticsearch](https://www.elastic.co/elasticsearch/) or [Elastic Cloud](https://www.elastic.co/cloud/) using the Elastic Common Schema (ECS).

## Installation [_installation_6]

Add a reference to the `Elastic.Serilog.Sinks` package:

```xml
<PackageReference Include="Elastic.Serilog.Sinks" Version="8.6.0" />
```

## Usage [_usage_6]

There are several ways to configure a `Serilog` `LoggerConfiguration`:

```csharp
Log.Logger = new LoggerConfiguration()
	.MinimumLevel.Debug()
	.Enrich.FromLogContext()
```

**NOTE:** Don't forget that we also publish an [`Elastic.Apm.SerilogEnricher`](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.Apm.SerilogEnricher) for the Elastic APM Agent!

Writing to `Elasticsearch`

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
}, transport =>
{
	// transport.Authentication(new BasicAuthentication(username, password)); // Basic Auth
	// transport.Authentication(new ApiKey(base64EncodedApiKey)); // ApiKey
})
```

Writing to `Elastic Cloud`:

```csharp
.WriteTo.ElasticCloud("cloudId", "cloudUser", "cloudPass", opts =>
```

`opts` is an instance of `ElasticsearchSinkOptions` with the following options:

## Configuration [_configuration_2]
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


## Authentication [_authentication]

When {{es}} security features are enabled, requests without a valid authentication header will be rejected. You can enable authentication via one of the methods below:

**Basic Auth**

```csharp
.WriteTo.Elasticsearch(new [] { new Uri("http://localhost:9200" )}, opts =>
{
	...
}, transport =>
{
	transport.Authentication(new BasicAuthentication(username, password)); <1>
})
```

1. Basic authentication


**API Key**

```csharp
.WriteTo.Elasticsearch(new [] { new Uri("http://localhost:9200" )}, opts =>
{
	...
}, transport =>
{
	transport.Authentication(new ApiKey(base64EncodedApiKey)); <1>
})
```

1. API Key


To learn more about authentication with the {{stack}}, see [User Authentication](docs-content://deploy-manage/users-roles/cluster-or-deployment-auth/user-authentication.md).


## ECS aware message templates [_ecs_aware_message_templates_4]

The formatter allows you to set ECS fields directly through message templates using properties that follow the [Message Templates](https://messagetemplates.org/) format.

The available ECS message template properties are listed under `LogTemplateProperties.*` e.g `LogTemplateProperties.TraceId`

```csharp
Log.Information("The time is {TraceId}", "my-trace-id");
```

This overrides `trace.id` in the resulting ECS JSON document.


## Troubleshooting [_troubleshooting]

In case of issues, you can enable the [Serilog Self-Log feature](https://github.com/serilog/serilog/wiki/Debugging-and-Diagnostics#selflog) to expose any error you might have encountered.

## Comparison with [`Serilog.Sinks.Elasticsearch`](https://github.com/serilog-contrib/serilog-sinks-elasticsearch) [_comparison_with_serilog_sinks_elasticsearchhttpsgithub_comserilog_contribserilog_sinks_elasticsearch]

* `Serilog.Sinks.Elasticsearch` is an amazing community led sink with many configuration options and support for older Elasticsearch versions (`< 8.0`).
* `Serilog.Sinks.Elasticsearch` is not officially supported by Elastic, although members of the .NET team help maintain it.
* `Elastic.Serilog.Sinks` is **officially supported by Elastic** and was purpose-built to follow modern best practices for logging, datastreams and ILM.
* `Elastic.Serilog.Sinks` is intentionally designed to offer fewer configuration options and be more prescriptive than `Serilog.Sinks.Elasticsearch`.
* This doesn't mean that `Elastic.Serilog.Sinks` lacks configuration hooks.

### Notable absent features: [_notable_absent_features]

* `Elastic.Serilog.Sinks` only supports Elasticsearch 8.x and later.
* This is because the bootstrapping process (`BootstrapMethod`) attempts to install templates designed for Elasticsearch 8.0 and later.
* `Elastic.Serilog.Sinks` uses a single format for emitting data to Elasticsearch, following the [ECS logging specification](https://github.com/elastic/ecs-logging).
* However, you can still add your own custom properties.
* `Elastic.Serilog.Sinks` does not support durable logging.
* If you need stronger guarantees for log delivery, use [`Serilog.Sinks.File`](https://github.com/serilog/serilog-sinks-file) together with our [ECS log formatter](https://www.nuget.org/packages/Elastic.CommonSchema.Serilog/) for Serilog, and use [Filebeat](https://www.elastic.co/beats/filebeat) to ship the resulting logs.
* You can also check out [Elastic Agent and Fleet](https://www.elastic.co/guide/en/fleet/current/fleet-overview.html) to simplify the collection of logs and metrics at the edge.

If you miss a particular feature from `Serilog.Sinks.Elasticsearch` in `Elastic.Serilog.Sinks`, please open a [feature request](https://github.com/elastic/ecs-dotnet/issues/new?assignees=&labels=enhancement&template=feature_request.md&title=%5BFEATURE%5D). We'd love to grow this sink organically moving forward!
