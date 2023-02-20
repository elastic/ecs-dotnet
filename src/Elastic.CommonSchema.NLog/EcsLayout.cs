// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Text;
using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;

namespace Elastic.CommonSchema.NLog
{
	internal class NlogEcsDocumentCreationOptions : IEcsDocumentCreationOptions
	{
		public static NlogEcsDocumentCreationOptions Default { get; } = new();
		public bool IncludeHost { get; set; } = false;
		public bool IncludeProcess { get; set; } = false;
		public bool IncludeUser { get; set; } = false;
	}

	/// <summary> An NLOG layout implementation that renders logs as ECS json</summary>
	[Layout(Name)]
	[ThreadSafe]
	[ThreadAgnostic]
	public class EcsLayout : Layout
	{
		/// <summary> An NLOG layout implementation that renders logs as ECS json</summary>
		public const string Name = nameof(EcsLayout);

		private static bool? _nlogApmLoaded;
		private static bool? _nlogWebLoaded;
		private static Agent _defaultAgent;

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

		/// <summary> An NLOG layout implementation that renders logs as ECS json</summary>
		public EcsLayout()
		{
			IncludeEventProperties = true;

			LogOriginCallSiteMethod = "${exception:format=method}";
			LogOriginCallSiteFile = "${exception:format=source}";

			ProcessId = "${processid}";
			ProcessName = "${processname:FullName=false}";
			ProcessExecutable = "${processname:FullName=true}";
			ProcessTitle = "${processinfo:MainWindowTitle:whenEmpty=${assembly-version:cached=true}}";
			ProcessThreadId = "${threadid}";

			HostName = "${hostname}";	// NLog 4.6
			HostIp = "${local-ip:cachedSeconds=60}"; // NLog 4.6.8

			ServerUser = "${environment-user}"; // NLog 4.6.4

			EventCode = "${event-properties:EventId}";
			_defaultAgent = EcsDocument.CreateAgent(typeof(EcsLayout));

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
					ApmTraceId = "${scopeproperty:item=RequestId:whenEmpty=${aspnet-TraceIdentifier}}}";
			}
		}

		/// <summary></summary>
		// ReSharper disable UnusedMember.Global
		[Obsolete("Replaced by IncludeEventProperties")]
		public bool IncludeAllProperties { get => IncludeEventProperties; set => IncludeEventProperties = value; }

		/// <summary></summary>
		[Obsolete("Replaced by IncludeScopeProperties")]
		public bool IncludeMdlc { get => IncludeScopeProperties; set => IncludeScopeProperties = value; }

		/// <summary>
		/// Allow dynamically disabling <see cref="ThreadAgnosticAttribute" /> to
		/// ensure correct async context capture when necessary
		/// </summary>
		public Layout DisableThreadAgnostic => IncludeScopeProperties ? _disableThreadAgnostic : null;
		// ReSharper restore UnusedMember.Global


		/// <summary></summary>
		public Layout AgentId { get; set; }
		/// <summary></summary>
		public Layout AgentName { get; set; }
		/// <summary></summary>
		public Layout AgentType { get; set; }
		/// <summary></summary>
		public Layout AgentVersion { get; set; }

		// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
		/// <summary></summary>
		public Layout ApmTraceId { get; set; }
		/// <summary></summary>
		public Layout ApmTransactionId { get; set; }
		/// <summary></summary>
		public Layout ApmSpanId { get; set; }

		/// <summary></summary>
		public Layout ApmServiceName { get; set; }
		/// <summary></summary>
		public Layout ApmServiceNodeName { get; set; }
		/// <summary></summary>
		public Layout ApmServiceVersion { get; set; }

		/// <summary></summary>
		public Layout LogOriginCallSiteMethod { get; set; }
		/// <summary></summary>
		public Layout LogOriginCallSiteFile { get; set; }
		/// <summary></summary>
		public Layout LogOriginCallSiteLine { get; set; }

		/// <summary></summary>
		public Layout EventAction { get; set; }
		/// <summary></summary>
		public Layout EventCategory { get; set; }
		/// <summary></summary>
		public Layout EventId { get; set; }
		/// <summary></summary>
		public Layout EventCode { get; set; }
		/// <summary></summary>
		public Layout EventKind { get; set; }
		/// <summary></summary>
		public Layout EventSeverity { get; set; }
		/// <summary></summary>
		public Layout EventDurationMs { get; set; }

		/// <summary></summary>
		public Layout HostId { get; set; }
		/// <summary></summary>
		public Layout HostIp { get; set; }
		/// <summary></summary>
		public Layout HostName { get; set; }

		/// <summary></summary>
		public bool IncludeEventProperties { get; set; }

		/// <summary></summary>
		public bool IncludeScopeProperties { get; set; }

		/// <summary></summary>
		[ArrayParameter(typeof(TargetPropertyWithContext), "label")]
		public IList<TargetPropertyWithContext> Labels { get; } = new List<TargetPropertyWithContext>();

