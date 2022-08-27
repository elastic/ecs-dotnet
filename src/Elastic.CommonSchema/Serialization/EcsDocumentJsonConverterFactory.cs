using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.Serialization
{
	internal class EcsDocumentJsonConverterFactory : JsonConverterFactory
	{
		public override bool CanConvert(Type typeToConvert) => typeof(EcsDocument).IsAssignableFrom(typeToConvert);

		public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) =>
			typeToConvert == typeof(EcsDocument)
				? EcsJsonConfiguration.DefaultEcsDocumentJsonConverter
				// TODO validate this is only called once
				: Activator.CreateInstance(typeof(EcsDocumentJsonConverter<>).MakeGenericType(typeToConvert)) as JsonConverter;
	}
}
