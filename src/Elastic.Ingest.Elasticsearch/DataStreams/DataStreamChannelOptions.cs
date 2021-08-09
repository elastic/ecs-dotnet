using Elastic.Ingest.Elasticsearch.Serialization;
using Elastic.Transport;

namespace Elastic.Ingest.Elasticsearch
{
	public class DataStreamChannelOptions<TEvent> : ChannelOptionsBase<TEvent, BulkResponse, BulkResponseItem, ElasticsearchBufferOptions<TEvent>>
	{
		public DataStreamChannelOptions() : base() =>
			DataStream = new DataStreamName(typeof(TEvent).Name.ToLowerInvariant());

		public DataStreamChannelOptions(ITransport<ITransportConfiguration> transport) : base(transport) =>
			DataStream = new DataStreamName(typeof(TEvent).Name.ToLowerInvariant());

		public DataStreamChannelOptions(ITransport<ITransportConfiguration> transport, DataStreamName name) : base(transport) =>
			DataStream = name;

		public DataStreamName DataStream { get; }
	}
}
