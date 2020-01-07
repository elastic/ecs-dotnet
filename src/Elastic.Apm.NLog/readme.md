# Elastic APM NLog Layout Renderer

Allows you to add the following place holders in your NLog templates

* `ElasticApmTraceId`
* `ElasticApmTransactionId`

Which will be replace with the appropriate Elastic APM variables if available


## How to Enable

```csharp
			var target = new MemoryTarget();
			target.Layout = "${ElasticApmTraceId}|${ElasticApmTransactionId}|${message}";
			Agent.Tracer.CaptureTransaction("TestTransaction", "Test", t =>
			{
				traceId = "trace-id";
				transactionId = "transaction-id";
				logger.Debug("InTransaction");
			});
			// Logged message will be in format of `trace-id|transation-id|InTransaction`
			// or `||InTransaction` if the place holders are not available
```

## Prerequisite

The prerequisite for this to work is a configured [Elastic APM Agent](https://github.com/elastic/apm-agent-dotnet). If the agent is not configured the enricher won't add anything to the logs.

## Copyright and License

This software is Copyright (c) 2014-2019 by Elasticsearch BV.

This is free software, licensed under: [The Apache License Version 2.0](https://github.com/elastic/ecs-dotnet/blob/master/license.txt).
