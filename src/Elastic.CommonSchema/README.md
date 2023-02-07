# Elastic Common Schema .NET

The `Elastic.CommonSchema` project contains a full C# representation of [Elastic Common Schema](https://github.com/elastic/ecs) (ECS) - see [documentation](https://www.elastic.co/guide/en/ecs/current/index.html).

The intention is that this library forms a reliable and correct basis for integrations into Elasticsearch, that use both Microsoft .NET and ECS.

These types can be used in either as-is, or in conjunction with, the [Official .NET clients for Elasticsearch](https://github.com/elastic/elasticsearch-net). The types are annotated with the corresponding `DataMember` attributes, enabling out-of-the-box serialisation support with the Elasticsearch.net clients.


See also:

* [Elastic.Ingest.Elasticsearch.CommonSchema](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.Ingest.Elasticsearch.CommonSchema) to easily persist ECS document to Elasticsearch or Elastic Cloud. 

## Packages

The .NET assemblies are published to NuGet under the package name [Elastic.CommonSchema](http://nuget.org/packages/Elastic.CommonSchema)

The main branch pushes new NuGet packages on successful CI builds to https://ci.appveyor.com/nuget/ecs-dotnet

## Versioning

The version of the Elastic.CommonSchema package matches the published ECS version, with the same corresponding branch names:

 - Nested Schema (The C# types are generated from this YAML file): https://github.com/elastic/ecs/blob/v1.4.0/generated/ecs/ecs_nested.yml
 - .NET types: https://github.com/elastic/ecs-dotnet/tree/v1.4.0

The version numbers of the NuGet package must match the exact version of ECS used within Elasticsearch. Attempting to use mismatched versions, for example a NuGet package with version 1.2.0 against an Elasticsearch index configured to use an ECS template with version 1.1.0, will result in indexing and data problems.

## Getting started

### Installing

You can install Elastic.CommonSchema from the package manager console:

    PM> Install-Package Elastic.CommonSchema

Alternatively, simply search for Elastic.CommonSchema in the package manager UI.

### Usage

#### Creating an ECS event

Creating a new ECS event is as simple as newing up an instance:

```csharp
var ecsDocument = new EcsDocument
{
	Timestamp = DateTimeOffset.Parse("2019-10-23T19:44:38.485Z"),
	Dns = new Dns
	{
		Id = "23666",
		OpCode = "QUERY",
		Type = "answer",
		QuestionName = "www.example.com",
		QuestionType = "A",
		QuestionClass = "IN",
		QuestionRegisteredDomain = "example.com",
		HeaderFlags = new[] { "RD", "RA" },
		ResponseCode = "NOERROR",
		ResolvedIp = new[] { "10.0.190.47", "10.0.190.117" },
		Answers = new[]
		{
			new DnsAnswers
			{
				Data = "10.0.190.47",
				Name = "www.example.com",
				Type = "A",
				Class = "IN",
				Ttl = 59
			},
			new DnsAnswers
			{
				Data = "10.0.190.117",
				Name = "www.example.com",
				Type = "A",
				Class = "IN",
				Ttl = 59
			}
		}
	},
	Network = new Network
	{
		Type = "ipv4",
		Transport = "udp",
		Protocol = "dns",
		Direction = "outbound",
		CommunityId = "1:19beef+RWVW9+BEEF/Q45VFU+2Y=",
		Bytes = 126
	},
	Source = new Source { Ip = "192.168.86.26", Port = 5785, Bytes = 31 },
	Destination = new Destination { Ip = "8.8.4.4", Port = 53, Bytes = 95 },
	Client = new Client { Ip = "192.168.86.26", Port = 5785, Bytes = 31 },
	Server = new Server { Ip = "8.8.4.4", Port = 53, Bytes = 95 },
	Event = new Event
	{
		Duration = 122433000,
		Start = DateTimeOffset.Parse("2019-10-23T19:44:38.485Z"),
		End = DateTimeOffset.Parse("2019-10-23T19:44:38.607Z"),
		Kind = "event",
		Category = new[] { "network_traffic" }
	},
	Ecs = new Ecs { Version = "1.2.0" },
	Metadata = new Dictionary<string, object> { { "client", "ecs-dotnet" } }
};

```

### Dynamically assign ECS fields

Additionally ecs fields can be dynamically assigned through 

```csharp
ecsDocument.AssignProperty("orchestrator.cluster.id", "id");
```
This will assign `ecsDocument.Orchestrator.ClusterId` to `"id"` and automatically create a new `Orchestrator` instance if needed.

Any `string` or `boolean` value that is not a known `ecs` field will be assigned to `labels.*` everything else to `metatadata.*`

#### A note on the `Metadata` property

The C# `EcsDocument` type includes a property called `Metadata` with the signature:

```csharp
/// <summary>
/// Container for additional metadata against this event.
/// </summary>
[JsonPropertyName("metadata"), DataMember(Name = "metadata")]
public IDictionary<string, object> Metadata { get; set; }
```
This property is not part of the ECS specification, but is included as a means to index supplementary information.

#### Extending EcsDocument

In instances where using the `IDictionary<string, object> Metadata` property is not sufficient, or there is a clearer definition of the structure of the ECS-compatible document you would like to index, it is possible to subclass the `EcsDocument` object and provide your own property definitions.

Through `TryRead`/`ReceiveProperty`/`WriteAdditionalProperties` you can hook into the `EcsDocumentJsonConverter` and read/write additional properties.

```csharp
/// <summary>
/// An extended ECS document with an additional property
/// </summary>
[JsonConverter(typeof(EcsDocumentJsonConverterFactory))]
public class MyEcsDocument : EcsDocument
{
	[JsonPropertyName("my_root_property"), DataMember(Name = "my_root_property")]
	public MyCustomType MyRootProperty { get; set; }

	protected override bool TryRead(string propertyName, out Type type)
	{
		type = propertyName switch
		{
			"my_root_property" => typeof(MyCustomType),
			_ => null
		};
		return type != null;
	}

	protected override bool ReceiveProperty(string propertyName, object value) =>
		propertyName switch
		{
			"my_root_property" => null != (MyRootProperty = value as MyCustomType),
			_ => false
		};

	protected override void WriteAdditionalProperties(Action<string, object> write) => write("my_root_property", MyCustomType);
}
```

The Elastic.CommonSchema.BenchmarkDotNetExporter project takes this approach, in the [Domain source directory](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.CommonSchema.BenchmarkDotNetExporter), where the BenchmarkDocument subclasses EcsDocument.

## Copyright and License

This software is Copyright (c) 2014-2020 by Elasticsearch BV.

This is free software, licensed under: [The Apache License Version 2.0](https://github.com/elastic/ecs-dotnet/blob/main/license.txt).
