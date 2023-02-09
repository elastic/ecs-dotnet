// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Elastic.CommonSchema;
using Elastic.Channels;
using Elasticsearch.Extensions.Logging.Options;
using Microsoft.Extensions.Logging;

namespace Elasticsearch.Extensions.Logging
{
	public class ElasticsearchLogger : ILogger
	{
		private readonly string _categoryName;
		private readonly IBufferedChannel<LogEvent> _channel;
		private readonly ElasticsearchLoggerOptions _options;
		private readonly IExternalScopeProvider? _scopeProvider;

		internal ElasticsearchLogger(
			string categoryName,
			IBufferedChannel<LogEvent> channel,
			ElasticsearchLoggerOptions options,
			IExternalScopeProvider? scopeProvider
		)
		{
			_categoryName = categoryName;
			_channel = channel;
			_options = options;
			_scopeProvider = scopeProvider;
		}

		public IDisposable? BeginScope<TState>(TState state) => _scopeProvider?.Push(state);

		public bool IsEnabled(LogLevel logLevel) => _options.IsEnabled;

		public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
			Func<TState, Exception, string> formatter
		)
		{
			try
			{
				if (!IsEnabled(logLevel)) return;

				if (formatter is null) throw new ArgumentNullException(nameof(formatter));

				// TODO: Want to render state values (separate from message) to pass to log event, for semantic logging
				// Maybe render to JSON in-process, then queue bytes for sending to index ??

				var logEvent = BuildLogEvent(_categoryName, logLevel, eventId, state, exception, formatter);
				_channel.TryWrite(logEvent);
			}
			catch (Exception ex)
			{
				Console.Error.WriteLine("ElasticsearchLogger exception: {0}", ex);
			}
		}

		private void AddScopeValues(LogEvent logEvent)
		{
			if (_options.IncludeScopes)
			{
				_scopeProvider?.ForEachScope((scope, le) =>
				{
					le.Labels ??= new Labels();
					le.Scopes ??= new List<string>();

					var isFormattedLogValues = false;
					if (scope is IEnumerable<KeyValuePair<string, object>> scopeValues)
					{
						foreach (var kvp in scopeValues)
						{
							if (kvp.Key == "{OriginalFormat}")
							{
								isFormattedLogValues = true;
								continue;
							}
							le.AssignField(kvp.Key, FormatValue(kvp.Value));
						}
					}

					var formattedScope = isFormattedLogValues ? scope.ToString() : FormatValue(scope);
					le.Scopes.Add(formattedScope);
				}, logEvent);
			}
		}

		private void AddStateValues<TState>(TState state, LogEvent logEvent)
		{
			if (state is IEnumerable<KeyValuePair<string, object>> stateValues)
			{
				foreach (var kvp in stateValues)
				{
					if (kvp.Key == "{OriginalFormat}")
					{
						logEvent.MessageTemplate = kvp.Value.ToString();
						continue;
					}
					logEvent.AssignField(kvp.Key, FormatValue(kvp.Value));
				}
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
			logEvent.Log = new Log { Level = LogEventToEcsHelper.GetLogLevelString(logLevel), Logger = categoryName };
			logEvent.Event = new Event { Action = eventId.Name, Code = eventId.Id.ToString(), Severity = LogEventToEcsHelper.GetSeverity(logLevel) };
			logEvent.Agent = DefaultAgent;

			if (_options.Tags != null && _options.Tags.Length > 0) logEvent.Tags = _options.Tags;

			if (_options.IncludeScopes) AddScopeValues(logEvent);

			// These will overwrite any scope values with the same name
			AddStateValues(state, logEvent);

			return logEvent;
		}

		private string FormatEnumerable(IEnumerable enumerable, int depth)
		{
			var stringBuilder = new StringBuilder();

			// The standard array.ToString() isn't very interesting, so render the elements
			depth = depth + 1;
			var index = 0;
			foreach (var item in enumerable)
			{
				if (index > 0) stringBuilder.Append(_options.ListSeparator);

				var value = FormatValue(item, depth);
				stringBuilder.Append(value);
				index++;
			}

			return stringBuilder.ToString();
		}

		private string FormatStringDictionary(IDictionary<string, object> dictionary, int depth)
		{
			// The standard dictionary.ToString() isn't very interesting, so render the key-value pairs
			var stringBuilder = new StringBuilder();
			depth = depth + 1;
			var index = 0;
			foreach (var kvp in dictionary)
			{
				if (index > 0) stringBuilder.Append(" ");

				WriteName(stringBuilder, kvp.Key);
				stringBuilder.Append('=');
				stringBuilder.Append('"');
				WriteValue(stringBuilder, FormatValue(kvp.Value, depth));
				stringBuilder.Append('"');
				index++;
			}

			return stringBuilder.ToString();
		}

		private string FormatValue(object value, int depth = 0)
		{
			switch (value)
			{
				case null:
					return string.Empty;
				case byte b:
					return b.ToString("X2");
				case byte[] bytes:
					var builder = new StringBuilder("0x");
					foreach (var b in bytes) builder.Append(b.ToString("X2"));

					return builder.ToString();
				case DateTime dateTime:
					if (dateTime.TimeOfDay.Equals(TimeSpan.Zero))
						return dateTime.ToString("yyyy'-'MM'-'dd");
					return dateTime.ToString("o");
				case DateTimeOffset dateTimeOffset:
					return dateTimeOffset.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.ffffffzzz");
				case string s:
					// since 'string' implements IEnumerable, special case it
					return s;
				default:
					// need to special case dictionary before IEnumerable
					if (depth < 1 && value is IDictionary<string, object> dictionary)
						return FormatStringDictionary(dictionary, depth);
					// if the value implements IEnumerable, build a comma separated string
					if (depth < 1 && value is IEnumerable enumerable)
						return FormatEnumerable(enumerable, depth);
					return value.ToString();
			}
		}

		private static void WriteName(StringBuilder stringBuilder, string name)
		{
			foreach (var c in name)
			{
				if (c == ' ')
					stringBuilder.Append('_');
				else if (c == '=')
					stringBuilder.AppendFormat("_x{0:X2}_", (int)c);
				else
					stringBuilder.Append(c);
			}
		}

		private static void WriteValue(StringBuilder stringBuilder, string value)
		{
			foreach (var c in value)
			{
				if (c == '"' || c == '\\')
				{
					stringBuilder.Append('\\');
					stringBuilder.Append(c);
				}
				else
					stringBuilder.Append(c);
			}
		}
	}
}
