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
	public class ElasticsearchSchemaSinkOptions
	{
		public ITransport Transport { get; set; } = TransportHelper.Default();
		public EcsTextFormatterConfiguration EcsTextFormatterConfiguration { get; set; } = new ();
		public DataStreamName DataStream { get; set; } = new("logs", "dotnet");
		public Action<DataStreamChannelOptions<EcsDocument>>? ConfigureChannel { get; set; }

	}
	public class ElasticsearchSink : ILogEventSink
	{
		private readonly EcsTextFormatterConfiguration _formatterConfiguration;
		private readonly EcsTextFormatter _formatter;
		private readonly CommonSchemaChannel<EcsDocument> _channel;

		public ElasticsearchSink(ElasticsearchSchemaSinkOptions options)
		{
			_formatterConfiguration = options.EcsTextFormatterConfiguration;
			_formatter = new EcsTextFormatter(_formatterConfiguration);
			var channelOptions = new DataStreamChannelOptions<EcsDocument>(options.Transport)
			{
				DataStream = options.DataStream,
				ResponseCallback = ((response, statistics) =>
				{
					var errorItems = response.Items.Where(i => i.Status >= 300).ToList();
					if (response.TryGetElasticsearchServerError(out var error))
						SelfLog.WriteLine("{0}", error);
					foreach (var errorItem in errorItems)
						SelfLog.WriteLine("{0}", $"Failed to {errorItem.Action} document status: ${errorItem.Status}, error: ${errorItem.Error}");

				})
			};
			options.ConfigureChannel?.Invoke(channelOptions);
			_channel = new CommonSchemaChannel<EcsDocument>(channelOptions);
		}


		public void Emit(LogEvent logEvent)
		{
			var ecsDoc = LogEventConverter.ConvertToEcs(logEvent, _formatterConfiguration);
			_channel.TryWrite(ecsDoc);
		}
	}
}
