using System;
using System.Threading.Tasks;
using Elastic.CommonSchema;
using Elastic.CommonSchema.Elasticsearch;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Transport;

namespace Elastic.Ingest.Elasticsearch.CommonSchema
{
	public class CommonSchemaChannel<TEcsDocument> : DataStreamChannel<TEcsDocument>
		where TEcsDocument : EcsDocument
	{
		public CommonSchemaChannel(DataStreamChannelOptions<TEcsDocument> options) : base(options) { }


		public async Task CreateIndexTemplates()
		{
			var template = IndexTemplates.GetIndexTemplateForElasticsearchComposable(Options.DataStream.GetTemplatePrefix());
			var putIndexTemplateResponse = await Options.Transport.RequestAsync<PutIndexTemplateResponse>
				(HttpMethod.PUT, $"_index_template/{Options.DataStream}", PostData.String(template))
				.ConfigureAwait(false);
			if (!putIndexTemplateResponse.Success)
				throw new Exception($"Failure to create index templates for {Options.DataStream.GetTemplatePrefix()}: {putIndexTemplateResponse}");
		}

	}

	public class PutIndexTemplateResponse : TransportResponseBase { }
}
