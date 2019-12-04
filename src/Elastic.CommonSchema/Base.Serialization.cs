// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Buffers;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Elastic.CommonSchema.Serialization;

namespace Elastic.CommonSchema
{
	[JsonConverter(typeof(BaseJsonConverter))]
	public partial class Base
	{

		public static Base Deserialize(string s) =>
			JsonSerializer.Deserialize<Base>(s, JsonConfiguration.SerializerOptions);

		public static Base Deserialize(ReadOnlySpan<byte> json) =>
			JsonSerializer.Deserialize<Base>(json, JsonConfiguration.SerializerOptions);

		public static Base Deserialize(Stream s)
		{
			using var ms = new MemoryStream();
			var buffer = ArrayPool<byte>.Shared.Rent(1024);
			var total = 0;
			int read;
			while ((read = s.Read(buffer, 0, buffer.Length)) > 0)
			{
				ms.Write(buffer, 0, read);
				total += read;
			}
			if (ms.TryGetBuffer(out var segment))
				return Deserialize(new ReadOnlyMemory<byte>(segment.Array, segment.Offset, total).Span);
			return Deserialize(new ReadOnlyMemory<byte>(ms.ToArray()).Span);
		}

		public static ValueTask<Base> DeserializeAsync(Stream s, CancellationToken cancellationToken = default) =>
			JsonSerializer.DeserializeAsync<Base>(s, JsonConfiguration.SerializerOptions, cancellationToken);

		public string Serialize() => JsonSerializer.Serialize(this, JsonConfiguration.SerializerOptions);

		public byte[] SerializeToUtf8Bytes() => JsonSerializer.SerializeToUtf8Bytes(this, JsonConfiguration.SerializerOptions);

		public void Serialize(Stream s)
		{
			using var writer = new Utf8JsonWriter(s);
			JsonSerializer.Serialize(writer, this, JsonConfiguration.SerializerOptions);
		}

		public Task SerializeAsync(Stream utf8Json, CancellationToken cancellationToken = default) =>
			JsonSerializer.SerializeAsync(utf8Json, this, JsonConfiguration.SerializerOptions, cancellationToken);

	}
}
