// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Elastic.CommonSchema;
using Elastic.Channels;
using Elastic.Channels.Diagnostics;
using Elastic.Extensions.Logging.Common;
using Elastic.Extensions.Logging.Options;
using Microsoft.Extensions.Logging;

namespace Elastic.Extensions.Logging
{
	/// <summary>
	/// An <see cref="ILogger"/> implementation that writes logs directly to Elasticsearch
	/// </summary>
	public class ElasticsearchLogger : ILogger
	{
		private readonly string _categoryName;
		private IBufferedChannel<LogEvent> _channel => _channelProvider.GetChannel();
		private readonly IChannelProvider _channelProvider;
		private readonly ElasticsearchLoggerOptions _options;
		private readonly IExternalScopeProvider? _scopeProvider;

		/// <inheritdoc cref="IChannelDiagnosticsListener"/>
		public IChannelDiagnosticsListener? DiagnosticsListener => _channel.DiagnosticsListener;

		internal ElasticsearchLogger(
			string categoryName,
			IChannelProvider channelProvider,
			ElasticsearchLoggerOptions options,
			IExternalScopeProvider? scopeProvider
		)
		{
			_categoryName = categoryName;
			_options = options;
			_channelProvider = channelProvider;
			_scopeProvider = scopeProvider;
		}

		private class EmptyDisposable : IDisposable
		{
			public void Dispose() { }
		}
		private readonly IDisposable _emptyScope = new EmptyDisposable();

		/// <inheritdoc cref="ILogger.BeginScope{TState}"/>
		public IDisposable BeginScope<TState>(TState state) => _scopeProvider?.Push(state) ?? _emptyScope;

		/// <inheritdoc cref="ILogger.IsEnabled"/>
		public bool IsEnabled(LogLevel logLevel) => _options.IsEnabled;

		/// <inheritdoc cref="ILogger.Log{TState}"/>
		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception, string> formatter)
		{
			try
			{
				if (!IsEnabled(logLevel)) return;

				if (formatter is null) throw new ArgumentNullException(nameof(formatter));

				// TODO: Want to render state values (separate from message) to pass to log event, for semantic logging
				// Maybe render to JSON in-process, then queue bytes for sending to index ??

				var logEvent = BuildLogEvent(_categoryName, logLevel, eventId, state, exception, formatter);
				var written = _channel.TryWrite(logEvent);
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine("ElasticsearchLogger exception: {0}", ex);
			}
		}

		private static Agent? DefaultAgent { get; } = EcsDocument.CreateAgent(typeof(ElasticsearchLogger));

		private LogEvent BuildLogEvent<TState>(string categoryName, LogLevel logLevel,
			EventId eventId, TState state, Exception? exception,
			Func<TState, Exception, string> formatter
		)
		{
			var timestamp = ElasticsearchLoggerProvider.LocalDateTimeProvider();
			var logEvent = EcsDocument.CreateNewWithDefaults<LogEvent>(timestamp, exception, _options);

			logEvent.Message = formatter(state, exception!);
			logEvent.Log = new Log { Level = logLevel.ToEcsLogLevelString(), Logger = categoryName };
			logEvent.Event = new Event { Action = eventId.Name, Code = eventId.Id.ToString(), Severity = logLevel.ToEcsSeverity() };
			logEvent.Agent = DefaultAgent;

			if (_options.Tags is { Length: > 0 }) logEvent.Tags = _options.Tags;

			if (_options.IncludeScopes)
				logEvent.AddScopeValues(_scopeProvider, _options);

			// These will overwrite any scope values with the same name
			logEvent.AddStateValues(state, _options);

			return logEvent;
		}

	}
}
