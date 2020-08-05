// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Concurrent;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Elasticsearch.Extensions.Logging
{
	[ProviderAlias("Elasticsearch")]
	public class ElasticsearchLoggerProvider : ILoggerProvider, ISupportExternalScope
	{
		private readonly ConcurrentDictionary<string, ElasticsearchLogger> _loggers;
		private readonly IOptionsMonitor<ElasticsearchLoggerOptions> _options;

		private readonly IDisposable _optionsReloadToken;
		private readonly ElasticsearchDataShipper _shipper;

		public ElasticsearchLoggerProvider(IOptionsMonitor<ElasticsearchLoggerOptions> options)
		{
			_options = options;
			_shipper = new ElasticsearchDataShipper();
			_loggers = new ConcurrentDictionary<string, ElasticsearchLogger>();
			ReloadLoggerOptions(options.CurrentValue);
			_optionsReloadToken = _options.OnChange(ReloadLoggerOptions);
		}

		private IExternalScopeProvider _scopeProvider = default!;

		public static Func<DateTimeOffset> LocalDateTimeProvider { get; set; } = () => DateTimeOffset.Now;

		public ILogger CreateLogger(string name) =>
			_loggers.GetOrAdd(name,
				loggerName =>
					new ElasticsearchLogger(name, _shipper) { Options = _options.CurrentValue, ScopeProvider = _scopeProvider });

		public void Dispose()
		{
			_optionsReloadToken?.Dispose();
			_shipper.Dispose();
		}

		public void SetScopeProvider(IExternalScopeProvider scopeProvider)
		{
			_scopeProvider = scopeProvider;
			foreach (var logger in _loggers) logger.Value.ScopeProvider = scopeProvider;
		}

		private void ReloadLoggerOptions(ElasticsearchLoggerOptions options)
		{
			_shipper.Options = options;
			foreach (var logger in _loggers) logger.Value.Options = options;
		}
	}
}
