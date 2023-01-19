using System;
using Elastic.Transport;

namespace Elastic.Ingest.Elasticsearch.Indices
{
	public class IndexChannelOptions<TEvent> : ElasticsearchChannelOptionsBase<TEvent>
	{
		public IndexChannelOptions(HttpTransport transport) : base(transport) { }

		/// <summary>
		/// Gets or sets the format string for the Elastic search index. The current <c>DateTimeOffset</c> is passed as parameter
		/// 0.
		/// </summary>
		public string Index { get; set; } = "dotnet-{0:yyyy.MM.dd}";

		/// <summary>
		/// Gets or sets the offset to use for the index <c>DateTimeOffset</c>. Default value is null, which uses the system local
		/// offset. Use "00:00" for UTC.
		/// </summary>
		public TimeSpan? IndexOffset { get; set; }

		public Func<TEvent, DateTimeOffset?> TimestampLookup { get; set; } = null!;

		public Func<TEvent, string> BulkOperationIdLookup { get; set; } = null!;
	}
}
