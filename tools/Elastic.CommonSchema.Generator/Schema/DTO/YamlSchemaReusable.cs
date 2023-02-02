// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Elastic.CommonSchema.Generator.Schema.DTO
{
	[JsonObject(MemberSerialization.OptIn)]
	public class YamlSchemaReusable
	{
		[JsonProperty("expected")]
		public List<Expected> Expected { get; set; }

		[JsonProperty("top_level")]
		public bool? TopLevel { get; set; }
	}

	[JsonObject(MemberSerialization.OptIn)]
	public class Expected
	{
		[JsonProperty("as")]
		public string As { get; set; }

		[JsonProperty("at")]
		public string At { get; set; }

		[JsonProperty("full")]
		public string Full { get; set; }

		[JsonProperty("beta")]
		public string Beta { get; set; }

		[JsonProperty("short_override")]
		public string ShortOverride { get; set; }

		/// <summary>
		/// Describes the normalisation of this field (e.g. array)
		/// </summary>
		[JsonProperty("normalize")]
		public string[] Normalize { get; set; }
	}

	public class ExpectedConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => throw new NotImplementedException();

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			switch (reader.TokenType)
			{
				case JsonToken.StartObject:
					var token = JToken.ReadFrom(reader);
					return token.ToObject<Expected>();
				case JsonToken.String:
					return new Expected { At = (string)reader.Value };
				case JsonToken.Null:
					return null;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		public override bool CanConvert(Type objectType) => objectType == typeof(Expected);
	}
}
