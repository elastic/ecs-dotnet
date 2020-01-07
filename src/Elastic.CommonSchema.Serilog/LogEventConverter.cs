// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Serilog.Events;
#if NETSTANDARD
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Abstractions;
#else

#endif

namespace Elastic.CommonSchema.Serilog
{
	/// <summary>
	/// Elastic Common Schema converter for LogEvent
	/// </summary>
	public class LogEventConverter
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

			if (configuration.MapHttpAdapter != null) exceptions.AddRange(configuration.MapHttpAdapter.Exceptions);

			var ecsEvent = new Base
			{
				Timestamp = logEvent.Timestamp,
				Ecs = new Ecs { Version = Base.Version },
				Log = GetLog(logEvent, exceptions, configuration),
				Agent = GetAgent(logEvent),
				Event = GetEvent(logEvent),
				Metadata = GetMetadata(logEvent),
				Process = GetProcess(logEvent, configuration.MapCurrentThread),
				Host = GetHost(logEvent),
				Trace = GetTrace(logEvent),
				Transaction = GetTransaction(logEvent)
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

			if (configuration.MapExceptions) ecsEvent.Error = GetError(exceptions);

			if (configuration.MapCustom != null) ecsEvent = configuration.MapCustom(ecsEvent, logEvent);

			ecsEvent.Message = logEvent.RenderMessage();

			return ecsEvent;
		}

		private static Trace GetTrace(LogEvent logEvent) => !logEvent.Properties.TryGetValue("ElasticApmTraceId", out var traceId)
			? null
			: new Trace { Id = traceId.ToString().Replace("\"", string.Empty) };

		private static Transaction GetTransaction(LogEvent logEvent) =>
			!logEvent.Properties.TryGetValue("ElasticApmTransactionId", out var transactionId)
				? null
				: new Transaction { Id = transactionId.ToString().Replace("\"", string.Empty) };

