// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.Serialization
{
	/// <summary> A JsonConverter for <see cref="EcsDocument"/> that supports the
	/// https://github.com/elastic/ecs-logging specification
	/// </summary>
	public partial class EcsDocumentJsonConverter<TBase> where TBase : EcsDocument, new()
	{
		/// <inheritdoc cref="JsonConverter{T}.Read"/>
		public override TBase Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.Null)
			{
				reader.Read();
				return null;
			}
			if (reader.TokenType != JsonTokenType.StartObject)
				throw new JsonException();

			var ecsEvent = new TBase();

			string loglevel = null;
			string ecsVersion = null;
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

				var _ = ReadProperties(ref reader, ecsEvent, ref timestamp, ref loglevel, ref ecsVersion);
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
			if (!string.IsNullOrEmpty(value?.Message))
				writer.WriteString("message", value.Message);
		}

		private static void WriteLogEntity(Utf8JsonWriter writer, Log value) {
			if (value == null) return;
			if (!value.ShouldSerialize) return;

			WriteProp(writer, "log", value, EcsJsonContext.Default.Log);
		}

		private static void WriteLogLevel(Utf8JsonWriter writer, EcsDocument value)
		{
			if (!string.IsNullOrEmpty(value?.Log?.Level))
				writer.WriteString("log.level", value.Log?.Level);
		}

		private static void WriteEcsEntity(Utf8JsonWriter writer, Ecs value) {
			if (value == null) return;
			if (!value.ShouldSerialize) return;

			WriteProp(writer, "ecs", value, EcsJsonContext.Default.Ecs);
		}

		private static void WriteEcsVersion(Utf8JsonWriter writer, EcsDocument value) =>
			writer.WriteString("ecs.version", value.Ecs?.Version ?? EcsDocument.Version);

		private static void WriteTimestamp(Utf8JsonWriter writer, BaseFieldSet value)
		{
			if (!value.Timestamp.HasValue) return;

			writer.WritePropertyName("@timestamp");
			EcsJsonConfiguration.DateTimeOffsetConverter.Write(writer, value.Timestamp.Value, EcsJsonConfiguration.SerializerOptions);
		}
	}

	/// <summary> A JsonConverter for <see cref="EcsDocument"/> that supports the
	/// https://github.com/elastic/ecs-logging specification
	/// </summary>
	public class EcsDocumentJsonConverter : EcsDocumentJsonConverter<EcsDocument>
	{
	}
}
