using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.Serialization
{
	/// <summary>
	/// Ensures any subclass of <see cref="EcsDocument"/> uses a json converter that adheres to the
	/// https://github.com/elastic/ecs-logging specification
	/// </summary>
	public class EcsDocumentJsonConverterFactory : JsonConverterFactory
	{
		/// <inheritdoc cref="JsonConverter.CanConvert"/>
		public override bool CanConvert(Type typeToConvert) => typeof(EcsDocument).IsAssignableFrom(typeToConvert);

		/// <inheritdoc cref="JsonConverterFactory.CreateConverter"/>
		public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options) =>
			typeToConvert == typeof(EcsDocument)
				? EcsJsonConfiguration.DefaultEcsDocumentJsonConverter
				// TODO validate this is only called once
				: Activator.CreateInstance(typeof(EcsDocumentJsonConverter<>).MakeGenericType(typeToConvert)) as JsonConverter;
	}
}
