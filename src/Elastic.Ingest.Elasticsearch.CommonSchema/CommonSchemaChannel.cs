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


		public async Task<bool> SetupElasticsearchTemplatesAsync()
		{
			var prefix = $"{Options.DataStream.Type}-{Options.DataStream.DataSet}";
			var templateExists = await Options.Transport.RequestAsync<HeadIndexTemplateResponse>
					(HttpMethod.HEAD, $"_index_template/{prefix}")
				.ConfigureAwait(false);
			if (templateExists.HttpStatusCode != null && templateExists.HttpStatusCode == 200) return false;

			foreach (var (name, component) in IndexComponents.Components)
			{
				var putComponentTemplate = await Options.Transport.RequestAsync<PutComponentTemplateResponse>
						(HttpMethod.PUT, $"_component_template/{name}", PostData.String(component))
					.ConfigureAwait(false);
				if (!putComponentTemplate.Success)
					throw new Exception(
						$"Failure to create component template `${name}` for {Options.DataStream.GetTemplatePrefix()}: {putComponentTemplate}");
			}


			var template = IndexTemplates.GetIndexTemplateForElasticsearchComposable($"{prefix}-*");
			var putIndexTemplateResponse = await Options.Transport.RequestAsync<PutIndexTemplateResponse>
					(HttpMethod.PUT, $"_index_template/{prefix}", PostData.String(template))
				.ConfigureAwait(false);
			if (!putIndexTemplateResponse.Success)
				throw new Exception($"Failure to create index templates for {Options.DataStream.GetTemplatePrefix()}: {putIndexTemplateResponse}");

			return true;
		}
		public bool SetupElasticsearchTemplates()
		{
			var transport = Options.Transport;
			var prefix = $"{Options.DataStream.Type}-{Options.DataStream.DataSet}";
			var templateExists = transport.Request<HeadIndexTemplateResponse>(HttpMethod.HEAD, $"_index_template/{prefix}");
			if (templateExists.HttpStatusCode != null && templateExists.HttpStatusCode == 200) return true;

			foreach (var (name, component) in IndexComponents.Components)
			{
				var putComponentTemplate =
					transport.Request<PutComponentTemplateResponse>(HttpMethod.PUT, $"_component_template/{name}", PostData.String(component));
				if (!putComponentTemplate.Success)
					throw new Exception(
						$"Failure to create component template `${name}` for {Options.DataStream.GetTemplatePrefix()}: {putComponentTemplate}");
			}


			var template = IndexTemplates.GetIndexTemplateForElasticsearchComposable($"{prefix}-*");
			var putIndexTemplateResponse = transport.Request<PutIndexTemplateResponse>(HttpMethod.PUT, $"_index_template/{prefix}", PostData.String(template));
			if (!putIndexTemplateResponse.Success)
				throw new Exception($"Failure to create index templates for {Options.DataStream.GetTemplatePrefix()}: {putIndexTemplateResponse}");

			return true;
		}

		private class HeadIndexTemplateResponse : TransportResponseBase { }

		private class PutIndexTemplateResponse : TransportResponseBase { }

		private class PutComponentTemplateResponse : TransportResponseBase { }
	}
}
