// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;

namespace Elastic.CommonSchema.NLog
{
	[Layout(Name)]
	[ThreadSafe]
	[ThreadAgnostic]
	public class EcsLayout : Layout
	{
		public const string Name = nameof(EcsLayout);

		private static bool? _nlogApmLoaded;
		private static bool? _nlogWebLoaded;

		private static bool NLogApmLoaded()
		{
			if (_nlogApmLoaded.HasValue) return _nlogApmLoaded.Value;
			_nlogApmLoaded = Type.GetType("Elastic.Apm.NLog.ApmTraceIdLayoutRenderer, Elastic.Apm.NLog") != null;
			return _nlogApmLoaded.Value;
		}

		private static bool NLogWeb5Loaded()
		{
			if (_nlogWebLoaded.HasValue)
				return _nlogWebLoaded.Value;
			_nlogWebLoaded = Type.GetType("NLog.Web.LayoutRenderers.AspNetRequestDurationLayoutRenderer, NLog.Web.AspNetCore") != null;
			return _nlogWebLoaded.Value;
		}

		private readonly Layout _disableThreadAgnostic = "${threadid:cached=true}";

		public EcsLayout()
		{
			IncludeEventProperties = true;

			LogOriginCallSiteMethod = "${exception:format=method}";
			LogOriginCallSiteFile = "${exception:format=source}";

			ProcessId = "${processid}";
			ProcessName = "${processname:FullName=false}";
			ProcessExecutable = "${processname:FullName=true}";
			ProcessTitle = "${processinfo:MainWindowTitle}";
			ProcessThreadId = "${threadid}";

			HostName = "${machinename}";
			HostIp = "${local-ip:cachedSeconds=60}"; // NLog 4.6.8

			ServerUser = "${environment-user}"; // NLog 4.6.4

			// These values are set by the Elastic.Apm.NLog package
			if (NLogApmLoaded())
			{
				ApmTraceId = "${ElasticApmTraceId}";
				ApmTransactionId = "${ElasticApmTransactionId}";
				ApmSpanId = "${ElasticApmSpanId}";

				ApmServiceName = "${ElasticApmServiceName}";
				ApmServiceNodeName = "${ElasticApmServiceNodeName}";
				ApmServiceVersion = "${ElasticApmServiceVersion}";
			}

			if (NLogWeb5Loaded())
			{
				EventDurationMs = "${aspnet-request-duration}";

				HttpRequestId = "${aspnet-TraceIdentifier}";
				HttpRequestMethod = "${aspnet-request-method}";
				RequestBodyBytes = "${aspnet-request-contentlength}";
				HttpRequestReferrer = "${aspnet-request-referrer}";
				HttpResponseStatusCode = "${aspnet-response-statuscode}";

				UrlScheme = "${aspnet-request-url:IncludeScheme=true:IncludeHost=false:IncludePath=false}";
				UrlDomain = "${aspnet-request-url:IncludeScheme=false:IncludeHost=true:IncludePath=false}";
				UrlPath = "${aspnet-request-url:IncludeScheme=false:IncludeHost=false:IncludePath=true}";
				UrlPort = "${aspnet-request-url:IncludeScheme=false:IncludeHost=false:IncludePath=false:IncludePort=true}";
				UrlQuery = "${aspnet-request-url:IncludeScheme=false:IncludeHost=false:IncludePath=false:IncludeQueryString=true}";
				UrlUserName = "${aspnet-user-identity}";

				if (!NLogApmLoaded())
				{
					ApmTraceId = "${scopeproperty:item=RequestId:whenEmpty=${aspnet-TraceIdentifier}}}";
				}
			}
		}

		public Layout AgentId { get; set; }
		public Layout AgentName { get; set; }
		public Layout AgentType { get; set; }
		public Layout AgentVersion { get; set; }

		public Layout ApmTraceId { get; set; }
		public Layout ApmTransactionId { get; set; }
		public Layout ApmSpanId { get; set; }

		public Layout ApmServiceName { get; set; }
		public Layout ApmServiceNodeName { get; set; }
		public Layout ApmServiceVersion { get; set; }

		/// <summary>
		/// Allow dynamically disabling <see cref="ThreadAgnosticAttribute" /> to
		/// ensure correct async context capture when necessary
		/// </summary>
		public Layout DisableThreadAgnostic => IncludeScopeProperties ? _disableThreadAgnostic : null;

