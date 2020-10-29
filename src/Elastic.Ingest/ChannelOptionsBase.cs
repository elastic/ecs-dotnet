using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Elastic.Transport;

namespace Elastic.Ingest
{
	public abstract class ChannelOptionsBase<TEvent, TResponse, TResponseItem, TBuffer>
		where TBuffer : BufferOptions<TEvent, TResponse, TResponseItem>, new()
	{
		protected ChannelOptionsBase() { }

		protected ChannelOptionsBase(ITransport<ITransportConfigurationValues> transport) => ShipTo = new ShipTo(transport);

		/// <summary>
		/// Gets or sets the ShipTo property of the Elasticsearch.
		/// If not specified the default single node is being used.
		/// "http://localhost:9200" is used.
		/// </summary>
		public ShipTo ShipTo { get; set; } = new ShipTo();

		/// <summary>
		/// Gets or sets the connection pool type. Default for multiple nodes is <c>Sniffing</c>; other supported values are
		/// <c>Static</c>, <c>Sticky</c>, or force to <c>SingleNode</c>.
		/// </summary>
		public ConnectionPoolType ConnectionPoolType { get; set; }

		public Func<Stream, CancellationToken, TEvent, Task> WriteEvent { get; set; } = null!;

		public TBuffer BufferOptions { get; set; } = new TBuffer();


	}
}
