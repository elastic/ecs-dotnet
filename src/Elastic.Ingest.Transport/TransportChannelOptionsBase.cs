using Elastic.Transport;

namespace Elastic.Ingest.Transport
{
	public abstract class TransportChannelOptionsBase<TEvent, TResponse, TResponseItem, TBuffer>
		: ChannelOptionsBase<TEvent, TResponse, TResponseItem, TBuffer>
		where TBuffer : BufferOptions<TEvent, TResponse, TResponseItem>, new()
	{
		protected TransportChannelOptionsBase(ITransport<ITransportConfiguration> transport) => Transport = transport;

		public ITransport<ITransportConfiguration> Transport { get; }
	}
}
