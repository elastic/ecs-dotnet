using System.Collections.Generic;
using Elastic.Ingest.Elasticsearch.Serialization;

namespace Elastic.Ingest.Elasticsearch.DataStreams
{
	public class DataStreamChannel<TEvent> : ElasticsearchChannelBase<TEvent, DataStreamChannelOptions<TEvent>>
	{
		private readonly CreateOperation _fixedHeader;

		public DataStreamChannel(DataStreamChannelOptions<TEvent> options) : base(options)
		{
			var target = Options.DataStream.ToString();
			_fixedHeader = new CreateOperation { Index = target };
		}

		protected override BulkOperationHeader CreateBulkOperationHeader(TEvent @event) => _fixedHeader;

	}
}
