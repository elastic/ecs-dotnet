using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Elasticsearch.Net;
using Essential.LoggerProvider.Ecs;
using Microsoft.Extensions.Logging;
using Process = System.Diagnostics.Process;
using Thread = System.Threading.Thread;

namespace Essential.LoggerProvider
{
    internal class ElasticsearchDataProcessor : IDisposable
    {
        private Agent? _agent;
        private Host? _host;
        private IElasticLowLevelClient _lowLevelClient = default!;
        private const int MaxQueuedMessages = 1024;
        private readonly BlockingCollection<ElasticsearchData> _messageQueue =
            new BlockingCollection<ElasticsearchData>(MaxQueuedMessages);
        private ElasticsearchLoggerOptions _options = default!;
        private readonly Thread _outputThread;
        private int _processId;
        private string? _processName;
        private Service? _service;

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

        public void EnqueueMessage(ElasticsearchData elasticsearchData)
        {
            if (!_messageQueue.IsAddingCompleted)
            {
                try
                {
                    _messageQueue.Add(elasticsearchData);
                    return;
                }
                catch (InvalidOperationException) { }
            }

            // Adding is complete, so just log the message
            try
            {
                WriteMessage(elasticsearchData);
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
                var version = versionAttribute.InformationalVersion;
                _agent = new Agent(type, version);
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

                var operatingSystem = new Ecs.OperatingSystem(
                    RuntimeInformation.OSDescription,
                    Environment.OSVersion.Platform.ToString(),
                    Environment.OSVersion.VersionString);
                _host = new Host(Environment.MachineName, RuntimeInformation.OSArchitecture.ToString(),
                    operatingSystem);
            }

            return _host;
        }

        internal Ecs.Process GetProcess()
        {
            if (_processName == null)
            {
                using var process = Process.GetCurrentProcess();
                _processId = process.Id;
                _processName = process.ProcessName;
            }

            var currentThread = Thread.CurrentThread;

            return new Ecs.Process(_processName, _processId,
                new Ecs.Thread(currentThread.Name, currentThread.ManagedThreadId));
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
                _service = new Service(type, version);
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
            // TODO: Injectable factory? Or some way of testing.

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

            _ = Interlocked.Exchange(ref _lowLevelClient, lowlevelClient);
        }

        private void WriteMessage(ElasticsearchData elasticsearchData)
        {
            var index = string.Format(_options.Index, elasticsearchData.Timestamp);

            var id = Guid.NewGuid().ToString();

            var localClient = _lowLevelClient;
            var response = localClient.Index<StringResponse>(index, id, PostData.Serializable(elasticsearchData));

            //_writer.WriteLine(message);
        }
    }
}