		private static IDictionary<string, object> GetMetadata(LogEvent logEvent)
		{
			var dict = new Dictionary<string, object>();
			//TODO what does this do and where does it come from?
			if (logEvent.Properties.TryGetValue("ActionPayload", out var actionPayload))
			{
				var logEventPropertyValues = (actionPayload as SequenceValue)?.Elements;

				if (logEventPropertyValues != null)
				{
					foreach (var item in logEventPropertyValues.Select(x => x.ToString()
							.Replace("\"", string.Empty)
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

				if (logEventPropertyValue.Value is SequenceValue values)
				{
					dict.Add(ToSnakeCase(logEventPropertyValue.Key), values.Elements.Select(e => e.ToString()).ToArray());
					continue;
				}

				if (logEventPropertyValue.Value is ScalarValue sv)
					dict.Add(ToSnakeCase(logEventPropertyValue.Key), sv.Value);
				else
					dict.Add(ToSnakeCase(logEventPropertyValue.Key), logEventPropertyValue.Value);
			}
			if (dict.Count == 0) return null;
			return dict;
		}

		private static string ToSnakeCase(string key) => key;

		private static Host GetHost(LogEvent e)
		{
			if (!e.Properties.TryGetValue(SpecialKeys.MachineName, out var machineName))
				return null;

			var host = new Host { Name = machineName.ToString() };
			//todo map more uptime etc
			return host;
		}

		private static Server GetServer(LogEvent e, IEcsTextFormatterConfiguration configuration)
		{
			var server = configuration.MapHttpAdapter?.Server?? new Server();
			server.User = e.Properties.TryGetValue(SpecialKeys.EnvironmentUserName, out var environmentUserName)
				? new User { Name = environmentUserName.ToString() }
				: null;

			var hasHost = e.Properties.TryGetValue(SpecialKeys.Host, out var host);
			server.Address = hasHost ? host.ToString() : null;
			server.Ip = hasHost ? host.ToString() : null;
			return server;
		}

		private static Process GetProcess(LogEvent e, bool mapFromCurrentThread)
		{
			LogEventPropertyValue processNameProp = null;
			LogEventPropertyValue processIdProp = null;
			LogEventPropertyValue threadIdProp = null;
			e.Properties.TryGetValue(SpecialKeys.ProcessName, out processNameProp);
			e.Properties.TryGetValue(SpecialKeys.ProcessId, out processIdProp);
			e.Properties.TryGetValue(SpecialKeys.ThreadId, out threadIdProp);
			if (processNameProp == null
				&& processIdProp == null
				&& threadIdProp == null
				&& !mapFromCurrentThread)
				return null;

			var processName = processNameProp?.ToString();
			var processId = processIdProp?.ToString();
			var threadId = threadIdProp?.ToString();
			var pid = int.TryParse(processId ?? "", out var p)
				? p
				: (int?)null;

			if (!mapFromCurrentThread)
			{
				return new Process
				{
					Title = processName,
					Name = processName,
					Pid = pid,
					Thread = int.TryParse(threadId ?? processId ?? "", out var id)
						? new ProcessThread() { Id = id }
						: null,
				};
			}

			var currentThread = Thread.CurrentThread;
			var process = TryGetProcess(pid);

			return new Process
			{
				Title = process?.MainWindowTitle,
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
			var source = e.Properties.TryGetValue(SpecialKeys.SourceContext, out var context)
				 ? context.ToString()
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
				? new Error { Message = exceptions[0].Message, StackTrace = CatchErrors(exceptions), Code = exceptions[0].GetType().ToString() }
				: null;

		private static Event GetEvent(LogEvent e)
		{
			var hasActionCategory = e.Properties.TryGetValue(SpecialKeys.ActionCategory, out var actionCategoryProperty);
			var hasActionKind = e.Properties.TryGetValue(SpecialKeys.ActionKind, out var actionKindProperty);

		    var actionCategoryIsEnum =	Enum.TryParse(actionCategoryProperty.ToString().Replace("\"", ""), out EventCategory actionCategory);
		    var actionKindIsEnum =	Enum.TryParse(actionKindProperty.ToString().Replace("\"", ""), out EventKind actionKind);

			var evnt = new Event
			{
				Created = e.Timestamp,
				Category = hasActionCategory && actionCategoryIsEnum ? actionCategory : (EventCategory?)null,
				Action = e.Properties.TryGetValue(SpecialKeys.ActionName, out var action) ? action.ToString().Replace("\"", "") : null,
				Id = e.Properties.TryGetValue(SpecialKeys.ActionId, out var actionId)
					? actionId.ToString().Replace("\"", "")
					: null,
				Kind = hasActionKind && actionKindIsEnum ? actionKind : (EventKind?)null,
				Severity = e.Properties.TryGetValue(SpecialKeys.ActionSeverity, out var actionSev)
					? long.Parse(actionSev.ToString())
					: (int)e.Level,
				Timezone = TimeZoneInfo.Local.StandardName
			};

			//Why does this get overriden in full framework?
#if FULLFRAMEWORK
			evnt.Timezone = TimeZone.CurrentTimeZone.StandardName;
#endif
			return evnt;
		}

		private static Agent GetAgent(LogEvent e)
		{
			Agent agent = null;

			void Assign(string key, Action<Agent, string> assign)
			{
				if (!e.Properties.TryGetValue(key, out var v)) return;

				agent ??= new Agent();
				assign(agent, v.ToString());
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
				fullText.WriteLine($"Location: {frame.GetFileName()}");
				fullText.WriteLine(
					$"Method: {frame.GetMethod()} ({frame.GetFileLineNumber()}, {frame.GetFileColumnNumber()})");

				var exception = error.InnerException;
				while (exception != null)
				{
					frame = new StackTrace(exception, true).GetFrame(0);
					fullText.WriteLine($"\tException {i:D2} inner --------------------------");
					fullText.WriteLine($"\tType: {exception.GetType()}");
					fullText.WriteLine($"\tSource: {exception.TargetSite?.DeclaringType?.AssemblyQualifiedName}");
					fullText.WriteLine($"\tMessage: {exception.Message}");
					fullText.WriteLine($"\tLocation: {frame.GetFileName()}");
					fullText.WriteLine(
						$"\tMethod: {frame.GetMethod()} ({frame.GetFileLineNumber()}, {frame.GetFileColumnNumber()})");

					exception = exception.InnerException;
				}
			}

			return fullText.ToString();
		}
	}
}
