using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
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
		[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "We always provide a static JsonTypeInfoResolver")]
		[UnconditionalSuppressMessage("AotAnalysis", "IL3050:RequiresDynamicCode", Justification = "We always provide a static JsonTypeInfoResolver")]
		[UnconditionalSuppressMessage("AotAnalysis", "IL2092:DynamicallyAccessedMemberTypes", Justification = "More concrete then override")]
		public override JsonConverter CreateConverter([DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicParameterlessConstructor)]Type typeToConvert, JsonSerializerOptions options)
		{
			if (typeToConvert == typeof(EcsDocument))
				return EcsJsonConfiguration.DefaultEcsDocumentJsonConverter;

			var instance = Activator.CreateInstance(typeof(EcsDocumentJsonConverter<>).MakeGenericType(typeToConvert));
			return (JsonConverter)instance!;
		}
	}
}
