---
mapped_pages:
  - https://www.elastic.co/guide/en/ecs-logging/dotnet/current/_elasticsearch_security.html
---

# Elasticsearch security [_elasticsearch_security]

If Elasticsearch’s security is enabled you will need to ensure you configure a user or API key with enough privileges

## Bootstrap [_bootstrap]

In order for the datashippers to have enough privileges to bootstrap the target datastreams with all the ECS mappings, templates and settings the authenticated security principal needs the following minimum privileges:

| Type | Privileges |
| --- | --- |
| Cluster | `monitor`, `manage_ilm`, `manage_index_templates`, `manage_pipeline` |
| Index | `manage`, `create_doc` |


## No bootstrap [_no_bootstrap]

If the datashippers are configured to skip bootstrapping the target destinations all together, the security principal requires the following minimum privileges to push data.

| Type | Privileges |
| --- | --- |
| Cluster | `monitor` |
| Index | `auto_configure` `create_doc` |


