// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.Serialization
{
	internal class DictionaryJsonConverterFactory : JsonConverterFactory
	{
		public override bool CanConvert(Type typeToConvert) => typeof(IDictionary<string, object>).IsAssignableFrom(typeToConvert);

		public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) =>
			JsonConfiguration.MetaDataDictionaryConverter;
	}

	internal class BaseJsonConverterFactory : JsonConverterFactory
	{
		public override bool CanConvert(Type typeToConvert) => typeof(Base).IsAssignableFrom(typeToConvert);

		public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) =>
			typeToConvert == typeof(Base)
				? JsonConfiguration.BaseConverter
				// TODO validate this is only called once
				: Activator.CreateInstance(typeof(BaseJsonConverter<>).MakeGenericType(typeToConvert)) as JsonConverter;
	}
}
