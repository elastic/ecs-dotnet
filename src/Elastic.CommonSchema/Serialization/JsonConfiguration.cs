// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.Serialization
{
	/// <summary>Static class holding <see cref="JsonSerializerOptions"/></summary>
	public static class EcsJsonConfiguration
	{
		/// <summary>Default <see cref="JsonSerializerOptions"/> used by ECS integrations</summary>
		public static JsonSerializerOptions SerializerOptions { get; } = new()
		{
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
			NumberHandling = JsonNumberHandling.AllowNamedFloatingPointLiterals,
			Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
			PropertyNamingPolicy = new SnakeCaseJsonNamingPolicy(),
			Converters =
			{
				new EcsDocumentJsonConverterFactory(),
				new LogEntityJsonConverter(),
				new EcsEntityJsonConverter(),
				// System.Text.Json got significantly better at not tripping over BCL types with .NET 7.0.
				// ECS should fallback from serialization failures in metadata however this list catches the most
				// common offenders. This to ensure better interop with older ASP.NET version out of the box see:
				// https://github.com/elastic/ecs-dotnet/issues/219
				new EcsJsonStringConverter<System.Reflection.Assembly>(),
				new EcsJsonStringConverter<System.Reflection.Module>(),
				new EcsJsonStringConverter<System.Reflection.MemberInfo>(),
				new EcsJsonStringConverter<Delegate>(),
				new EcsJsonStringConverter<System.IO.Stream>()
			}
		};

		internal static readonly JsonConverter<DateTimeOffset> DateTimeOffsetConverter =
			(JsonConverter<DateTimeOffset>)SerializerOptions.GetConverter(typeof(DateTimeOffset));

		/// <summary>Default <see cref="JsonConverter{T}"/> for <see cref="EcsDocument"/></summary>
		public static readonly EcsDocumentJsonConverter DefaultEcsDocumentJsonConverter = new();

		private sealed class EcsJsonStringConverter<T> : JsonConverter<T>
		{
			public override bool CanConvert(Type typeToConvert) => typeof(T).IsAssignableFrom(typeToConvert);

			public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) => default;

			public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
			{
				if (value is null)
					writer.WriteNullValue();
				else
					writer.WriteStringValue(value.ToString());
			}
		}
	}
}
