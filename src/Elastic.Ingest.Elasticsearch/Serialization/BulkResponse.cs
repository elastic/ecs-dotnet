using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Elastic.Transport;
using Elastic.Transport.Products.Elasticsearch;

namespace Elastic.Ingest.Elasticsearch.Serialization
{

	public class BulkResponse : TransportResponse
	{
		[JsonPropertyName("items")]
		[JsonConverter(typeof(ResponseItemsConverter))]
		public IReadOnlyCollection<BulkResponseItem> Items { get; set; } = null!;

		[JsonPropertyName("error")]
		public ErrorCause? Error { get; set; }

		public bool TryGetServerErrorReason(out string? reason)
		{
			reason = Error?.Reason;
			return !string.IsNullOrWhiteSpace(reason);
		}

		public override string ToString() => ApiCallDetails.DebugInformation;
	}
	internal class ResponseItemsConverter : JsonConverter<IReadOnlyCollection<BulkResponseItem>>
	{
		public static readonly IReadOnlyCollection<BulkResponseItem> EmptyBulkItems =
			new ReadOnlyCollection<BulkResponseItem>(new List<BulkResponseItem>());

		public override IReadOnlyCollection<BulkResponseItem> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.StartArray) return EmptyBulkItems;

			var list = new List<BulkResponseItem>();
			var depth = reader.CurrentDepth;
			while (reader.Read() && reader.CurrentDepth > depth)
			{
				var item = JsonSerializer.Deserialize<BulkResponseItem>(ref reader, options);
				if (item != null)
					list.Add(item);
			}
			return new ReadOnlyCollection<BulkResponseItem>(list);
		}

		public override void Write(Utf8JsonWriter writer, IReadOnlyCollection<BulkResponseItem> value, JsonSerializerOptions options) =>
			throw new NotImplementedException();
	}

}
