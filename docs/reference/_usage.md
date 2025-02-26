---
mapped_pages:
  - https://www.elastic.co/guide/en/ecs-logging/dotnet/current/_usage.html
---

# Usage [_usage]

## Creating an ECS event [_creating_an_ecs_event]

The recommended way to create instances of `EcsDocument` is through:

```csharp
var doc = EcsDocument.CreateNewWithDefaults<EcsDocument>();
```

This will automatically assign most common ECS fields that can be inferred from the running process.

However there is no requirement to do so,  simply creating a new `EcsDocument` instance directly is completely valid and supported.

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


## Dynamically assign ECS fields [_dynamically_assign_ecs_fields]

Additionally, ECS fields can be dynamically assigned through

```csharp
ecsDocument.AssignProperty("orchestrator.cluster.id", "id");
```

This will assign `ecsDocument.Orchestrator.ClusterId` to `"id"` and automatically create a new `Orchestrator` instance if needed.

Any `string` or `boolean` value that is not a known `ecs` field will be assigned to `labels.*` and everything else to `metatadata.*`


