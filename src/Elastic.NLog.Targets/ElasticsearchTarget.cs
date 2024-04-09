using System;
using System.Collections.Generic;
using System.Linq;
using Elastic.Channels;
using Elastic.Channels.Buffers;
using Elastic.Channels.Diagnostics;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.CommonSchema;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Ingest.Elasticsearch.Serialization;
using Elastic.Transport;
using Elastic.Transport.Products.Elasticsearch;
using NLog.Layouts;
using static Elastic.CommonSchema.NLog.EcsLayout;

namespace NLog.Targets
{
	/// <summary>
	/// This sink allows you to write serilog logs directly to Elasticsearch or Elastic Cloud
	/// </summary>
	[Target("Elasticsearch")]
	public class ElasticsearchTarget : TargetWithLayout
	{
		/// <inheritdoc />
		public override Layout Layout { get => _layout; set => _layout = value as Elastic.CommonSchema.NLog.EcsLayout ?? _layout; }
		private Elastic.CommonSchema.NLog.EcsLayout _layout = new Elastic.CommonSchema.NLog.EcsLayout();
		private EcsDataStreamChannel<NLogEcsDocument>? _channel;

		/// <summary>
		/// Gets or sets the connection pool type. Default for multiple nodes is <c>Sniffing</c>; other supported values are
		/// <c>Static</c>, <c>Sticky</c>, or force to <c>SingleNode</c>.
		/// </summary>
		public NodePoolType NodePoolType { get; set; }

		/// <summary>
		/// Gets or sets the URIs of the Elasticsearch nodes in the connection pool. If not specified the default single node
		/// "http://localhost:9200" is used.
		/// </summary>
		public Layout? NodeUris { get; set; }

		/// <summary>
		/// Allows the target datastream to be bootstrapped. The default is no bootstrapping
		/// since we assume the configured user might not have management privileges
		/// </summary>
		public BootstrapMethod BootstrapMethod { get; set; }

		/// <summary> Generic type describing the data</summary>
		public Layout? DataStreamType { get; set; } = "logs";
		/// <summary> Describes the data ingested and its structure</summary>
		public Layout? DataStreamSet { get; set; } = "dotnet";
		/// <summary> User-configurable arbitrary grouping</summary>
		public Layout? DataStreamNamespace { get; set; } = "default";

		/// <summary>
		/// The maximum number of in flight instances that can be queued in memory. If this threshold is reached, events will be dropped
		/// <para>Defaults to <c>100_000</c></para>
		/// </summary>
		public int InboundBufferMaxSize { get; set; }

		/// <summary>
		/// The maximum size to export to <see cref="BufferedChannelBase{TChannelOptions,TEvent,TResponse}.ExportAsync"/> at once.
		/// <para>Defaults to <c>1_000</c></para>
		/// </summary>
		public int OutboundBufferMaxSize { get; set; }

		/// <summary>
		/// The maximum lifetime of a buffer to export to <see cref="BufferedChannelBase{TChannelOptions,TEvent,TResponse}.ExportAsync"/>.
		/// If a buffer is older then the configured <see cref="OutboundBufferMaxLifetimeSeconds"/> it will be flushed to
		/// <see cref="BufferedChannelBase{TChannelOptions,TEvent,TResponse}.ExportAsync"/> regardless of it's current size
		/// <para>Defaults to <c>5 seconds</c></para>
		/// </summary>
		public int OutboundBufferMaxLifetimeSeconds { get; set; }

		/// <summary>
		/// The maximum number of consumers allowed to poll for new events on the channel.
		/// <para>Defaults to <c>1</c>, increase to introduce concurrency.</para>
		/// </summary>
		public int ExportMaxConcurrency { get; set; }

		/// <summary>
		/// The times to retry an export if <see cref="BufferedChannelBase{TChannelOptions,TEvent,TResponse}.RetryBuffer"/> yields items to retry.
		/// <para>Whether or not items are selected for retrying depends on the actual channel implementation</para>
		/// <para>Defaults to <c>3</c>, when <see cref="BufferedChannelBase{TChannelOptions,TEvent,TResponse}.RetryBuffer"/> yields any items</para>
		/// </summary>
		public int ExportMaxRetries { get; set; } = -1;