		public Layout LogOriginCallSiteMethod { get; set; }
		public Layout LogOriginCallSiteFile { get; set; }
		public Layout LogOriginCallSiteLine { get; set; }

		public Layout EventAction { get; set; }
		public Layout EventCategory { get; set; }
		public Layout EventId { get; set; }
		public Layout EventKind { get; set; }
		public Layout EventSeverity { get; set; }
		public Layout EventDurationMs { get; set; }

		public Layout HostId { get; set; }
		public Layout HostIp { get; set; }
		public Layout HostName { get; set; }

		[Obsolete("Replaced by IncludeEventProperties")]
		public bool IncludeAllProperties { get => IncludeEventProperties; set => IncludeEventProperties = value; }

		[Obsolete("Replaced by IncludeScopeProperties")]
		public bool IncludeMdlc { get => IncludeScopeProperties; set => IncludeScopeProperties = value; }

		public bool IncludeEventProperties { get; set; }

		public bool IncludeScopeProperties { get; set; }

		[ArrayParameter(typeof(TargetPropertyWithContext), "label")]
		public IList<TargetPropertyWithContext> Labels { get; } = new List<TargetPropertyWithContext>();

		[ArrayParameter(typeof(TargetPropertyWithContext), "metadata")]
		public IList<TargetPropertyWithContext> Metadata { get; } = new List<TargetPropertyWithContext>();

		public Layout ProcessExecutable { get; set; }
		public Layout ProcessId { get; set; }
		public Layout ProcessName { get; set; }
		public Layout ProcessThreadId { get; set; }
		public Layout ProcessTitle { get; set; }

		public Layout ServerAddress { get; set; }
		public Layout ServerIp { get; set; }
		public Layout ServerUser { get; set; }

		public Layout HttpRequestId { get; set; }
		public Layout HttpRequestMethod { get; set; }
		public Layout RequestBodyBytes { get; set; }
		public Layout HttpRequestReferrer { get; set; }
		public Layout HttpResponseStatusCode { get; set; }

		public Layout UrlScheme { get; set; }
		public Layout UrlDomain { get; set; }
		public Layout UrlPort { get; set; }
		public Layout UrlPath { get; set; }
		public Layout UrlQuery { get; set; }
		public Layout UrlUserName { get; set; }

		/// <summary>
		/// Optional action to enrich the constructed <see cref="Base">EcsEvent</see> before it is serialized
		/// </summary>
		/// <remarks>This is called last in the chain of enrichment functions</remarks>
		public Action<EcsDocument,LogEventInfo> EnrichAction { get; set; }

		[ArrayParameter(typeof(TargetPropertyWithContext), "tag")]
		public IList<TargetPropertyWithContext> Tags { get; } = new List<TargetPropertyWithContext>();

