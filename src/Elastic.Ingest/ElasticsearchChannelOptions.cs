using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Elastic.Transport;

namespace Elastic.Ingest
{
	public class ElasticsearchChannelOptions<TEvent>
	{
		public ElasticsearchChannelOptions() { }

		public ElasticsearchChannelOptions(ITransport<ITransportConfigurationValues> transport) => ShipTo = new ShipTo(transport);

		//TODO index patters are more complex then this, ILM, write alias, buffer tier, datastreams
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

		/// <summary>
		/// Gets or sets the connection pool type. Default for multiple nodes is <c>Sniffing</c>; other supported values are
		/// <c>Static</c>, <c>Sticky</c>, or force to <c>SingleNode</c>.
		/// </summary>
		public ConnectionPoolType ConnectionPoolType { get; set; }

		/// <summary>
		/// Gets or sets the ShipTo property of the Elasticsearch.
		/// If not specified the default single node is being used.
		/// "http://localhost:9200" is used.
		/// </summary>
		public ShipTo ShipTo { get; set; } = new ShipTo();

		public BufferOptions<TEvent> BufferOptions { get; set; } = new BufferOptions<TEvent>();

		public Func<TEvent, DateTimeOffset?> TimestampLookup { get; set; } = null!;

		public Func<Stream, CancellationToken, TEvent, Task> WriteEvent { get; set; } = null!;
	}
}
