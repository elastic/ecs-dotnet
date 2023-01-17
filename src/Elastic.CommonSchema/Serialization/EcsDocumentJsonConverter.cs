// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Text.Json;

namespace Elastic.CommonSchema.Serialization
{
	public partial class EcsDocumentJsonConverter<TBase> where TBase : EcsDocument, new()
	{
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
			DateTimeOffset? timestamp = default;
			while (reader.Read())
			{
				if (reader.TokenType == JsonTokenType.EndObject)
					break;

				if (reader.TokenType != JsonTokenType.PropertyName)
					throw new JsonException();

				var read = ReadProperties(ref reader, ecsEvent, ref timestamp, ref loglevel);
			}
			if (!string.IsNullOrEmpty(loglevel))
			{
				ecsEvent.Log ??= new Log();
				ecsEvent.Log.Level = loglevel;
			}
			ecsEvent.Timestamp = timestamp;

			return ecsEvent;
		}

		private static void WriteMessage(Utf8JsonWriter writer, EcsDocument value)
		{
			if (!string.IsNullOrEmpty(value?.Message))
				writer.WriteString("message", value.Message);
		}

		private static void WriteLogLevel(Utf8JsonWriter writer, EcsDocument value)
		{
			if (!string.IsNullOrEmpty(value?.Log?.Level))
				writer.WriteString("log.level", value.Log?.Level);
		}

		private static void WriteTimestamp(Utf8JsonWriter writer, BaseFieldSet value)
		{
			if (!value.Timestamp.HasValue) return;

			writer.WritePropertyName("@timestamp");
			EcsJsonConfiguration.DateTimeOffsetConverter.Write(writer, value.Timestamp.Value, EcsJsonConfiguration.SerializerOptions);
		}
	}

	public partial class EcsDocumentJsonConverter : EcsDocumentJsonConverter<EcsDocument>
	{
	}
}
