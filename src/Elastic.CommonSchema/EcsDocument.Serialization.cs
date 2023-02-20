// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Elastic.CommonSchema.Serialization;
using static Elastic.CommonSchema.Serialization.EcsJsonConfiguration;

namespace Elastic.CommonSchema
{
	[JsonConverter(typeof(EcsDocumentJsonConverterFactory))]
	public partial class EcsDocument
	{
		/// <summary>
		/// If implemented in a subclass, this allows you to hook into <see cref="EcsDocumentJsonConverter"/>
		/// and make it aware of properties on a subclass of <see cref="EcsDocument"/>.
		/// If <paramref name="propertyName"/> is known, set <paramref name="type"/> to the correct type and return true.
		/// </summary>
		/// <param name="propertyName">The additional property that <see cref="EcsDocumentJsonConverter"/> encountered</param>
		/// <param name="type">Set this to the type you wish to deserialize to</param>
		/// <returns>Return true if <paramref name="propertyName"/> is handled</returns>
		// ReSharper disable once UnusedParameter.Global
		protected internal virtual bool TryRead(string propertyName, out Type type)
		{
			type = null;
			return false;
		}

		/// <summary>
		/// If <see cref="TryRead"/> returns <c>true</c> this will be called with the deserialized <paramref name="value"/>
		/// </summary>
		/// <param name="propertyName">The additional property <see cref="EcsDocumentJsonConverter"/> encountered</param>
		/// <param name="value">The deserialized boxed value you will have to manually unbox to the type that <see cref="TryRead"/> set</param>
		/// <returns></returns>
		// ReSharper disable UnusedParameter.Global
		protected internal virtual bool ReceiveProperty(string propertyName, object value) => false;
		// ReSharper restore UnusedParameter.Global

		/// <summary>
		/// Write any additional properties in your subclass during <see cref="EcsDocumentJsonConverter"/> serialization.
		/// </summary>
		/// <param name="write">An action taking a <c>property name</c> and <c>boxed value</c> to write to the output</param>
		// ReSharper disable once UnusedParameter.Global
		protected internal virtual void WriteAdditionalProperties(Action<string, object> write) { }

		// ReSharper disable once UnusedMember.Global
		/// <summary> Deserialize json string to <see cref="EcsDocument"/> </summary>
		public static EcsDocument Deserialize(string json) => EcsSerializerFactory<EcsDocument>.Deserialize(json);

		// ReSharper disable once UnusedMember.Global
		/// <summary> Deserialize readonly span of bytes to <see cref="EcsDocument"/> </summary>
		public static EcsDocument Deserialize(ReadOnlySpan<byte> json) => EcsSerializerFactory<EcsDocument>.Deserialize(json);

		// ReSharper disable once UnusedMember.Global
		/// <summary> Deserialize stream to <see cref="EcsDocument"/> </summary>
		public static EcsDocument Deserialize(Stream stream) => EcsSerializerFactory<EcsDocument>.Deserialize(stream);

		// ReSharper disable once UnusedMember.Global
		/// <summary> Deserialize asynchronously a stream to <see cref="EcsDocument"/> </summary>
		public static ValueTask<EcsDocument> DeserializeAsync(Stream stream, CancellationToken ctx = default) =>
			EcsSerializerFactory<EcsDocument>.DeserializeAsync(stream, ctx);

		/// <summary> Serialize this <see cref="EcsDocument"/> instance to string</summary>
		public string Serialize() => JsonSerializer.Serialize(this, GetType(), SerializerOptions);

		// ReSharper disable once UnusedMember.Global
		/// <summary> Serialize this <see cref="EcsDocument"/> instance to utf8 bytes</summary>
		public byte[] SerializeToUtf8Bytes() => JsonSerializer.SerializeToUtf8Bytes(this, GetType(), SerializerOptions);

		private static ReusableUtf8JsonWriter CachedReusableUtf8JsonWriter;
		private static ReusableUtf8JsonWriter ReusableJsonWriter => CachedReusableUtf8JsonWriter ??= new ReusableUtf8JsonWriter();

		// ReSharper disable once UnusedMethodReturnValue.Global
		/// <summary> Serialize this <see cref="EcsDocument"/> instance to a StringBuilder</summary>
		public StringBuilder Serialize(StringBuilder stringBuilder)
		{
			using var reusableWriter = ReusableJsonWriter.AllocateJsonWriter(stringBuilder);
			reusableWriter.Serialize(this);
			return stringBuilder;
		}

		// ReSharper disable once UnusedMember.Global
		/// <summary> Serialize this <see cref="EcsDocument"/> instance to a Stream</summary>
		public void Serialize(Stream stream)
		{
			using var writer = new Utf8JsonWriter(stream, new JsonWriterOptions
			{
				Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
				Indented = false
			});
			JsonSerializer.Serialize(writer, this, SerializerOptions);
		}

		internal void Serialize(Utf8JsonWriter writer) => JsonSerializer.Serialize(writer, this, SerializerOptions);

		/// <summary> Serialize this <see cref="EcsDocument"/> instance to a Stream asynchronously</summary>
		public Task SerializeAsync(Stream stream, CancellationToken ctx = default) =>
			JsonSerializer.SerializeAsync(stream, this, GetType(), SerializerOptions, ctx);
	}
}
