// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.Serialization;

/// Deserialize a dictionary of metadata
public class MetadataDictionaryConverter : JsonConverter<MetadataDictionary>
{
	internal class MetaDataSerializationFailure
	{
		[JsonPropertyName("reason"), DataMember(Name = "reason")]
		public string? SerializationFailure { get; set; }

		[JsonPropertyName("key"), DataMember(Name = "key")]
		public string? Property { get; set; }
	}

	/// <inheritdoc/>
	public override MetadataDictionary? Read(ref Utf8JsonReader reader, Type? typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType != JsonTokenType.StartObject)
			throw new JsonException($"JsonTokenType was of type {reader.TokenType}, only objects are supported");

		var dictionary = new MetadataDictionary();
		var originalDepth = reader.CurrentDepth;
		while (reader.Read())
		{
			if (reader.TokenType == JsonTokenType.EndObject)
			{
				if (reader.CurrentDepth <= originalDepth)
					break;
				continue;
			}

			if (reader.TokenType != JsonTokenType.PropertyName)
				throw new JsonException("JsonTokenType was not PropertyName");

			var propertyName = reader.GetString();

			if (propertyName.IsNullOrEmpty())
				throw new JsonException("Failed to get property name");

			reader.Read();
			var value = ExtractValue(ref reader, options);
			dictionary.Add(propertyName, value);
		}

		return dictionary.Count > 0 ? dictionary : null;
	}

	/// <inheritdoc/>
	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "We always provide a static JsonTypeInfoResolver")]
	[UnconditionalSuppressMessage("AotAnalysis", "IL3050:RequiresDynamicCode", Justification = "We always provide a static JsonTypeInfoResolver")]
	public override void Write(Utf8JsonWriter writer, MetadataDictionary value, JsonSerializerOptions options)
	{
		writer.WriteStartObject();

		List<MetaDataSerializationFailure>? failures = null;

		foreach (var kvp in value)
		{
			var propertyName = kvp.Key;

			try
			{
				// The following is not safe
				// JsonSerializer.Serialize(writer, kvp.Value, inputType, options);
				// If a getter throws an exception we risk not logging anything
				WriteProp(writer, propertyName, kvp.Value, options);
			}
			catch (Exception e)
			{
				failures ??= new List<MetaDataSerializationFailure>();
				failures.Add(new MetaDataSerializationFailure { Property = propertyName, SerializationFailure = e.Message });
			}
		}
		if (failures != null)
		{
			writer.WritePropertyName("__failures__");
			JsonSerializer.Serialize(writer, failures, typeof(List<MetaDataSerializationFailure>), options);
		}
		writer.WriteEndObject();
	}

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "We always provide a static JsonTypeInfoResolver")]
	[UnconditionalSuppressMessage("AotAnalysis", "IL3050:RequiresDynamicCode", Justification = "We always provide a static JsonTypeInfoResolver")]
	private static void WriteProp(Utf8JsonWriter writer, string key, object? value, JsonSerializerOptions options)
	{
		if (value is null)
		{
			writer.WritePropertyName(key);
			writer.WriteNullValue();
			return;
		}

		// Recognize common types and write directly without GetTypeInfo<TValue>
		switch (value)
		{
			case int v:
				writer.WritePropertyName(key);
				writer.WriteNumberValue(v);
				break;
			case uint v:
				writer.WritePropertyName(key);
				writer.WriteNumberValue(v);
				break;
			case long v:
				writer.WritePropertyName(key);
				writer.WriteNumberValue(v);
				break;
			case ulong v:
				writer.WritePropertyName(key);
				writer.WriteNumberValue(v);
				break;
			case float v:
				{
					writer.WritePropertyName(key);
#if NET || NETSTANDARD2_1_OR_GREATER
					WriteFormattedNumber(writer, v);
#else
					if(float.IsNaN(v) || float.IsInfinity(v))
						writer.WriteStringValue(v.ToString(System.Globalization.CultureInfo.InvariantCulture));
					else
						writer.WriteNumberValue(v);
#endif
				}
				break;
			case double v:
				{
					writer.WritePropertyName(key);
#if NET || NETSTANDARD2_1_OR_GREATER
					WriteFormattedNumber(writer, v);
#else
					if(double.IsNaN(v) || double.IsInfinity(v))
						writer.WriteStringValue(v.ToString(System.Globalization.CultureInfo.InvariantCulture));
					else
						writer.WriteNumberValue(v);
#endif
				}
				break;
			case decimal v:
				{
					writer.WritePropertyName(key);
#if NET || NETSTANDARD2_1_OR_GREATER
					WriteFormattedNumber(writer, v);
#else
					writer.WriteNumberValue(v);
#endif
				}
				break;
			case bool v:
				writer.WritePropertyName(key);
				writer.WriteBooleanValue(v);
				break;
			case char v:
				{
					writer.WritePropertyName(key);
#if NET || NETSTANDARD2_1_OR_GREATER
					Span<char> buffer = [v];
#else
					var buffer = v.ToString();
#endif
					writer.WriteStringValue(buffer);
				}
				break;
			case string v:
				writer.WritePropertyName(key);
				writer.WriteStringValue(v);
				break;
			case Guid v:
				writer.WritePropertyName(key);
				writer.WriteStringValue(v);
				break;
			case DateTime v:
				writer.WritePropertyName(key);
				writer.WriteStringValue(v);
				break;
			case DateTimeOffset v:
				writer.WritePropertyName(key);
				writer.WriteStringValue(v);
				break;
			case Enum v:
				writer.WritePropertyName(key);
				writer.WriteStringValue(v.ToString());
				break;
			default:
				// Unknown/Unsafe so serialize before writing property name to avoid writing an invalid JSON document.
				var bytes = JsonSerializer.SerializeToUtf8Bytes(value, options);
				writer.WritePropertyName(key);
				writer.WriteRawValue(bytes);
				break;
		}
	}

