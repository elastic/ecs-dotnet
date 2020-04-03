# Elastic Common Schema Usage Example

## Console example with ElasticsearchLoggerProvider 

This example uses a stand alone logger provider, [Essential.LoggerProvider.Elasticsearch](https://github.com/sgryphon/essential-logging/tree/master/src/Essential.LoggerProvider.Elasticsearch), 
that integrates directly with Microsoft.Extensions.Logging, and uses the Elastic Common Schema library.

The example also uses the LoggerMessage for [high performance logging](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/logging/loggermessage).

## Configuration

To use the stand alone ElasticsearchLoggerProvider in your own project, add a reference to the `Essential.LoggerProvider.Elasticsearch` package:

```powershell
dotnet add package Essential.LoggerProvider.Elasticsearch
```

Then, add the provider to the loggingBuilder during host construction, using the namespace and the provided extension method. 

```c#
using Essential.LoggerProvider;

// ...

    .ConfigureLogging((hostContext, loggingBuilder) =>
    {
        loggingBuilder.AddElasticsearch();
    })
```

The default configuration will write to a local Elasticsearch running at http://localhost:9200/.

For more details on configuration, see the [Essential.LoggerProvider.Elasticsearch project](https://github.com/sgryphon/essential-logging/tree/master/src/Essential.LoggerProvider.Elasticsearch).

## Running the sample

You need to be running Elasticsearch and Kibana. A docker compose configuration is provided, to run on either Linux,
or using Docker Desktop (see https://docs.docker.com/docker-for-windows/). The provided configuration will create two nodes, one for Elasticsearch, and one for Kibana:

```powershell
docker-compose -f ./examples/console-with-loggerprovider/docker/docker-compose.yml start
```

Then run the example:

```powershell
dotnet run --project ./examples/console-with-loggerprovider
```

Open a browser to the Kibana application (http://localhost:5601/) and create the index pattern "dotnet-*", with the time filter "@timestamp".

Some useful columns to add are `log.level`, `log.logger`, `event.code`, `message`, `tags`, and `process.thread.id`. Custom 
key/value pairs are logged as `labels.*`, e.g. `labels.CustomerId`.

**Example output: Elasticsearch via Kibana** 

![Example - Elasticsearch Kibana](example-elasticsearch-kibana.png)


## Example Document

Document fields follows the Elastic Common Schema standards (using the library), with a derived base class conta two custom fields, MessageTemplate and Scopes, for the convention for variant casing.

```json
{
  "_index": "dotnet-2020.04.01",
  "_type": "_doc",
  "_id": "b1f9c454-4562-4a37-a950-441dcda83f48",
  "_version": 1,
  "_score": null,
  "_source": {
    "MessageTemplate": "Unexpected error processing customer {CustomerId}.",
    "Scopes": [
      "IP address 2001:db8:85a3::8a2e:370:7334",
      "PlainScope"
    ],
    "agent": {
      "version": "1.0.0+bd3ad6",
      "type": "Essential.LoggerProvider.Elasticsearch"
    },
    "ecs": {
      "version": "1.5.0"
    },
    "error": {
      "message": "Calculation error",
      "type": "System.Exception",
      "stack_trace": "System.Exception: Calculation error\n ---> System.DivideByZeroException: Attempted to divide by zero.\n   at HelloElasticsearch.Worker.ExecuteAsync(CancellationToken stoppingToken) in /home/sly/Code/essential-logging/examples/HelloElasticsearch/Worker.cs:line 70\n   --- End of inner exception stack trace ---\n   at HelloElasticsearch.Worker.ExecuteAsync(CancellationToken stoppingToken) in /home/sly/Code/essential-logging/examples/HelloElasticsearch/Worker.cs:line 74"
    },
    "event": {
      "code": "5000",
      "action": "ErrorProcessingCustomer",
      "severity": 3
    },
    "host": {
      "os": {
        "platform": "Unix",
        "full": "Linux 4.15.0-91-generic #92-Ubuntu SMP Fri Feb 28 11:09:48 UTC 2020",
        "version": "4.15.0.91"
      },
      "hostname": "VUB1804",
      "architecture": "X64"
    },
    "log": {
      "level": "Error",
      "logger": "ConsoleExample.Worker"
    },
    "process": {
      "thread": {
        "id": 6
      },
      "pid": 21054,
      "name": "ConsoleExample"
    },
    "service": {
      "type": "ConsoleExample",
      "version": "1.0.0"
    },
    "user": {
      "id": "sgryphon+es@live.com",
      "name": "sly",
      "domain": "VUB1804"
    },
    "@timestamp": "2020-04-02T21:30:56.1351149+10:00",
    "tags": [
      "Development", "Example"
    ],
    "labels": {
      "ip": "2001:db8:85a3::8a2e:370:7334",
      "CustomerId": "12345"
    },
    "message": "Unexpected error processing customer 12345.",
    "trace": {
      "id": "380f61e2-c365-4c8c-96d9-1ccfb9ded562"
    }
  },
  "fields": {
    "@timestamp": [
      "2020-04-02T11:30:56.135Z"
    ]
  },
  "sort": [
    1585827056135
  ]
}
```
