using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using Elastic.CommonSchema;
using Microsoft.Extensions.Logging;
using Trace = System.Diagnostics.Trace;

namespace Essential.LoggerProvider
{
    public class ElasticsearchLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly ElasticsearchDataProcessor _dataProcessor;
        private ElasticsearchLoggerOptions _options = default!;

        internal ElasticsearchLogger(string categoryName, ElasticsearchDataProcessor dataProcessor)
        {
            _categoryName = categoryName;
            _dataProcessor = dataProcessor;
        }

        internal ElasticsearchLoggerOptions Options
        {
            get => _options;
            set
            {
                _options = value;
            }
        }

        internal IExternalScopeProvider ScopeProvider { get; set; } = default!;

        public IDisposable BeginScope<TState>(TState state)
        {
            return ScopeProvider.Push(state);
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return Options.IsEnabled;
        }


        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            try
            {
                if (!IsEnabled(logLevel))
                {
                    return;
                }

                if (formatter == null)
                {
                    throw new ArgumentNullException(nameof(formatter));
                }

                // TODO: Want to render state values (separate from message) to pass to log event, for semantic logging
                // Maybe render to JSON in-process, then queue bytes for sending to index ??

                var elasticsearchData =
                    BuildLogEvent(_categoryName, logLevel, eventId, state, exception, formatter);

                _dataProcessor.EnqueueMessage(elasticsearchData);
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
            logEvent.Error = new Error
            {
                Type = exception.GetType().FullName, Message = exception.Message, StackTrace = stackTrace
            };
        }

