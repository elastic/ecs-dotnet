// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using Utf8Json;

namespace Elastic.CommonSchema.Serialization
{
	internal partial class EcsUtf8JsonFormatterBase<TBase>
	{
		public bool ReadRef<T>(ref JsonReader reader, ref T set, IJsonFormatterResolver formatterResolver)
		{
			var formatter = formatterResolver.GetFormatter<T>();
			set = formatter.Deserialize(ref reader, formatterResolver);
			return true;
		}
		public bool Read<TProp>(ref JsonReader reader, TBase b, Action<TBase, TProp> set, IJsonFormatterResolver formatterResolver)
		{
			var formatter = formatterResolver.GetFormatter<TProp>();
			set(b, formatter.Deserialize(ref reader, formatterResolver));
			return true;
		}

		public static bool ReadString(ref JsonReader reader, ref string stringProp)
		{
			stringProp = reader.ReadString();
			return true;
		}
	}


	internal class LogJsonFormatter : EcsUtf8JsonFormatterBase<Log>, IJsonFormatter<Log>
	{
		private static IncrementingAutomataDictionary AutomataDictionary { get; } = new IncrementingAutomataDictionary
		{
			// Base fields
			{ "origin" }, // 0
			{ "original" }, // 1
			{ "level" }, // 2
			{ "syslog" }, // 3
			{ "logger" }, // 4
		};
		public Log Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver)
		{
			if (reader.ReadIsNull()) return null;

			var count = 0;
			var log = new Log();
			string loglevel = null;
			string original = null;
			string logger = null;

			while (reader.ReadIsInObject(ref count))
			{
				var propertyName = reader.ReadPropertyNameSegmentRaw();
				if (AutomataDictionary.TryGetValue(propertyName, out var value))
				{
					var read = _ = value switch
					{
						0 => Read<LogOrigin>(ref reader, log, (b, v) => b.Origin = v, formatterResolver),
						1 => ReadString(ref reader, ref original),
						2 => ReadString(ref reader, ref loglevel),
						3 => Read<LogSyslog[]>(ref reader, log, (b, v) => b.Syslog = v, formatterResolver),
						4 => ReadString(ref reader, ref logger),
						_ => false
					};
					if (!read)
						reader.ReadNext();
				}
				else reader.ReadNext();
			}
			log.Level = loglevel;
			log.Original = original;
			log.Logger = logger;
			return log;
		}

		public void Serialize(ref JsonWriter writer, Log value, IJsonFormatterResolver formatterResolver)
		{
			if (value == null) return;

			writer.WriteBeginObject();
			var written = false;
			WriteProp(ref writer, "original", value.Original, formatterResolver, ref written);
			WriteProp(ref writer, "origin", value.Origin, formatterResolver, ref written);
			WriteProp(ref writer, "syslog", value.Syslog, formatterResolver, ref written);
			WriteProp(ref writer, "logger", value.Logger, formatterResolver, ref written);
			writer.WriteEndObject();
		}

		private static void WriteProp<T>(ref JsonWriter writer, string key, T value, IJsonFormatterResolver formatterResolver, ref bool written)
		{
			if (value == null) return;

			if (written)
				writer.WriteNameSeparator();
			writer.WritePropertyName(key);
			var formatter = formatterResolver.GetFormatter<T>();
			formatter.Serialize(ref writer, value, formatterResolver);
			written = true;
		}
	}
}
