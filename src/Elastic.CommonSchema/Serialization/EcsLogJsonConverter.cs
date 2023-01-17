// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Text.Json;

namespace Elastic.CommonSchema.Serialization
{
	public partial class EcsLogJsonConverter
	{
		public override Log Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType == JsonTokenType.Null)
			{
				reader.Read();
				return null;
			}
			if (reader.TokenType != JsonTokenType.StartObject)
				throw new JsonException();

			var ecsEvent = new Log();

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
	}
}
