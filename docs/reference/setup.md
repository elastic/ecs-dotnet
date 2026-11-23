---
applies_to:
  stack: ga
  serverless: ga
mapped_pages:
  - https://www.elastic.co/guide/en/ecs-logging/dotnet/current/setup.html
navigation_title: 'Get started'
---

# Get started with ECS Logging .NET [setup]


## Step 1: Configure application logging [setup-step-1]

If you want to integrate with an existing logger emitting ECS json to a file or stdout/stderr.

Choose one of our formatters:

* [`Elastic.CommonSchema.Serilog`](/reference/serilog-formatter.md)
* [`Elastic.CommonSchema.NLog`](/reference/nlog-formatter.md)
* [`Elastic.CommonSchema.Log4Net`](/reference/log4net-formatter.md)

If you want to write the logs directly to one of Elastic’s endpoints (e.g Elastic Cloud / Elasticsearch)

Choose one of our data shipping loggers:

* [`Elastic.Serilog.Sinks`](/reference/serilog-data-shipper.md)
* [`Elastic.Extensions.Logging`](/reference/extensions-logging-data-shipper.md)


## Step 2: Enable APM log correlation (optional) [setup-step-2]

If you are using the Elastic APM .NET agent, [log correlation can be configured](apm-agent-dotnet://reference/logs.md) to inject trace, transaction and span id fields into log events.

By default the ECS logging integrations will read tracing information from [System.Diagnostics.Activity](https://learn.microsoft.com/en-us/dotnet/api/system.diagnostics.activity?view=net-7.0) if the APM logging corrolation libraries are not installed.


## Step 3: Ship your logs (optional) [setup-step-3]

If you use one of the supported log formatters, you can ship the Elastic Common Schema (ECS) JSON logs to Elastic with {{agent}} or {{filebeat}}.

### Option 1: {{agent}} [setup-step-3-agent]

Use the Custom Logs integration to collect the ECS JSON logs your application writes and manage collection centrally with {{fleet}}. When you configure the integration, set the following JSON parsing options so that the integration parses the ECS fields correctly:

* `overwrite_keys: true`
* `add_error_key: true`
* `expand_keys: true`
* `keys_under_root: true`

For the full procedure and an annotated configuration, refer to [Ingest logs with {{agent}}](docs-content://solutions/observability/logs/ecs-formatted-application-logs.md#ingest-ecs-logs-with-agent).

### Option 2: {{filebeat}} [setup-step-3-filebeat]

```{applies_to}
serverless: unavailable
```

Use one of the following methods to ship your logs with {{filebeat}}:

:::::::{tab-set}

::::::{tab-item} Log file
1. Follow the [Filebeat quick start](beats://reference/filebeat/filebeat-installation-configuration.md)
2. Add the following configuration to your `filebeat.yaml` file.

For Filebeat 7.16+

```yaml
filebeat.inputs:
- type: filestream <1>
  paths: /path/to/logs.json
  parsers:
    - ndjson:
      overwrite_keys: true <2>
      add_error_key: true <3>
      expand_keys: true <4>

processors: <5>
  - add_host_metadata: ~
  - add_cloud_metadata: ~
  - add_docker_metadata: ~
  - add_kubernetes_metadata: ~
```

1. Use the filestream input to read lines from active log files.
2. Values from the decoded JSON object overwrite the fields that {{filebeat}} normally adds (type, source, offset, etc.) in case of conflicts.
3. {{filebeat}} adds an "error.message" and "error.type: json" key in case of JSON unmarshalling errors.
4. {{filebeat}} will recursively de-dot keys in the decoded JSON, and expand them into a hierarchical object structure.
5. Processors enhance your data. See [processors](beats://reference/filebeat/filtering-enhancing-data.md) to learn more.


For Filebeat < 7.16

```yaml
filebeat.inputs:
- type: log
  paths: /path/to/logs.json
  json.keys_under_root: true
  json.overwrite_keys: true
  json.add_error_key: true
  json.expand_keys: true

processors:
- add_host_metadata: ~
- add_cloud_metadata: ~
- add_docker_metadata: ~
- add_kubernetes_metadata: ~
```
::::::

::::::{tab-item} Kubernetes
1. Make sure your application logs to stdout/stderr.
2. Follow the [Run Filebeat on Kubernetes](beats://reference/filebeat/running-on-kubernetes.md) guide.
3. Enable [hints-based autodiscover](beats://reference/filebeat/configuration-autodiscover-hints.md) (uncomment the corresponding section in `filebeat-kubernetes.yaml`).
4. Add these annotations to your pods that log using ECS loggers. This will make sure the logs are parsed appropriately.

```yaml
annotations:
  co.elastic.logs/json.overwrite_keys: true <1>
  co.elastic.logs/json.add_error_key: true <2>
  co.elastic.logs/json.expand_keys: true <3>
```

1. Values from the decoded JSON object overwrite the fields that {{filebeat}} normally adds (type, source, offset, etc.) in case of conflicts.
2. {{filebeat}} adds an "error.message" and "error.type: json" key in case of JSON unmarshalling errors.
3. {{filebeat}} will recursively de-dot keys in the decoded JSON, and expand them into a hierarchical object structure.
::::::

::::::{tab-item} Docker
1. Make sure your application logs to stdout/stderr.
2. Follow the [Run Filebeat on Docker](beats://reference/filebeat/running-on-docker.md) guide.
3. Enable [hints-based autodiscover](beats://reference/filebeat/configuration-autodiscover-hints.md).
4. Add these labels to your containers that log using ECS loggers. This will make sure the logs are parsed appropriately.

```yaml
labels:
  co.elastic.logs/json.overwrite_keys: true <1>
  co.elastic.logs/json.add_error_key: true <2>
  co.elastic.logs/json.expand_keys: true <3>
```

1. Values from the decoded JSON object overwrite the fields that {{filebeat}} normally adds (type, source, offset, etc.) in case of conflicts.
2. {{filebeat}} adds an "error.message" and "error.type: json" key in case of JSON unmarshalling errors.
3. {{filebeat}} will recursively de-dot keys in the decoded JSON, and expand them into a hierarchical object structure.
::::::

:::::::
For more information, see the [Filebeat reference](beats://reference/filebeat/configuring-howto-filebeat.md).

