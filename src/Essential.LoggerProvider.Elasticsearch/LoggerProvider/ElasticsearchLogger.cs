using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;

namespace Essential.LoggerProvider
{
    public class ElasticsearchLogger : ILogger
    {
        private readonly string _categoryName;
        private readonly ElasticsearchLoggerProcessor _loggerProcessor;
        private ElasticsearchLoggerOptions _options = default!;

        internal ElasticsearchLogger(string categoryName, ElasticsearchLoggerProcessor loggerProcessor)
        {
            _categoryName = categoryName;
            _loggerProcessor = loggerProcessor;
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
            
            var message = formatter(state, exception);

            var scopeProvider = ScopeProvider;
            object[]? scopes = null;
            if (Options.IncludeScopes && scopeProvider != null)
            {
                var scopeList = new List<object>();
                scopeProvider.ForEachScope((scope, localList) =>
                {
                    localList.Add(scope);
                }, scopeList);
                scopes = scopeList.ToArray();
            }
            
            var logEvent = new QueueEvent(
                _categoryName,
                logLevel,
                eventId,
                message,
                exception,
                scopes
            );
            
            _loggerProcessor.EnqueueMessage(logEvent);
        }
        
    }
}
