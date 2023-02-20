using System;
using System.Linq;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.CommonSchema;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Transport;
using Elastic.Transport.Products.Elasticsearch;
using Serilog.Core;
using Serilog.Debugging;
using Serilog.Events;

namespace Elastic.CommonSchema.Serilog.Sink
{
	public class ElasticsearchSchemaSinkOptions : ElasticsearchSchemaSinkOptions<EcsDocument>
	{
		public ElasticsearchSchemaSinkOptions() { }

		public ElasticsearchSchemaSinkOptions(HttpTransport transport) : base(transport) { }
	}

	public class ElasticsearchSchemaSinkOptions<TEcsDocument> where TEcsDocument : EcsDocument, new()
	{
		public ElasticsearchSchemaSinkOptions() : this(TransportHelper.Default()) { }

		public ElasticsearchSchemaSinkOptions(HttpTransport transport) => Transport = transport;

		public HttpTransport Transport { get; }
		public EcsTextFormatterConfiguration<TEcsDocument> TextFormatting { get; set; } = new();
		public DataStreamName DataStream { get; set; } = new("logs", "dotnet");
		public Action<DataStreamChannelOptions<TEcsDocument>>? ConfigureChannel { get; set; }
		public BootstrapMethod BootstrapMethod { get; set; }

	}

	public class ElasticsearchSink : ElasticsearchSink<EcsDocument>
	{
		public ElasticsearchSink(ElasticsearchSchemaSinkOptions options) : base(options) {}
	}

	public class ElasticsearchSink<TEcsDocument> : ILogEventSink
		where TEcsDocument : EcsDocument, new()
	{
		private readonly EcsTextFormatterConfiguration<TEcsDocument> _formatterConfiguration;
		private readonly EcsDataStreamChannel<TEcsDocument> _channel;

		public ElasticsearchSink(ElasticsearchSchemaSinkOptions<TEcsDocument> options)
		{
			_formatterConfiguration = options.TextFormatting;
			var channelOptions = new DataStreamChannelOptions<TEcsDocument>(options.Transport)
			{
				DataStream = options.DataStream,
				ExportResponseCallback = (response, _) =>
				{
					var errorItems = response.Items.Where(i => i.Status >= 300).ToList();
					if (response.TryGetElasticsearchServerError(out var error))
						SelfLog.WriteLine("{0}", error);
					foreach (var errorItem in errorItems)
						SelfLog.WriteLine("{0}", $"Failed to {errorItem.Action} document status: ${errorItem.Status}, error: ${errorItem.Error}");

				}
			};
			options.ConfigureChannel?.Invoke(channelOptions);
			_channel = new EcsDataStreamChannel<TEcsDocument>(channelOptions);
			_channel.BootstrapElasticsearch(options.BootstrapMethod);
		}


		public void Emit(LogEvent logEvent)
		{
			var ecsDoc = LogEventConverter.ConvertToEcs(logEvent, _formatterConfiguration);
			_channel.TryWrite(ecsDoc);
		}

	}
}
