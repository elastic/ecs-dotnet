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
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.Serialization;


/// <summary> Specialized converter for <see cref="Log"/> </summary>
internal partial class LogEntityJsonConverter : PropertiesReaderJsonConverterBase<Log>
{
	/// <inheritdoc cref="PropertiesReaderJsonConverterBase{T}.ReadProperties"/>
	protected override bool ReadProperties(ref Utf8JsonReader reader, Log ecsEvent, JsonSerializerOptions options)
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
			"syslog" => ReadProp<LogSyslog>(ref reader, "syslog", ecsEvent, (b, v) => b.Syslog = v, options),
			_ => ReadProperty(ref reader, propertyName, ecsEvent, options)
		};
	}

	private partial bool ReadProperty(ref Utf8JsonReader reader, string propertyName, Log ecsEvent, JsonSerializerOptions options);
		
	/// <inheritdoc cref="JsonConverter{T}.Write"/>
	public override void Write(Utf8JsonWriter writer, Log value, JsonSerializerOptions options)
	{
		if (value == null || !value.ShouldSerialize)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();

		WritePropString(writer, "file.path", value.FilePath);
		WritePropString(writer, "logger", value.Logger);
		WritePropLong(writer, "origin.file.line", value.OriginFileLine);
		WritePropString(writer, "origin.file.name", value.OriginFileName);
		WritePropString(writer, "origin.function", value.OriginFunction);
		WriteProp(writer, "syslog", value.Syslog, options);

		writer.WriteEndObject();
	}
}

/// <summary> Specialized converter for <see cref="Ecs"/> </summary>
internal partial class EcsEntityJsonConverter : PropertiesReaderJsonConverterBase<Ecs>
{
	/// <inheritdoc cref="PropertiesReaderJsonConverterBase{T}.ReadProperties"/>
	protected override bool ReadProperties(ref Utf8JsonReader reader, Ecs ecsEvent, JsonSerializerOptions options)
	{
		var propertyName = reader.GetString();
		reader.Read();
		return propertyName switch
		{
			"version" => ReadPropString(ref reader, "version", ecsEvent, (b, v) => b.Version = v),
			_ => ReadProperty(ref reader, propertyName, ecsEvent, options)
		};
	}

	private partial bool ReadProperty(ref Utf8JsonReader reader, string propertyName, Ecs ecsEvent, JsonSerializerOptions options);
		
	/// <inheritdoc cref="JsonConverter{T}.Write"/>
	public override void Write(Utf8JsonWriter writer, Ecs value, JsonSerializerOptions options)
	{
		if (value == null || !value.ShouldSerialize)
		{
			writer.WriteNullValue();
			return;
		}
		writer.WriteStartObject();


		writer.WriteEndObject();
	}
}
