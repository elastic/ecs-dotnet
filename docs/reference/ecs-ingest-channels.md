---
mapped_pages:
  - https://www.elastic.co/guide/en/ecs-logging/dotnet/current/ecs-ingest-channels.html
---

# ECS ingest channels [ecs-ingest-channels]

A specialization of [`Elastic.Ingest.Elasticsearch`](https://www.nuget.org/packages/Elastic.Ingest.Elasticsearch#readme-body-tab) that offers two channel implementations that make it easy to write ECS formatted data and bootstrap the target datastreams/indices with ECS mappings and settings.

## Installation [_installation_5]

Add a reference to the `Elastic.Ingest.Elasticsearch.CommonSchema` package:

```xml
<PackageReference Include="Elastic.Ingest.Elasticsearch.CommonSchema" Version="8.6.0" />
```


## Usage [_usage_5]

### EcsDataStreamChannel<TEvent> [_ecsdatastreamchanneltevent]

A channel that specializes to writing data with a timestamp to Elasticsearch data streams.

A channel can be created to push data to the `logs-dotnet-default` data stream.

```csharp
var dataStream = new DataStreamName("logs", "dotnet");
var bufferOptions = new BufferOptions { }
var options = new DataStreamChannelOptions<EcsDocument>(transport)
{
  DataStream = dataStream,
  BufferOptions = bufferOptions
};
var channel = new EcsDataStreamChannel<EcsDocument>(options);
```

::::{tip}
Learn more about Elastic’s data stream naming convention in [this blog post](https://www.elastic.co/blog/an-introduction-to-the-elastic-data-stream-naming-scheme).
::::


We can now push data to Elasticsearch using the `EcsDataStreamChannel`

```csharp
var doc = new EcsDocument
{
    Timestamp = DateTimeOffset.Now,
    Message = "Hello World!",
}
channel.TryWrite(doc);
```


### EcsIndexChannel<TEvent> [_ecsindexchanneltevent]

A channel that specializes in writing catalog data to Elastic indices.

We can create an `EcsIndexChannel<>` to push `EcsDocument` (or subclassed) instances.

```csharp
var options = new IndexChannelOptions<EcsDocument>(transport)
{
    IndexFormat = "catalog-data-{0:yyyy.MM.dd}",
    // BulkOperationIdLookup = c => null,
    TimestampLookup = c => c.Timestamp,
};
var channel = new EcsIndexChannel<CatalogDocument>(options);
```

Now we can push data using:

```csharp
var doc = new CatalogDocument
{
    Created = date,
    Title = "Hello World!",
    Id = "hello-world"
}
channel.TryWrite(doc);
```

This will push data to `catalog-data-2023.01.1` because `TimestampLookup` yields `Timestamp` to `IndexFormat`.

`IndexFormat` can also simply be a fixed string to write to an Elasticsearch alias/index.

`BulkOperationIdLookup` determines if the document should be pushed to Elasticsearch using a `create` or `index` operation.


## Bootstrapping target datastream or index [_bootstrapping_target_datastream_or_index]

Optionally the target data stream or index can be bootstrapped using the following.

```csharp
await channel.BootstrapElasticsearchAsync(BootstrapMethod.Failure, "7-days-default");
```

This will bootstrap:

* Set up component templates for all ECS fieldsets
* reference: {{ecs-ref}}/ecs-field-reference.html
* templates: [https://github.com/elastic/ecs/tree/main/generated/elasticsearch/composable/component](https://github.com/elastic/ecs/tree/main/generated/elasticsearch/composable/component)
* Create a special `*-settings` component template for the datastream/indices that sets up ILM.
* Set up an [index template](docs-content://manage-data/data-store/templates.md) for the target data streams or indices.

If the index template already exists no further bootstrapping will occur.

Just like `Elastic.Ingest.Elasticsearch` the channel is aware that `logs` and `metrics` have default component templates and ensures the new index tempate references them.



