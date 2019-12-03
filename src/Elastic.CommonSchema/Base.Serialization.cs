// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Text.Json;
using System.Text.Json.Serialization;
using Elastic.CommonSchema.Serialization;

namespace Elastic.CommonSchema
{
	[JsonConverter(typeof(BaseJsonConverter))]
	public partial class Base
	{
		public byte[] Serialize() => JsonSerializer.SerializeToUtf8Bytes(this, JsonConfiguration.SerializerOptions);

		public static Base Deserialize(string s) =>
			JsonSerializer.Deserialize<Base>(s, JsonConfiguration.SerializerOptions);
	}
}
