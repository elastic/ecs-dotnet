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
using Elasticsearch.Extensions.Logging.Options;
using Microsoft.Extensions.Logging;

namespace Elasticsearch.Extensions.Logging
{
	/// <summary>
	/// An <see cref="ILogger"/> implementation that writes logs directly to Elasticsearch
	/// </summary>
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

		/// <inheritdoc cref="ILogger.BeginScope{TState}"/>
		public IDisposable? BeginScope<TState>(TState state) => _scopeProvider?.Push(state);

		/// <inheritdoc cref="ILogger.IsEnabled"/>
		public bool IsEnabled(LogLevel logLevel) => _options.IsEnabled;

		/// <inheritdoc cref="ILogger.Log{TState}"/>
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
			if (!_options.IncludeScopes) return;

			void AddScopeValue<TState>(TState scope, LogEvent log)
			{
				if (scope is null) return;
				log.Labels ??= new Labels();
				log.Scopes ??= new List<string>();


				var scopeValues = (scope as IEnumerable<KeyValuePair<string, object>>)?.ToList();
				var scopeName = scope as string ?? scope.GetType().Name;
				if (scopeValues != null && scopeValues.Any(kv=>kv.Key == "{OriginalFormat}"))
					scopeName = FormatValue(scope);
				log.Scopes.Add(scopeName);

				if (scopeValues == null) return;

				foreach (var kvp in scopeValues)
					AssignStateOrScopeLabels(logEvent, kvp);
			}

			_scopeProvider?.ForEachScope((o, @event) => AddScopeValue(o, @event), logEvent);
		}

		private void AddStateValues<TState>(TState state, LogEvent logEvent)
		{
			var stateValues = state as IEnumerable<KeyValuePair<string, object>>;
			if (stateValues == null) return;

			foreach (var kvp in stateValues)
				AssignStateOrScopeLabels(logEvent, kvp);
		}

		private void AssignStateOrScopeLabels(LogEvent logEvent, KeyValuePair<string, object> kvp)
		{
			if (kvp.Key == "{OriginalFormat}")
			{
				logEvent.MessageTemplate ??= kvp.Value.ToString();
				return;
			}
			var value = FormatValue(kvp.Value);
			if (!AssignKnownHttpKeys(logEvent, kvp.Key, value))
				logEvent.AssignField(kvp.Key, value);
		}

		private static bool AssignKnownHttpKeys(LogEvent logEvent, string key, object value)
		{
			switch (key)
			{
				case "RequestId" when value is string requestId:
					logEvent.Http ??= new Http();
					logEvent.Http.RequestId = requestId;
					return true;
				case "RequestPath" when value is string path:
					logEvent.Url ??= new Url();
					logEvent.Url.Path = path;
					return true;
				// ReSharper disable once UnusedVariable
				case "Protocol" when value is string protocol:
					// TODO protocol
					//logEvent.Http ??= new Http();
					//logEvent.Http. = requestId;
					return true;
				case "Method" when value is string method:
					logEvent.Http ??= new Http();
					logEvent.Http.RequestMethod = method;
					return true;
				case "ContentType" when value is string contentType:
					logEvent.Http ??= new Http();
					logEvent.Http.RequestMimeType = contentType;
					return true;
				case "ContentLength" when value is string contentLength:
					logEvent.Http ??= new Http();
					logEvent.Http.RequestBytes = long.TryParse(contentLength, out var l) ? l : (long?)null;
					return true;
				case "Scheme" when value is string scheme:
					logEvent.Http ??= new Http();
					logEvent.Url.Scheme = scheme;
					return true;
				case "Host" when value is string host:
					logEvent.Url ??= new Url();
					logEvent.Url.Domain = host;
					return true;
				case "Path":
				case "PathBase":
					//covered by 'RequestPath'
					return true;
				case "QueryString" when value is string qs:
					logEvent.Url ??= new Url();
					logEvent.Url.Query = qs;
					return true;
				default: return false;
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
