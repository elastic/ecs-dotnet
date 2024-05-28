using System.Buffers;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Elastic.Ingest.Elasticsearch.CommonSchema.IntegrationTests;

public class CustomEventWriter<T> : IElasticsearchEventWriter<T>
{
	// ReSharper disable once StaticMemberInGenericType
	private static readonly JsonSerializerOptions s_serializerOptions = new() { Converters = { new JsonStringEnumConverter() } };

	public Action<ArrayBufferWriter<byte>, T>? WriteToArrayBuffer
	{
		get => throw new NotImplementedException();
		set => throw new NotImplementedException();
	}

	public Func<Stream, T, CancellationToken, Task>? WriteToStreamAsync { get; set; } =
		(stream, doc, ctx) => JsonSerializer.SerializeAsync<T>(stream, doc, s_serializerOptions, ctx);
}