		/// <summary></summary>
		[ArrayParameter(typeof(TargetPropertyWithContext), "metadata")]
		public IList<TargetPropertyWithContext> Metadata { get; } = new List<TargetPropertyWithContext>();

		/// <summary></summary>
		public Layout ProcessExecutable { get; set; }
		/// <summary></summary>
		public Layout ProcessId { get; set; }
		/// <summary></summary>
		public Layout ProcessName { get; set; }
		/// <summary></summary>
		public Layout ProcessThreadId { get; set; }
		/// <summary></summary>
		public Layout ProcessTitle { get; set; }

		/// <summary></summary>
		public Layout ServerAddress { get; set; }
		/// <summary></summary>
		public Layout ServerIp { get; set; }
		/// <summary></summary>
		public Layout ServerUser { get; set; }

		/// <summary></summary>
		public Layout HttpRequestId { get; set; }
		/// <summary></summary>
		public Layout HttpRequestMethod { get; set; }
		/// <summary></summary>
		public Layout RequestBodyBytes { get; set; }
		/// <summary></summary>
		public Layout HttpRequestReferrer { get; set; }
		/// <summary></summary>
		public Layout HttpResponseStatusCode { get; set; }

		/// <summary></summary>
		public Layout UrlScheme { get; set; }
		/// <summary></summary>
		public Layout UrlDomain { get; set; }
		/// <summary></summary>
		public Layout UrlPort { get; set; }
		/// <summary></summary>
		public Layout UrlPath { get; set; }
		/// <summary></summary>
		public Layout UrlQuery { get; set; }
		/// <summary></summary>
		public Layout UrlUserName { get; set; }

		/// <summary>
		/// Optional action to enrich the constructed <see cref="EcsDocument">EcsDocument</see> before it is serialized
		/// </summary>
		/// <remarks>This is called last in the chain of enrichment functions</remarks>
		public Action<EcsDocument,LogEventInfo> EnrichAction { get; set; }

		/// <summary></summary>
		[ArrayParameter(typeof(TargetPropertyWithContext), "tag")]
		public IList<TargetPropertyWithContext> Tags { get; } = new List<TargetPropertyWithContext>();

