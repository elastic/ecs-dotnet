// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using Utf8Json;

namespace Elastic.CommonSchema.Serialization
{
	internal class LogJsonFormatter : IJsonFormatter<Log>
	{
		public Log Deserialize(ref JsonReader reader, IJsonFormatterResolver formatterResolver) => throw new NotImplementedException();

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
