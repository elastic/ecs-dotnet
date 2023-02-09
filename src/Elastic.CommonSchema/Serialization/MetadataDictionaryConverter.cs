// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.Serialization
{
	internal class MetadataDictionaryConverter : JsonConverter<MetadataDictionary>
	{
		internal class MetaDataSerializationFailure
		{
			[JsonPropertyName("reason"), DataMember(Name = "reason")]
			public string SerializationFailure { get; set; }

			[JsonPropertyName("key"), DataMember(Name = "key")]
			public string Property { get; set; }
		}

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

			List<MetaDataSerializationFailure> failures = null;

			foreach (var kvp in value)
			{
				var propertyName = kvp.Key;

				if (kvp.Value == null)
				{
					writer.WritePropertyName(propertyName);
					writer.WriteNullValue();
				}
				else
				{
					try
					{
						// The following is not safe
						// JsonSerializer.Serialize(writer, kvp.Value, inputType, options);
						// If a getter throws an exception we risk not logging anything

						var bytes = JsonSerializer.SerializeToUtf8Bytes(kvp.Value, options);
						writer.WritePropertyName(propertyName);
						writer.WriteRawValue(bytes);
					}
					catch (Exception e)
					{
						failures ??= new List<MetaDataSerializationFailure>();
						failures.Add(new MetaDataSerializationFailure { Property = propertyName, SerializationFailure = e.Message });
					}
				}
			}
			if (failures != null)
			{
				writer.WritePropertyName("__failures__");
				JsonSerializer.Serialize(writer, failures, typeof(List<MetaDataSerializationFailure>), options);
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
				case JsonTokenType.Number:
					return reader.TryGetInt64(out var result) ? result : reader.TryGetDouble(out var d) ? d : reader.GetDecimal();
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
