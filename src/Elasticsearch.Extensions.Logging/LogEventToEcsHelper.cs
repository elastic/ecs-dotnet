using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using Elastic.CommonSchema;
using Microsoft.Extensions.Logging;

namespace Elasticsearch.Extensions.Logging
{
	internal static class LogEventToEcsHelper
	{
		private static Agent? _agent;
		private static Ecs? _ecs;
		private static Host? _host;
		private static int _processId;
		private static string? _processName;
		private static Service? _service;

		public static int GetSeverity(LogLevel logLevel) =>
			logLevel switch
			{
				LogLevel.Critical => 2,
				LogLevel.Error => 3,
				LogLevel.Warning => 4,
				LogLevel.Information => 6,
				LogLevel.Trace => 7,
				LogLevel.Debug => 7,
				LogLevel.None => 8,
				_ => 7
			};

		public static string GetLogLevelString(LogLevel logLevel) =>
			logLevel switch
			{
				LogLevel.Critical => nameof(LogLevel.Critical),
				LogLevel.Error => nameof(LogLevel.Error),
				LogLevel.Warning => nameof(LogLevel.Warning),
				LogLevel.Information => nameof(LogLevel.Information),
				LogLevel.Trace => nameof(LogLevel.Trace),
				LogLevel.Debug => nameof(LogLevel.Debug),
				LogLevel.None => nameof(LogLevel.None),
				_ => "Unknown"
			};

		public static Ecs GetEcs() => _ecs ??= new Ecs() { Version = Base.Version };

		public static Agent GetAgent()
		{
			if (!(_agent is null)) return _agent;

			var assembly = typeof(ElasticsearchLogger).Assembly;
			var type = assembly.GetName().Name;
			var versionAttribute = assembly.GetCustomAttributes(false)
				.OfType<AssemblyInformationalVersionAttribute>()
				.FirstOrDefault();
			var version = versionAttribute?.InformationalVersion;
			_agent = new Agent { Type = type, Version = version };

			return _agent;
		}

		public static Host GetHost()
		{
			if (!(_host is null)) return _host;

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

			return _host;
		}

		public static Process GetProcess()
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

		public static Service GetService()
		{
			if (!(_service is null)) return _service;

			var entryAssembly = Assembly.GetEntryAssembly();
			var entryAssemblyName = entryAssembly.GetName();
			var type = entryAssemblyName.Name;
			var versionAttribute = entryAssembly.GetCustomAttributes(false)
				.OfType<AssemblyInformationalVersionAttribute>()
				.FirstOrDefault();
			var version = versionAttribute?.InformationalVersion ?? entryAssemblyName.Version.ToString();
			_service = new Service { Type = type, Version = version };

			return _service;
		}

	}
}
