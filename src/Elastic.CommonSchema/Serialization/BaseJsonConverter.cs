using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Elastic.CommonSchema.Serialization
{
	internal partial class BaseJsonConverter : EcsJsonConverterBase<Base>
	{
		public override Base Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.Null)
			{
				reader.Read();
				return null;
			}
			if (reader.TokenType != JsonTokenType.StartObject) throw new JsonException();

			var ecsEvent = new Base();

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
			ecsEvent.Log ??= new Log();
			ecsEvent.Log.Level = loglevel;
			ecsEvent.Timestamp = timestamp;

			return ecsEvent;
		}

		private static void WriteMessage(Utf8JsonWriter writer, Base value) => writer.WriteString("message", value.Message);

		private static void WriteLogLevel(Utf8JsonWriter writer, Base value) => writer.WriteString("log.level", value.Log?.Level);

		private static void WriteTimestamp(Utf8JsonWriter writer, Base value)
		{
			writer.WritePropertyName("@timestamp");
			if (value.Timestamp.HasValue)
				JsonConfiguration.DateTimeOffsetConverter.Write(writer, value.Timestamp.Value, JsonConfiguration.SerializerOptions);
			else writer.WriteNullValue();
		}
	}
}
