// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Elastic.Ingest;
using Elastic.Ingest.Elasticsearch;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Elasticsearch.Extensions.Logging
{
	[ProviderAlias("Elasticsearch")]
	public class ElasticsearchLoggerProvider : ILoggerProvider, ISupportExternalScope
	{
		private readonly IChannelSetup[] _channelConfigurations;
		private readonly IOptionsMonitor<ElasticsearchLoggerOptions> _options;
		private readonly IDisposable _optionsReloadToken;
		private IExternalScopeProvider? _scopeProvider;
		private readonly ElasticsearchChannel<LogEvent> _shipper;

		public ElasticsearchLoggerProvider(IOptionsMonitor<ElasticsearchLoggerOptions> options,
			IEnumerable<IChannelSetup> channelConfigurations
		)
		{
			_options = options ?? throw new ArgumentNullException(nameof(options));

			if (channelConfigurations is null)
				throw new ArgumentNullException(nameof(channelConfigurations));

			_channelConfigurations = channelConfigurations.ToArray();

			var channelOptions = CreateChannelOptions(options.CurrentValue, _channelConfigurations);
			_shipper = new ElasticsearchChannel<LogEvent>(channelOptions);

			ReloadLoggerOptions(options.CurrentValue);
			_optionsReloadToken = _options.OnChange(o => ReloadLoggerOptions(o));
		}

		public static Func<DateTimeOffset> LocalDateTimeProvider { get; set; } = () => DateTimeOffset.UtcNow;

		public ILogger CreateLogger(string name) =>
			new ElasticsearchLogger(name, _shipper, _options.CurrentValue, _scopeProvider);

		public void Dispose()
		{
			_optionsReloadToken.Dispose();
			_shipper.Dispose();
		}

		public void SetScopeProvider(IExternalScopeProvider scopeProvider) => _scopeProvider = scopeProvider;

		private static ElasticsearchChannelOptions<LogEvent> CreateChannelOptions(ElasticsearchLoggerOptions options, IChannelSetup[] channelConfigurations)
		{
			var channelOptions = new ElasticsearchChannelOptions<LogEvent>
			{
				Index = options.Index,
				IndexOffset = options.IndexOffset,
				ConnectionPoolType = options.ShipTo.ConnectionPoolType,
				WriteEvent = async (stream, ctx, logEvent) => await logEvent.SerializeAsync(stream, ctx).ConfigureAwait(false),
				TimestampLookup = l => l.Timestamp
			};

			if (options.ShipTo.ConnectionPoolType == ConnectionPoolType.Cloud
				|| options.ShipTo.ConnectionPoolType == ConnectionPoolType.Unknown && !string.IsNullOrEmpty(options.ShipTo.CloudId))
			{
				channelOptions.ShipTo = !string.IsNullOrWhiteSpace(options.ShipTo.Username)
					? new ShipTo(options.ShipTo.CloudId, options.ShipTo.Username, options.ShipTo.Password)
					: new ShipTo(options.ShipTo.CloudId, options.ShipTo.ApiKey);
			}
			else
				channelOptions.ShipTo = new ShipTo(options.ShipTo.NodeUris, options.ShipTo.ConnectionPoolType);

			foreach (var channelSetup in channelConfigurations)
				channelSetup.ConfigureChannel(channelOptions);

			return channelOptions;
		}

		private void ReloadLoggerOptions(ElasticsearchLoggerOptions options) =>
			_shipper.Options = CreateChannelOptions(options, _channelConfigurations);
	}
}
