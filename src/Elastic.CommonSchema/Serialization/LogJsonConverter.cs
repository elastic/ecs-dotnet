// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Text.Json;

namespace Elastic.CommonSchema.Serialization
{
	internal class LogJsonConverter : EcsJsonConverterBase<Log>
	{
		public override Log Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.Null)
			{
				reader.Read();
				return null;
			}
			if (reader.TokenType != JsonTokenType.StartObject) throw new JsonException();

			var log = new Log();

			string loglevel = null;
			string original = null;
			string logger = null;
			while (reader.Read())
			{
				if (reader.TokenType == JsonTokenType.EndObject)
					break;

				if (reader.TokenType != JsonTokenType.PropertyName)
					throw new JsonException();

				var propertyName = reader.GetString();
				reader.Read();
				var read = propertyName switch
				{
					"origin" => ReadProp<LogOrigin>(ref reader, "origin", log, (b, v) => b.Origin = v),
					"original" => ReadString(ref reader, ref original),
					"level" => ReadString(ref reader, ref loglevel),
					"syslog" => ReadProp<LogSyslog[]>(ref reader, "syslog", log, (b, v) => b.Syslog = v),
					"logger" => ReadString(ref reader, ref logger),
					_ => false
				};
			}
			return log;
		}


		public override void Write(Utf8JsonWriter writer, Log value, JsonSerializerOptions options)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();

			writer.WriteString("logger", value.Logger);
			writer.WriteString("original", value.Logger);

			WriteProp(writer, "origin", value.Origin); // 3
			WriteProp(writer, "syslog", value.Syslog); // 4
			writer.WriteEndObject();
		}
	}
}
