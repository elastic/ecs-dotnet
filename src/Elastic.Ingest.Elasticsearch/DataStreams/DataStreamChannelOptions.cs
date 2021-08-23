using Elastic.Transport;

namespace Elastic.Ingest.Elasticsearch.DataStreams
{
	public class DataStreamChannelOptions<TEvent> : ElasticsearchChannelOptionsBase<TEvent>
	{
		public DataStreamChannelOptions(ITransport<ITransportConfiguration> transport) : base(transport) =>
			DataStream = new DataStreamName(typeof(TEvent).Name.ToLowerInvariant());

		public DataStreamName DataStream { get; set; }
	}
}
