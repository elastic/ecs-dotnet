#nullable enable
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Elastic.CommonSchema;
using Elastic.CommonSchema.Elasticsearch;
using Elastic.CommonSchema.Serialization;
using Elastic.Ingest.Elasticsearch.Indices;

namespace Elastic.Ingest.Elasticsearch.CommonSchema
{
	/// <summary>
	/// An channel implementation that allows you to push ECS data to Elasticsearch indices
	/// <para>Note for timeseries data <see cref="EcsDataStreamChannel{TEcsDocument}"/> ships with better defaults</para>
	/// </summary>
	public class EcsIndexChannel<TEcsDocument> : IndexChannel<TEcsDocument>
		where TEcsDocument : EcsDocument
	{
		/// <inheritdoc cref="EcsIndexChannel{TEcsDocument}"/>
		public EcsIndexChannel(IndexChannelOptions<TEcsDocument> options) : base(options) =>
			options.WriteEvent = async (stream, ctx, @event) =>
				await JsonSerializer.SerializeAsync(stream, @event, typeof(TEcsDocument), EcsJsonConfiguration.SerializerOptions, ctx)
					.ConfigureAwait(false);

		/// <summary>
		/// Bootstrap the target index. Will register the appropriate index and component templates
		/// </summary>
		/// <param name="bootstrapMethod">Either None (no bootstrapping), Silent (quiet exit), Failure (throw exceptions)</param>
		/// <param name="ilmPolicy">Registers a component template that ensures the template is managed by this ilm policy</param>
		public override bool BootstrapElasticsearch(BootstrapMethod bootstrapMethod, string? ilmPolicy = null)
		{
			if (bootstrapMethod == BootstrapMethod.None) return true;

			var name = $"{TemplateName}-{EcsDocument.Version}";
			var match = TemplateWildcard;
			if (IndexTemplateExists(name)) return false;

			foreach (var kv in IndexComponents.Components)
			{
				if (!PutComponentTemplate(bootstrapMethod, kv.Key, kv.Value))
					return false;
			}

			var additionalComponents = new List<string>();
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

		/// <summary>
		/// Bootstrap the target index. Will register the appropriate index and component templates
		/// </summary>
		/// <param name="bootstrapMethod">Either None (no bootstrapping), Silent (quiet exit), Failure (throw exceptions)</param>
		/// <param name="ilmPolicy">Registers a component template that ensures the template is managed by this ilm policy</param>
		/// <param name="ctx"></param>
		public override async Task<bool> BootstrapElasticsearchAsync(BootstrapMethod bootstrapMethod, string? ilmPolicy = null, CancellationToken ctx = default)
		{
			if (bootstrapMethod == BootstrapMethod.None) return true;

			var name = TemplateName;
			var match = TemplateWildcard;
			if (await IndexTemplateExistsAsync(name, ctx).ConfigureAwait(false)) return false;

			foreach (var kv in IndexComponents.Components)
			{
				if (!await PutComponentTemplateAsync(bootstrapMethod, kv.Key, kv.Value, ctx).ConfigureAwait(false))
					return false;
			}
			var additionalComponents = new List<string>();
			if (!string.IsNullOrEmpty(ilmPolicy))
			{
				// create a component template that sets  index.lifecycle.name
				var (settingsName, settingsBody) = GetDefaultComponentSettings(name, ilmPolicy);
				if (!await PutComponentTemplateAsync(bootstrapMethod, settingsName, settingsBody, ctx).ConfigureAwait(false))
					return false;
				additionalComponents.Add(settingsName);
			}

			var template = IndexTemplates.GetIndexTemplateForElasticsearchComposable(match, additionalComponents.ToArray());
			//hack but this would setup the target as a datastream
			template = template.Replace("\"data_stream\": {},", "");
			if (!await PutIndexTemplateAsync(bootstrapMethod, name, template, ctx).ConfigureAwait(false))
				return false;

			return true;
		}

	}
}
