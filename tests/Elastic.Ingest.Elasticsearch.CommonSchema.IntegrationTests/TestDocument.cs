// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Text.Json.Serialization;
using Elastic.CommonSchema;

namespace Elastic.Ingest.Elasticsearch.CommonSchema.IntegrationTests;

public class TimeSeriesDocument : EcsDocument
{
}

public class CatalogDocument : EcsDocument
{
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	[JsonPropertyName("title")]
	public string? Title { get; set; }

	[JsonPropertyName("created")]
	public DateTimeOffset Created { get; set; }

	protected override bool TryRead(string propertyName, out Type? type)
	{
		type = propertyName switch
		{
			"id" => typeof(string),
			"title" => typeof(string),
			"created" => typeof(DateTimeOffset),
			_ => null
		};
		return type != null;
	}

	protected override bool ReceiveProperty(string propertyName, object value) =>
		propertyName switch
		{
			"created" => default != (Created = value is DateTimeOffset ? (DateTimeOffset)value : default),
			"title" => null != (Title = value as string),
			"id" => null != (Id = value as string),
			_ => false
		};

	protected override void WriteAdditionalProperties(Action<string, object> write)
	{
		if (Id != null) write("id", Id);
		if (Created != default)	write("created", Created);
		if (Title != null) write("title", Title);
	}
}
