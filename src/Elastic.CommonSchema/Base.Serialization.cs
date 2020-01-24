// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Buffers;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Elastic.CommonSchema.Serialization;
using static Elastic.CommonSchema.Serialization.JsonConfiguration;

namespace Elastic.CommonSchema.Serialization
{
	/// <summary>
	/// This static class allows you to deserialize subclasses of <see cref="Base"/>
	/// If you are dealing with <see cref="Base"/> directly you do not need to use this class.
	/// Use <see cref="Base.Deserialize(string)"/> and the overloads instead.
	/// Note this class should only be used for advanced use cases, for simpler use cases you can utilise the <see cref="Base.Metadata"/> property.
	/// </summary>
	/// <typeparam name="TBase">Type of the <see cref="Base"/> subclass</typeparam>
	public static class EcsSerializerFactory<TBase> where TBase : Base, new()
	{
		public static ValueTask<TBase> DeserializeAsync(Stream stream, CancellationToken ctx = default) =>
			JsonSerializer.DeserializeAsync<TBase>(stream, SerializerOptions, ctx);

		public static TBase Deserialize(string json) => JsonSerializer.Deserialize<TBase>(json, SerializerOptions);

		public static TBase Deserialize(ReadOnlySpan<byte> json) => JsonSerializer.Deserialize<TBase>(json, SerializerOptions);

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

namespace Elastic.CommonSchema
{
	public partial class Base
	{
		/// <summary>
		/// If implemented in a subclass, this allows you to hook into <see cref="BaseJsonConverter"/>
		/// and make it aware of properties on a subclass of <see cref="Base"/>.
		/// If <paramref name="propertyName"/> is known, set <paramref name="type"/> to the correct type and return true.
		/// </summary>
		/// <param name="propertyName">The additional property that <see cref="BaseJsonConverter"/> encountered</param>
		/// <param name="type">Set this to the type you wish to deserialize to</param>
		/// <returns>Return true if <paramref name="propertyName"/> is handled</returns>
		protected internal virtual bool TryRead(string propertyName, out Type type)
		{
			type = null;
			return false;
		}

		/// <summary>
		/// If <see cref="TryRead"/> returns <c>true</c> this will be called with the deserialized <paramref name="value"/>
		/// </summary>
		/// <param name="propertyName">The additional property <see cref="BaseJsonConverter"/> encountered</param>
		/// <param name="value">The deserialized boxed value you will have to manually unbox to the type that <see cref="TryRead"/> set</param>
		/// <returns></returns>
		protected internal virtual bool ReceiveProperty(string propertyName, object value) => false;

		/// <summary>
		/// Write any additional properties in your subclass during <see cref="BaseJsonConverter"/> serialization.
		/// </summary>
		/// <param name="write">An action taking a <c>property name</c> and <c>boxed value</c> to write to the output</param>
		protected internal virtual void WriteAdditionalProperties(Action<string, object> write) { }

		public static Base Deserialize(string json) => EcsSerializerFactory<Base>.Deserialize(json);

		public static Base Deserialize(ReadOnlySpan<byte> json) => EcsSerializerFactory<Base>.Deserialize(json);

		public static Base Deserialize(Stream stream) => EcsSerializerFactory<Base>.Deserialize(stream);

		public static ValueTask<Base> DeserializeAsync(Stream stream, CancellationToken ctx = default) =>
			EcsSerializerFactory<Base>.DeserializeAsync(stream, ctx);

		public string Serialize() => JsonSerializer.Serialize(this, GetType(), SerializerOptions);

		public byte[] SerializeToUtf8Bytes() => JsonSerializer.SerializeToUtf8Bytes(this, GetType(), SerializerOptions);

		public void Serialize(Stream stream)
		{
			using var writer = new Utf8JsonWriter(stream, new JsonWriterOptions
			{
				Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
				Indented = false
			});
			JsonSerializer.Serialize(writer, this, JsonConfiguration.SerializerOptions);
		}

		public Task SerializeAsync(Stream stream, CancellationToken ctx = default) =>
			JsonSerializer.SerializeAsync(stream, this, GetType(), SerializerOptions, ctx);
	}
}
