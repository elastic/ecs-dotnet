using Elastic.Ingest.Elasticsearch.Serialization;
using Elastic.Ingest.Transport;
using Elastic.Transport;

namespace Elastic.Ingest.Elasticsearch
{
	public class ElasticsearchChannelOptionsBase<TEvent> : TransportChannelOptionsBase<TEvent, BulkResponse, BulkResponseItem, ElasticsearchBufferOptions<TEvent>>
	{
		protected ElasticsearchChannelOptionsBase(HttpTransport transport) : base(transport)
		{
		}
	}
}
