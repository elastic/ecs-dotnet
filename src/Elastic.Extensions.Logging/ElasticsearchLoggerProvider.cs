// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Elastic.Channels;
using Elastic.Channels.Diagnostics;
using Elastic.Extensions.Logging.Options;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.CommonSchema;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Ingest.Elasticsearch.Indices;
using Elastic.Transport;
using Elastic.Transport.Products.Elasticsearch;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Elastic.Extensions.Logging
{
	/// <summary>
	/// An <see cref="ILoggerProvider"/> implementation that exposes a way to create <see cref="ElasticsearchLogger"/>
	/// instances to <see cref="LoggerFactory"/>
	/// </summary>
	[ProviderAlias("Elasticsearch")]
	public class ElasticsearchLoggerProvider : ILoggerProvider, ISupportExternalScope, IChannelProvider
	{
		private readonly IChannelSetup[] _channelConfigurations;
		private readonly IOptionsMonitor<ElasticsearchLoggerOptions> _options;
		private readonly IDisposable _optionsReloadToken;
		private IExternalScopeProvider? _scopeProvider;
		private IBufferedChannel<LogEvent> _shipper;

		/// <inheritdoc cref="IChannelDiagnosticsListener"/>
		public IChannelDiagnosticsListener? DiagnosticsListener { get; }

		/// <inheritdoc cref="ElasticsearchLoggerProvider"/>
		public ElasticsearchLoggerProvider(IOptionsMonitor<ElasticsearchLoggerOptions> options,
			IEnumerable<IChannelSetup> channelConfigurations
		)
		{
			_options = options ?? throw new ArgumentNullException(nameof(options));

			if (channelConfigurations is null)
				throw new ArgumentNullException(nameof(channelConfigurations));

			_channelConfigurations = channelConfigurations.ToArray();

			_shipper = CreatIngestChannel(options.CurrentValue);
			_optionsReloadToken = _options.OnChange(o => ReloadShipper(o));
			DiagnosticsListener = _shipper.DiagnosticsListener;
		}

		// ReSharper disable once AutoPropertyCanBeMadeGetOnly.Global
		/// <summary> Returns <see cref="DateTimeOffset.UtcNow"/></summary>
		public static Func<DateTimeOffset> LocalDateTimeProvider { get; set; } = () => DateTimeOffset.UtcNow;

		/// <inheritdoc cref="ILoggerProvider.CreateLogger"/>
		public ILogger CreateLogger(string name) =>
			new ElasticsearchLogger(name, this, _options.CurrentValue, _scopeProvider);

		/// <inheritdoc cref="IDisposable.Dispose"/>
		public void Dispose()
		{
			_optionsReloadToken.Dispose();
			_shipper.Dispose();
		}

		/// <inheritdoc cref="ISupportExternalScope.SetScopeProvider"/>
		public void SetScopeProvider(IExternalScopeProvider scopeProvider) => _scopeProvider = scopeProvider;

		private static void SetupChannelOptions(
			IChannelSetup[] channelConfigurations,
			ElasticsearchChannelOptionsBase<LogEvent> channelOptions
		)
		{
			foreach (var channelSetup in channelConfigurations)
				channelSetup.ConfigureChannel(channelOptions);
		}

		private static NodePool CreateNodePool(ElasticsearchLoggerOptions loggerOptions)
		{
			var shipTo = loggerOptions.ShipTo;
			var connectionPool = loggerOptions.ShipTo.NodePoolType;
			var nodeUris = loggerOptions.ShipTo.NodeUris?.ToArray() ?? Array.Empty<Uri>();
			if (nodeUris.Length == 0 && connectionPool != NodePoolType.Cloud)
				return new SingleNodePool(new Uri("http://localhost:9200"));
			if (connectionPool == NodePoolType.SingleNode || connectionPool == NodePoolType.Unknown && nodeUris.Length == 1)
				return new SingleNodePool(nodeUris[0]);

			switch (connectionPool)
			{
				// TODO: Add option to randomize pool
				case NodePoolType.Unknown:
				case NodePoolType.Sniffing:
					return new SniffingNodePool(nodeUris);
				case NodePoolType.Static:
					return new StaticNodePool(nodeUris);
				case NodePoolType.Sticky:
					return new StickyNodePool(nodeUris);
				// case NodePoolType.StickySniffing:
				case NodePoolType.Cloud:
					if (shipTo.CloudId.IsNullOrEmpty())
						throw new Exception($"Cloud {nameof(CloudNodePool)} requires '{nameof(ShipToOptions.CloudId)}' to be provided as well");

					if (!shipTo.ApiKey.IsNullOrEmpty())
					{
						var apiKeyCredentials = new ApiKey(shipTo.ApiKey);
						return new CloudNodePool(shipTo.CloudId, apiKeyCredentials);
					}
					if (!shipTo.Username.IsNullOrEmpty() && !shipTo.Password.IsNullOrEmpty())
					{
						var basicAuthCredentials = new BasicAuthentication(shipTo.Username, shipTo.Password);
						return new CloudNodePool(shipTo.CloudId, basicAuthCredentials);
					}
					throw new Exception(
						$"Cloud requires either '{nameof(ShipToOptions.ApiKey)}' or"
						+ $"'{nameof(ShipToOptions.Username)}' and '{nameof(ShipToOptions.Password)}"
					);
				default:
					throw new ArgumentException($"Unrecognised connection pool type '{connectionPool}' specified in the configuration.",
						nameof(connectionPool));
			}
		}

		private static ITransport CreateTransport(ElasticsearchLoggerOptions loggerOptions)
		{
			// TODO: Check if Uri has changed before recreating
			// TODO: Injectable factory? Or some way of testing.
			if (loggerOptions.Transport != null) return loggerOptions.Transport;

			var connectionPool = CreateNodePool(loggerOptions);
			var config = new TransportConfiguration(connectionPool, productRegistration: ElasticsearchProductRegistration.Default);
			// Cloud sets authentication as required parameter in the constructor
			if (loggerOptions.ShipTo.NodePoolType != NodePoolType.Cloud)
				config = SetAuthenticationOnTransport(loggerOptions, config);

			var transport = new DistributedTransport<TransportConfiguration>(config);
			return transport;
		}

		private static TransportConfiguration SetAuthenticationOnTransport(ElasticsearchLoggerOptions loggerOptions, TransportConfiguration config)
		{
			var apiKey = loggerOptions.ShipTo.ApiKey;
			var username = loggerOptions.ShipTo.Username;
			var password = loggerOptions.ShipTo.Password;
			if (!username.IsNullOrEmpty() && !password.IsNullOrEmpty())
				config = config.Authentication(new BasicAuthentication(username, password));
			else if (!apiKey.IsNullOrEmpty())
				config = config.Authentication(new ApiKey(apiKey));
			return config;
		}

		private void ReloadShipper(ElasticsearchLoggerOptions loggerOptions)
		{
			var newShipper = CreatIngestChannel(loggerOptions);
			var oldShipper = Interlocked.Exchange(ref _shipper, newShipper);
			oldShipper?.Dispose();
		}

		private IBufferedChannel<LogEvent> CreatIngestChannel(ElasticsearchLoggerOptions loggerOptions)
		{
			var transport = CreateTransport(loggerOptions);
			if (loggerOptions.Index != null)
			{
				var indexChannelOptions = new IndexChannelOptions<LogEvent>(transport)
				{
					IndexFormat = loggerOptions.Index.Format,
					IndexOffset = loggerOptions.Index.IndexOffset,
					TimestampLookup = l => l.Timestamp,
				};
				SetupChannelOptions(_channelConfigurations, indexChannelOptions);
				return new EcsIndexChannel<LogEvent>(indexChannelOptions);
			}
			else
			{
				var dataStreamNameOptions = loggerOptions.DataStream ?? new DataStreamNameOptions();
				var indexChannelOptions = new DataStreamChannelOptions<LogEvent>(transport)
				{
					DataStream = new DataStreamName(dataStreamNameOptions.Type, dataStreamNameOptions.DataSet, dataStreamNameOptions.Namespace),
					WriteEvent = async (stream, ctx, logEvent) => await logEvent.SerializeAsync(stream, ctx).ConfigureAwait(false),
				};
				SetupChannelOptions(_channelConfigurations, indexChannelOptions);
				var channel = new EcsDataStreamChannel<LogEvent>(indexChannelOptions);
				channel.BootstrapElasticsearch(loggerOptions.BootstrapMethod, loggerOptions.IlmPolicy);
				return channel;
			}
		}

		/// <inheritdoc cref="IChannelProvider.GetChannel"/>
		public IBufferedChannel<LogEvent> GetChannel() => _shipper;
	}
}