		/// <summary>
		/// The ILM Policy to apply, see the following for more details:
		/// <para>https://www.elastic.co/guide/en/elasticsearch/reference/current/index-lifecycle-management.html</para>
		/// Defaults to `logs` which is shipped by default with Elasticsearch
		/// </summary>
		public Layout? IlmPolicy { get; set; }

		/// <summary>
		/// Gets or sets the cloud ID, where connection pool type is Cloud.
		/// </summary>
		public Layout? CloudId { get; set; }

		/// <summary>
		/// Gets or sets the API Key, where connection pool type is Cloud, and authenticating via API Key.
		/// </summary>
		public Layout? ApiKey { get; set; }

		/// <summary>
		/// Gets or sets the password, where connection pool type is Cloud, and authenticating via username/password.
		/// </summary>
		public Layout? Password { get; set; }

		/// <summary>
		/// Gets or sets the username, where connection pool type is Cloud, and authenticating via username/password.
		/// </summary>
		public Layout? Username { get; set; }

		/// <summary>
		/// Provide callbacks to further configure <see cref="DataStreamChannelOptions{TEvent}"/>
		/// </summary>
		public Action<DataStreamChannelOptions<NLogEcsDocument>>? ConfigureChannel { get; set; }

		/// <inheritdoc cref="IChannelDiagnosticsListener"/>
		public IChannelDiagnosticsListener? DiagnosticsListener => _channel?.DiagnosticsListener;

		/// <inheritdoc />
		protected override void InitializeTarget()
		{
			var ilmPolicy = IlmPolicy?.Render(LogEventInfo.CreateNullEvent());
			var dataStreamType = DataStreamType?.Render(LogEventInfo.CreateNullEvent()) ?? string.Empty;
			var dataStreamSet = DataStreamSet?.Render(LogEventInfo.CreateNullEvent()) ?? string.Empty;
			var dataStreamNamespace = DataStreamNamespace?.Render(LogEventInfo.CreateNullEvent()) ?? string.Empty;

			var connectionPool = CreateNodePool();
			var config = new TransportConfiguration(connectionPool, productRegistration: ElasticsearchProductRegistration.Default);
			// Cloud sets authentication as required parameter in the constructor
			if (NodePoolType != NodePoolType.Cloud)
				config = SetAuthenticationOnTransport(config);

			var transport = new DistributedTransport<TransportConfiguration>(config);
			var channelOptions = new DataStreamChannelOptions<NLogEcsDocument>(transport)
			{
				DataStream = new DataStreamName(dataStreamType, dataStreamSet, dataStreamNamespace),
				WriteEvent = async (stream, ctx, logEvent) => await logEvent.SerializeAsync(stream, ctx).ConfigureAwait(false),
			};
			if (InboundBufferMaxSize > 0)
				channelOptions.BufferOptions.InboundBufferMaxSize = InboundBufferMaxSize;
			if (OutboundBufferMaxSize > 0)
				channelOptions.BufferOptions.OutboundBufferMaxSize = OutboundBufferMaxSize;
			if (OutboundBufferMaxLifetimeSeconds > 0)
				channelOptions.BufferOptions.OutboundBufferMaxLifetime = TimeSpan.FromSeconds(OutboundBufferMaxLifetimeSeconds);
			if (ExportMaxConcurrency > 0)
				channelOptions.BufferOptions.ExportMaxConcurrency = ExportMaxConcurrency;
			if (ExportMaxRetries >= 0)
				channelOptions.BufferOptions.ExportMaxRetries = ExportMaxRetries;
			ConfigureChannel?.Invoke(channelOptions);

			var channel = new EcsDataStreamChannel<NLogEcsDocument>(channelOptions, new[] { new InternalLoggerCallbackListener<NLogEcsDocument>() });
			channel.BootstrapElasticsearch(BootstrapMethod, ilmPolicy);
			_channel = channel;
		}

		/// <inheritdoc />
		protected override void CloseTarget()
		{
			_channel?.Dispose();
			base.CloseTarget();
		}

		/// <inheritdoc />
		protected override void Write(LogEventInfo logEvent)
		{ 
			var ecsDoc = _layout.RenderEcsDocument(logEvent);
			_channel?.TryWrite(ecsDoc);
		}