#if NET || NETSTANDARD2_1_OR_GREATER
	private static void WriteFormattedNumber(Utf8JsonWriter writer, float value)
	{
		Span<byte> buffer = stackalloc byte[32];

		if (!System.Buffers.Text.Utf8Formatter.TryFormat(value, buffer, out var written))
			throw new InvalidOperationException("Buffer too small.");

		writer.WriteRawValue(EnsureDecimal(buffer, written), skipInputValidation: true);
	}

	private static void WriteFormattedNumber(Utf8JsonWriter writer, double value)
	{
		Span<byte> buffer = stackalloc byte[32];

		if (!System.Buffers.Text.Utf8Formatter.TryFormat(value, buffer, out var written))
			throw new InvalidOperationException("Buffer too small.");

		writer.WriteRawValue(EnsureDecimal(buffer, written), skipInputValidation: true);
	}

	private static void WriteFormattedNumber(Utf8JsonWriter writer, decimal value)
	{
		Span<byte> buffer = stackalloc byte[32];
		Span<char> chars = stackalloc char[32];

		if (!value.TryFormat(chars, out var written, default, System.Globalization.CultureInfo.InvariantCulture))
			throw new InvalidOperationException("Buffer too small.");

		var hasDecimalPoint = false;
		for (var i = 0; i < written; i++)
		{
			hasDecimalPoint |= chars[i] == '.';
			buffer[i] = (byte)chars[i];
		}

		if (!hasDecimalPoint)
		{
			// Force an explicit decimal representation.
			buffer[written++] = (byte)'.';
			buffer[written++] = (byte)'0';
		}

		writer.WriteRawValue(buffer[..written], skipInputValidation: true);
	}

	private static ReadOnlySpan<byte> EnsureDecimal(Span<byte> buffer, int written)
	{
		var span = buffer[..written];
		if (span.IndexOfAny((byte)'.', (byte)'e', (byte)'E') >= 0)
			return span;

		var firstChar = span.Length > 0 ? span[0] : 0;
		if (firstChar == (byte)'N' || firstChar == (byte)'I' || (firstChar == (byte)'-' && span[1] == (byte)'I'))
		{
			// NaN or Infinity, wrap in quotes to make it valid JSON
			span.CopyTo(buffer[1..]);   // Move 1 forward
			buffer[0] = (byte)'"';
			buffer[written + 1] = (byte)'"';
			return buffer[..(written + 2)];
		}

		// Force an explicit decimal representation.
		buffer[written++] = (byte)'.';
		buffer[written++] = (byte)'0';
		return buffer[..written];
	}
#endif

	private object? ExtractValue(ref Utf8JsonReader reader, JsonSerializerOptions options)
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
				var list = new List<object?>();
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
