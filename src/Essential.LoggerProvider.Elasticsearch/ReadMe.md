![Essential Logging](../../docs/images/diagnostics-logo-64.png)

# ElasticsearchLoggerProvider

This logger provider writes to Elasticsearch.

## Basic usage

Add a reference to the `Essential.LoggerProvider.Elasticsearch` package:

```powershell
dotnet add package Essential.LoggerProvider.Elasticsearch
```

Then, add the provider to the loggingBuilder during host construction, using the provided extension method. 

```c#
using Essential.LoggerProvider;

// ...

    .ConfigureLogging((hostContext, loggingBuilder) =>
    {
        loggingBuilder.AddElasticsearch();
    })
```

## Example

* [HelloElasticsearch](../../examples/HelloElasticsearch)

![Example - Elasticsearch](../../docs/images/example-elasticsearch.png)

## Configuration

The logger provider will be automatically configured with any logging settings under the alias `Elasticsearch`. 

The following default settings are used.

```json
{
  "Logging": {
    "Elasticsearch": {
      "Connections": "",
      "IncludeScopes": false,
      "IsEnabled": true
    },
  }
}
```

If you want to configure from a different section, it can be configured manually:

```c#
    .ConfigureLogging((hostContext, loggingBuilder) =>
    {
        loggingBuilder.AddElasticsearch(options =>
            hostContext.Configuration.Bind("Logging:CustomElasticsearch", options));
    })
```

### Development notes

Elasticsearch common schema

https://www.elastic.co/guide/en/ecs/current/ecs-reference.html

Low level client

https://github.com/elastic/elasticsearch-net


