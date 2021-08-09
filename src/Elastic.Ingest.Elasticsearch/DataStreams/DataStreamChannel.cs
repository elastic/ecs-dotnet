using System.Collections.Generic;

namespace Elastic.Ingest.Elasticsearch
{
	public class DataStreamChannel<TEvent> : ElasticsearchChannelBase<TEvent, DataStreamChannelOptions<TEvent>>
	{
		public DataStreamChannel(DataStreamChannelOptions<TEvent> options) : base(options) { }

		//TODO move away from object
		//TODO look into caching headers
		protected override object CreateBulkOperationHeader(TEvent @event)
		{
			var index = Options.DataStream.ToString();
			var indexHeader = new Dictionary<string, object> { { "create", new { _index = index } } };
			return indexHeader;
		}
	}
}
