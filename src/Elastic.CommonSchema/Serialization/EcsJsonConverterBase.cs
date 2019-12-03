using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.Serialization
{
	internal abstract class EcsJsonConverterBase<T> : JsonConverter<T>
	{
		protected static bool ReadDateTime(ref Utf8JsonReader reader, ref DateTimeOffset? set)
		{
			if (reader.TokenType == JsonTokenType.Null)
				return reader.Read();

			set = JsonConfiguration.DateTimeOffsetConverter.Read(ref reader, typeof(DateTimeOffset), JsonConfiguration.SerializerOptions);
			return true;
		}

		protected static bool ReadString(ref Utf8JsonReader reader, ref string stringProp)
		{
			stringProp = reader.GetString();
			return true;
		}

		protected static void WriteProp<TValue>(Utf8JsonWriter writer, string key, TValue value)
		{
			if (value == null) return;

			var options = JsonConfiguration.SerializerOptions;

			writer.WritePropertyName(key);
			// Attempt to use existing converter first before re-entering through JsonSerializer.Serialize().
			// The default converter for object does not support writing.
			if (typeof(TValue) != typeof(object) && (options?.GetConverter(typeof(TValue)) is JsonConverter<TValue> keyConverter))
				keyConverter.Write(writer, value, options);
			else
				JsonSerializer.Serialize<TValue>(writer, value, options);
		}

		protected static TValue ReadProp<TValue>(ref Utf8JsonReader reader, string key)
			where TValue : class
		{
			if (reader.TokenType == JsonTokenType.Null) return null;

			var t = typeof(T);
			var options = JsonConfiguration.SerializerOptions;

			if (typeof(T) != typeof(object) && (options?.GetConverter(typeof(TValue)) is JsonConverter<TValue> keyConverter))
				return keyConverter.Read(ref reader, t, options);
			return JsonSerializer.Deserialize<TValue>(ref reader, options);
		}

		protected static bool ReadProp<TValue>(ref Utf8JsonReader reader, string key, T b, Action<T, TValue> set)
			where TValue : class
		{
			set(b, ReadProp<TValue>(ref reader, key));
			return true;
		}
	}
}
