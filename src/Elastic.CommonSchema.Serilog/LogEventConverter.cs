// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using Serilog.Events;

namespace Elastic.CommonSchema.Serilog
{
	/// <summary>
	/// Elastic Common Schema converter for LogEvent
	/// </summary>
	public static class LogEventConverter
	{
		private static class SpecialKeys
		{
			public const string DefaultLogger = "Elastic.CommonSchema.Serilog";

			public const string SourceContext = nameof(SourceContext);
			public const string EnvironmentUserName = nameof(EnvironmentUserName);
			public const string Host = nameof(Host);
			public const string ActionCategory = nameof(ActionCategory);
			public const string ActionName = nameof(ActionName);
			public const string ActionId = nameof(ActionId);
			public const string ActionKind = nameof(ActionKind);
			public const string ActionSeverity = nameof(ActionSeverity);
			public const string ApplicationId = nameof(ApplicationId);
			public const string ApplicationName = nameof(ApplicationName);
			public const string ApplicationType = nameof(ApplicationType);
			public const string ApplicationVersion = nameof(ApplicationVersion);
			public const string ProcessName = nameof(ProcessName);
			public const string ProcessId = nameof(ProcessId);
			public const string ThreadId = nameof(ThreadId);
			public const string MachineName = nameof(MachineName);
		}

		public static Base ConvertToEcs(LogEvent logEvent, IEcsTextFormatterConfiguration configuration)
		{
			var exceptions = logEvent.Exception != null
				? new List<Exception> { logEvent.Exception }
				: new List<Exception>();

			if (configuration.MapHttpAdapter != null)
				exceptions.AddRange(configuration.MapHttpAdapter.Exceptions);

			var ecsEvent = new Base
			{
				Timestamp = logEvent.Timestamp,
				Message = logEvent.RenderMessage(),
				Ecs = new Ecs { Version = Base.Version },
				Log = GetLog(logEvent, exceptions, configuration),
				Agent = GetAgent(logEvent),
				Event = GetEvent(logEvent),
				Metadata = GetMetadata(logEvent,configuration.LogEventPropertiesToFilter),
				Process = GetProcess(logEvent, configuration.MapCurrentThread),
				Host = GetHost(logEvent),
				Trace = GetTrace(logEvent),
				Transaction = GetTransaction(logEvent),
				Span = GetSpan(logEvent)
			};

			if (configuration.MapHttpAdapter != null)
			{
				ecsEvent.Http = configuration.MapHttpAdapter.Http;
				ecsEvent.Server = GetServer(logEvent, configuration);
				ecsEvent.Url = configuration.MapHttpAdapter.Url;
				ecsEvent.UserAgent = configuration.MapHttpAdapter.UserAgent;
				ecsEvent.Client = configuration.MapHttpAdapter.Client;
				ecsEvent.User = configuration.MapHttpAdapter.User;
			}

			if (configuration.MapExceptions)
				ecsEvent.Error = GetError(exceptions);

			if (configuration.MapCustom != null)
				ecsEvent = configuration.MapCustom(ecsEvent, logEvent);

			return ecsEvent;
		}

		private static Trace GetTrace(LogEvent logEvent) => !logEvent.TryGetScalarPropertyValue("ElasticApmTraceId", out var traceId)
			? null
			: new Trace { Id = traceId.Value.ToString() };

		private static Transaction GetTransaction(LogEvent logEvent) =>
			!logEvent.TryGetScalarPropertyValue("ElasticApmTransactionId", out var transactionId)
				? null
				: new Transaction { Id = transactionId.Value.ToString() };

		private static Span GetSpan(LogEvent logEvent) =>
			!logEvent.TryGetScalarPropertyValue("ElasticApmSpanId", out var spanId)
				? null
				: new Span { Id = spanId.Value.ToString() };

