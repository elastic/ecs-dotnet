using System;
using System.Collections.Generic;

namespace Elastic.Ingest.Elasticsearch.Indices
{
	public class IndexChannel<TEvent> : ElasticsearchChannelBase<TEvent, IndexChannelOptions<TEvent>>
	{
		public IndexChannel(IndexChannelOptions<TEvent> options) : base(options) { }

		//TODO move away from object
		protected override object CreateBulkOperationHeader(TEvent @event)
		{
			var indexTime = Options.TimestampLookup?.Invoke(@event) ?? DateTimeOffset.Now;
			if (Options.IndexOffset.HasValue) indexTime = indexTime.ToOffset(Options.IndexOffset.Value);

			var index = string.Format(Options.Index, indexTime);
			var id = Options.BulkOperationIdLookup?.Invoke(@event);
			var indexHeader =
				!string.IsNullOrWhiteSpace(id)
					? new Dictionary<string, object> { { "index", new { _index = index, _id = id } } }
					: new Dictionary<string, object> { { "create", new { _index = index } } };
			return indexHeader;
		}
	}
}
