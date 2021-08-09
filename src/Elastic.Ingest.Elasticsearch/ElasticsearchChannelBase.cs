using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Elastic.Ingest.Elasticsearch.Serialization;
using Elastic.Transport;

namespace Elastic.Ingest.Elasticsearch
{
	public abstract class ElasticsearchChannelBase<TEvent, TChannelOptions>
		: TransportChannelBase<TChannelOptions, ElasticsearchBufferOptions<TEvent>, TEvent, BulkResponse, BulkResponseItem>
		where TChannelOptions : ChannelOptionsBase<TEvent, BulkResponse, BulkResponseItem, ElasticsearchBufferOptions<TEvent>>
	{
		public ElasticsearchChannelBase(TChannelOptions options) : base(options) { }

		protected override bool BackOffRequest(BulkResponse response) => response.ApiCall.HttpStatusCode == 429;

		protected override List<(TEvent, BulkResponseItem)> Zip(BulkResponse response, List<TEvent> page) =>
			page.Zip(response.Items, (doc, item) => (doc, item)).ToList();

		protected override bool RetryEvent((TEvent, BulkResponseItem) @event) =>
			ElasticsearchChannelStatics.RetryStatusCodes.Contains(@event.Item2.Status);

		protected override bool RejectEvent((TEvent, BulkResponseItem) @event) =>
			@event.Item2.Status < 200 || @event.Item2.Status > 300;

		protected override Task<BulkResponse> Send(ITransport<ITransportConfiguration> transport, List<TEvent> page) =>
			transport.RequestAsync<BulkResponse>(HttpMethod.POST, "/_bulk",
				default,
				PostData.StreamHandler(page,
					(b, stream) =>
					{
						/* NOT USED */
					},
					async (b, stream, ctx) => { await WriteBufferToStreamAsync(b, stream, ctx).ConfigureAwait(false); })
				, ElasticsearchChannelStatics.RequestParams);

		protected abstract object CreateBulkOperationHeader(TEvent @event);

		private async Task WriteBufferToStreamAsync(List<TEvent> b, Stream stream, CancellationToken ctx)
		{
			foreach (var @event in b)
			{
				if (@event == null) continue;

				var indexHeader = CreateBulkOperationHeader(@event);
				await JsonSerializer.SerializeAsync(stream, indexHeader, indexHeader.GetType(), ElasticsearchChannelStatics.SerializerOptions, ctx)
					.ConfigureAwait(false);
				await stream.WriteAsync(ElasticsearchChannelStatics.LineFeed, 0, 1, ctx).ConfigureAwait(false);
				if (Options.WriteEvent != null)
					await Options.WriteEvent(stream, ctx, @event).ConfigureAwait(false);
				else
				{
					await JsonSerializer.SerializeAsync(stream, @event, typeof(TEvent), ElasticsearchChannelStatics.SerializerOptions, ctx)
						.ConfigureAwait(false);
				}

				await stream.WriteAsync(ElasticsearchChannelStatics.LineFeed, 0, 1, ctx).ConfigureAwait(false);
			}
		}
	}
}
