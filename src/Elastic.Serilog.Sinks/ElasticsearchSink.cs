using System;
using System.Collections.Generic;
using System.Linq;
using Elastic.Channels;
using Elastic.Channels.Buffers;
using Elastic.Channels.Diagnostics;
using Elastic.CommonSchema;
using Elastic.CommonSchema.Serilog;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.CommonSchema;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Ingest.Elasticsearch.Serialization;
using Elastic.Transport;
using Elastic.Transport.Products.Elasticsearch;
using Serilog.Core;
using Serilog.Debugging;
using Serilog.Events;

namespace Elastic.Serilog.Sinks
{

	/// <summary>
	/// A read only view of the options provided to <see cref="ElasticsearchSink"/>
	/// </summary>
	public interface IElasticsearchSinkOptions
	{
		/// <inheritdoc cref="BootstrapMethod"/>
		BootstrapMethod BootstrapMethod { get; }

		/// <inheritdoc cref="IEcsTextFormatterConfiguration"/>
		IEcsTextFormatterConfiguration EcsTextFormatterConfiguration { get; }

		/// <inheritdoc cref="DataStreamName"/>
		public DataStreamName DataStream { get; }

		/// <summary>
		/// The ILM Policy to apply, see the following for more details:
		/// <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/index-lifecycle-management.html</para>
		/// Defaults to `logs` which is shipped by default with Elasticsearch
		/// </summary>
		public string? IlmPolicy { get; }

	}

	/// <summary>
	/// Provides configuration options to <see cref="ElasticsearchSink"/> to control how and where data gets written
	/// </summary>
	public class ElasticsearchSinkOptions : ElasticsearchSinkOptions<LogEventEcsDocument>
	{
		/// <inheritdoc cref="ElasticsearchSinkOptions"/>
		public ElasticsearchSinkOptions() { }

		/// <inheritdoc cref="ElasticsearchSinkOptions"/>
		public ElasticsearchSinkOptions(ITransport transport) : base(transport) { }
	}

	/// <inheritdoc cref="ElasticsearchSinkOptions{TEcsDocument}"/>
	public class ElasticsearchSinkOptions<TEcsDocument>
		: IElasticsearchSinkOptions
		where TEcsDocument : LogEventEcsDocument, new()
	{
		/// <inheritdoc cref="ElasticsearchSinkOptions"/>
		public ElasticsearchSinkOptions() : this(new DistributedTransport(TransportHelper.Default())) { }

		/// <inheritdoc cref="ElasticsearchSinkOptions"/>
		public ElasticsearchSinkOptions(ITransport transport) => Transport = transport;

		/// <inheritdoc cref="ITransport{TConfiguration}"/>
		internal ITransport Transport { get; }

		IEcsTextFormatterConfiguration IElasticsearchSinkOptions.EcsTextFormatterConfiguration => TextFormatting;

		/// <inheritdoc cref="EcsTextFormatterConfiguration{TEcsDocument}"/>
		public EcsTextFormatterConfiguration<TEcsDocument> TextFormatting { get; set; } = new();

		/// <inheritdoc cref="DataStreamName"/>
		public DataStreamName DataStream { get; set; } = new("logs", "dotnet");

		/// <summary>
		/// Allows you to configure the <see cref="EcsDataStreamChannel{TEcsDocument}"/> used by the sink to send data to Elasticsearch
		/// </summary>
		public Action<DataStreamChannelOptions<TEcsDocument>>? ConfigureChannel { get; set; }

		/// <summary>
		/// Allows programmatic access to active channel diagnostics listener when its created.
		/// </summary>
		public Action<IChannelDiagnosticsListener>? ChannelDiagnosticsCallback { get; set; }

		/// <inheritdoc cref="BootstrapMethod"/>
		public BootstrapMethod BootstrapMethod { get; set; }

		/// <inheritdoc cref="IElasticsearchSinkOptions.IlmPolicy"/>
		public string? IlmPolicy { get; set; }

		/// <summary>
		/// Provide an explicit minimum <see cref="LogEventLevel"/> for the Elasticsearch sink.
		/// <para>This allows you to separately configure the sink to filter out messages.</para>
		/// <para>E.g: Configure default logging at <see cref="LogEventLevel.Verbose"/> but only write <see cref="LogEventLevel.Error"/>
		/// to Elasticsearch</para>
		/// </summary>
		public LogEventLevel? MinimumLevel { get; set; }

		/// <summary>
		/// A switch allowing the pass-through minimum level to be changed at runtime.
		/// <para>Takes precedence over <see cref="MinimumLevel"/> if both are configured</para>
		/// </summary>
		public LoggingLevelSwitch? LevelSwitch { get; set; }

	}

	/// <summary>
	/// This sink allows you to write serilog logs directly to Elasticsearch or Elastic Cloud
	/// </summary>
	public class ElasticsearchSink : ElasticsearchSink<LogEventEcsDocument>
	{
		/// <inheritdoc cref="ElasticsearchSink"/>>
		public ElasticsearchSink(ElasticsearchSinkOptions options) : base(options) {}
	}

