using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Elastic.Ingest.Elasticsearch.Serialization;
using Elastic.Ingest.Transport;
using Elastic.Transport;

namespace Elastic.Ingest.Elasticsearch
{
	public abstract class ElasticsearchChannelBase<TEvent, TChannelOptions>
		: TransportChannelBase<TChannelOptions, ElasticsearchBufferOptions<TEvent>, TEvent, BulkResponse, BulkResponseItem>
		where TChannelOptions : TransportChannelOptionsBase<TEvent, BulkResponse, BulkResponseItem, ElasticsearchBufferOptions<TEvent>>
	{
		public ElasticsearchChannelBase(TChannelOptions options) : base(options) { }


		protected override bool Retry(BulkResponse response)
		{
			var details = response.ApiCallDetails;
			if (!details.HasSuccessfulStatusCode)
				Options.ExceptionCallback?.Invoke(new Exception(details.ToString(), details.OriginalException));
			return details.HasSuccessfulStatusCode;
		}

		protected override bool RetryAllItems(BulkResponse response) => response.ApiCallDetails.HttpStatusCode == 429;

		protected override List<(TEvent, BulkResponseItem)> Zip(BulkResponse response, IReadOnlyCollection<TEvent> page) =>
			page.Zip(response.Items, (doc, item) => (doc, item)).ToList();

		protected override bool RetryEvent((TEvent, BulkResponseItem) @event) =>
			ElasticsearchChannelStatics.RetryStatusCodes.Contains(@event.Item2.Status);

		protected override bool RejectEvent((TEvent, BulkResponseItem) @event) =>
			@event.Item2.Status < 200 || @event.Item2.Status > 300;

		protected override Task<BulkResponse> Send(HttpTransport transport, IReadOnlyCollection<TEvent> page) =>
			transport.RequestAsync<BulkResponse>(HttpMethod.POST, "/_bulk",
				PostData.StreamHandler(page,
					(b, stream) =>
					{
						/* NOT USED */
					},
					async (b, stream, ctx) => { await WriteBufferToStreamAsync(b, stream, ctx).ConfigureAwait(false); })
				, ElasticsearchChannelStatics.RequestParams);

		protected abstract BulkOperationHeader CreateBulkOperationHeader(TEvent @event);

		private async Task WriteBufferToStreamAsync(IReadOnlyCollection<TEvent> b, Stream stream, CancellationToken ctx)
		{
			foreach (var @event in b)
			{
				if (@event == null) continue;

				var indexHeader = CreateBulkOperationHeader(@event);
				await JsonSerializer.SerializeAsync(stream, indexHeader, indexHeader.GetType(), ElasticsearchChannelStatics.SerializerOptions, ctx)
					.ConfigureAwait(false);
				await stream.WriteAsync(ElasticsearchChannelStatics.LineFeed, 0, 1, ctx).ConfigureAwait(false);

				if (indexHeader is UpdateOperation)
					await stream.WriteAsync(ElasticsearchChannelStatics.DocUpdateHeaderStart, ctx).ConfigureAwait(false);

				if (Options.WriteEvent != null)
					await Options.WriteEvent(stream, ctx, @event).ConfigureAwait(false);
				else
				{
					await JsonSerializer.SerializeAsync(stream, @event, typeof(TEvent), ElasticsearchChannelStatics.SerializerOptions, ctx)
						.ConfigureAwait(false);
				}

				if (indexHeader is UpdateOperation)
					await stream.WriteAsync(ElasticsearchChannelStatics.DocUpdateHeaderEnd, ctx).ConfigureAwait(false);

				await stream.WriteAsync(ElasticsearchChannelStatics.LineFeed, 0, 1, ctx).ConfigureAwait(false);
			}
		}
	}
}
