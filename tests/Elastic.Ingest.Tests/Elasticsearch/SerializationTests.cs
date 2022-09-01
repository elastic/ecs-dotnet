using System.Text.Json;
using Elastic.Ingest.Elasticsearch.Serialization;
using FluentAssertions;
using Xunit;

namespace Elastic.Ingest.Tests.Elasticsearch
{
	public class SerializationTests
	{
		[Fact]
		public void CanSerializeBulkResponseItem()
		{
			var json = "{\"index\":{\"status\":200}}";
			var item = JsonSerializer.Deserialize<BulkResponseItem>(json);

			item.Should().NotBeNull();

			var actual = JsonSerializer.Serialize(item);

			actual.Should().Be(json);
		}
	}
}
