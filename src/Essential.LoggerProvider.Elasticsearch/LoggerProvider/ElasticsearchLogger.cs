using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Essential.LoggerProvider.Ecs;
using Microsoft.Extensions.Logging;
using System.Threading;
using Thread = System.Threading.Thread;
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

                var elasticsearchData = BuildElasticsearchData(_categoryName, logLevel, eventId, state, exception, formatter);

                _dataProcessor.EnqueueMessage(elasticsearchData);
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("ElasticsearchLogger exception: {0}", ex);
            }
        }

        private ElasticsearchData BuildElasticsearchData<TState>(string categoryName, LogLevel logLevel, EventId eventId, TState state, Exception? exception,
            Func<TState, Exception, string> formatter)
        {
            var elasticsearchData = new ElasticsearchData();
            
            elasticsearchData.Timestamp = ElasticsearchLoggerProvider.LocalDateTimeProvider();
            elasticsearchData.Message = formatter(state, exception!);
            elasticsearchData.Log = new Log(logLevel, categoryName);
            elasticsearchData.Event = new Event(eventId.Name, eventId.Id.ToString(), _dataProcessor.GetSeverity(logLevel));

            if (exception != null)
            {
                AddException(exception, elasticsearchData);
            }
            
            elasticsearchData.Agent = _dataProcessor.GetAgent();
            elasticsearchData.Service = _dataProcessor.GetService();

            if (_options.Tags != null && _options.Tags.Length > 0)
            {
                elasticsearchData.Tags = _options.Tags;
            }

            if (_options.IncludeHost)
            {
                elasticsearchData.Host = _dataProcessor.GetHost();
            }

            if (_options.IncludeProcess)
            {
                elasticsearchData.Process = _dataProcessor.GetProcess();
            }

            if (_options.IncludeUser)
            {
                elasticsearchData.User = new User(Thread.CurrentPrincipal?.Identity.Name, Environment.UserName,
                    Environment.UserDomainName);
            }

            if (!Trace.CorrelationManager.ActivityId.Equals(Guid.Empty))
            {
                elasticsearchData.Trace = new Ecs.Trace(Trace.CorrelationManager.ActivityId.ToString());
            }
            
            if (_options.IncludeScopes)
            {
                AddScopeValues(elasticsearchData);
            }
            
            // These will overwrite any scope values with the same name
            AddStateValues(state, elasticsearchData);

            return elasticsearchData;
        }

        private static void AddException(Exception exception, ElasticsearchData elasticsearchData)
        {
            var stackTrace = exception.StackTrace;
            if (exception.InnerException != null)
            {
                stackTrace += Environment.NewLine + "---> " + exception.InnerException.ToString();
            }

            elasticsearchData.Error = new Error(exception.GetType().FullName, exception.Message, stackTrace);
        }

        private static void AddStateValues<TState>(TState state, ElasticsearchData elasticsearchData)
        {
            if (state is IEnumerable<KeyValuePair<string, object>> stateValues)
            {
                if (stateValues.Count() > 0)
                {
                    if (elasticsearchData.Labels == null)
                    {
                        elasticsearchData.Labels = new Dictionary<string, string>();
                    }

                    foreach (var kvp in stateValues)
                    {
                        if (kvp.Key == "{OriginalFormat}")
                        {
                            elasticsearchData.MessageTemplate = kvp.Value.ToString();
                        }
                        else
                        {
                            // TODO: Handling for different types, e.g. array
                            elasticsearchData.Labels[kvp.Key] = kvp.Value.ToString();
                        }
                    }
                }
            }
        }

        private void AddScopeValues(ElasticsearchData elasticsearchData)
        {
            var scopeProvider = ScopeProvider;
            if (Options.IncludeScopes && scopeProvider != null)
            {
                scopeProvider.ForEachScope((scope, innerData) =>
                {
                    if (elasticsearchData.Labels == null)
                    {
                        elasticsearchData.Labels = new Dictionary<string, string>();
                    }
                    if (elasticsearchData.Scopes == null)
                    {
                        elasticsearchData.Scopes = new List<string>();
                    }

                    bool isFormattedLogValues = false;
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
                                // TODO: Handling for different types, e.g. array
                                elasticsearchData.Labels[kvp.Key] = kvp.Value.ToString();
                            }
                        }
                    }
                    // TODO: Handling for different types, e.g. array (but not formatted log values)
                    elasticsearchData.Scopes.Add(scope.ToString());
                }, elasticsearchData);
            }
        }
    }
}
