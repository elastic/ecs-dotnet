using Elastic.Transport;

namespace Elastic.Ingest.Transport
{
	public abstract class TransportChannelOptionsBase<TEvent, TResponse, TResponseItem, TBuffer>
		: ChannelOptionsBase<TEvent, TBuffer, TResponse, TResponseItem>
		where TBuffer : BufferOptions<TEvent>, new()
	{
		protected TransportChannelOptionsBase(ITransport<ITransportConfiguration> transport) => Transport = transport;

		public ITransport<ITransportConfiguration> Transport { get; }
	}
}
