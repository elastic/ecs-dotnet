// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Text.Json;

namespace Elastic.CommonSchema.Serialization
{
	/// <summary>
	/// An abstract implementation that makes it easier to read all properties of a json object.
	/// Used to read properties both as <c>x.y: 1</c> and <c>x : { y: 1 }</c> for specific fields.
	/// </summary>
	public abstract class PropertiesReaderJsonConverterBase<T> : EcsJsonConverterBase<T>
		where T : new()
	{
		/// <inheritdoc cref="System.Text.Json.Serialization.JsonConverter{T}.Read"/>
		public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.Null)
			{
				reader.Read();
				return default;
			}
			if (reader.TokenType != JsonTokenType.StartObject)
				throw new JsonException();

			var ecsEvent = new T();

			while (reader.Read())
			{
				if (reader.TokenType == JsonTokenType.EndObject)
					break;

				if (reader.TokenType != JsonTokenType.PropertyName)
					throw new JsonException();

				var _ = ReadProperties(ref reader, ecsEvent);
			}

			return ecsEvent;
		}

		/// <summary> Handle reading the current property</summary>
		protected abstract bool ReadProperties(ref Utf8JsonReader reader, T ecsEvent);
	}
}
