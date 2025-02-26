---
mapped_pages:
  - https://www.elastic.co/guide/en/ecs-logging/dotnet/current/serilog-data-shipper.html
---

# Elastic.Serilog.Sinks [serilog-data-shipper]

A [Serilog](https://serilog.net/) sink that writes logs directly to [Elasticsearch](https://www.elastic.co/elasticsearch/) or [Elastic Cloud](https://www.elastic.co/cloud)

## Installation [_installation_6]

Add a reference to the `Elastic.Serilog.Sinks` package:

```xml
<PackageReference Include="Elastic.Serilog.Sinks" Version="8.6.0" />
```


## Usage [_usage_6]

There’s a few ways that you can extend a `Serilog` `LoggerConfiguration`:

```csharp
Log.Logger = new LoggerConfiguration()
	.MinimumLevel.Debug()
	.Enrich.FromLogContext()
```

**NOTE:** Don’t forget we also publish an [`Elastic.Apm.SerilogEnricher`](https://github.com/elastic/ecs-dotnet/blob/main/src/Elastic.Apm.SerilogEnricher/readme.md) for the Elastic APM Agent!

Writing to `Elasticsearch`

```csharp
.WriteTo.Elasticsearch(new [] { new Uri("http://localhost:9200" )}, opts =>
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

`opts` is an instance of `ElasticsearchSinkOptions` with the following options


## Configuration [_configuration_2]

| Option | Description |
| --- | --- |
| `Transport` | An instance of `Elastic.Transport` that dictates where and how we are communicating to. Defaults to `http://localhost:9200` |
| `DataStream` | Where to write data, defaults to the `logs-dotnet-default` datastream. |
| `BootstrapMethod` | Wheter the sink should attempt to install component and index templates to ensure the datastream has ECS mappings. Can be be either `None` (the default), `Silent` (attempt but fail silently), `Failure` (attempt and fail with exceptions if bootstrapping fails). |
| `TextFormatting` | Allows explicit control of over the `EcsTextFormatterConfiguration` used to emit ECS json documents. See [`Elastic.CommonSchema.Serilog`](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.CommonSchema.Serilog) for available options. |
| `ConfigureChannel` | A callback receiving the `DatastreamChannelOptions` which allows you to control sizing, backpressure etc. See [`Elastic.Ingest.Elasticsearch`](https://github.com/elastic/elastic-ingest-dotnet/blob/main/src/Elastic.Ingest.Elasticsearch/README.md#elasticingestelasticsearch) for more information. |

Note that you can also pass `ElasticsearchSinkOptions` directly

```csharp
.WriteTo.Elasticsearch(new ElasticsearchSinkOptions(client.Transport))
```

This allows you to reuse the `Transport` used by the Elasticsearch Client for instance.


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

This sink by proxy of its formatter allows you to set ECS fields directly from the message template using properties that adhere to the [https://messagetemplates.org/](https://messagetemplates.org/) format.

The available ECS message template properties are listed under `LogTemplateProperties.*` e.g `LogTemplateProperties.TraceId`

```csharp
Log.Information("The time is {TraceId}", "my-trace-id");
```

Will override `trace.id` on the resulting ECS json document.


## Troubleshooting [_troubleshooting]

In case of issues, you can enable the [Serilog Self-Log feature](https://github.com/serilog/serilog/wiki/Debugging-and-Diagnostics#selflog) to expose any error you might have encountered.


## Comparison with [`Serilog.Sinks.Elasticsearch`](https://github.com/serilog-contrib/serilog-sinks-elasticsearch) [_comparison_with_serilog_sinks_elasticsearchhttpsgithub_comserilog_contribserilog_sinks_elasticsearch]

* `Serilog.Sinks.Elasticsearch` is an amazing community led sink that has a ton of options and works against older Elasticsearch versions `< 8.0`.
* `Serilog.Sinks.Elasticsearch` is unofficially supported by Elastic with some of the .NET team helping to maintain it.
* `Elastic.Serilog.Sinks` is **officially** supported by Elastic and was purposely build to adhere to newer best practices around logging, datastreams and ILM.
* `Elastic.Serilog.Sinks` is purposely build to have fewer configuration options and be more prescriptive than `Serilog.Sinks.Elasticsearch`.
* That is not to say there aren’t plenty of configuration hooks in `Elastic.Serilog.Sinks`

### Notable absent features: [_notable_absent_features]

* `Elastic.Serilog.Sinks` only works with `Elasticsearch 8.x` and up.
* This is because the bootrapping (`BootstrapMethod`) attempts to load templates build for Elasticsearch 8.0 and up.
* `Elastic.Serilog.Sinks` has only one way it emits data to Elasticsearch confirming to the [ecs-logging specification](https://github.com/elastic/ecs-logging)
* That doesn’t mean you can not introduce your own additional properties though.
* `Elastic.Serilog.Sinks` has no durable mode.
* If you need higher guarantees on log delivery use [`Serilog.Sinks.File`](https://github.com/serilog/serilog-sinks-file) with our [ECS log formatter](https://www.nuget.org/packages/Elastic.CommonSchema.Serilog/) for Serilog and use [filebeat](https://www.elastic.co/beats/filebeat) to ship these logs.
* Check out [Elastic Agent and Fleet](docs-content://reference/ingestion-tools/fleet/index.md) to simplify collecting logs and metrics on the edge.

If you miss a particular feature from `Serilog.Sinks.Elasticsearch` in `Elastic.Serilog.Sinks` please open a [feature request](https://github.com/elastic/ecs-dotnet/issues/new?assignees=&labels=enhancement&template=feature_request.md&title=%5BFEATURE%5D)! We’d love to grow this sink organically moving forward.
