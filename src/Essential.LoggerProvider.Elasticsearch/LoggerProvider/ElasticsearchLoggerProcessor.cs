using System;
using System.Collections.Concurrent;
using System.Threading;

namespace Essential.LoggerProvider
{
    internal class ElasticsearchLoggerProcessor : IDisposable
    {
        private const int _maxQueuedMessages = 1024;

        private readonly BlockingCollection<LogEvent> _messageQueue = new BlockingCollection<LogEvent>(_maxQueuedMessages);

        private readonly Thread _outputThread;

        public ElasticsearchLoggerProcessor()
        {
            _outputThread = new Thread(ProcessLogQueue)
            {
                IsBackground = true, Name = "ElasticsearchLoggerProcessor.ProcessLogQueue"
            };
            _outputThread.Start();
        }

        internal ElasticsearchLoggerOptions Options { get; set; } = default!;

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

        public void EnqueueMessage(LogEvent logEvent)
        {
            if (!_messageQueue.IsAddingCompleted)
            {
                try
                {
                    _messageQueue.Add(logEvent);
                    return;
                }
                catch (InvalidOperationException) { }
            }

            // Adding is complete, so just log the message
            try
            {
                WriteMessage(logEvent);
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

        private void WriteMessage(LogEvent logEvent)
        {
            //_writer.WriteLine(message);
        }
    }
}
