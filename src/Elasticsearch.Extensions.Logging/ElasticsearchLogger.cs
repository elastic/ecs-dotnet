// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using Elastic.CommonSchema;
using Elastic.Ingest;
using Microsoft.Extensions.Logging;
using Trace = Elastic.CommonSchema.Trace;

namespace Elasticsearch.Extensions.Logging
{
	public class ElasticsearchLogger : ILogger
	{
		private readonly string _categoryName;
		private readonly ElasticsearchChannel<LogEvent> _channel;
		private readonly ElasticsearchLoggerOptions _options;
		private readonly IExternalScopeProvider? _scopeProvider;

		internal ElasticsearchLogger(
			string categoryName,
			ElasticsearchChannel<LogEvent> channel,
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

		private static void AddException(Exception exception, LogEvent logEvent)
		{
			// Use the full string of the exception, which includes both the outer stack trace and any
			// inner exceptions and their stack trace. It also includes any additional values that some
			// exceptions have in ToString() that is not in Message.
			var stackTrace = exception.ToString();
			logEvent.Error = new Error { Type = exception.GetType().FullName, Message = exception.Message, StackTrace = stackTrace };
		}

		private void AddScopeValues(LogEvent logEvent)
		{
			if (_options.IncludeScopes)
			{
				_scopeProvider?.ForEachScope((scope, le) =>
				{
					le.Labels ??= new Dictionary<string, string>();
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

							if (CheckTracingValues(le, kvp)) continue;

							le.Labels[kvp.Key] = FormatValue(kvp.Value);
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

					if (CheckTracingValues(logEvent, kvp)) continue;

					logEvent.Labels ??= new Dictionary<string, string>();
					logEvent.Labels[kvp.Key] = FormatValue(kvp.Value);
				}
			}
		}

		private void AddTracing(LogEvent logEvent)
		{
			var activity = Activity.Current;

			if (activity != null)
			{
				if (activity.IdFormat == ActivityIdFormat.W3C)
				{
					// Unique identifier of the trace.
					// A trace groups multiple events like transactions that belong together. For example, a user request handled by multiple inter-connected services.
					logEvent.Trace = new Trace { Id = activity.TraceId.ToString() };
					logEvent.Span = new Span { Id = activity.SpanId.ToString() };
				}
				else
				{
					if (activity.RootId != null) logEvent.Trace = new Trace { Id = activity.RootId };
					if (activity.Id != null) logEvent.Span = new Span { Id = activity.Id };
				}
			}
			else
			{
				if (!System.Diagnostics.Trace.CorrelationManager.ActivityId.Equals(Guid.Empty))
				{
					logEvent.Trace =
						new Trace { Id = System.Diagnostics.Trace.CorrelationManager.ActivityId.ToString() };
				}
			}
		}

		private LogEvent BuildLogEvent<TState>(string categoryName, LogLevel logLevel,
			EventId eventId, TState state, Exception? exception,
			Func<TState, Exception, string> formatter
		)
		{
			var logEvent = new LogEvent
			{
				Ecs = LogEventToEcsHelper.GetEcs(),
				Timestamp = ElasticsearchLoggerProvider.LocalDateTimeProvider(),
				Message = formatter(state, exception!),
				Log = new Log { Level = LogEventToEcsHelper.GetLogLevelString(logLevel), Logger = categoryName },
				Event = new Event { Action = eventId.Name, Code = eventId.Id.ToString(), Severity = LogEventToEcsHelper.GetSeverity(logLevel) }
			};

			if (exception != null) AddException(exception, logEvent);

			logEvent.Agent = LogEventToEcsHelper.GetAgent();
			logEvent.Service = LogEventToEcsHelper.GetService();

			if (_options.Tags != null && _options.Tags.Length > 0) logEvent.Tags = _options.Tags;

			if (_options.IncludeHost) logEvent.Host = LogEventToEcsHelper.GetHost();

			if (_options.IncludeProcess) logEvent.Process = LogEventToEcsHelper.GetProcess();

			if (_options.IncludeUser)
			{
				logEvent.User = new User
				{
					Id = Thread.CurrentPrincipal?.Identity.Name, Name = Environment.UserName, Domain = Environment.UserDomainName
				};
			}

			AddTracing(logEvent);

			if (_options.IncludeScopes) AddScopeValues(logEvent);

			// These will overwrite any scope values with the same name
			AddStateValues(state, logEvent);

			return logEvent;
		}

		private bool CheckTracingValues(LogEvent logEvent, KeyValuePair<string, object> kvp)
		{
			if (kvp.Key == "span.id")
			{
				var value = FormatValue(kvp.Value);
				if (!string.IsNullOrWhiteSpace(value))
				{
					logEvent.Span ??= new Span();
					logEvent.Span.Id = value;
				}

				return true;
			}

			if (kvp.Key == "trace.id")
			{
				var value = FormatValue(kvp.Value);
				if (!string.IsNullOrWhiteSpace(value))
				{
					logEvent.Trace ??= new Trace();
					logEvent.Trace.Id = value;
				}

				return true;
			}

			if (kvp.Key == "transaction.id")
			{
				var value = FormatValue(kvp.Value);
				if (!string.IsNullOrWhiteSpace(value))
				{
					logEvent.Transaction ??= new Transaction();
					logEvent.Transaction.Id = value;
				}

				return true;
			}

			return false;
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
					else
						return dateTime.ToString("o");
				case DateTimeOffset dateTimeOffset:
					return dateTimeOffset.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.ffffffzzz");
				case string s:
					// since 'string' implements IEnumerable, special case it
					return s;
				default:
					if (depth < 1 && value is IDictionary<string, object> dictionary)
					{
						// need to special case dictionary before IEnumerable
						return FormatStringDictionary(dictionary, depth);
					}
					else if (depth < 1 && value is IEnumerable enumerable)
					{
						// if the value implements IEnumerable, build a comma separated string
						return FormatEnumerable(enumerable, depth);
					}
					else
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
