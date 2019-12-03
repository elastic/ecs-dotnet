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

		private static bool ReadProperties(
			ref Utf8JsonReader reader,
			Base ecsEvent,
			ref DateTimeOffset? timestamp,
			ref string loglevel
		)
		{
			var propertyName = reader.GetString();
			reader.Read();
			return propertyName switch
			{
				"@timestamp" => ReadDateTime(ref reader, ref timestamp),
				"log.level" => ReadString(ref reader, ref loglevel),
				"message" => ReadProp<string>(ref reader, "message", ecsEvent, (b, v) => b.Message = v),
				"_metadata" => ReadProp<Dictionary<string, object>>(ref reader, "_metadata", ecsEvent, (b, v) => b.Metadata = v),
				"labels" => ReadProp<Dictionary<string, object>>(ref reader, "labels", ecsEvent, (b, v) => b.Labels = v),
				"tags" => ReadProp<string[]>(ref reader, "tags", ecsEvent, (b, v) => b.Tags = v),
				"agent" => ReadProp<Agent>(ref reader, "agent", ecsEvent, (b, v) => b.Agent = v),
				"ecs" => ReadProp<Ecs>(ref reader, "ecs", ecsEvent, (b, v) => b.Ecs = v),
				"error" => ReadProp<Error>(ref reader, "error", ecsEvent, (b, v) => b.Error = v),
				"event" => ReadProp<Event>(ref reader, "event", ecsEvent, (b, v) => b.Event = v),
				"host" => ReadProp<Host>(ref reader, "host", ecsEvent, (b, v) => b.Host = v),
				"log" => ReadProp<Log>(ref reader, "log", ecsEvent, (b, v) => b.Log = v),
				"process" => ReadProp<Process>(ref reader, "process", ecsEvent, (b, v) => b.Process = v),
				_ => false
			};
		}

		public override void Write(Utf8JsonWriter writer, Base value, JsonSerializerOptions options)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();

			WriteTimestamp(writer, value, options);

			WriteLogLevel(writer, value);
			WriteMessage(writer, value);

			WriteProp(writer, "_metadata", value.Metadata); // 3
			WriteProp(writer, "labels", value.Labels); // 4
			WriteProp(writer, "tags", value.Tags); // 5
			// Complex types
			WriteProp(writer, "agent", value.Agent); // 6
			WriteProp(writer, "as", value.As); // 7
			WriteProp(writer, "client", value.Client); // 8
			WriteProp(writer, "cloud", value.Cloud); // 9
			WriteProp(writer, "container", value.Container); // 10
			WriteProp(writer, "destination", value.Destination); // 11
			WriteProp(writer, "dns", value.Dns); // 12
			WriteProp(writer, "ecs", value.Ecs); // 13
			WriteProp(writer, "error", value.Error); // 14
			WriteProp(writer, "event", value.Event); // 15
			WriteProp(writer, "file", value.File); // 16
			WriteProp(writer, "geo", value.Geo); // 17
			WriteProp(writer, "group", value.Group); // 18
			WriteProp(writer, "hash", value.Hash); // 19
			WriteProp(writer, "host", value.Host); // 20
			WriteProp(writer, "http", value.Http); // 21
			WriteProp(writer, "log", value.Log); // 22
			WriteProp(writer, "network", value.Network); // 23
			WriteProp(writer, "observer", value.Observer); // 24
			WriteProp(writer, "organization", value.Organization); // 25
			WriteProp(writer, "os", value.Os); // 26
			WriteProp(writer, "package", value.Package); // 27
			WriteProp(writer, "process", value.Process); // 28
			WriteProp(writer, "related", value.Related); // 29
			WriteProp(writer, "server", value.Server); // 30
			WriteProp(writer, "service", value.Service); // 31
			WriteProp(writer, "source", value.Source); // 32
			WriteProp(writer, "threat", value.Threat); // 33
			WriteProp(writer, "tls", value.Tls); // 34
			WriteProp(writer, "tracing", value.Tracing); // 35
			WriteProp(writer, "url", value.Url); // 36
			WriteProp(writer, "user", value.User); // 37
			WriteProp(writer, "user_agent", value.UserAgent); // 38
			WriteProp(writer, "vulnerability", value.Vulnerability); // 39

			writer.WriteEndObject();
		}

		private static void WriteMessage(Utf8JsonWriter writer, Base value) => writer.WriteString("message", value.Message);

		private static void WriteLogLevel(Utf8JsonWriter writer, Base value) => writer.WriteString("log.level", value.Log?.Level);

		private static void WriteTimestamp(Utf8JsonWriter writer, Base value, JsonSerializerOptions options)
		{
			writer.WritePropertyName("@timestamp");
			if (value.Timestamp.HasValue)
				JsonConfiguration.DateTimeOffsetConverter.Write(writer, value.Timestamp.Value, options);
			else writer.WriteNullValue();
		}
	}
}