		/// <summary>
		/// List of property names to exclude from MetaData, when <see cref="IncludeEventProperties"/> is true
		/// </summary>
		public ISet<string> ExcludeProperties { get; set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

		// ReSharper restore AutoPropertyCanBeMadeGetOnly.Global

		/// <inheritdoc cref="Layout.RenderFormattedMessage"/>
		protected override void RenderFormattedMessage(LogEventInfo logEvent, StringBuilder target)
		{
			var ecsEvent = EcsDocument.CreateNewWithDefaults<EcsDocument>(logEvent.TimeStamp, logEvent.Exception, NlogEcsDocumentCreationOptions.Default);

			// prefer tracing information set by Elastic APM
			SetApmTraceId(ecsEvent, logEvent);
			SetApmTransactionId(ecsEvent, logEvent);
			SetApmSpanId(ecsEvent, logEvent);

			// prefer setting service information set by Elastic APM
			var service = GetService(logEvent);
			if (service != null) ecsEvent.Service = service;

			ecsEvent.Message = logEvent.FormattedMessage;
			ecsEvent.Log = GetLog(logEvent);
			ecsEvent.Event = GetEvent(logEvent);
			ecsEvent.Process = GetProcess(logEvent);
			ecsEvent.Tags = GetTags(logEvent);
			ecsEvent.Labels = GetLabels(logEvent);
			ecsEvent.Agent = GetAgent(logEvent) ?? _defaultAgent;
			ecsEvent.Server = GetServer(logEvent);
			ecsEvent.Host = GetHost(logEvent);
			ecsEvent.Http = GetHttp(logEvent);
			ecsEvent.Url = GetUrl(logEvent);

			var metadata = GetMetadata(logEvent) ?? new MetadataDictionary();
			foreach(var kv in metadata)
				ecsEvent.AssignField(kv.Key, kv.Value);

			//Give any deriving classes a chance to enrich the event
			EnrichEvent(logEvent, ref ecsEvent);
			//Allow programmatic actions to enrich before serializing
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
		// ReSharper disable UnusedParameter.Global
		protected virtual void EnrichEvent(LogEventInfo logEvent, ref EcsDocument ecsEvent)
		{
		}
		// ReSharper restore UnusedParameter.Global

		/// <inheritdoc cref="Layout.GetFormattedMessage"/>
		protected override string GetFormattedMessage(LogEventInfo logEvent)
		{
			var sb = new StringBuilder();
			RenderFormattedMessage(logEvent, sb);
			return sb.ToString();
		}

		private MetadataDictionary GetMetadata(LogEventInfo e)
		{
			if ((!IncludeEventProperties || !e.HasProperties) && Metadata?.Count == 0 && !IncludeScopeProperties)
				return null;

			var metadata = new MetadataDictionary();

			if (IncludeEventProperties && e.HasProperties)
			{
				global::NLog.MessageTemplates.MessageTemplateParameters templateParameters = null;

				foreach (var prop in e.Properties)
				{
					var propertyName = prop.Key?.ToString();
					if (string.IsNullOrEmpty(propertyName) || ExcludeProperties.Contains(propertyName))
						continue;

					var propertyValue = prop.Value;
					if (propertyValue is null or IConvertible || propertyValue.GetType().IsValueType)
						Populate(metadata, propertyName, propertyValue);
					else
					{
						templateParameters ??= e.MessageTemplateParameters;
						var value = AllowSerializePropertyValue(propertyName, templateParameters) ? propertyValue : propertyValue.ToString();
						Populate(metadata, propertyName, value);
					}
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

		private bool AllowSerializePropertyValue(string propertyName, global::NLog.MessageTemplates.MessageTemplateParameters templateParameters)
		{
			if (templateParameters.Count > 0 && !templateParameters.IsPositional)
			{
				// System.Text.Json is very fragile, and can only handle safe objects
				// Microsoft ASP.NET often uses message-templates for logging unsafe objects
				foreach (var messageProperty in templateParameters)
				{
					if (propertyName == messageProperty.Name)
						return messageProperty.CaptureType == global::NLog.MessageTemplates.CaptureType.Serialize;
				}
			}

			return true;	// Not from Message-Template, then probably safe
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
			var eventCode = EventCode?.Render(logEventInfo);
			if (string.IsNullOrEmpty(eventCode) || eventCode == "0")
				eventCode = null;

			var evnt = new Event
			{
				Created = logEventInfo.TimeStamp,
				Category = !string.IsNullOrEmpty(eventCategory) ? new[] { eventCategory } : null,
				Action = EventAction?.Render(logEventInfo),
				Id = EventId?.Render(logEventInfo),
				Code = eventCode,
				Kind = EventKind?.Render(logEventInfo),
				Severity = !string.IsNullOrEmpty(eventSeverity)
					? long.Parse(eventSeverity)
					: GetSysLogSeverity(logEventInfo.Level),
				Timezone = TimeZoneInfo.Local.StandardName
			};

			if (!string.IsNullOrEmpty(eventDurationMs) && double.TryParse(eventDurationMs, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var durationMs))
				evnt.Duration = (long)(durationMs * 1000000.0);   // milliseconds to nanoseconds

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

		private void SetApmTraceId(EcsDocument ecsDocument, LogEventInfo logEventInfo)
		{
			var traceId = ApmTraceId?.Render(logEventInfo);
			if (!string.IsNullOrEmpty(traceId)) ecsDocument.TraceId = traceId;
		}

		private void SetApmTransactionId(EcsDocument ecsDocument, LogEventInfo logEventInfo)
		{
			var transactionId = ApmTransactionId?.Render(logEventInfo);
			if (!string.IsNullOrEmpty(transactionId)) ecsDocument.TransactionId = transactionId;
		}

		private void SetApmSpanId(EcsDocument ecsDocument, LogEventInfo logEventInfo)
		{
			var spanId = ApmSpanId?.Render(logEventInfo);
			if (!string.IsNullOrEmpty(spanId)) ecsDocument.SpanId = spanId;
		}

		private Http GetHttp(LogEventInfo logEventInfo)
		{
			var requestId = HttpRequestId?.Render(logEventInfo);
			var requestMethod = HttpRequestMethod?.Render(logEventInfo);
			if (string.IsNullOrEmpty(requestMethod) && string.IsNullOrEmpty(requestId))
				return null;

			var http = new Http
			{
				RequestId = requestId,
				RequestMethod = requestMethod
			};

			var requestReferrer = HttpRequestReferrer?.Render(logEventInfo);
			if (!string.IsNullOrEmpty(requestReferrer))
				http.RequestReferrer = requestReferrer;

			var requestBytes = RequestBodyBytes?.Render(logEventInfo);
			if (!string.IsNullOrEmpty(requestBytes) && long.TryParse(requestBytes, out var requestSize) && requestSize > 0)
				http.RequestBodyBytes = requestSize;

			var responseStatusCode = HttpResponseStatusCode?.Render(logEventInfo);
			if (!string.IsNullOrEmpty(responseStatusCode) && long.TryParse(responseStatusCode, out var statusCode) && statusCode > 0)
				http.ResponseStatusCode = statusCode;

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

			var url = new Url
			{
				Scheme = urlScheme,
				Domain = urlDomain,
				Path = urlPath,
				Query = string.IsNullOrEmpty(urlQuery) ? null : urlQuery,
				Username = string.IsNullOrEmpty(urlUserName) ? null : urlUserName
			};

			if (!string.IsNullOrEmpty(urlPort) && long.TryParse(urlPort, out var portNumber) && portNumber > 0)
				url.Port = portNumber;

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
				Id = string.IsNullOrEmpty(hostId) ? null : hostId,
				Name = string.IsNullOrEmpty(hostName) ? null : hostName,
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
