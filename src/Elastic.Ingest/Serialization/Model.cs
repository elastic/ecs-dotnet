using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using Elastic.Transport;
using Elastic.Transport.Products.Elasticsearch.Failures;

namespace Elastic.Ingest.Serialization
{
	public class BulkResponse : ITransportResponse
	{
		[JsonIgnore]
		IApiCallDetails ITransportResponse.ApiCall { get; set; } = null!;
		[JsonIgnore]
		public IApiCallDetails ApiCall => ((ITransportResponse)this).ApiCall;

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

	}

	[JsonConverter(typeof(ItemConverter))]
	public class BulkResponseItem
	{
		public string Action { get; internal set; } = null!;
		public ErrorCause? Error { get; internal set; }
		public int Status { get; internal set; }
	}

	public class ResponseItemsConverter : JsonConverter<IReadOnlyCollection<BulkResponseItem>>
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
				list.Add(item);
			}
			return new ReadOnlyCollection<BulkResponseItem>(list);
		}

		public override void Write(Utf8JsonWriter writer, IReadOnlyCollection<BulkResponseItem> value, JsonSerializerOptions options) =>
			throw new NotImplementedException();
	}

	internal class ItemConverter : JsonConverter<BulkResponseItem>
	{
		private static readonly BulkResponseItem OkayBulkResponseItem = new BulkResponseItem { Status = 200, Action = "index" };

		public override BulkResponseItem Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			//TODO nasty null return
			if (reader.TokenType != JsonTokenType.StartObject) return null!;

			reader.Read();
			var depth = reader.CurrentDepth;
			var status = 0;
			ErrorCause? error = null;
			var action = reader.GetString();
			while (reader.Read() && reader.CurrentDepth >= depth)
			{
				if (reader.TokenType != JsonTokenType.PropertyName) continue;

				var text = reader.GetString();
				switch (text)
				{
					case "status":
						reader.Read();
						status = reader.GetInt32();
						break;
					case "error":
						reader.Read();
						error = JsonSerializer.Deserialize<ErrorCause>(ref reader, options);
						break;
				}
			}
			BulkResponseItem r = (status == 200)
				? OkayBulkResponseItem
				: new BulkResponseItem { Action = action, Status = status, Error = error };
			return r;

		}

		public override void Write(Utf8JsonWriter writer, BulkResponseItem value, JsonSerializerOptions options)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}

			writer.WriteStartObject();
			writer.WritePropertyName(value.Action);
			writer.WriteStartObject();

			if (value.Error != null)
			{
				writer.WritePropertyName("error");
				JsonSerializer.Serialize(writer, value.Error, options);
			}

			writer.WritePropertyName("status");
			writer.WriteNumber("status", value.Status);

			writer.WriteEndObject();
			writer.WriteEndObject();
		}
	}


}
