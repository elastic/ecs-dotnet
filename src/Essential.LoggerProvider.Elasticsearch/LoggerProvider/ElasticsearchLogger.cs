using System;
using System.Collections;
using System.Collections.Generic;
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
                    BuildBaseEvent(_categoryName, logLevel, eventId, state, exception, formatter);

                _dataProcessor.EnqueueMessage(elasticsearchData);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("ElasticsearchLogger exception: {0}", ex);
            }
        }

        private static void AddException(Exception exception, Base elasticsearchData)
        {
            // Use the full string of the exception, which includes both the outer stack trace and any
            // inner exceptions and their stack trace. It also includes any additional values that some
            // exceptions have in ToString() that is not in Message.
            var stackTrace = exception.ToString();
            elasticsearchData.Error = new Error
            {
                Type = exception.GetType().FullName, Message = exception.Message, StackTrace = stackTrace
            };
        }

        private void AddScopeValues(Base baseEvent)
        {
            var scopeProvider = ScopeProvider;
            if (Options.IncludeScopes && scopeProvider != null)
            {
                scopeProvider.ForEachScope((scope, innerData) =>
                {
                    if (baseEvent.Labels == null)
                    {
                        baseEvent.Labels = new Dictionary<string, object>();
                    }

                    var scopes = new List<string>();
                    var isFormattedLogValues = false;
                    if (scope is IEnumerable<KeyValuePair<string, object>> scopeValues)
                    {
                        foreach (var kvp in scopeValues)
                        {
                            if (kvp.Key == "{OriginalFormat}")
                            {
                                isFormattedLogValues = true;
                            }
                            else
                            {
                                baseEvent.Labels[kvp.Key] = FormatValue(kvp.Value);
                            }
                        }
                    }

                    var formattedScope = isFormattedLogValues ? scope.ToString() : FormatValue(scope);
                    if (baseEvent.Metadata == null)
                    {
                        baseEvent.Metadata = new Dictionary<string, object>();
                    }

                    baseEvent.Metadata["Scopes"] = formattedScope;
                }, baseEvent);
            }
        }

        private void AddStateValues<TState>(TState state, Base baseEvent)
        {
            if (state is IEnumerable<KeyValuePair<string, object>> stateValues)
            {
                if (stateValues.Count() > 0)
                {
                    if (baseEvent.Labels == null)
                    {
                        baseEvent.Labels = new Dictionary<string, object>();
                    }

                    foreach (var kvp in stateValues)
                    {
                        if (kvp.Key == "{OriginalFormat}")
                        {
                            if (baseEvent.Metadata == null)
                            {
                                baseEvent.Metadata = new Dictionary<string, object>();
                            }

                            baseEvent.Metadata["MessageTemplate"] = kvp.Value.ToString();
                        }
                        else
                        {
                            baseEvent.Labels[kvp.Key] = FormatValue(kvp.Value);
                        }
                    }
                }
            }
        }

        private Base BuildBaseEvent<TState>(string categoryName, LogLevel logLevel,
            EventId eventId, TState state, Exception? exception,
            Func<TState, Exception, string> formatter)
        {
            var baseEvent = new Base();

            baseEvent.Ecs = _dataProcessor.GetEcs();
            baseEvent.Timestamp = ElasticsearchLoggerProvider.LocalDateTimeProvider();
            baseEvent.Message = formatter(state, exception!);
            baseEvent.Log = new Log {Level = logLevel.ToString(), Logger = categoryName};
            baseEvent.Event =
                new Event
                {
                    Action = eventId.Name,
                    Code = eventId.Id.ToString(),
                    Severity = _dataProcessor.GetSeverity(logLevel)
                };

            if (exception != null)
            {
                AddException(exception, baseEvent);
            }

            baseEvent.Agent = _dataProcessor.GetAgent();
            baseEvent.Service = _dataProcessor.GetService();

            if (_options.Tags != null && _options.Tags.Length > 0)
            {
                baseEvent.Tags = _options.Tags;
            }

            if (_options.IncludeHost)
            {
                baseEvent.Host = _dataProcessor.GetHost();
            }

            if (_options.IncludeProcess)
            {
                baseEvent.Process = _dataProcessor.GetProcess();
            }

            if (_options.IncludeUser)
            {
                baseEvent.User = new User
                {
                    Id = Thread.CurrentPrincipal?.Identity.Name,
                    Name = Environment.UserName,
                    Domain = Environment.UserDomainName
                };
            }

            if (!Trace.CorrelationManager.ActivityId.Equals(Guid.Empty))
            {
                baseEvent.Trace =
                    new Elastic.CommonSchema.Trace() {Id = Trace.CorrelationManager.ActivityId.ToString()};
            }

            if (_options.IncludeScopes)
            {
                AddScopeValues(baseEvent);
            }

            // These will overwrite any scope values with the same name
            AddStateValues(state, baseEvent);

            return baseEvent;
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
