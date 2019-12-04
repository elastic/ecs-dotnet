using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.Serialization
{
	internal static class JsonConfiguration
	{
		internal static readonly JsonSerializerOptions SerializerOptions = new JsonSerializerOptions()
		{
			IgnoreNullValues = true,
			Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
			PropertyNamingPolicy = new SnakeCaseJsonNamingPolicy(),
			Converters = { new DictionaryJsonConverterFactory() }
		};

		internal static readonly JsonConverter<DateTimeOffset> DateTimeOffsetConverter =
			(JsonConverter<DateTimeOffset>)SerializerOptions.GetConverter(typeof(DateTimeOffset));

		internal static readonly MetaDataDictionaryConverter MetaDataDictionaryConverter = new MetaDataDictionaryConverter();
	}
}
