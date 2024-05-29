// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Elastic.CommonSchema.Serialization
{
	/// <summary> A base implementation for dedicated Ecs Fieldset json converters </summary>
	public abstract class EcsJsonConverterBase<T> : JsonConverter<T>
	{
		/// <summary></summary>
		protected static bool ReadDateTime(ref Utf8JsonReader reader, ref DateTimeOffset? dateTime, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.Null)
			{
				dateTime = null;
				return true;
			}

			var converter = (JsonConverter<DateTimeOffset>)options.GetConverter(typeof(DateTimeOffset));
			dateTime = converter.Read(ref reader, typeof(DateTimeOffset), options);
			return true;
		}

		/// <summary></summary>
		// ReSharper disable once RedundantAssignment
		protected static bool ReadString(ref Utf8JsonReader reader, ref string? stringProp)
		{
			stringProp = reader.GetString();
			return true;
		}

		/// <summary></summary>
		protected static void WritePropLong(Utf8JsonWriter writer, string key, long? value)
		{
			if (value == null) return;

			writer.WritePropertyName(key);
			writer.WriteNumberValue(value.Value);
		}

		/// <summary></summary>
		protected static void WritePropString(Utf8JsonWriter writer, string key, string? value)
		{
			if (value == null) return;

			writer.WritePropertyName(key);
			writer.WriteStringValue(value);
		}

		/// <summary></summary>
		protected static void WriteProp<TValue>(Utf8JsonWriter writer, string key, TValue value, JsonSerializerOptions options)
		{
			if (value == null) return;

			writer.WritePropertyName(key);
			// Attempt to use existing converter first before re-entering through JsonSerializer.Serialize().
			// The default converter for object does not support writing.
			JsonSerializer.Serialize<TValue>(writer, value, options);
		}

		/// <summary></summary>
		protected static void WriteProp<TValue>(Utf8JsonWriter writer, string key, TValue value, JsonTypeInfo<TValue> typeInfo,
			JsonSerializerOptions options)
		{
			if (value == null) return;

			writer.WritePropertyName(key);
			var type = value.GetType();

			//To support user supplied subtypes
			if (type != typeof(TValue))
				JsonSerializer.Serialize(writer, value, type, options);
			else JsonSerializer.Serialize(writer, value, typeInfo);
		}

		internal static object? ReadPropDeserialize(ref Utf8JsonReader reader, Type type, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.Null) return null;

			return JsonSerializer.Deserialize(ref reader, type, options);
		}

		// ReSharper disable once UnusedParameter.Local (key is used for readability)
		private static long? ReadPropLong(ref Utf8JsonReader reader, string key)
		{
			if (reader.TokenType == JsonTokenType.PropertyName) reader.Read();
			return reader.TokenType != JsonTokenType.Number ? null : reader.TryGetInt64(out var l) ? l : null;
		}

		/// <summary></summary>
		protected static bool ReadPropLong(ref Utf8JsonReader reader, string key, T b, Action<T, long?> set)
		{
			set(b, ReadPropLong(ref reader, key));
			return true;
		}

		/// <summary></summary>
		// ReSharper disable once UnusedParameter.Local (key is used for readability)
		private static string? ReadPropString(ref Utf8JsonReader reader, string key)
		{
			if (reader.TokenType == JsonTokenType.PropertyName) reader.Read();
			return reader.TokenType != JsonTokenType.String ? null : reader.GetString();
		}

		/// <summary></summary>
		protected static bool ReadPropString(ref Utf8JsonReader reader, string key, T b, Action<T, string?> set)
		{
			set(b, ReadPropString(ref reader, key));
			return true;
		}

		/// <summary></summary>
		// ReSharper disable once UnusedParameter.Local (key is used for readability)
		private static TValue? ReadProp<TValue>(ref Utf8JsonReader reader, string key, JsonSerializerOptions options)  where TValue : class
		{
			if (reader.TokenType == JsonTokenType.Null) return null;

			return JsonSerializer.Deserialize<TValue>(ref reader, options);
		}

		/// <summary></summary>
		protected static bool ReadProp<TValue>(ref Utf8JsonReader reader, string key, T b, Action<T, TValue?> set, JsonSerializerOptions options)
			where TValue : class
		{
			set(b, ReadProp<TValue>(ref reader, key, options));
			return true;
		}

		/// <summary></summary>
		// ReSharper disable once UnusedParameter.Local (key is used for readability)
		protected static bool ReadProp<TValue>(ref Utf8JsonReader reader, string key, JsonTypeInfo<TValue> typeInfo, T b, Action<T, TValue?> set)
			where TValue : class
		{
			try
			{
				var value = JsonSerializer.Deserialize(ref reader, typeInfo);
				set(b, value);
			}
			catch (Exception e)
			{
				throw new Exception(key, e);
			}
			return true;
		}
	}
}
