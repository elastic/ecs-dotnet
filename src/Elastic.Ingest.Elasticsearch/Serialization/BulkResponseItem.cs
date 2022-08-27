using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using Elastic.Transport.Products.Elasticsearch;

namespace Elastic.Ingest.Elasticsearch.Serialization
{
	[JsonConverter(typeof(ItemConverter))]
	public class BulkResponseItem
	{
		public string Action { get; internal set; } = null!;
		public ErrorCause? Error { get; internal set; }
		public int Status { get; internal set; }
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
			var action = reader.GetString()!;
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
			var r = status == 200
				? OkayBulkResponseItem
				: new BulkResponseItem { Action = action!, Status = status, Error = error };

			return r;
		}

		public override void Write(Utf8JsonWriter writer, BulkResponseItem value, JsonSerializerOptions options)
		{
			if (value is null)
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

			writer.WriteNumber("status", value.Status);
			writer.WriteEndObject();
			writer.WriteEndObject();
		}
	}
}
