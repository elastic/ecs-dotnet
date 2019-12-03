using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.Serialization
{
	internal class MetaDataDictionaryConverter : JsonConverter<IDictionary<string, object>>
	{
		private static object ReadObject(ref Utf8JsonReader reader)
		{
			switch (reader.TokenType) {
				case JsonTokenType.True: return true;
				case JsonTokenType.False: return false;
				case JsonTokenType.Number when reader.TryGetInt64(out var l): return l;
				case JsonTokenType.Number: return reader.GetDouble();
				case JsonTokenType.String when reader.TryGetDateTime(out var datetime): return datetime;
				case JsonTokenType.String: return reader.GetString();
				default: {
					using var document = System.Text.Json.JsonDocument.ParseValue(ref reader);
					return document.RootElement.Clone();
				}
			}
		}

		public override IDictionary<string, object> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.StartObject)
				throw new JsonException();

			var value = new Dictionary<string, object>();

			while (reader.Read())
			{
				if (reader.TokenType == JsonTokenType.EndObject)
					return value;

				if (reader.TokenType != JsonTokenType.PropertyName)
					throw new JsonException();

				var key = reader.GetString();
				reader.Read();
				var v = ReadObject(ref reader);
				value.Add(key, v);
			}
			return value.Count == 0 ? null : value;
		}

		public override void Write(Utf8JsonWriter writer, IDictionary<string, object> value, JsonSerializerOptions options)
		{
			writer.WriteStartObject();

			foreach (var kvp in value)
			{
				writer.WritePropertyName(SnakeCaseJsonNamingPolicy.ToSnakeCase(kvp.Key));
				var t = kvp.Value.GetType();

				//TODO prevent reentry and cache get converters
				System.Text.Json.JsonSerializer.Serialize(writer, kvp.Value, t, options);
			}

			writer.WriteEndObject();
		}
	}
}
