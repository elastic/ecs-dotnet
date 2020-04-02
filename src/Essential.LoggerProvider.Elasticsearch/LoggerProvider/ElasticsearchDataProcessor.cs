using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Elastic.CommonSchema;
using Elasticsearch.Net;
using Microsoft.Extensions.Logging;
using Process = System.Diagnostics.Process;

namespace Essential.LoggerProvider
{
    internal class ElasticsearchDataProcessor : IDisposable
    {
        private Agent? _agent;
        private Host? _host;
        private IElasticLowLevelClient _lowLevelClient = default!;

        private readonly BlockingCollection<Base> _messageQueue =
            new BlockingCollection<Base>(MaxQueuedMessages);

        private ElasticsearchLoggerOptions _options = default!;
        private readonly Thread _outputThread;
        private int _processId;
        private string? _processName;
        private Service? _service;
        private const int MaxQueuedMessages = 1024;

        public ElasticsearchDataProcessor()
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

        public void EnqueueMessage(Base baseEvent)
        {
            if (!_messageQueue.IsAddingCompleted)
            {
                try
                {
                    _messageQueue.Add(baseEvent);
                    return;
                }
                catch (InvalidOperationException) { }
            }

            // Adding is complete, so just log the message
            try
            {
                PostEvent(baseEvent);
            }
            catch (Exception) { }
        }

        internal Agent GetAgent()
        {
            if (_agent is null)
            {
                var assembly = typeof(ElasticsearchLogger).Assembly;
                var type = assembly.GetName().Name;
                var versionAttribute = assembly.GetCustomAttributes(false)
                    .OfType<AssemblyInformationalVersionAttribute>().FirstOrDefault();
                var version = versionAttribute?.InformationalVersion;
                _agent = new Agent {Type = type, Version = version};
            }

            return _agent;
        }

        internal Host GetHost()
        {
            if (_host is null)
            {
                // Architecture osArchitecture = RuntimeInformation.OSArchitecture;
                // if (osDescription.Contains('#'))
                // {
                //     int indexOfHash = osDescription.IndexOf('#');
                //     osDescription = osDescription.Substring(0, Math.Max(0, indexOfHash - 1));
                // }

                var operatingSystem = new Os
                {
                    Full = RuntimeInformation.OSDescription,
                    Platform = Environment.OSVersion.Platform.ToString(),
                    Version = Environment.OSVersion.Version.ToString()
                };
                _host = new Host
                {
                    Hostname = Environment.MachineName,
                    Architecture = RuntimeInformation.OSArchitecture.ToString(),
                    Os = operatingSystem
                };
            }

            return _host;
        }

        internal Elastic.CommonSchema.Process GetProcess()
        {
            if (_processName == null)
            {
                using var process = Process.GetCurrentProcess();
                _processId = process.Id;
                _processName = process.ProcessName;
            }

            var currentThread = Thread.CurrentThread;

            return new Elastic.CommonSchema.Process
            {
                Name = _processName,
                Pid = _processId,
                Thread = new ProcessThread {Name = currentThread.Name, Id = currentThread.ManagedThreadId}
            };
        }

        internal Service GetService()
        {
            if (_service is null)
            {
                var entryAssembly = Assembly.GetEntryAssembly();
                var entryAssemblyName = entryAssembly.GetName();
                var type = entryAssemblyName.Name;
                var versionAttribute = entryAssembly.GetCustomAttributes(false)
                    .OfType<AssemblyInformationalVersionAttribute>().FirstOrDefault();
                var version = versionAttribute?.InformationalVersion ?? entryAssemblyName.Version.ToString();
                _service = new Service {Type = type, Version = version};
            }

            return _service;
        }

        internal int GetSeverity(LogLevel logLevel)
        {
            switch (logLevel)
            {
                case LogLevel.Critical:
                    return 2;
                case LogLevel.Error:
                    return 3;
                case LogLevel.Warning:
                    return 4;
                case LogLevel.Information:
                    return 6;
                case LogLevel.Debug:
                case LogLevel.Trace:
                    return 7;
                default:
                    return 7;
            }
        }

        private void PostEvent(Base baseEvent)
        {
            var indexTime = baseEvent.Timestamp ?? ElasticsearchLoggerProvider.LocalDateTimeProvider();
            if (_options.IndexOffset.HasValue)
            {
                indexTime = indexTime.ToOffset(_options.IndexOffset.Value);
            }
            var index = string.Format(_options.Index, indexTime);

            var id = Guid.NewGuid().ToString();

            var localClient = _lowLevelClient;
            var response = localClient.Index<StringResponse>(index, id, PostData.Serializable(baseEvent));
        }

        private void ProcessLogQueue()
        {
            try
            {
                foreach (var baseEvent in _messageQueue.GetConsumingEnumerable())
                {
                    PostEvent(baseEvent);
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
            // TODO: Injectable factory? Or some way of testing.

            ConnectionConfiguration settings;
            if (_options.NodeUris.Length == 0)
            {
                // This is SingleNode with "http://localhost:9200"
                settings = new ConnectionConfiguration();
            }
            else if (_options.ConnectionPoolType == ConnectionPoolType.SingleNode
                     || (_options.ConnectionPoolType == ConnectionPoolType.Unknown && _options.NodeUris.Length == 1))
            {
                settings = new ConnectionConfiguration(_options.NodeUris[0]);
            }
            else
            {
                IConnectionPool connectionPool;
                switch (_options.ConnectionPoolType)
                {
                    // TODO: Add option to randomize pool
                    case ConnectionPoolType.Unknown:
                    case ConnectionPoolType.Sniffing:
                        connectionPool = new SniffingConnectionPool(_options.NodeUris);
                        break;
                    case ConnectionPoolType.Static:
                        connectionPool = new StaticConnectionPool(_options.NodeUris);
                        break;
                    case ConnectionPoolType.Sticky:
                        connectionPool = new StickyConnectionPool(_options.NodeUris);
                        break;
                    // case ConnectionPoolType.StickySniffing:
                    // case ConnectionPoolType.Cloud:
                    default:
                        throw new NotSupportedException($"Unknown connection pool type {_options.ConnectionPoolType}");
                }

                settings = new ConnectionConfiguration(connectionPool);
            }

            var lowlevelClient = new ElasticLowLevelClient(settings);

            _ = Interlocked.Exchange(ref _lowLevelClient, lowlevelClient);
        }
    }
}
