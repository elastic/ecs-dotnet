using System;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Elasticsearch.Net;
using Essential.LoggerProvider.Ecs;

namespace Essential.LoggerProvider
{
    internal class ElasticsearchLoggerProcessor : IDisposable
    {
        private const int _maxQueuedMessages = 1024;
        private readonly BlockingCollection<QueueEvent> _messageQueue = new BlockingCollection<QueueEvent>(_maxQueuedMessages);
        private readonly Thread _outputThread;
        private ElasticsearchLoggerOptions _options = default!;
        private ElasticLowLevelClient _lowLevelClient = default!;

        public ElasticsearchLoggerProcessor()
        {
            _outputThread = new Thread(ProcessLogQueue)
            {
                IsBackground = true, Name = "ElasticsearchLoggerProcessor.ProcessLogQueue"
            };
            _outputThread.Start();
        }

        internal ElasticsearchLoggerOptions Options
        {
            get { return _options; }
            set
            {
                _options = value; 
                UpdateClient();
            }
        }

        public void Dispose()
        {
            _messageQueue?.CompleteAdding();
            try
            {
                _outputThread.Join(1500); // with timeout in case writer is locked
            }
            catch (ThreadStateException) { }

            _messageQueue?.Dispose();
        }

        public void EnqueueMessage(QueueEvent queueEvent)
        {
            if (!_messageQueue.IsAddingCompleted)
            {
                try
                {
                    _messageQueue.Add(queueEvent);
                    return;
                }
                catch (InvalidOperationException) { }
            }

            // Adding is complete, so just log the message
            try
            {
                WriteMessage(queueEvent);
            }
            catch (Exception) { }
        }

        private void ProcessLogQueue()
        {
            try
            {
                foreach (var logEvent in _messageQueue.GetConsumingEnumerable())
                {
                    WriteMessage(logEvent);
                }
            }
            catch
            {
                try
                {
                    _messageQueue.CompleteAdding();
                }
                catch { }
            }
        }

        private void UpdateClient()
        {
            // TODO: Check if Uri has changed before recreating

            ConnectionConfiguration settings;
            if (_options.NodeUris.Length == 0)
            {
                settings = new ConnectionConfiguration();
            }
            else if (_options.NodeUris.Length == 1)
            {
                settings = new ConnectionConfiguration(_options.NodeUris[0]);
            }
            else
            {
                IConnectionPool connectionPool;
                switch (_options.ConnectionPoolType)
                {
                    case ConnectionPoolType.Sniffing:
                    case ConnectionPoolType.Unknown:
                        connectionPool = new SniffingConnectionPool(_options.NodeUris);
                        break;
                    default:
                        throw new Exception($"Unknown connection pool type {_options.ConnectionPoolType}");
                }

                settings = new ConnectionConfiguration(connectionPool);
            }

            var lowlevelClient = new ElasticLowLevelClient(settings);

            var originalClient = Interlocked.Exchange(ref _lowLevelClient, lowlevelClient);
        }

        private void WriteMessage(QueueEvent queueEvent)
        {
            // TODO: injectable property provider
            var timestamp = DateTimeOffset.Now;
            var logEvent = new LogEvent()
            {
                Timestamp = timestamp,
                Message =  queueEvent.Message
            };
            var index = string.Format("log-{0:yyyy.MM.dd}", timestamp);
            var lowLevelClient = _lowLevelClient;
            var response = _lowLevelClient.Index<StringResponse>(index, PostData.Serializable(logEvent));
            
            //_writer.WriteLine(message);
        }
    }
}