        private void AddScopeValues(LogEvent logEvent)
        {
            var scopeProvider = ScopeProvider;
            if (Options.IncludeScopes && scopeProvider != null)
            {
                scopeProvider.ForEachScope((scope, innerData) =>
                {
                    if (logEvent.Labels == null)
                    {
                        logEvent.Labels = new Dictionary<string, object>();
                    }

                    if (logEvent.Scopes == null)
                    {
                        logEvent.Scopes = new List<string>();
                    }

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

                            if (CheckCorrelationValues(logEvent, kvp))
                            {
                                continue;
                            }

                            logEvent.Labels[kvp.Key] = FormatValue(kvp.Value);
                        }
                    }

                    var formattedScope = isFormattedLogValues ? scope.ToString() : FormatValue(scope);
                    logEvent.Scopes.Add(formattedScope);
                }, logEvent);
            }
        }

        private void AddStateValues<TState>(TState state, LogEvent logEvent)
        {
            if (state is IEnumerable<KeyValuePair<string, object>> stateValues)
            {
                if (stateValues.Count() > 0)
                {
                    if (logEvent.Labels == null)
                    {
                        logEvent.Labels = new Dictionary<string, object>();
                    }

                    foreach (var kvp in stateValues)
                    {
                        if (kvp.Key == "{OriginalFormat}")
                        {
                            logEvent.MessageTemplate = kvp.Value.ToString();
                            continue;
                        }

                        if (CheckCorrelationValues(logEvent, kvp))
                        {
                            continue;
                        }

                        logEvent.Labels[kvp.Key] = FormatValue(kvp.Value);
                    }
                }
            }
        }

        private LogEvent BuildLogEvent<TState>(string categoryName, LogLevel logLevel,
            EventId eventId, TState state, Exception? exception,
            Func<TState, Exception, string> formatter)
        {
            var logEvent = new LogEvent();

            logEvent.Ecs = _dataProcessor.GetEcs();
            logEvent.Timestamp = ElasticsearchLoggerProvider.LocalDateTimeProvider();
            logEvent.Message = formatter(state, exception!);
            logEvent.Log = new Log {Level = logLevel.ToString(), Logger = categoryName};
            logEvent.Event =
                new Event
                {
                    Action = eventId.Name,
                    Code = eventId.Id.ToString(),
                    Severity = _dataProcessor.GetSeverity(logLevel)
                };

            if (exception != null)
            {
                AddException(exception, logEvent);
            }

            logEvent.Agent = _dataProcessor.GetAgent();
            logEvent.Service = _dataProcessor.GetService();

            if (_options.Tags != null && _options.Tags.Length > 0)
            {
                logEvent.Tags = _options.Tags;
            }

            if (_options.IncludeHost)
            {
                logEvent.Host = _dataProcessor.GetHost();
            }

            if (_options.IncludeProcess)
            {
                logEvent.Process = _dataProcessor.GetProcess();
            }

            if (_options.IncludeUser)
            {
                logEvent.User = new User
                {
                    Id = Thread.CurrentPrincipal?.Identity.Name,
                    Name = Environment.UserName,
                    Domain = Environment.UserDomainName
                };
            }

            if (_options.IncludeScopes)
            {
                AddScopeValues(logEvent);
            }

            // These will overwrite any scope values with the same name
            AddStateValues(state, logEvent);

            DefaultCorrelationValues(logEvent);

            return logEvent;
        }

        private bool CheckCorrelationValues(LogEvent logEvent, KeyValuePair<string, object> kvp)
        {
            // Unique identifier of the trace.
            // A trace groups multiple events like transactions that belong together. For example, a user request handled by multiple inter-connected services.
            if (((kvp.Key == "TraceId" || kvp.Key == "CorrelationId") && _options.MapCorrelationValues)
                || kvp.Key == "trace.id")
            {
                if (logEvent.Trace == null)
                {
                    logEvent.Trace = new Elastic.CommonSchema.Trace();
                }

                logEvent.Trace.Id = FormatValue(kvp.Value);
                return true;
            }

            // Unique identifier of the transaction.
            // A transaction is the highest level of work measured within a service, such as a request to a server.
            if ((kvp.Key == "RequestId" && _options.MapCorrelationValues)
                || kvp.Key == "transaction.id")
            {
                if (logEvent.Transaction == null)
                {
                    logEvent.Transaction = new Transaction();
                }

                logEvent.Transaction.Id = FormatValue(kvp.Value);
                return true;
            }

            return false;
        }

        private static void DefaultCorrelationValues(LogEvent logEvent)
        {
            if (logEvent.Trace == null || string.IsNullOrEmpty(logEvent.Trace.Id))
            {
                var activity = Activity.Current;
                if (!string.IsNullOrEmpty(activity?.Id))
                {
                    if (logEvent.Trace == null)
                    {
                        logEvent.Trace = new Elastic.CommonSchema.Trace();
                    }

                    logEvent.Trace.Id = activity?.Id;
                }
                else if (!Trace.CorrelationManager.ActivityId.Equals(Guid.Empty))
                {
                    logEvent.Trace =
                        new Elastic.CommonSchema.Trace() {Id = Trace.CorrelationManager.ActivityId.ToString()};
                }
            }
        }

        private string FormatEnumerable(IEnumerable enumerable, int depth)
        {
            var stringBuilder = new StringBuilder();

            // The standard array.ToString() isn't very interesting, so render the elements
            depth = depth + 1;
            var index = 0;
            foreach (var item in enumerable)
            {
                if (index > 0)
                {
                    stringBuilder.Append(_options.ListSeparator);
                }

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
                if (index > 0)
                {
                    stringBuilder.Append(" ");
                }

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
                    foreach (var b in bytes)
                    {
                        builder.Append(b.ToString("X2"));
                    }

                    return builder.ToString();
                case DateTime dateTime:
                    if (dateTime.TimeOfDay.Equals(TimeSpan.Zero))
                    {
                        return dateTime.ToString("yyyy'-'MM'-'dd");
                    }
                    else
                    {
                        return dateTime.ToString("o");
                    }
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
                    {
                        return value.ToString();
                    }
            }
        }

        private void WriteName(StringBuilder stringBuilder, string name)
        {
            foreach (var c in name.Cast<char>())
            {
                if (c == ' ')
                {
                    stringBuilder.Append('_');
                }
                else if (c == '=')
                {
                    stringBuilder.AppendFormat("_x{0:X2}_", (int)c);
                }
                else
                {
                    stringBuilder.Append(c);
                }
            }
        }

        private void WriteValue(StringBuilder stringBuilder, string value)
        {
            foreach (var c in value.Cast<char>())
            {
                if (c == '"' || c == '\\')
                {
                    stringBuilder.Append('\\');
                    stringBuilder.Append(c);
                }
                else
                {
                    stringBuilder.Append(c);
                }
            }
        }
    }
}
