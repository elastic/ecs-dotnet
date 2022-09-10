// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.Serialization
{
	public static class EcsJsonConfiguration
	{
		public static JsonSerializerOptions SerializerOptions { get; } = new ()
		{
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
			Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
			PropertyNamingPolicy = new SnakeCaseJsonNamingPolicy(),
			Converters =
			{
				new EcsDocumentJsonConverterFactory(),
				new EcsJsonStringConverter<System.Reflection.Assembly>(),	// Cannot transfer assembly-objects over the wire
				new EcsJsonStringConverter<System.Reflection.Module>(),		// Cannot transfer module-objects over the wire
				new EcsJsonStringConverter<System.Reflection.MemberInfo>(),	// Cannot transfer method-addresses over the wire
				new EcsJsonStringConverter<System.Delegate>(),				// Cannot transfer methods over the wire
				new EcsJsonStringConverter<System.IO.Stream>(),				// Stream-properties often throws exceptions
			},
		};

		internal static readonly JsonConverter<DateTimeOffset> DateTimeOffsetConverter =
			(JsonConverter<DateTimeOffset>)SerializerOptions.GetConverter(typeof(DateTimeOffset));

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
