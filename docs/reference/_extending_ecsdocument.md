---
mapped_pages:
  - https://www.elastic.co/guide/en/ecs-logging/dotnet/current/_extending_ecsdocument.html
---

# Extending EcsDocument [_extending_ecsdocument]

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

The Elastic.CommonSchema.BenchmarkDotNetExporter project takes this approach in the [Domain source directory](https://github.com/elastic/ecs-dotnet/tree/main/src/Elastic.CommonSchema.BenchmarkDotNetExporter), where the BenchmarkDocument subclasses EcsDocument.

