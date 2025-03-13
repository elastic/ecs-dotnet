---
mapped_pages:
  - https://www.elastic.co/guide/en/ecs-logging/dotnet/current/ecs-dotnet.html
---

# .NET model of ECS [ecs-dotnet]

The `Elastic.CommonSchema` project contains a full C# representation of the [Elastic Common Schema (ECS)](https://github.com/elastic/ecs). The intention of this library is to form a reliable and correct basis for integrating into Elasticsearch, using both Microsoft .NET and ECS.

These types can be used either as-is or in conjunction with the [Official .NET clients for Elasticsearch](https://github.com/elastic/elasticsearch-net). The types are annotated with the corresponding `DataMember` attributes, enabling out-of-the-box serialization support with the Elasticsearch.net clients.


## Installation [_installation]

Add a reference to the Elastic.CommonSchema package:

```xml
<PackageReference Include="Elastic.CommonSchema" Version="8.6.0" />
```

::::{tip}
Use [Elastic.Ingest.Elasticsearch.CommonSchema](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.Ingest.Elasticsearch.CommonSchema) to easily persist ECS documents to Elasticsearch or Elastic Cloud.
::::



### Versioning [_versioning]

The version of the Elastic.CommonSchema package matches the published ECS version, with the same corresponding branch names:

* Nested Schema (The C# types are generated from this YAML file): [https://github.com/elastic/ecs/blob/v1.4.0/generated/ecs/ecs_nested.yml](https://github.com/elastic/ecs/blob/v1.4.0/generated/ecs/ecs_nested.yml)
* .NET types: [https://github.com/elastic/ecs-dotnet/tree/v1.4.0](https://github.com/elastic/ecs-dotnet)

The version numbers of the NuGet package must match the exact version of ECS used within Elasticsearch. Attempting to use mismatched versions, for example a NuGet package with version 1.2.0 against an Elasticsearch index configured to use an ECS template with version 1.1.0, will result in indexing and data problems.




