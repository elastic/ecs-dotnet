using System;
using Elastic.Ingest.Elasticsearch.Serialization;

namespace Elastic.Ingest.Elasticsearch.Indices
{
	public class IndexChannel<TEvent> : ElasticsearchChannelBase<TEvent, IndexChannelOptions<TEvent>>
	{
		public IndexChannel(IndexChannelOptions<TEvent> options) : base(options) { }

		protected override BulkOperationHeader CreateBulkOperationHeader(TEvent @event)
		{
			var indexTime = Options.TimestampLookup?.Invoke(@event) ?? DateTimeOffset.Now;
			if (Options.IndexOffset.HasValue) indexTime = indexTime.ToOffset(Options.IndexOffset.Value);

			var index = string.Format(Options.Index, indexTime);
			var id = Options.BulkOperationIdLookup?.Invoke(@event);
			return
				!string.IsNullOrWhiteSpace(id)
					? new IndexOperation { Index = index, Id = id }
					: new CreateOperation { Index = index };
		}
	}
}
