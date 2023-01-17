// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

/*
IMPORTANT NOTE
==============
This file has been generated. 
If you wish to submit a PR please modify the original csharp file and submit the PR with that change. Thanks!
*/

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Elastic.CommonSchema.Serialization
{
	public partial class EcsLogJsonConverter : EcsJsonConverterBase<Log>
	{
		private static bool ReadProperties(ref Utf8JsonReader reader, Log ecsEvent)
		{
			var propertyName = reader.GetString();
			reader.Read();
			return propertyName switch
			{
				"file.path" => ReadPropString(ref reader, "file.path", ecsEvent, (b, v) => b.FilePath = v),
				"level" => ReadPropString(ref reader, "level", ecsEvent, (b, v) => b.Level = v),
				"logger" => ReadPropString(ref reader, "logger", ecsEvent, (b, v) => b.Logger = v),
				"origin.file.line" => ReadPropLong(ref reader, "origin.file.line", ecsEvent, (b, v) => b.OriginFileLine = v),
				"origin.file.name" => ReadPropString(ref reader, "origin.file.name", ecsEvent, (b, v) => b.OriginFileName = v),
				"origin.function" => ReadPropString(ref reader, "origin.function", ecsEvent, (b, v) => b.OriginFunction = v),
				"syslog" => ReadProp<LogSyslog>(ref reader, "syslog", ecsEvent, (b, v) => b.Syslog = v),
				_ => false
			};
		}

		public override void Write(Utf8JsonWriter writer, Log value, JsonSerializerOptions options)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			if (
			value.FilePath == null &&
				value.Logger == null &&
				value.OriginFileLine == null &&
				value.OriginFileName == null &&
				value.OriginFunction == null &&
			value.Syslog == null &&
			true) {
				writer.WriteNullValue();
				return;
			}
			writer.WriteStartObject();

			WriteProp(writer, "file.path", value.FilePath);
				WriteProp(writer, "logger", value.Logger);
				WriteProp(writer, "origin.file.line", value.OriginFileLine);
				WriteProp(writer, "origin.file.name", value.OriginFileName);
				WriteProp(writer, "origin.function", value.OriginFunction);
			WriteProp(writer, "syslog", value.Syslog);

			writer.WriteEndObject();
		}
	}
}