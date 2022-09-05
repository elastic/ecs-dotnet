// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

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

		internal static object ReadPropDeserialize(ref Utf8JsonReader reader, Type type)
		{
			if (reader.TokenType == JsonTokenType.Null) return null;

			var options = EcsJsonConfiguration.SerializerOptions;

			return JsonSerializer.Deserialize(ref reader, type, options);
		}

		protected static TValue ReadProp<TValue>(ref Utf8JsonReader reader, string key)  where TValue : class
		{
			if (reader.TokenType == JsonTokenType.Null) return null;

			var options = EcsJsonConfiguration.SerializerOptions;

			/*
			 * System.NullReferenceException : Object reference not set to an instance of an object.
  Stack Trace:
     at System.Text.Json.JsonSerializer.LookupProperty(Object obj, ReadOnlySpan`1 unescapedPropertyName, ReadStack& state, Boolean& useExtensionProperty, Boolean createExtensionProperty)
   at System.Text.Json.Serialization.Converters.ObjectDefaultConverter`1.OnTryRead(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options, ReadStack& state, T& value)
   at System.Text.Json.Serialization.JsonConverter`1.TryRead(Utf8JsonReader& reader, Type typeToConvert, JsonSerializerOptions options, ReadStack& state, T& value)
			 *
			 * This used to be a documented fast path that appears to be broken with STJ 5.0. Leaving this commented out to revisit the true performance impact
			 */

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
