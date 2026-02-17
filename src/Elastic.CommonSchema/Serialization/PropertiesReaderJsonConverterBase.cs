// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.Serialization;

/// <summary>
/// An abstract implementation that makes it easier to read all properties of a json object.
/// Used to read properties both as <c>x.y: 1</c> and <c>x : { y: 1 }</c> for specific fields.
/// </summary>
public abstract class PropertiesReaderJsonConverterBase<T> : EcsJsonConverterBase<T>
	where T : new()
{
	/// <inheritdoc cref="System.Text.Json.Serialization.JsonConverter{T}.Read"/>
	public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.Null)
		{
			reader.Read();
			return default;
		}
		if (reader.TokenType != JsonTokenType.StartObject)
			throw new JsonException();

		var ecsEvent = new T();

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

			var _ = ReadProperties(ref reader, ecsEvent, options);
		}

		return ecsEvent;
	}

	/// <summary> Handle reading the current property</summary>
	protected abstract bool ReadProperties(ref Utf8JsonReader reader, T ecsEvent, JsonSerializerOptions options);
}

public partial class EcsEntityJsonConverter
{
	private partial bool ReadProperty(ref Utf8JsonReader reader, string propertyName, Ecs ecsEvent, JsonSerializerOptions options) => false;
}


/// intermediary parser objects, not meant for direct consumption
public class ParserIntermediary
{
	/// intermediary parser for log data in a different format
	public class LogFileOriginInvalid
	{
		/// <inheritdoc cref="LogFieldSet.OriginFileName"/>
		[JsonPropertyName("name"), DataMember(Name = "name")]
		public string? Name { get; set; }

		/// <inheritdoc cref="LogFieldSet.OriginFileLine"/>
		[JsonPropertyName("line"), DataMember(Name = "line")]
		public int? Line { get; set; }
	}

	/// intermediary parser for log data in a different format
	public class LogOriginInvalid
	{
		/// <inheritdoc cref="LogFieldSet.OriginFunction"/>
		[JsonPropertyName("function"), DataMember(Name = "function")]
		public string? Function { get; set; }

		/// <inheritdoc cref="LogFieldSet.FilePath"/>
		[JsonPropertyName("file"), DataMember(Name = "file")]
		public LogFileOriginInvalid? File { get; set; }
	}
}

public partial class LogEntityJsonConverter
{
	private partial bool ReadProperty(ref Utf8JsonReader reader, string propertyName, Log ecsEvent, JsonSerializerOptions options) =>
		propertyName switch
		{
			"origin" => ReadProp<ParserIntermediary.LogOriginInvalid>(ref reader, "origin", ecsEvent, (b, v) =>
			{
				if (v == null) return;
				b.OriginFunction = v.Function;
				if (v.File == null) return;
				b.OriginFileLine = v.File.Line;
				b.OriginFileName = v.File.Name;
			}, options),
			_ => false
		};
}
