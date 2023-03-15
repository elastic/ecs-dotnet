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
	/// <summary>
	/// Provides configuration options to <see cref="ElasticsearchSink"/> to control how and where data gets written
	/// </summary>
	public class ElasticsearchSinkOptions : ElasticsearchSinkOptions<EcsDocument>
	{
		/// <inheritdoc cref="ElasticsearchSinkOptions"/>
		public ElasticsearchSinkOptions() { }

		/// <inheritdoc cref="ElasticsearchSinkOptions"/>
		public ElasticsearchSinkOptions(HttpTransport transport) : base(transport) { }
	}

	/// <inheritdoc cref="ElasticsearchSinkOptions{TEcsDocument}"/>
	public class ElasticsearchSinkOptions<TEcsDocument> where TEcsDocument : EcsDocument, new()
	{
		/// <inheritdoc cref="ElasticsearchSinkOptions"/>
		public ElasticsearchSinkOptions() : this(new DefaultHttpTransport(TransportHelper.Default())) { }

		/// <inheritdoc cref="ElasticsearchSinkOptions"/>
		public ElasticsearchSinkOptions(HttpTransport transport) => Transport = transport;

		/// <inheritdoc cref="HttpTransport{TConfiguration}"/>
		internal HttpTransport Transport { get; }

		/// <inheritdoc cref="EcsTextFormatterConfiguration{TEcsDocument}"/>
		public EcsTextFormatterConfiguration<TEcsDocument> TextFormatting { get; set; } = new();

		/// <inheritdoc cref="DataStreamName"/>
		public DataStreamName DataStream { get; set; } = new("logs", "dotnet");

		/// <summary>
		/// Allows you to configure the <see cref="EcsDataStreamChannel{TEcsDocument}"/> used by the sink to send data to Elasticsearch
		/// </summary>
		public Action<DataStreamChannelOptions<TEcsDocument>>? ConfigureChannel { get; set; }

		/// <inheritdoc cref="BootstrapMethod"/>
		public BootstrapMethod BootstrapMethod { get; set; }

	}

	/// <summary>
	/// This sink allows you to write serilog logs directly to Elasticsearch or Elastic Cloud
	/// </summary>
	public class ElasticsearchSink : ElasticsearchSink<EcsDocument>
	{
		/// <inheritdoc cref="ElasticsearchSink"/>>
		public ElasticsearchSink(ElasticsearchSinkOptions options) : base(options) {}
	}

	/// <inheritdoc cref="ElasticsearchSink"/>>
	public class ElasticsearchSink<TEcsDocument> : ILogEventSink
		where TEcsDocument : EcsDocument, new()
	{
		private readonly EcsTextFormatterConfiguration<TEcsDocument> _formatterConfiguration;
		private readonly EcsDataStreamChannel<TEcsDocument> _channel;

		/// <inheritdoc cref="ElasticsearchSink"/>>
		public ElasticsearchSink(ElasticsearchSinkOptions<TEcsDocument> options)
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


		/// <inheritdoc cref="ILogEventSink.Emit"/>
		public void Emit(LogEvent logEvent)
		{
			var ecsDoc = LogEventConverter.ConvertToEcs(logEvent, _formatterConfiguration);
			_channel.TryWrite(ecsDoc);
		}

	}
}
