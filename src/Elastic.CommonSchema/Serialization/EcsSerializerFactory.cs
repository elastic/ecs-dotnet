using System;
using System.Buffers;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Elastic.CommonSchema.Serialization;

/// <summary>
/// This static class allows you to deserialize subclasses of <see cref="EcsDocument"/>
/// If you are dealing with <see cref="EcsDocument"/> directly you do not need to use this class,
/// use <see cref="EcsDocument.Deserialize(string)"/> and the overloads instead.
/// </summary>
/// <remarks>
/// This class should only be used for advanced use cases, for simpler use cases you can utilise the <see cref="EcsDocument.Metadata"/> property.
/// </remarks>
/// <typeparam name="TEcsDocument">Type of the <see cref="EcsDocument"/> subclass</typeparam>
public static class EcsSerializerFactory<TEcsDocument> where TEcsDocument : EcsDocument, new()
{
	/// <summary>
	/// Deserialize a <typeparamref name="TEcsDocument"/> instance from a Stream asynchronously.
	/// </summary>
	public static ValueTask<TEcsDocument> DeserializeAsync(Stream stream, CancellationToken ctx = default) =>
		JsonSerializer.DeserializeAsync<TEcsDocument>(stream, EcsJsonConfiguration.SerializerOptions, ctx);

	/// <summary>
	/// Deserialize a <typeparamref name="TEcsDocument"/> instance from a json string.
	/// </summary>
	public static TEcsDocument Deserialize(string json) => JsonSerializer.Deserialize<TEcsDocument>(json, EcsJsonConfiguration.SerializerOptions);

	/// <summary>
	/// Deserialize a <typeparamref name="TEcsDocument"/> instance from a readonly span of bytes.
	/// </summary>
	public static TEcsDocument Deserialize(ReadOnlySpan<byte> json) => JsonSerializer.Deserialize<TEcsDocument>(json, EcsJsonConfiguration.SerializerOptions);

	/// <summary>
	/// Deserialize a <typeparamref name="TEcsDocument"/> instance from a Stream.
	/// </summary>
	public static TEcsDocument Deserialize(Stream stream)
	{
		using var ms = new MemoryStream();
		var buffer = ArrayPool<byte>.Shared.Rent(1024);
		var total = 0;
		int read;
		while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
		{
			ms.Write(buffer, 0, read);
			total += read;
		}
		var span = ms.TryGetBuffer(out var segment)
			? new ReadOnlyMemory<byte>(segment.Array, segment.Offset, total).Span
			: new ReadOnlyMemory<byte>(ms.ToArray()).Span;
		return Deserialize(span);
	}
}
