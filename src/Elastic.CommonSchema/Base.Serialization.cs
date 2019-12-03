// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Buffers;
using System.IO;
using System.Text.Encodings.Web;
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

		public string Serialize() => JsonSerializer.Serialize(this, JsonConfiguration.SerializerOptions);

		public byte[] SerializeToUtf8Bytes() => JsonSerializer.SerializeToUtf8Bytes(this, JsonConfiguration.SerializerOptions);

		public Task SerializeAsync(Stream utf8Json, CancellationToken cancellationToken = default) =>
			JsonSerializer.SerializeAsync(utf8Json, this, JsonConfiguration.SerializerOptions, cancellationToken);

		public void Serialize(Stream s)
		{
			using var writer = new Utf8JsonWriter(s);
			JsonSerializer.Serialize(writer, this, JsonConfiguration.SerializerOptions);
		}
	}
}
