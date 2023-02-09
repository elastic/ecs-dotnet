#nullable enable
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Elastic.CommonSchema;
using Elastic.CommonSchema.Elasticsearch;
using Elastic.CommonSchema.Serialization;
using Elastic.Ingest.Elasticsearch.DataStreams;

namespace Elastic.Ingest.Elasticsearch.CommonSchema
{
	/// <summary>
	/// An channel implementation that allows you to push ECS data to Elasticsearch data streams
	/// </summary>
	public class EcsDataStreamChannel<TEcsDocument> : DataStreamChannel<TEcsDocument>
		where TEcsDocument : EcsDocument
	{
		public EcsDataStreamChannel(DataStreamChannelOptions<TEcsDocument> options) : base(options) =>
			options.WriteEvent = async (stream, ctx, @event) =>
				await JsonSerializer.SerializeAsync(stream, @event, typeof(TEcsDocument), EcsJsonConfiguration.SerializerOptions, ctx)
					.ConfigureAwait(false);

		public override bool BootstrapElasticsearch(BootstrapMethod bootstrapMethod, string? ilmPolicy = null)
		{
			if (bootstrapMethod == BootstrapMethod.None) return true;

			var name = TemplateName;
			var match = TemplateWildcard;
			if (IndexTemplateExists(name)) return false;

			foreach (var (componentName, component) in IndexComponents.Components)
			{
				if (!PutComponentTemplate(bootstrapMethod, componentName, component))
					return false;
			}

			var additionalComponents = GetInferredComponentTemplates();
			if (!string.IsNullOrEmpty(ilmPolicy))
			{
				// create a component template that sets index.lifecycle.name
				var (settingsName, settingsBody) = GetDefaultComponentSettings(name, ilmPolicy);
				if (!PutComponentTemplate(bootstrapMethod, settingsName, settingsBody))
					return false;
				additionalComponents.Add(settingsName);
			}

			var template = IndexTemplates.GetIndexTemplateForElasticsearchComposable(match, additionalComponents.ToArray());
			if (!PutIndexTemplate(bootstrapMethod, name, template))
				return false;

			return true;
		}

		public override async Task<bool> BootstrapElasticsearchAsync(BootstrapMethod bootstrapMethod, string? ilmPolicy = null, CancellationToken ctx = default)
		{
			if (bootstrapMethod == BootstrapMethod.None) return true;

			var name = TemplateName;
			var match = TemplateWildcard;
			if (await IndexTemplateExistsAsync(name, ctx).ConfigureAwait(false)) return false;

			foreach (var (componentName, component) in IndexComponents.Components)
			{
				if (!await PutComponentTemplateAsync(bootstrapMethod, componentName, component, ctx).ConfigureAwait(false))
					return false;
			}
			var additionalComponents = GetInferredComponentTemplates();
			if (!string.IsNullOrEmpty(ilmPolicy))
			{
				// create a component template that sets  index.lifecycle.name
				var (settingsName, settingsBody) = GetDefaultComponentSettings(name, ilmPolicy);
				if (!await PutComponentTemplateAsync(bootstrapMethod, settingsName, settingsBody, ctx).ConfigureAwait(false))
					return false;
				additionalComponents.Add(settingsName);
			}

			var template = IndexTemplates.GetIndexTemplateForElasticsearchComposable(match, additionalComponents.ToArray());
			if (!await PutIndexTemplateAsync(bootstrapMethod, name, template, ctx).ConfigureAwait(false))
				return false;

			return true;
		}

	}
}