		/// <summary>
		/// List of property names to exclude from MetaData, when <see cref="IncludeEventProperties"/> is true
		/// </summary>
		public ISet<string> ExcludeProperties { get; set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		protected override void RenderFormattedMessage(LogEventInfo logEvent, StringBuilder target)
		{
			var ecsEvent = new EcsDocument
			{
				Timestamp = logEvent.TimeStamp,
				Message = logEvent.FormattedMessage,
				Ecs = new Ecs { Version = EcsDocument.Version },
				Log = GetLog(logEvent),
				Service = GetService(logEvent),
				Event = GetEvent(logEvent),
				Metadata = GetMetadata(logEvent),
				Process = GetProcess(logEvent),
				TraceId = GetTrace(logEvent),
				TransactionId = GetTransaction(logEvent),
				SpanId = GetSpan(logEvent),
				Error = GetError(logEvent.Exception),
				Tags = GetTags(logEvent),
				Labels = GetLabels(logEvent),
				Agent = GetAgent(logEvent),
				Server = GetServer(logEvent),
				Host = GetHost(logEvent),
				Http = GetHttp(logEvent),
				Url = GetUrl(logEvent),
			};

			//Give any deriving classes a chance to enrich the event
			EnrichEvent(logEvent, ref ecsEvent);
			//Allow programmatical actions to enrich before serializing
			EnrichAction?.Invoke(ecsEvent, logEvent);

			ecsEvent.Serialize(target);
		}

		private Service GetService(LogEventInfo logEventInfo)
		{
			var serviceName = ApmServiceName?.Render(logEventInfo);
			if (string.IsNullOrEmpty(serviceName)) return null;

			var serviceNodeName = ApmServiceNodeName?.Render(logEventInfo);
			var serviceVersion = ApmServiceVersion?.Render(logEventInfo);
			return new Service { Name = serviceName, Version = serviceVersion, NodeName = serviceNodeName };
		}

		/// <summary>
		/// Override to supplement the ECS event parsing
		/// </summary>
		/// <param name="logEvent">The original log event</param>
		/// <param name="ecsEvent">The EcsEvent to modify</param>
		/// <returns>Enriched ECS Event</returns>
		/// <remarks>Destructive for performance</remarks>
		protected virtual void EnrichEvent(LogEventInfo logEvent, ref EcsDocument ecsEvent)
		{
		}

		protected override string GetFormattedMessage(LogEventInfo logEvent)
		{
			var sb = new StringBuilder();
			RenderFormattedMessage(logEvent, sb);
			return sb.ToString();
		}

		private static Error GetError(Exception exception) =>
			exception != null
				? new Error
				{
					Message = exception.Message,
					StackTrace = CatchError(exception),
					Type = exception.GetType().ToString(),
				}
				: null;

		private static string CatchError(Exception error)
		{
			if (error == null)
				return string.Empty;

			var i = 1;
			var fullText = new StringWriter();
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

			return fullText.ToString();
		}

		private IDictionary<string, object> GetMetadata(LogEventInfo e)
		{
			if ((!IncludeEventProperties || !e.HasProperties) && Metadata?.Count == 0 && !IncludeScopeProperties)
				return null;

			var metadata = new Dictionary<string, object>();

			if (IncludeEventProperties && e.HasProperties)
			{
				foreach (var prop in e.Properties)
				{
					var propertyName = prop.Key?.ToString();
					if (string.IsNullOrEmpty(propertyName) || ExcludeProperties.Contains(propertyName))
						continue;

					Populate(metadata, propertyName, prop.Value);
				}
			}

			if (IncludeScopeProperties)
			{
				foreach (var key in MappedDiagnosticsLogicalContext.GetNames())
				{
					if (string.IsNullOrEmpty(key) || ExcludeProperties.Contains(key))
						continue;

					var propertyValue = MappedDiagnosticsLogicalContext.GetObject(key);
					Populate(metadata, key, propertyValue);
				}
			}

			if (Metadata?.Count > 0)
			{
				foreach (var targetPropertyWithContext in Metadata)
				{
					var value = targetPropertyWithContext.Layout?.Render(e);
					if (targetPropertyWithContext.IncludeEmptyValue || !string.IsNullOrEmpty(value))
						Populate(metadata, targetPropertyWithContext.Name, value);
				}
			}

			return metadata.Count > 0
				? metadata
				: null;
		}

		private Log GetLog(LogEventInfo logEventInfo)
		{
			var logOriginMethod = LogOriginCallSiteMethod?.Render(logEventInfo);
			var logOriginSourceFile = LogOriginCallSiteFile?.Render(logEventInfo);
			var logOriginSourceLine = LogOriginCallSiteLine?.Render(logEventInfo);
			var logOriginSourceLineNo = ParseLogOriginCallSiteLineNo(logOriginSourceLine);

			var log = new Log
			{
				Level = logEventInfo.Level.ToString(),
				Logger = logEventInfo.LoggerName,
				OriginFunction = logOriginMethod,
				OriginFileName = logOriginSourceFile,
				OriginFileLine = logOriginSourceLineNo
			};

			return log;
		}

		private int? ParseLogOriginCallSiteLineNo(string logOriginSourceLine)
		{
			if (string.IsNullOrEmpty(logOriginSourceLine))
				return null;

			if (int.TryParse(logOriginSourceLine, out var logOriginSourceLineNo))
				return logOriginSourceLineNo;

			return 0;
		}

		private string[] GetTags(LogEventInfo e)
		{
			if (Tags is null || Tags.Count == 0)
				return null;

			if (Tags.Count == 1)
			{
				var tag = Tags[0].Layout.Render(e);
				return GetTagsSplit(tag);
			}

			var tags = new List<string>(Tags.Count);
			foreach (var targetPropertyWithContext in Tags)
			{
				var tag = targetPropertyWithContext.Layout.Render(e);
				tags.AddRange(GetTagsSplit(tag));
			}
			return tags.ToArray();
		}

		private static string[] GetTagsSplit(string tags) =>
			string.IsNullOrEmpty(tags)
				? Array.Empty<string>()
				: tags.Split(new[] { ';', ',', ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

		private Labels GetLabels(LogEventInfo e)
		{
			if (Labels?.Count == 0)
				return null;

			var labels = new Labels();
			for (var i = 0; i < Labels?.Count; ++i)
			{
				var value = Labels[i].Layout?.Render(e);
				if (!string.IsNullOrEmpty(value) || Labels[i].IncludeEmptyValue)
					Populate(labels, Labels[i].Name, value);
			}
			return labels.Count > 0
				? labels
				: null;
		}

		private Event GetEvent(LogEventInfo logEventInfo)
		{
			var eventCategory = EventCategory?.Render(logEventInfo);
			var eventSeverity = EventSeverity?.Render(logEventInfo);
			var eventDurationMs = EventDurationMs?.Render(logEventInfo);

			var evnt = new Event
			{
				Created = logEventInfo.TimeStamp,
				Category = !string.IsNullOrEmpty(eventCategory) ? new[] { eventCategory } : null,
				Action = EventAction?.Render(logEventInfo),
				Id = EventId?.Render(logEventInfo),
				Kind = EventKind?.Render(logEventInfo),
				Severity = !string.IsNullOrEmpty(eventSeverity)
					? long.Parse(eventSeverity)
					: GetSysLogSeverity(logEventInfo.Level),
				Timezone = TimeZoneInfo.Local.StandardName
			};

			if (!string.IsNullOrEmpty(eventDurationMs) && double.TryParse(eventDurationMs, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var durationMs))
			{
				evnt.Duration = (long)(durationMs * 1000000.0);   // milliseconds to nanoseconds
			}

			return evnt;
		}

		private Agent GetAgent(LogEventInfo logEventInfo)
		{
			var agentId = AgentId?.Render(logEventInfo);
			var agentName = AgentName?.Render(logEventInfo);
			var agentType = AgentType?.Render(logEventInfo);
			var agentVersion = AgentVersion?.Render(logEventInfo);

			if (string.IsNullOrEmpty(agentId)
				&& string.IsNullOrEmpty(agentName)
				&& string.IsNullOrEmpty(agentType)
				&& string.IsNullOrEmpty(agentVersion))
				return null;

			var agent = new Agent
			{
				Id = agentId,
				Name = agentName,
				Type = agentType,
				Version = agentVersion
			};

			return agent;
		}

		private Process GetProcess(LogEventInfo logEventInfo)
		{
			var processId = ProcessId?.Render(logEventInfo);
			var processName = ProcessName?.Render(logEventInfo);
			var processTitle = ProcessTitle?.Render(logEventInfo);
			var processExecutable = ProcessExecutable?.Render(logEventInfo);
			var processThreadId = ProcessThreadId?.Render(logEventInfo);

			if (string.IsNullOrEmpty(processId)
				&& string.IsNullOrEmpty(processName)
				&& string.IsNullOrEmpty(processTitle)
				&& string.IsNullOrEmpty(processExecutable)
				&& string.IsNullOrEmpty(processThreadId))
				return null;

			return new Process
			{
				Title = processTitle,
				Name = processName,
				Pid = !string.IsNullOrEmpty(processId) ? long.Parse(processId) : 0,
				Executable = processExecutable,
				ThreadId = !string.IsNullOrEmpty(processThreadId) ? long.Parse(processThreadId) : null
			};
		}

		private Server GetServer(LogEventInfo logEventInfo)
		{
			var serverUser = ServerUser?.Render(logEventInfo);
			var serverAddress = ServerAddress?.Render(logEventInfo);
			var serverIp = ServerIp?.Render(logEventInfo);
			if (string.IsNullOrEmpty(serverUser) && string.IsNullOrEmpty(serverAddress) && string.IsNullOrEmpty(serverIp))
				return null;

			return new Server
			{
				User = !string.IsNullOrEmpty(serverUser)
					? new User { Name = serverUser }
					: null,
				Address = serverAddress,
				Ip = serverIp
			};
		}

		private string GetTrace(LogEventInfo logEventInfo)
		{
			var traceId = ApmTraceId?.Render(logEventInfo);
			return string.IsNullOrEmpty(traceId) ? null : traceId;
		}

		private string GetTransaction(LogEventInfo logEventInfo)
		{
			var transactionId = ApmTransactionId?.Render(logEventInfo);
			return string.IsNullOrEmpty(transactionId) ? null : transactionId;
		}

		private string GetSpan(LogEventInfo logEventInfo)
		{
			var spanId = ApmSpanId?.Render(logEventInfo);
			return string.IsNullOrEmpty(spanId) ? null : spanId;
		}

		private Http GetHttp(LogEventInfo logEventInfo)
		{
			var requestId = HttpRequestId?.Render(logEventInfo);
			var requestMethod = HttpRequestMethod?.Render(logEventInfo);
			if (string.IsNullOrEmpty(requestMethod) && string.IsNullOrEmpty(requestId))
				return null;

			var http = new Http()
			{
				RequestId = requestId,
				RequestMethod = requestMethod,
			};

			var requestReferrer = HttpRequestReferrer?.Render(logEventInfo);
			if (!string.IsNullOrEmpty(requestReferrer))
			{
				http.RequestReferrer = requestReferrer;
			}

			var requestBytes = RequestBodyBytes?.Render(logEventInfo);
			if (!string.IsNullOrEmpty(requestBytes) && long.TryParse(requestBytes, out var requestSize) && requestSize > 0)
			{
				http.RequestBodyBytes = requestSize;
			}

			var responseStatusCode = HttpResponseStatusCode?.Render(logEventInfo);
			if (!string.IsNullOrEmpty(responseStatusCode) && long.TryParse(responseStatusCode, out var statusCode) && statusCode > 0)
			{
				http.ResponseStatusCode = statusCode;
			}

			return http;
		}

		private Url GetUrl(LogEventInfo logEventInfo)
		{
			var urlScheme = UrlScheme?.Render(logEventInfo);
			var urlPath = UrlPath?.Render(logEventInfo);
			var urlQuery = UrlQuery?.Render(logEventInfo);
			if (string.IsNullOrEmpty(urlScheme) && string.IsNullOrEmpty(urlPath) && string.IsNullOrEmpty(urlQuery))
				return null;

			var urlDomain = UrlDomain?.Render(logEventInfo);
			var urlUserName = UrlUserName?.Render(logEventInfo);
			var urlPort = UrlPort?.Render(logEventInfo);

			var url = new Url()
			{
				Scheme = urlScheme,
				Domain = urlDomain,
				Path = urlPath,
				Query = urlQuery,
				Username = urlUserName,
			};

			if (!string.IsNullOrEmpty(urlPort) && long.TryParse(urlPort, out var portNumber) && portNumber > 0)
			{
				url.Port = portNumber;
			}

			return url;
		}

		private Host GetHost(LogEventInfo logEventInfo)
		{
			var hostId = HostId?.Render(logEventInfo);
			var hostName = HostName?.Render(logEventInfo);
			var hostIp = HostIp?.Render(logEventInfo);

			if (string.IsNullOrEmpty(hostId)
				&& string.IsNullOrEmpty(hostName)
				&& string.IsNullOrEmpty(hostIp))
				return null;

			var host = new Host
			{
				Id = hostId,
				Name = hostName,
				Ip = string.IsNullOrEmpty(hostIp) ? null : new[] { hostIp }
			};

			return host;
		}

		private static long GetSysLogSeverity(LogLevel logLevel)
		{
			if (logLevel == LogLevel.Trace || logLevel == LogLevel.Debug)
				return 7;

			if (logLevel == LogLevel.Info)
				return 6;

			if (logLevel == LogLevel.Warn)
				return 4;

			if (logLevel == LogLevel.Error)
				return 3;

			return 2; // LogLevel.Fatal
		}

		private static void Populate(IDictionary<string, object> propertyBag, string key, object value)
		{
			if (string.IsNullOrEmpty(key))
				return;

			var usedKey = key;
			var count = 0;
			while (propertyBag.ContainsKey(usedKey))
			{
				if (string.Equals(value?.ToString(), propertyBag[usedKey]?.ToString(), StringComparison.Ordinal))
					return;

				usedKey = $"{key}_{++count}";
			}

			propertyBag.Add(usedKey, value);
		}

		private static void Populate(IDictionary<string, string> propertyBag, string key, string value)
		{
			if (string.IsNullOrEmpty(key))
				return;

			var usedKey = key;
			var count = 0;
			while (propertyBag.ContainsKey(usedKey))
			{
				if (string.Equals(value, propertyBag[usedKey], StringComparison.Ordinal))
					return;

				usedKey = $"{key}_{++count}";
			}

			propertyBag.Add(usedKey, value);
		}
	}
}
