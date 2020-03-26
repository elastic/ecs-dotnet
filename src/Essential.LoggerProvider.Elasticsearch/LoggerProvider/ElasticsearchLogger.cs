using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private ElasticsearchData BuildElasticsearchData<TState>(string categoryName, LogLevel logLevel, EventId eventId, TState state, Exception exception,
            Func<TState, Exception, string> formatter)
        {
            var timestamp = ElasticsearchLoggerProvider.LocalDateTimeProvider();
            var message = formatter(state, exception);

            var elasticsearchData = new ElasticsearchData()
            {
                Timestamp = timestamp,
                Message =  message
            };

            elasticsearchData.Log = new Log(logLevel, categoryName);
            elasticsearchData.Agent = _dataProcessor.GetAgent();
            elasticsearchData.Event = new Event(eventId.Name, eventId.Id.ToString(), _dataProcessor.GetSeverity(logLevel));
            elasticsearchData.Host = _dataProcessor.GetHost();
            elasticsearchData.Process = _dataProcessor.GetProcess();
            elasticsearchData.User = new User(Thread.CurrentPrincipal?.Identity.Name, Environment.UserName, Environment.UserDomainName);
            elasticsearchData.Trace = new Ecs.Trace(Trace.CorrelationManager.ActivityId.ToString());
            elasticsearchData.Service = _dataProcessor.GetService();

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

            return elasticsearchData;
        }
        
    }
}
