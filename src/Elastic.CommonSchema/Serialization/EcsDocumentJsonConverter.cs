// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.Serialization;

/// <summary> A JsonConverter for <see cref="EcsDocument"/> that supports the
/// https://github.com/elastic/ecs-logging specification
/// </summary>
public partial class EcsDocumentJsonConverter<TBase> where TBase : EcsDocument, new()
{
	/// <inheritdoc cref="JsonConverter{T}.Read"/>
	public override TBase? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.Null)
		{
			reader.Read();
			return null;
		}
		if (reader.TokenType != JsonTokenType.StartObject)
			throw new JsonException();

		var ecsEvent = new TBase();

		string? loglevel = null;
		string? ecsVersion = null;
		DateTimeOffset? timestamp = default;
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
				throw new JsonException();

			var _ = ReadProperties(ref reader, ecsEvent, ref timestamp, ref loglevel, ref ecsVersion, options);
		}
		if (!string.IsNullOrEmpty(loglevel))
		{
			ecsEvent.Log ??= new Log();
			ecsEvent.Log.Level = loglevel;
		}
		if (!string.IsNullOrEmpty(ecsVersion))
		{
			ecsEvent.Ecs ??= new Ecs();
			ecsEvent.Ecs.Version = ecsVersion;
		}
		ecsEvent.Timestamp = timestamp;

		return ecsEvent;
	}

	private static void WriteMessage(Utf8JsonWriter writer, EcsDocument value)
	{
		if (!string.IsNullOrEmpty(value.Message))
			writer.WriteString("message", value.Message);
	}

	private static void WriteLogEntity(Utf8JsonWriter writer, Log? value, JsonSerializerOptions options) {
		if (value == null) return;
		if (!value.ShouldSerialize) return;

		WriteProp(writer, "log", value, EcsJsonContext.Default.Log, options);
	}

	private static void WriteLogLevel(Utf8JsonWriter writer, EcsDocument value)
	{
		if (!string.IsNullOrEmpty(value.Log?.Level))
			writer.WriteString("log.level", value.Log?.Level);
	}

	private static void WriteEcsEntity(Utf8JsonWriter writer, Ecs? value, JsonSerializerOptions options)
	{
		if (value == null) return;
		if (!value.ShouldSerialize) return;

		WriteProp(writer, "ecs", value, EcsJsonContext.Default.Ecs, options);
	}

	private static void WriteEcsVersion(Utf8JsonWriter writer, EcsDocument value) =>
		writer.WriteString("ecs.version", value.Ecs?.Version ?? EcsDocument.Version);

	private static void WriteTimestamp(Utf8JsonWriter writer, BaseFieldSet value, JsonSerializerOptions options)
	{
		if (!value.Timestamp.HasValue) return;

		writer.WritePropertyName("@timestamp");
		var converter = GetDateTimeOffsetConverter(options);
		converter.Write(writer, value.Timestamp.Value, options);
	}

	[System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "We always provide a static JsonTypeInfoResolver")]
	[System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage("AotAnalysis", "IL3050:RequiresDynamicCode", Justification = "We always provide a static JsonTypeInfoResolver")]
	private static bool ReadOTelAttributes(ref Utf8JsonReader reader, TBase ecsEvent, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.Null)
			return true;

		if (reader.TokenType != JsonTokenType.StartObject)
			return false;

		ecsEvent.Attributes ??= new MetadataDictionary();

		while (reader.Read())
		{
			if (reader.TokenType == JsonTokenType.EndObject)
				break;

			if (reader.TokenType != JsonTokenType.PropertyName)
				throw new JsonException("Expected property name in attributes object");

			var attrName = reader.GetString()!;
			reader.Read();

			object? value = reader.TokenType switch
			{
				JsonTokenType.String => reader.GetString(),
				JsonTokenType.Number => reader.TryGetInt64(out var l) ? l : reader.GetDouble(),
				JsonTokenType.True => true,
				JsonTokenType.False => false,
				JsonTokenType.Null => null,
				_ => JsonSerializer.Deserialize<object>(ref reader, options)
			};

			// Store in Attributes
			ecsEvent.Attributes[attrName] = value;

			// If there's an OTel->ECS mapping, also set the ECS property
			if (value != null)
			{
				if (OTelMappings.OTelToEcs.TryGetValue(attrName, out var ecsPath))
					ecsEvent.AssignField(ecsPath, value);
				else
					// For match relations, OTel name IS the ECS name
					ecsEvent.AssignField(attrName, value);
			}
		}
		return true;
	}
}

/// <summary> A JsonConverter for <see cref="EcsDocument"/> that supports the
/// https://github.com/elastic/ecs-logging specification
/// </summary>
public class EcsDocumentJsonConverter : EcsDocumentJsonConverter<EcsDocument>;
