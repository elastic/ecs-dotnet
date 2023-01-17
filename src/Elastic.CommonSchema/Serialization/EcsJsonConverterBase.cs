// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Elastic.CommonSchema.Serialization
{
	public abstract class EcsJsonConverterBase<T> : JsonConverter<T>
	{
		protected static bool ReadDateTime(ref Utf8JsonReader reader, ref DateTimeOffset? set)
		{
			if (reader.TokenType == JsonTokenType.Null)
			{
				set = null;
				return true;
			}

			set = EcsJsonConfiguration.DateTimeOffsetConverter.Read(ref reader, typeof(DateTimeOffset), EcsJsonConfiguration.SerializerOptions);
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

			var options = EcsJsonConfiguration.SerializerOptions;

			writer.WritePropertyName(key);
			// Attempt to use existing converter first before re-entering through JsonSerializer.Serialize().
			// The default converter for object does not support writing.
			var type = value.GetType();
			if (typeof(TValue) != typeof(object) && type == typeof(TValue) && (options?.GetConverter(typeof(TValue)) is JsonConverter<TValue> keyConverter))
				keyConverter.Write(writer, value, options);
			else
				JsonSerializer.Serialize(writer, value, type, options);
		}

		protected static void WriteProp<TValue>(Utf8JsonWriter writer, string key, TValue value, JsonTypeInfo<TValue> typeInfo)
		{
			if (value == null) return;

			writer.WritePropertyName(key);
			var type = value.GetType();

			//To support user supplied subtypes
			if (type != typeof(TValue))
				JsonSerializer.Serialize(writer, value, type, EcsJsonConfiguration.SerializerOptions);
			else JsonSerializer.Serialize(writer, value, typeInfo);
		}

		internal static object ReadPropDeserialize(ref Utf8JsonReader reader, Type type)
		{
			if (reader.TokenType == JsonTokenType.Null) return null;

			var options = EcsJsonConfiguration.SerializerOptions;

			return JsonSerializer.Deserialize(ref reader, type, options);
		}

		private static long? ReadPropLong(ref Utf8JsonReader reader, string key)
		{
			if (reader.TokenType == JsonTokenType.PropertyName) reader.Read();
			return reader.TokenType != JsonTokenType.Number ? null : reader.TryGetInt64(out var l) ? l : null;
		}

		protected static bool ReadPropLong(ref Utf8JsonReader reader, string key, T b, Action<T, long?> set)
		{
			set(b, ReadPropLong(ref reader, key));
			return true;
		}

		private static string ReadPropString(ref Utf8JsonReader reader, string key)
		{
			if (reader.TokenType == JsonTokenType.PropertyName) reader.Read();
			return reader.TokenType != JsonTokenType.String ? null : reader.GetString();
		}

		protected static bool ReadPropString(ref Utf8JsonReader reader, string key, T b, Action<T, string> set)
		{
			set(b, ReadPropString(ref reader, key));
			return true;
		}

		private static TValue ReadProp<TValue>(ref Utf8JsonReader reader, string key)  where TValue : class
		{
			if (reader.TokenType == JsonTokenType.Null) return null;

			var options = EcsJsonConfiguration.SerializerOptions;
			return JsonSerializer.Deserialize<TValue>(ref reader, options);
		}

		protected static bool ReadProp<TValue>(ref Utf8JsonReader reader, string key, T b, Action<T, TValue> set)
			where TValue : class
		{
			set(b, ReadProp<TValue>(ref reader, key));
			return true;
		}
		protected static bool ReadProp<TValue>(ref Utf8JsonReader reader, string key, JsonTypeInfo<TValue> typeInfo, T b, Action<T, TValue> set)
			where TValue : class
		{
			var value = JsonSerializer.Deserialize<TValue>(ref reader, typeInfo);
			set(b, value);
			return true;
		}
	}
}
