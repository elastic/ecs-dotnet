// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Concurrent;
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

		public static TEcsDocument ConvertToEcs<TEcsDocument>(LogEvent logEvent, IEcsTextFormatterConfiguration<TEcsDocument> configuration)
			where TEcsDocument : EcsDocument, new()
		{
			var exceptions = logEvent.Exception != null
				? new List<Exception> { logEvent.Exception }
				: new List<Exception>();

			if (configuration.MapHttpAdapter != null)
				exceptions.AddRange(configuration.MapHttpAdapter.Exceptions);

			var ecsEvent = new TEcsDocument
			{
				Timestamp = logEvent.Timestamp,
				Message = logEvent.RenderMessage(),
				Ecs = new Ecs { Version = EcsDocument.Version },
				Log = GetLog(logEvent, exceptions, configuration),
				Service = GetService(logEvent),
				Agent = GetAgent(logEvent),
				Event = GetEvent(logEvent),
				Process = GetProcess(logEvent, configuration.MapCurrentThread),
				Host = GetHost(logEvent),
				TraceId = GetTrace(logEvent),
				TransactionId = GetTransaction(logEvent),
				SpanId = GetSpan(logEvent),
				Server = GetServer(logEvent, configuration),
				Http = GetHttp(logEvent, configuration),
				Url = GetUrl(logEvent, configuration),
				UserAgent = GetUserAgent(logEvent, configuration),
				Client = GetClient(logEvent, configuration),
				User = GetUser(logEvent, configuration)
			};
			ecsEvent.SetActivityData();

			var metaData = GetMetadata(logEvent, configuration.LogEventPropertiesToFilter);
			foreach (var kv in metaData)
				ecsEvent.AssignField(kv.Key, kv.Value);

			ecsEvent.Error = GetError(exceptions);

			if (configuration.MapCustom != null)
				ecsEvent = configuration.MapCustom(ecsEvent, logEvent);

			return ecsEvent;
		}

		public static EcsDocument ConvertToEcs(LogEvent logEvent, IEcsTextFormatterConfiguration<EcsDocument> configuration) =>
			ConvertToEcs<EcsDocument>(logEvent, configuration);

		private static Service GetService(LogEvent logEvent)
		{
			if (!logEvent.TryGetScalarPropertyValue("ElasticApmServiceName", out var serviceName))
				return null;

			return new Service
			{
				Name = serviceName.Value.ToString(),
				Version = logEvent.TryGetScalarPropertyValue("ElasticApmServiceVersion", out var version) ? version.Value.ToString() : null,
				NodeName = logEvent.TryGetScalarPropertyValue("ElasticApmServiceNodeName", out var name) ? name.Value.ToString() : null,
			};
		}

		private static string GetTrace(LogEvent logEvent) => !logEvent.TryGetScalarPropertyValue("ElasticApmTraceId", out var traceId)
			? null
			: traceId.Value.ToString();

		private static string GetTransaction(LogEvent logEvent) =>
			!logEvent.TryGetScalarPropertyValue("ElasticApmTransactionId", out var transactionId)
				? null
				: transactionId.Value.ToString();

		private static string GetSpan(LogEvent logEvent) =>
			!logEvent.TryGetScalarPropertyValue("ElasticApmSpanId", out var spanId)
				? null
				: spanId.Value.ToString();

		private static MetadataDictionary GetMetadata(LogEvent logEvent, ISet<string> logEventPropertiesToFilter)
		{
			var dict = new MetadataDictionary
			{
				{ "MessageTemplate", logEvent.MessageTemplate.Text }
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
						dict.Add(item.Key, item.Value);
				}
			}

			foreach (var logEventPropertyValue in logEvent.Properties)
			{
				if (PropertyAlreadyMapped(logEventPropertyValue.Key))
					continue;

				//key present in list of keys to filter
				if (logEventPropertiesToFilter?.Contains(logEventPropertyValue.Key) ?? false)
					continue;

				dict.Add(logEventPropertyValue.Key, PropertyValueToObject(logEventPropertyValue.Value));
			}

			return dict.Count == 0 ? MetadataDictionary.Default : dict;
		}

		private static bool PropertyAlreadyMapped(string property)
		{
			switch (property)
			{
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
				case SpecialKeys.Elapsed:
				case SpecialKeys.ElapsedMilliseconds:
				case SpecialKeys.Method:
				case SpecialKeys.RequestMethod:
				case SpecialKeys.Path:
				case SpecialKeys.RequestPath:
				case SpecialKeys.StatusCode:
				case SpecialKeys.Scheme:
				case SpecialKeys.QueryString:
				case SpecialKeys.RequestId:
				case SpecialKeys.HttpContext:
				case SpecialKeys.ContentType:
				case SpecialKeys.HostingRequestFinishedLog:
					return true;
				default:
					return false;
			}
		}

		private static object PropertyValueToObject(LogEventPropertyValue propertyValue)
		{
			switch (propertyValue) {
				case SequenceValue values:
					return values.Elements.Select(PropertyValueToObject).ToArray();
				case ScalarValue sv:
					return sv.Value;
				case DictionaryValue dv:
					return dv.Elements.ToDictionary(keySelector: kvp => kvp.Key.Value.ToString(), elementSelector: (kvp) => PropertyValueToObject(kvp.Value));
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
			var server = configuration.MapHttpAdapter?.Server;
			e.TryGetScalarPropertyValue(SpecialKeys.EnvironmentUserName, out var environmentUserName);
			e.TryGetScalarPropertyValue(SpecialKeys.Host, out var host);

			if (server == null && environmentUserName == null && host == null)
				return null;

			server ??= new Server();
			server.User = environmentUserName?.Value != null
				? new User { Name = environmentUserName.Value.ToString() }
				: null;
			server.Address = host?.Value?.ToString();

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
					ThreadId = int.TryParse(threadId ?? processId, out var id) ? id : null,
				};
			}

			if (pid == null)
				return CurrentProcess ??= ToEcsProcess(null, processName);

			if (ProcessLookup.TryGetValue(pid.Value, out var cachedProcess))
				return cachedProcess;

			var process = ToEcsProcess(pid, processName);
			if (!ProcessLookup.TryAdd(pid.Value, process)) return process;

			// simplistic fixed memory cache
			// if we spot that we are caching more then 10k process id's assume something is wrong
			// and purge cache
			var count = Interlocked.Increment(ref LookupCount);
			if (count <= 10_000) return process;

			ProcessLookup.Clear();
			// This could reset a previous increment from possible other threads adding.
			// The count being approximately 10k is good enough
			Interlocked.Exchange(ref LookupCount, 0);
			return process;
		}

		private static Process CurrentProcess = null;
		private static readonly ConcurrentDictionary<int, Process> ProcessLookup = new();
		private static int LookupCount = 0;

		private static Process ToEcsProcess(int? pid, string processName)
		{
			var process = TryGetProcess(pid);

			var mainWindowTitle = process?.MainWindowTitle;
			var currentThread = Thread.CurrentThread;
			return new Process
			{
				Title = string.IsNullOrEmpty(mainWindowTitle) ? null : mainWindowTitle,
				Name = process?.ProcessName ?? processName,
				Pid = process?.Id ?? pid,
				Executable = process?.ProcessName ?? processName,
				ThreadId = currentThread.ManagedThreadId
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
				: SpecialKeys.DefaultLogger;

			var log = new Log { Level = e.Level.ToString("F"), Logger = source };

			if (exceptions.Count > 0)
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
			var elapsedMs = e.TryGetScalarPropertyValue(SpecialKeys.Elapsed, out var elapsed)
				? elapsed.Value
				: e.TryGetScalarPropertyValue(SpecialKeys.ElapsedMilliseconds, out elapsed) ? elapsed.Value : null;

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
				Timezone = TimeZoneInfo.Local.StandardName,
				Duration = elapsedMs != null ? (long)((double)elapsedMs * 1000000) : null
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

		private static Http GetHttp(LogEvent e, IEcsTextFormatterConfiguration configuration)
		{
			if (e.TryGetScalarPropertyValue(SpecialKeys.HttpContext, out var httpContext)
				&& httpContext?.Value is HttpContextEnricher.HttpContextEnrichments enriched)
				return enriched.Http;

			var http = configuration.MapHttpAdapter?.Http;

			if (e.TryGetScalarPropertyValue(SpecialKeys.Method, out var method) || e.TryGetScalarPropertyValue(SpecialKeys.RequestMethod, out method))
			{
				http ??= new Http();
				http.RequestMethod = method.Value.ToString();
			}

			if (e.TryGetScalarPropertyValue(SpecialKeys.RequestId, out var requestId))
			{
				http ??= new Http();
				http.RequestId = requestId.Value.ToString();
			}

			if (e.TryGetScalarPropertyValue(SpecialKeys.StatusCode, out var statusCode))
			{
				http ??= new Http();
				http.ResponseStatusCode = (int)statusCode.Value;
			}
			if (e.TryGetScalarPropertyValue(SpecialKeys.ContentType, out var contentType))
			{
				http ??= new Http();
				http.ResponseMimeType = contentType.Value.ToString();
			}

			return http;
		}

		private static Url GetUrl(LogEvent e, IEcsTextFormatterConfiguration configuration)
		{
			if (e.TryGetScalarPropertyValue(SpecialKeys.HttpContext, out var httpContext)
				&& httpContext?.Value is HttpContextEnricher.HttpContextEnrichments enriched)
				return enriched.Url;

			var url = configuration.MapHttpAdapter?.Url;

			if (e.TryGetScalarPropertyValue(SpecialKeys.Path, out var path) || e.TryGetScalarPropertyValue(SpecialKeys.RequestPath, out path))
			{
				url ??= new Url();
				url.Path = path.Value.ToString();
			}

			if (e.TryGetScalarPropertyValue(SpecialKeys.Scheme, out var scheme))
			{
				url ??= new Url();
				url.Scheme = scheme.Value.ToString();
			}

			if (e.TryGetScalarPropertyValue(SpecialKeys.QueryString, out var queryString))
			{
				url ??= new Url();
				var str = queryString.Value?.ToString();
				url.Query = string.IsNullOrEmpty(str) ? null : str.TrimStart('?');
			}

			return url;
		}

		private static UserAgent GetUserAgent(LogEvent e, IEcsTextFormatterConfiguration configuration)
		{
			if (e.TryGetScalarPropertyValue(SpecialKeys.HttpContext, out var httpContext)
				&& httpContext?.Value is HttpContextEnricher.HttpContextEnrichments enriched)
				return enriched.UserAgent;
			return configuration.MapHttpAdapter?.UserAgent;
		}

		private static User GetUser(LogEvent e, IEcsTextFormatterConfiguration configuration)
		{
			if (e.TryGetScalarPropertyValue(SpecialKeys.HttpContext, out var httpContext)
				&& httpContext?.Value is HttpContextEnricher.HttpContextEnrichments enriched)
				return enriched.User;
			return configuration.MapHttpAdapter?.User;

		}

		private static Client GetClient(LogEvent e, IEcsTextFormatterConfiguration configuration)
		{
			if (e.TryGetScalarPropertyValue(SpecialKeys.HttpContext, out var httpContext)
				&& httpContext?.Value is HttpContextEnricher.HttpContextEnrichments enriched)
				return enriched.Client;
			return configuration.MapHttpAdapter?.Client;
		}
	}
}
