# ECS .NET

## Introduction

The Elastic Common Schema (ECS) defines a common set of fields for ingesting data into Elasticsearch. A common schema helps you correlate data from sources like logs and metrics or IT operations analytics and security analytics. Further information on ECS can be found in the official [github repository](https://github.com/elastic/ecs) or [Elastic documentation](https://www.elastic.co/guide/en/ecs/current/index.html).

This repository contains a full C# representation of the ECS YAML schema.

The intention is that this library forms a reliable and correct basis for integrations into Elasticsearch, that use both Microsoft .NET and the ECS schema.

These types can be used in either as-is, or in conjunction with, the [Elasticsearch.net client libraries](https://github.com/elastic/elasticsearch-net). The types are annotated with the corresponding `DataMember` attributes, enabling out-of-the-box serialisation support with the Elasticsearch.net clients.

## Packages

The .NET assemblies are published to nuget under the package name [Elastic.CommonSchema](http://nuget.org/packages/Elastic.CommonSchema).

*Preview builds*

All branches push new nuget packages on successful CI builds to https://ci.appveyor.com/nuget/ecs-dotnet

## Versioning

The version of the package matches the published ECS schema version, with the same corresponding branch names.

- Nested Schema *(C# types generated from this resource)*: `https://github.com/elastic/ecs/blob/{version}/generated/ecs/ecs_nested.yml`
- .NET types: `https://github.com/elastic/ecs-dotnet/tree/{version}`

Where `{version}` is the ECS schema version, e.g. `1.2`.

### Further Compatibility Clarifications

The version numbers of the nuget package must match the *exact* version of the ECS schema used within Elasticsearch.

Attempting to use mismatched versions, for example; a nuget package with version `1.2` against an Elasticsearch index configured to use an ECS template with version `1.1` will result in indexing and data problems.

## Getting started

### Installing

You can install Elastic.CommonSchema from the package manager console:

    PM> Install-Package Elastic.CommonSchema

Alternatively, simply search for Elastic.CommonSchema in the package manager UI.

### Usage

#### Client Installation

In this example, we will also install the [Elasticsearch.net Low Level Client](https://github.com/elastic/elasticsearch-net#elasticsearchnet) and use this to perform the HTTP communications with our Elasticsearch server.

    PM> Install-Package Elasticsearch.Net

#### Connecting to Elasticsearch

    var node = new Uri("http://localhost:9200");
    var config = new ConnectionConfiguration(node);
    var lowLevelClient = new ElasticLowLevelClient(config);

#### Creating an Index Template

Now we need to put an index template, so that any new indices that match our configured index name pattern are to use the ECS schema.

We ship with different index templates for different major versions of Elasticsearch within the `Elastic.CommonSchema.Elasticsearch` namespace.

    // We are using Elasticsearch version 7.4.0, lets use a 7 version index template
    var template = Elastic.CommonSchema.Elasticsearch.IndexTemplates.GetIndexTemplateForElasticsearch7("ecs-*");

    // Send the template to the Elasticsearch server
	var templateResponse = lowLevelClient.Indices.PutTemplateForAll<StringResponse>(
		"ecs-template", 
		template);
   
    // Check everything was successful
    Debug.Assert(templateResponse.Success);

Now that we have applied the index template, any indices that match the pattern `ecs-*` will use the ECS schema.

NOTE: We only need to apply the index template once.

#### Creating an ECS event

Creating a new ECS event is as simple as newing up an instance:

    var ecsEvent = new Base
    {
        Timestamp = DateTimeOffset.Parse("2019-10-23T19:44:38.485Z"),
        Dns = new Dns
        {
            Id = "23666",
            OpCode = "QUERY",
            Type = "answer",
            Question = new DnsQuestion
            {
                 Name   = "www.example.com",
                 Type = "A",
                 Class = "IN",
                 RegisteredDomain = "example.com"
            },
            HeaderFlags = new [] { "RD", "RA" },
            ResponseCode = "NOERROR",
            ResolvedIp = new [] { "10.0.190.47", "10.0.190.117" },
            Answers = new []
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
        Source = new Source
        {
            Ip = "192.168.86.26",
            Port = 5785,
            Bytes = 31
        },
        Destination = new Destination
        {
            Ip = "8.8.4.4",
            Port = 53,
            Bytes = 95
        },
        Client = new Client
        {
            Ip = "192.168.86.26",
            Port = 5785,
            Bytes = 31
        },
        Server = new Server
        {
            Ip = "8.8.4.4",
            Port = 53,
            Bytes = 95
        },
        Event = new Event
        {
            Duration = 122433000,
            Start = DateTimeOffset.Parse("2019-10-23T19:44:38.485Z"),
            End = DateTimeOffset.Parse("2019-10-23T19:44:38.607Z"),
            Kind = "event",
            Category = "network_traffic"
        },
        Ecs = new Ecs
        {
            Version = "1.2.0"
        },
        Metadata = new Dictionary<string, object>
        {
            { "client", "ecs-dotnet" }
        }
    };

This can then be indexed into Elasticsearch:

    var indexResponse = lowLevelClient.Index<StringResponse>(index,PostData.Serializable(ecsEvent));

    // Check everything was successful
    Debug.Assert(indexResponse.Success);

Congratulations, you are now using the Elastic Common Schema!

## Copyright and License

This software is Copyright (c) 2014-2019 by Elasticsearch BV.

This is free software, licensed under: [The Apache License Version 2.0](https://github.com/elastic/ecs-dotnet/blob/master/license.txt).
