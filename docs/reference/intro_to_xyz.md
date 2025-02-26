---
mapped_pages:
  - https://www.elastic.co/guide/en/ecs-logging/dotnet/current/intro_to_xyz.html
---

# A note on the Metadata property [intro_to_xyz]

The C# `EcsDocument` type includes a property called `Metadata` with the signature:

```csharp
/// <summary>
/// Container for additional metadata against this event.
/// </summary>
[JsonPropertyName("metadata"), DataMember(Name = "metadata")]
public IDictionary<string, object> Metadata { get; set; }
```

This property is not part of the ECS specification, but is included as a means to index supplementary information.

