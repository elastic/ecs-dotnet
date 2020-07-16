// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Elastic.CommonSchema;
using Elasticsearch.Net;
using Microsoft.Extensions.Logging;

namespace Elasticsearch.Extensions.Logging
{
	internal class ElasticsearchDataProcessor : IDisposable
	{
		private const int MaxQueuedMessages = 1024;

		private readonly BlockingCollection<LogEvent> _messageQueue =
			new BlockingCollection<LogEvent>(MaxQueuedMessages);

		private readonly Thread _outputThread;

		public ElasticsearchDataProcessor()
		{
			_outputThread = new Thread(ProcessLogQueue) { IsBackground = true, Name = "ElasticsearchLoggerProcessor.ProcessLogQueue" };
			_outputThread.Start();
		}

		private Agent? _agent;

		private Ecs? _ecs;
		private Host? _host;
		private IElasticLowLevelClient _lowLevelClient = default!;

		private ElasticsearchLoggerOptions _options = default!;
		private int _processId;
		private string? _processName;
		private Service? _service;

		internal ElasticsearchLoggerOptions Options
		{
			get => _options;
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
				PostEvent(logEvent);
			}
			catch (Exception) { }
		}

		public Ecs GetEcs()
		{
			if (_ecs is null) _ecs = new Ecs() { Version = Base.Version };

			return _ecs;
		}

		internal Agent GetAgent()
		{
			if (_agent is null)
			{
				var assembly = typeof(ElasticsearchLogger).Assembly;
				var type = assembly.GetName().Name;
				var versionAttribute = assembly.GetCustomAttributes(false)
					.OfType<AssemblyInformationalVersionAttribute>()
					.FirstOrDefault();
				var version = versionAttribute?.InformationalVersion;
				_agent = new Agent { Type = type, Version = version };
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
					Hostname = Environment.MachineName, Architecture = RuntimeInformation.OSArchitecture.ToString(), Os = operatingSystem
				};
			}

			return _host;
		}

		internal Process GetProcess()
		{
			if (_processName == null)
			{
				using var process = System.Diagnostics.Process.GetCurrentProcess();
				_processId = process.Id;
				_processName = process.ProcessName;
			}

			var currentThread = Thread.CurrentThread;

			return new Process
			{
				Name = _processName,
				Pid = _processId,
				Thread = new ProcessThread { Name = currentThread.Name, Id = currentThread.ManagedThreadId }
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
					.OfType<AssemblyInformationalVersionAttribute>()
					.FirstOrDefault();
				var version = versionAttribute?.InformationalVersion ?? entryAssemblyName.Version.ToString();
				_service = new Service { Type = type, Version = version };
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

		private void PostEvent(LogEvent logEvent)
		{
			var indexTime = logEvent.Timestamp ?? ElasticsearchLoggerProvider.LocalDateTimeProvider();
			if (_options.IndexOffset.HasValue) indexTime = indexTime.ToOffset(_options.IndexOffset.Value);

			var index = string.Format(_options.Index, indexTime);

			var id = Guid.NewGuid().ToString();

			var localClient = _lowLevelClient;
			var response = localClient.Index<StringResponse>(index, id, PostData.Serializable(logEvent));
		}

		private void ProcessLogQueue()
		{
			try
			{
				foreach (var logEvent in _messageQueue.GetConsumingEnumerable()) PostEvent(logEvent);
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
			var connectionPool = _options.ShipTo.CreateConnectionPool();
			var nodes = _options.ShipTo.NodeUris.ToArray();

			ConnectionConfiguration settings;

			if (nodes.Length == 0 && _options.ShipTo.ConnectionPoolType != ConnectionPoolType.Cloud)
			{
				// This is SingleNode with "http://localhost:9200"
				settings = new ConnectionConfiguration();
			}
			else if (_options.ConnectionPoolType == ConnectionPoolType.SingleNode
				|| _options.ConnectionPoolType == ConnectionPoolType.Unknown && nodes.Length == 1)
				settings = new ConnectionConfiguration(nodes[0]);
			else
			{
				settings = new ConnectionConfiguration(connectionPool);
			}

			var lowlevelClient = new ElasticLowLevelClient(settings);

			_ = Interlocked.Exchange(ref _lowLevelClient, lowlevelClient);
		}
	}
}
