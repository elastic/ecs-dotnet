using System;
using System.Buffers;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Elastic.CommonSchema.Serialization
{
	/// <summary>
	/// This static class allows you to deserialize subclasses of <see cref="Base"/>
	/// If you are dealing with <see cref="Base"/> directly you do not need to use this class,
	/// use <see cref="Base.Deserialize(string)"/> and the overloads instead.
	/// </summary>
	/// <remarks>
	/// This class should only be used for advanced use cases, for simpler use cases you can utilise the <see cref="Base.Metadata"/> property.
	/// </remarks>
	/// <typeparam name="TBase">Type of the <see cref="Base"/> subclass</typeparam>
	public static class EcsSerializerFactory<TBase> where TBase : Base, new()
	{
		public static ValueTask<TBase> DeserializeAsync(Stream stream, CancellationToken ctx = default) =>
			JsonSerializer.DeserializeAsync<TBase>(stream, JsonConfiguration.SerializerOptions, ctx);

		public static TBase Deserialize(string json) => JsonSerializer.Deserialize<TBase>(json, JsonConfiguration.SerializerOptions);

		public static TBase Deserialize(ReadOnlySpan<byte> json) => JsonSerializer.Deserialize<TBase>(json, JsonConfiguration.SerializerOptions);

		public static TBase Deserialize(Stream stream)
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
}
