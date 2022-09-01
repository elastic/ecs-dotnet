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
				new DictionaryJsonConverterFactory(),
				new EcsDocumentJsonConverterFactory()
			}
		};

		internal static readonly JsonConverter<DateTimeOffset> DateTimeOffsetConverter =
			(JsonConverter<DateTimeOffset>)SerializerOptions.GetConverter(typeof(DateTimeOffset));

		internal static readonly MetaDataDictionaryConverter MetaDataDictionaryConverter = new();

		public static readonly EcsDocumentJsonConverter DefaultEcsDocumentJsonConverter = new();
	}
}
