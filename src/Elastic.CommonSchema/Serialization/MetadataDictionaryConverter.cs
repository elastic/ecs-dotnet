// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.Serialization
{
	internal class MetadataDictionaryConverter : JsonConverter<MetadataDictionary>
	{
		public override MetadataDictionary Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.StartObject)
				throw new JsonException($"JsonTokenType was of type {reader.TokenType}, only objects are supported");

			var dictionary = new MetadataDictionary();
			while (reader.Read())
			{
				if (reader.TokenType == JsonTokenType.EndObject)
					return dictionary;

				if (reader.TokenType != JsonTokenType.PropertyName)
					throw new JsonException("JsonTokenType was not PropertyName");

				var propertyName = reader.GetString();

				if (string.IsNullOrWhiteSpace(propertyName))
					throw new JsonException("Failed to get property name");

				reader.Read();

				dictionary.Add(propertyName, ExtractValue(ref reader, options));
			}

			return dictionary.Count > 0 ? dictionary : null;
		}

		public override void Write(Utf8JsonWriter writer, MetadataDictionary value, JsonSerializerOptions options)
		{
			writer.WriteStartObject();

			foreach (var kvp in value)
			{
				var propertyName = kvp.Key;
				writer.WritePropertyName(propertyName);

				if (kvp.Value == null)
					writer.WriteNullValue();
				else
				{
					var inputType = kvp.Value.GetType();
					//TODO prevent reentry and cache get converters
					JsonSerializer.Serialize(writer, kvp.Value, inputType, options);
				}
			}
			writer.WriteEndObject();
		}

		private object ExtractValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
		{
			switch (reader.TokenType)
			{
				case JsonTokenType.String when reader.TryGetDateTime(out var date): return date;
				case JsonTokenType.String: return reader.GetString();
				case JsonTokenType.False: return false;
				case JsonTokenType.True: return true;
				case JsonTokenType.Null: return null;
				case JsonTokenType.Number: return reader.TryGetInt64(out var result) ? result : reader.TryGetDouble(out var d) ? d : reader.GetDecimal();
				case JsonTokenType.StartObject:
					return Read(ref reader, null, options);
				case JsonTokenType.StartArray:
					var list = new List<object>();
					while (reader.Read() && reader.TokenType != JsonTokenType.EndArray) list.Add(ExtractValue(ref reader, options));
					return list;
				case JsonTokenType.None:
				case JsonTokenType.EndObject:
				case JsonTokenType.EndArray:
				case JsonTokenType.PropertyName:
				case JsonTokenType.Comment:
				default:
					throw new JsonException($"'{reader.TokenType}' is not supported");
			}
		}
	}
}