	/// <inheritdoc cref="ElasticsearchSink"/>>
	public class ElasticsearchSink<TEcsDocument> : ILogEventSink, IDisposable, ISetLoggingFailureListener
		where TEcsDocument : LogEventEcsDocument, new()
	{
		private readonly EcsTextFormatterConfiguration<TEcsDocument> _formatterConfiguration;
		private readonly EcsDataStreamChannel<TEcsDocument> _channel;
		private ILoggingFailureListener _failureListener = SelfLog.FailureListener;

		/// <inheritdoc cref="IElasticsearchSinkOptions"/>
		public IElasticsearchSinkOptions Options { get; }

		/// <inheritdoc cref="ElasticsearchSink"/>>
		public ElasticsearchSink(ElasticsearchSinkOptions<TEcsDocument> options)
		{
			Options = options;
			_formatterConfiguration = options.TextFormatting;
			var channelOptions = new DataStreamChannelOptions<TEcsDocument>(options.Transport)
			{
				DataStream = options.DataStream,
				ExportMaxRetriesCallback = EmitExportFailures

			};
			options.ConfigureChannel?.Invoke(channelOptions);
			_channel = new EcsDataStreamChannel<TEcsDocument>(channelOptions, new [] { new SelfLogCallbackListener<TEcsDocument>(options)});
			if (_channel.DiagnosticsListener != null)
				options.ChannelDiagnosticsCallback?.Invoke(_channel.DiagnosticsListener);
			_channel.BootstrapElasticsearch(options.BootstrapMethod, options.IlmPolicy);
		}

		private void EmitExportFailures(IReadOnlyCollection<TEcsDocument> documents)
		{
			var logs = documents
				.Select(d => d.LogEvent)
				.ToArray();
			_failureListener.OnLoggingFailed(
				this,
				LoggingFailureKind.Temporary,
				"Failure to export events over to Elasticsearch.",
				logs,
				exception: null
			);
		}

		/// <inheritdoc cref="ILogEventSink.Emit"/>
		public void Emit(LogEvent logEvent)
		{
			var ecsDoc = LogEventConverter.ConvertToEcs(logEvent, _formatterConfiguration);
			ecsDoc.LogEvent = logEvent;
			if (!_channel.TryWrite(ecsDoc))
			{
				_failureListener.OnLoggingFailed(
					this,
					LoggingFailureKind.Temporary,
					"Failure to push event over the channel.",
					[logEvent],
					exception: null
				);
			}
		}

		/// <summary> Disposes and flushed <see cref="EcsDataStreamChannel{TEcsDocument}"/> </summary>
		public void Dispose() => _channel.Dispose();

		void ISetLoggingFailureListener.SetFailureListener(ILoggingFailureListener failureListener) =>
			_failureListener = failureListener ?? throw new ArgumentNullException(nameof(failureListener));
	}

	internal class SelfLogCallbackListener<TEcsDocument> : IChannelCallbacks<TEcsDocument, BulkResponse>
		where TEcsDocument : LogEventEcsDocument, new()
	{
		public Action<Exception>? ExportExceptionCallback { get; }
		public Action<BulkResponse, IWriteTrackingBuffer>? ExportResponseCallback { get; }

		// ReSharper disable UnassignedGetOnlyAutoProperty
		public Action<int, int>? ExportItemsAttemptCallback { get; }
		public Action<IReadOnlyCollection<TEcsDocument>>? ExportMaxRetriesCallback { get; }
		public Action<IReadOnlyCollection<TEcsDocument>>? ExportRetryCallback { get; }
		public Action? PublishToInboundChannelCallback { get; }
		public Action? PublishToInboundChannelFailureCallback { get; }
		public Action? PublishToOutboundChannelCallback { get; }
		public Action? OutboundChannelStartedCallback { get; }
		public Action? OutboundChannelExitedCallback { get; }
		public Action? InboundChannelStartedCallback { get; }
		public Action? PublishToOutboundChannelFailureCallback { get; }
		public Action? ExportBufferCallback { get; }
		public Action<int>? ExportRetryableCountCallback { get; }
		// ReSharper enable UnassignedGetOnlyAutoProperty

		public SelfLogCallbackListener(ElasticsearchSinkOptions<TEcsDocument> options)
		{
			ExportExceptionCallback = e =>
			{
				SelfLog.WriteLine("Observed an exception while writing to {0}", options.DataStream);
				SelfLog.WriteLine("{0}", e);
			};
			ExportResponseCallback = (response, _) =>
			{
				if (response == null) return;

				if (response.TryGetElasticsearchServerError(out var error))
					SelfLog.WriteLine("{0}", error);
				// ReSharper disable once ConditionalAccessQualifierIsNonNullableAccordingToAPIContract
				var errorItems = response.Items?.Where(i => i.Status >= 300).ToArray() ?? Array.Empty<BulkResponseItem>();
				foreach (var errorItem in errorItems)
					SelfLog.WriteLine("{0}", $"Failed to {errorItem.Action} document status: ${errorItem.Status}, error: ${errorItem.Error}");

			};
		}
	}
}
