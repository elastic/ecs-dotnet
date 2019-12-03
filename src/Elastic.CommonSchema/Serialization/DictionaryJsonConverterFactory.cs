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
}