		private static IDictionary<string, object> GetMetadata(LogEvent logEvent, ISet<string> logEventPropertiesToFilter)
		{
			var dict = new Dictionary<string, object>
			{
				{ ToSnakeCase("MessageTemplate"), logEvent.MessageTemplate.Text }
			};

			//TODO what does this do and where does it come from?
			if (logEvent.Properties.TryGetValue("ActionPayload", out var actionPayload))
			{
				var logEventPropertyValues = (actionPayload as SequenceValue)?.Elements;

				if (logEventPropertyValues != null)
				{
					foreach (var item in logEventPropertyValues.Select(x => x.ToString()
							.Replace("\"", string.Empty)
							.Replace("[", string.Empty)
							.Replace("]", string.Empty)
							.Split(','))
						.Select(value => new { Key = value[0].Trim(), Value = value[1].Trim() }))
						dict.Add(ToSnakeCase(item.Key), item.Value);
				}
			}

			foreach (var logEventPropertyValue in logEvent.Properties)
			{
				switch (logEventPropertyValue.Key) {
					// already mapped as structured ECS event
					case SpecialKeys.SourceContext:
					case SpecialKeys.EnvironmentUserName:
					case SpecialKeys.Host:
					case SpecialKeys.ActionCategory:
					case SpecialKeys.ActionName:
					case SpecialKeys.ActionId:
					case SpecialKeys.ActionKind:
					case SpecialKeys.ActionSeverity:
					case SpecialKeys.ApplicationId:
					case SpecialKeys.ApplicationName:
					case SpecialKeys.ApplicationType:
					case SpecialKeys.ApplicationVersion:
					case SpecialKeys.ProcessName:
					case SpecialKeys.ProcessId:
					case SpecialKeys.ThreadId:
					case SpecialKeys.MachineName:
						continue;
				}
				//key present in list of keys to filter
				if (logEventPropertiesToFilter?.Contains(logEventPropertyValue.Key) ?? false)
					continue;
				dict.Add(ToSnakeCase(logEventPropertyValue.Key), PropertyValueToObject(logEventPropertyValue.Value));
			}

			if (dict.Count == 0)
				return null;

			return dict;
		}

		private static object PropertyValueToObject(LogEventPropertyValue propertyValue)
		{
			switch (propertyValue) {
				case SequenceValue values:
					return values.Elements.Select(PropertyValueToObject).ToArray();
				case ScalarValue sv:
					return sv.Value;
				case DictionaryValue dv:
					return dv.Elements.ToDictionary(keySelector: kvp => ToSnakeCase(kvp.Key.Value.ToString()), elementSelector: (kvp) => PropertyValueToObject(kvp.Value));
				case StructureValue ov:
				{
					var dict = ov.Properties.ToDictionary(p => p.Name, p => PropertyValueToObject(p.Value));
					if (ov.TypeTag != null) dict.Add("$type", ov.TypeTag);
					return dict;
				}
				default:
					return propertyValue;
			}
		}

		private static string ToSnakeCase(string key) => key;

		private static Host GetHost(LogEvent e)
		{
			if (!e.TryGetScalarPropertyValue(SpecialKeys.MachineName, out var machineName))
				return null;

			var host = new Host
			{
				Name = machineName.Value.ToString()
			};

			//todo map more uptime etc
			return host;
		}

		private static Server GetServer(LogEvent e, IEcsTextFormatterConfiguration configuration)
		{
			var server = configuration.MapHttpAdapter?.Server?? new Server();
			server.User = e.TryGetScalarPropertyValue(SpecialKeys.EnvironmentUserName, out var environmentUserName)
				? new User { Name = environmentUserName.Value.ToString() }
				: null;

			var hasHost = e.TryGetScalarPropertyValue(SpecialKeys.Host, out var host);
			server.Address = hasHost ? host.Value.ToString() : null;
			return server;
		}

		private static Process GetProcess(LogEvent e, bool mapFromCurrentThread)
		{
			e.TryGetScalarPropertyValue(SpecialKeys.ProcessName, out var processNameProp);
			e.TryGetScalarPropertyValue(SpecialKeys.ProcessId, out var processIdProp);
			e.TryGetScalarPropertyValue(SpecialKeys.ThreadId, out var threadIdProp);
			if (processNameProp == null
				&& processIdProp == null
				&& threadIdProp == null
				&& !mapFromCurrentThread)
				return null;

			var processName = processNameProp?.Value.ToString();
			var processId = processIdProp?.Value.ToString();
			var threadId = threadIdProp?.Value.ToString();
			var pid = int.TryParse(processId ?? "", out var p)
				? p
				: (int?)null;

			if (!mapFromCurrentThread)
			{
				return new Process
				{
					Title = string.IsNullOrEmpty(processName) ? null : processName,
					Name = processName,
					Pid = pid,
					Thread = int.TryParse(threadId ?? processId, out var id)
						? new ProcessThread { Id = id }
						: null,
				};
			}

			var currentThread = Thread.CurrentThread;
			var process = TryGetProcess(pid);

			var mainWindowTitle = process?.MainWindowTitle;
			return new Process
			{
				Title = string.IsNullOrEmpty(mainWindowTitle) ? null : mainWindowTitle,
				Name = process?.ProcessName ?? processName,
				Pid = process?.Id ?? pid,
				Executable = process?.ProcessName ?? processName,
				Thread = new ProcessThread { Id = currentThread.ManagedThreadId }
			};
		}

