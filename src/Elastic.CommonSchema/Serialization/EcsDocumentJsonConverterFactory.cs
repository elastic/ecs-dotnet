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
		public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
		{
			if (typeToConvert == typeof(EcsDocument))
				return EcsJsonConfiguration.DefaultEcsDocumentJsonConverter;

			var instance = Activator.CreateInstance(typeof(EcsDocumentJsonConverter<>).MakeGenericType(typeToConvert));
			return (JsonConverter)instance!;
		}
	}
}