		private NodePool CreateNodePool()
		{
			var nodeUris = NodeUris?.Render(LogEventInfo.CreateNullEvent()).Split(new[] { ',' }).Select(uri => uri.Trim()).Where(uri => !string.IsNullOrEmpty(uri)).Select(uri => new Uri(uri)).ToArray() ?? Array.Empty<Uri>();
			if (nodeUris.Length == 0 && NodePoolType != NodePoolType.Cloud)
				return new SingleNodePool(new Uri("http://localhost:9200"));
			if (NodePoolType == NodePoolType.SingleNode || NodePoolType == NodePoolType.Unknown && nodeUris.Length == 1)
				return new SingleNodePool(nodeUris[0]);

			switch (NodePoolType)
			{
				case NodePoolType.Unknown:
				case NodePoolType.Sniffing:
					return new SniffingNodePool(nodeUris);
				case NodePoolType.Static:
					return new StaticNodePool(nodeUris);
				case NodePoolType.Sticky:
					return new StickyNodePool(nodeUris);
				// case NodePoolType.StickySniffing:
				case NodePoolType.Cloud:
					var cloudId = CloudId?.Render(LogEventInfo.CreateNullEvent()) ?? string.Empty;
					if (string.IsNullOrEmpty(cloudId))
						throw new NLogConfigurationException($"ElasticSearch Cloud {nameof(CloudNodePool)} requires '{nameof(CloudId)}' to be provided as well");

					var apiKey = ApiKey?.Render(LogEventInfo.CreateNullEvent()) ?? string.Empty;
					if (!string.IsNullOrEmpty(apiKey))
					{
						var apiKeyCredentials = new ApiKey(apiKey);
						return new CloudNodePool(cloudId, apiKeyCredentials);
					}

					var username = Username?.Render(LogEventInfo.CreateNullEvent()) ?? string.Empty;
					var password = Password?.Render(LogEventInfo.CreateNullEvent()) ?? string.Empty;
					if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
					{
						var basicAuthCredentials = new BasicAuthentication(username, password);
						return new CloudNodePool(cloudId, basicAuthCredentials);
					}

					throw new NLogConfigurationException($"ElasticSearch Cloud requires either '{nameof(ApiKey)}' or"
						+ $"'{nameof(Username)}' and '{nameof(Password)}");

				default:
					throw new NLogConfigurationException($"Unrecognised ElasticSearch connection pool type '{NodePoolType}' specified in the configuration.",
						nameof(NodePoolType));
			}
		}

		private TransportConfiguration SetAuthenticationOnTransport(TransportConfiguration config)
		{
			var apiKey = ApiKey?.Render(LogEventInfo.CreateNullEvent()) ?? string.Empty;
			var username = Username?.Render(LogEventInfo.CreateNullEvent()) ?? string.Empty;
			var password = Password?.Render(LogEventInfo.CreateNullEvent()) ?? string.Empty;
			if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
				config = config.Authentication(new BasicAuthentication(username, password));
			else if (!string.IsNullOrEmpty(apiKey))
				config = config.Authentication(new ApiKey(apiKey));
			return config;
		}
	}

	internal class InternalLoggerCallbackListener<TNLogEcsDocument> : IChannelCallbacks<TNLogEcsDocument, BulkResponse> where TNLogEcsDocument : NLogEcsDocument, new()
	{
		public Action<Exception>? ExportExceptionCallback { get; }
		public Action<BulkResponse, IWriteTrackingBuffer>? ExportResponseCallback { get; }

		// ReSharper disable UnassignedGetOnlyAutoProperty
		public Action<int, int>? ExportItemsAttemptCallback { get; }
		public Action<IReadOnlyCollection<TNLogEcsDocument>>? ExportMaxRetriesCallback { get; }
		public Action<IReadOnlyCollection<TNLogEcsDocument>>? ExportRetryCallback { get; }
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

		public InternalLoggerCallbackListener()
		{
			ExportExceptionCallback = ex =>
			{
				NLog.Common.InternalLogger.Error(ex, "ElasticSearch - Export Exception");
			};
			ExportResponseCallback = (response, _) =>
			{
				if (response is null)
					return;

				if (response.TryGetElasticsearchServerError(out var error))
					NLog.Common.InternalLogger.Error("ElasticSearch - Export Response Server Error - {0}", error);

				if (response.Items?.Count > 0)
				{
					foreach (var itemResult in response.Items)
						if (itemResult?.Status >= 300)
							NLog.Common.InternalLogger.Error("ElasticSearch - Export Item failed to {0} document status {1} - {2}", itemResult.Action, itemResult.Status, itemResult.Error);
				}
			};
		}
	}
}
