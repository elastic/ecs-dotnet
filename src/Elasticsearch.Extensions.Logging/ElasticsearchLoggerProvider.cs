// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Elastic.Ingest;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Elasticsearch.Extensions.Logging
{
	[ProviderAlias("Elasticsearch")]
	public class ElasticsearchLoggerProvider : ILoggerProvider, ISupportExternalScope
	{
		private readonly IChannelSetup[] _channelConfigurations;

		private readonly ConcurrentDictionary<string, ElasticsearchLogger> _loggers;

		private readonly IOptionsMonitor<ElasticsearchLoggerOptions> _options;

		private readonly IDisposable _optionsReloadToken;

		private IExternalScopeProvider _scopeProvider = default!;
		private readonly ElasticsearchChannel<LogEvent> _shipper;

		public ElasticsearchLoggerProvider(IOptionsMonitor<ElasticsearchLoggerOptions> options,
			IEnumerable<IChannelSetup> channelConfigurations
		)
		{
			_options = options;
			_channelConfigurations = channelConfigurations.ToArray();

			var channelOptions = CreateChannelOptions(options.CurrentValue, _channelConfigurations);
			_shipper = new ElasticsearchChannel<LogEvent>(channelOptions);

			_loggers = new ConcurrentDictionary<string, ElasticsearchLogger>();
			ReloadLoggerOptions(options.CurrentValue);
			_optionsReloadToken = _options.OnChange(ReloadLoggerOptions);
		}

		public static Func<DateTimeOffset> LocalDateTimeProvider { get; set; } = () => DateTimeOffset.UtcNow;

		public ILogger CreateLogger(string name) =>
			_loggers.GetOrAdd(name,
				loggerName =>
					new ElasticsearchLogger(name, _shipper) { Options = _options.CurrentValue, ScopeProvider = _scopeProvider });

		public void Dispose()
		{
			_optionsReloadToken.Dispose();
			_shipper.Dispose();
		}

		public void SetScopeProvider(IExternalScopeProvider scopeProvider)
		{
			_scopeProvider = scopeProvider;
			foreach (var logger in _loggers) logger.Value.ScopeProvider = scopeProvider;
		}

		private ElasticsearchChannelOptions<LogEvent> CreateChannelOptions(ElasticsearchLoggerOptions options,
			IChannelSetup[] channelConfigurations
		)
		{
			var channelOptions = new ElasticsearchChannelOptions<LogEvent>();
			channelOptions.Index = options.Index;
			channelOptions.IndexOffset = options.IndexOffset;
			channelOptions.ConnectionPoolType = options.ShipTo.ConnectionPoolType;

			channelOptions.WriteEvent = async (stream, ctx, l) => await l.SerializeAsync(stream, ctx).ConfigureAwait(false);
			channelOptions.TimestampLookup = l => l.Timestamp;

			if (options.ShipTo.ConnectionPoolType == ConnectionPoolType.Cloud
				|| options.ShipTo.ConnectionPoolType == ConnectionPoolType.Unknown && !string.IsNullOrEmpty(options.ShipTo.CloudId))
			{
				if (!string.IsNullOrWhiteSpace(options.ShipTo.Username))
					channelOptions.ShipTo = new ShipTo(options.ShipTo.CloudId, options.ShipTo.Username, options.ShipTo.Password);
				else
					channelOptions.ShipTo = new ShipTo(options.ShipTo.CloudId, options.ShipTo.ApiKey);
			}
			else
				channelOptions.ShipTo = new ShipTo(options.ShipTo.NodeUris, options.ShipTo.ConnectionPoolType);

			foreach (var channelSetup in channelConfigurations) channelSetup.ConfigureChannel(channelOptions);

			return channelOptions;
		}

		private void ReloadLoggerOptions(ElasticsearchLoggerOptions options)
		{
			var channelOptions = CreateChannelOptions(options, _channelConfigurations);
			_shipper.Options = channelOptions;

			foreach (var logger in _loggers) logger.Value.Options = options;
		}
	}
}