		private static System.Diagnostics.Process TryGetProcess(int? processId)
		{
			try
			{
				var pid = processId != null
					? System.Diagnostics.Process.GetProcessById(processId.Value)
					: System.Diagnostics.Process.GetCurrentProcess();
				return pid;
			}
			catch (Exception)
			{
				return null;
			}
		}

		private static Log GetLog(LogEvent e, IReadOnlyList<Exception> exceptions, IEcsTextFormatterConfiguration configuration)
		{
			var source = e.TryGetScalarPropertyValue(SpecialKeys.SourceContext, out var context)
				 ? context.Value.ToString()
				 : SpecialKeys.DefaultLogger ;

			var log = new Log { Level = e.Level.ToString("F"), Logger = source};

			if (configuration.MapExceptions)
			{
				// TODO - walk stack trace for other information
			}

			return log;
		}

		private static Error GetError(IReadOnlyList<Exception> exceptions) =>
			exceptions != null && exceptions.Count > 0
				? new Error { Message = exceptions[0].Message, StackTrace = CatchErrors(exceptions), Type = exceptions[0].GetType().ToString() }
				: null;

		private static Event GetEvent(LogEvent e)
		{
			var evnt = new Event
			{
				Created = e.Timestamp,
				Category = e.TryGetScalarPropertyValue(SpecialKeys.ActionCategory, out var actionCategoryProperty)
					? new [] { actionCategoryProperty.Value.ToString() }
					: null,
				Action = e.TryGetScalarPropertyValue(SpecialKeys.ActionName, out var action)
					? action.Value.ToString()
					: null,
				Id = e.TryGetScalarPropertyValue(SpecialKeys.ActionId, out var actionId)
					? actionId.Value.ToString()
					: null,
				Kind = e.TryGetScalarPropertyValue(SpecialKeys.ActionKind, out var actionKindProperty) ? actionKindProperty.Value.ToString() : null,
				Severity = e.TryGetScalarPropertyValue(SpecialKeys.ActionSeverity, out var actionSev)
					? long.Parse(actionSev.Value.ToString())
					: (int)e.Level,
				Timezone = TimeZoneInfo.Local.StandardName
			};

			return evnt;
		}

		private static Agent GetAgent(LogEvent e)
		{
			Agent agent = null;

			void Assign(string key, Action<Agent, string> assign)
			{
				if (!e.TryGetScalarPropertyValue(key, out var v)) return;

				agent ??= new Agent();
				assign(agent, v.Value.ToString());
			}

			Assign(SpecialKeys.ApplicationId, (a, v) => a.Id = v);
			Assign(SpecialKeys.ApplicationName, (a, v) => a.Name = v);
			Assign(SpecialKeys.ApplicationType, (a, v) => a.Type = v);
			Assign(SpecialKeys.ApplicationVersion, (a, v) => a.Version = v);
			return agent;
		}

		private static string CatchErrors(IReadOnlyCollection<Exception> errors)
		{
			if (errors == null || errors.Count <= 0)
				return string.Empty;

			var i = 1;
			var fullText = new StringWriter();
			foreach (var error in errors)
			{
				var frame = new StackTrace(error, true).GetFrame(0);

				fullText.WriteLine($"Exception {i++:D2} ===================================");
				fullText.WriteLine($"Type: {error.GetType()}");
				fullText.WriteLine($"Source: {error.TargetSite?.DeclaringType?.AssemblyQualifiedName}");
				fullText.WriteLine($"Message: {error.Message}");
				fullText.WriteLine($"Trace: {error.StackTrace}");
				if (frame != null)
				{
					fullText.WriteLine($"Location: {frame.GetFileName()}");
					fullText.WriteLine($"Method: {frame.GetMethod()} ({frame.GetFileLineNumber()}, {frame.GetFileColumnNumber()})");
				}

				var exception = error.InnerException;
				while (exception != null)
				{
					frame = new StackTrace(exception, true).GetFrame(0);
					fullText.WriteLine($"\tException {i++:D2} inner --------------------------");
					fullText.WriteLine($"\tType: {exception.GetType()}");
					fullText.WriteLine($"\tSource: {exception.TargetSite?.DeclaringType?.AssemblyQualifiedName}");
					fullText.WriteLine($"\tMessage: {exception.Message}");
					fullText.WriteLine($"\tTrace: {exception.StackTrace}");
					if (frame != null)
					{
						fullText.WriteLine($"\tLocation: {frame.GetFileName()}");
						fullText.WriteLine($"\tMethod: {frame.GetMethod()} ({frame.GetFileLineNumber()}, {frame.GetFileColumnNumber()})");
					}

					exception = exception.InnerException;
				}
			}

			return fullText.ToString();
		}
	}
}
