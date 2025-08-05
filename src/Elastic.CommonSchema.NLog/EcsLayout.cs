// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using Elastic.CommonSchema.Serialization;
using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;

namespace Elastic.CommonSchema.NLog
{
	/// <summary> An NLOG layout implementation that renders logs as ECS json</summary>
	[Layout(Name)]
	[ThreadSafe]
	[ThreadAgnostic]
	public partial class EcsLayout : Layout
	{
		/// <summary> An NLOG layout implementation that renders logs as ECS json</summary>
		public const string Name = nameof(EcsLayout);
		private static Agent _defaultAgent;
		private Agent _previousAgent;
		private Service _previousService;
		private Host _previousHost;
		private Server _previousServer;
		private Process _previousProcess;

		private readonly Layout _disableThreadAgnostic = "${threadid:cached=true}";

		/// <summary> An NLOG layout implementation that renders logs as ECS json</summary>
		public EcsLayout()
		{
			IncludeEventProperties = true;

			MessageTemplate = "${onhasproperties:${message:raw=true}}";

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
			EventAction = "${event-properties:EventName}";
			_defaultAgent = EcsDocument.CreateAgent(typeof(EcsLayout));

			// These values are set by the Elastic.Apm.NLog package
			if (NLogApmLoaded.Value)
			{
				ApmTraceId = "${ElasticApmTraceId}";
				ApmTransactionId = "${ElasticApmTransactionId}";
				ApmSpanId = "${ElasticApmSpanId}";

				ApmServiceName = "${ElasticApmServiceName}";
				ApmServiceNodeName = "${ElasticApmServiceNodeName}";
				ApmServiceVersion = "${ElasticApmServiceVersion}";
			}
		}

		/// <remarks>
		/// Initialize NLog.Web related layout renderers. Initialization is delayed
		/// to allow consumer to control it via <see cref="IncludeAspNetProperties"/>.
		/// </remarks>
		protected override void InitializeLayout()
		{
			if (CanIncludeAspNetProperties())
			{
				if (NLogWeb5Registered.Value)
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

				if (!NLogApmLoaded.Value)
					ApmTraceId = "${scopeproperty:item=RequestId:whenEmpty=${aspnet-TraceIdentifier}}";
			}

			base.InitializeLayout();
		}

		private static Lazy<bool> NLogApmLoaded { get; } = new Lazy<bool>(() => Type.GetType("Elastic.Apm.NLog.ApmTraceIdLayoutRenderer, Elastic.Apm.NLog") != null);

#if NETFRAMEWORK
		private static Lazy<bool> NLogWeb4Registered { get; } = new Lazy<bool>(() => Type.GetType("NLog.Web.LayoutRenderers.AspNetRequestCookieLayoutRenderer, NLog.Web") != null);
#else
		private static Lazy<bool> NLogWeb4Registered { get; } = new Lazy<bool>(() => Type.GetType("NLog.Web.LayoutRenderers.AspNetRequestCookieLayoutRenderer, NLog.Web.AspNetCore") != null);
#endif

#if NETFRAMEWORK
		private static Lazy<bool> NLogWeb5Registered { get; } = new Lazy<bool>(() => Type.GetType("NLog.Web.LayoutRenderers.AspNetRequestDurationLayoutRenderer, NLog.Web") != null);
#else
		private static Lazy<bool> NLogWeb5Registered { get; } = new Lazy<bool>(() => Type.GetType("NLog.Web.LayoutRenderers.AspNetRequestDurationLayoutRenderer, NLog.Web.AspNetCore") != null);
#endif

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

		/// <inheritdoc cref="AgentFieldSet.Id"/>
		public Layout AgentId { get; set; }
		/// <inheritdoc cref="AgentFieldSet.Name"/>
		public Layout AgentName { get; set; }
		/// <inheritdoc cref="AgentFieldSet.Type"/>
		public Layout AgentType { get; set; }
		/// <inheritdoc cref="AgentFieldSet.Version"/>
		public Layout AgentVersion { get; set; }

		// ReSharper disable AutoPropertyCanBeMadeGetOnly.Global
		/// <inheritdoc cref="BaseFieldSet.TraceId"/>
		public Layout ApmTraceId { get; set; } = FromMethod(_ => ResolveTraceId());
		/// <inheritdoc cref="BaseFieldSet.TransactionId"/>
		public Layout ApmTransactionId { get; set; }
		/// <inheritdoc cref="BaseFieldSet.SpanId"/>
		public Layout ApmSpanId { get; set; } = FromMethod(_ => ResolveSpanId());

		/// <inheritdoc cref="ServiceFieldSet.Name"/>
		public Layout ApmServiceName { get; set; }
		/// <inheritdoc cref="ServiceFieldSet.NodeName"/>
		public Layout ApmServiceNodeName { get; set; }
		/// <inheritdoc cref="ServiceFieldSet.Version"/>
		public Layout ApmServiceVersion { get; set; }
		/// <inheritdoc cref="ServiceFieldSet.Environment"/>
		public Layout ServiceEnvironment { get; set; }

		/// <inheritdoc cref="LogFieldSet.OriginFunction"/>
		public Layout LogOriginCallSiteMethod { get; set; }
		/// <inheritdoc cref="LogFieldSet.OriginFileName"/>
		public Layout LogOriginCallSiteFile { get; set; }
		/// <inheritdoc cref="LogFieldSet.OriginFileLine"/>
		public Layout LogOriginCallSiteLine { get; set; }

		/// <inheritdoc cref="EventFieldSet.Action"/>
		public Layout EventAction { get; set; }
		/// <inheritdoc cref="EventFieldSet.Category"/>
		public Layout EventCategory { get; set; }
		/// <inheritdoc cref="EventFieldSet.Id"/>
		public Layout EventId { get; set; }
		/// <inheritdoc cref="EventFieldSet.Code"/>
		public Layout EventCode { get; set; }
		/// <inheritdoc cref="EventFieldSet.Kind"/>
		public Layout EventKind { get; set; }
		/// <inheritdoc cref="EventFieldSet.Severity"/>
		public Layout EventSeverity { get; set; }
		/// <inheritdoc cref="EventFieldSet.Duration"/>
		public Layout EventDurationMs { get; set; }

		/// <inheritdoc cref="HostFieldSet.Id"/>
		public Layout HostId { get; set; }
		/// <inheritdoc cref="HostFieldSet.Ip"/>
		public Layout HostIp { get; set; }
		/// <inheritdoc cref="HostFieldSet.Hostname"/>
		public Layout HostName { get; set; }

		/// <summary></summary>
		public bool IncludeEventProperties { get; set; }

		/// <summary></summary>
		public bool IncludeScopeProperties { get; set; }

		/// <summary>
		/// Set to false to disable rendering of aspnet properties.
		/// </summary>
		/// <remarks>
		/// Default value is true, and actual rendering of aspnet properties
		/// is not happening unless aspnet laout renderers are registered
		/// (for example by registering NLog.Web.AspNetCore extension).
		/// </remarks>
		/// <seealso cref="CanIncludeAspNetProperties"/>
		public bool IncludeAspNetProperties { get; set; } = true;

		/// <summary>
		/// Tests if aspnet properties would be rendered
		/// </summary>
		public bool CanIncludeAspNetProperties() => IncludeAspNetProperties && NLogWeb4Registered.Value;

		/// <summary></summary>
		[ArrayParameter(typeof(TargetPropertyWithContext), "label")]
		public IList<TargetPropertyWithContext> Labels { get; } = new List<TargetPropertyWithContext>();

		/// <summary></summary>
		[ArrayParameter(typeof(TargetPropertyWithContext), "metadata")]
		public IList<TargetPropertyWithContext> Metadata { get; } = new List<TargetPropertyWithContext>();

		/// <summary></summary>
		public Layout MessageTemplate { get; set; }
		/// <inheritdoc cref="ProcessFieldSet.Executable"/>
		public Layout ProcessExecutable { get; set; }
		/// <inheritdoc cref="ProcessFieldSet.Pid"/>
		public Layout ProcessId { get; set; }
		/// <inheritdoc cref="ProcessFieldSet.Name"/>
		public Layout ProcessName { get; set; }
		/// <inheritdoc cref="ProcessFieldSet.ThreadId"/>
		public Layout ProcessThreadId { get; set; }
		/// <inheritdoc cref="ProcessFieldSet.ThreadName"/>
		public Layout ProcessThreadName { get; set; }
		/// <inheritdoc cref="ProcessFieldSet.Title"/>
		public Layout ProcessTitle { get; set; }

		/// <inheritdoc cref="ServerFieldSet.Address"/>
		public Layout ServerAddress { get; set; }
		/// <inheritdoc cref="ServerFieldSet.Domain"/>
		public Layout ServerDomain { get; set; }
		/// <inheritdoc cref="ServerFieldSet.Ip"/>
		public Layout ServerIp { get; set; }
		/// <inheritdoc cref="UserFieldSet.Name"/>
		public Layout ServerUser { get; set; }

		/// <inheritdoc cref="HttpFieldSet.RequestId"/>
		public Layout HttpRequestId { get; set; }
		/// <inheritdoc cref="HttpFieldSet.RequestMethod"/>
		public Layout HttpRequestMethod { get; set; }
		/// <inheritdoc cref="HttpFieldSet.RequestBodyBytes"/>
		public Layout RequestBodyBytes { get; set; }
		/// <inheritdoc cref="HttpFieldSet.RequestReferrer"/>
		public Layout HttpRequestReferrer { get; set; }
		/// <inheritdoc cref="HttpFieldSet.ResponseStatusCode"/>
		public Layout HttpResponseStatusCode { get; set; }

		/// <inheritdoc cref="UrlFieldSet.Scheme"/>
		public Layout UrlScheme { get; set; }
		/// <inheritdoc cref="UrlFieldSet.Domain"/>
		public Layout UrlDomain { get; set; }
		/// <inheritdoc cref="UrlFieldSet.Port"/>
		public Layout UrlPort { get; set; }
		/// <inheritdoc cref="UrlFieldSet.Path"/>
		public Layout UrlPath { get; set; }
		/// <inheritdoc cref="UrlFieldSet.Query"/>
		public Layout UrlQuery { get; set; }
		/// <inheritdoc cref="UrlFieldSet.Username"/>
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
			var ecsDocument = RenderEcsDocument(logEvent);
			ecsDocument.Serialize(target);
		}

		/// <summary>
		/// Create an instance of <see cref="NLogEcsDocument"/> and enrich it with as many fields as possible.
		/// </summary>
		public NLogEcsDocument RenderEcsDocument(LogEventInfo logEvent)
		{
			var ecsEvent = EcsDocument.CreateNewWithDefaults<NLogEcsDocument>(logEvent.TimeStamp, logEvent.Exception, NlogEcsDocumentCreationOptions.Default);

			// prefer tracing information set by Elastic APM
			SetApmTraceId(ecsEvent, logEvent);
			SetApmTransactionId(ecsEvent, logEvent);
			SetApmSpanId(ecsEvent, logEvent);

			ecsEvent.Agent = GetAgent(logEvent, _defaultAgent);
			ecsEvent.Service = GetService(logEvent, ecsEvent.Service);
			ecsEvent.Host = GetHost(logEvent, ecsEvent.Host);
			ecsEvent.Server = GetServer(logEvent, ecsEvent.Server);

			ecsEvent.Message = logEvent.FormattedMessage;
			ecsEvent.Log = GetLog(logEvent);
			ecsEvent.Event = GetEvent(logEvent);
			ecsEvent.Process = GetProcess(logEvent);
			ecsEvent.Tags = GetTags(logEvent);
			ecsEvent.Labels = GetLabels(logEvent);
			ecsEvent.Http = GetHttp(logEvent);
			ecsEvent.Url = GetUrl(logEvent);

			var messageTemplate = MessageTemplate?.Render(logEvent);
			ecsEvent.MessageTemplate = !string.IsNullOrEmpty(messageTemplate) ? messageTemplate : null;

			var metadata = GetMetadata(logEvent);
			if (metadata?.Count > 0)
			{
				foreach (var kv in metadata)
					ecsEvent.AssignField(kv.Key, kv.Value);
			}

			//Give any deriving classes a chance to enrich the event
			EcsDocument ecsDocument = ecsEvent;
			EnrichEvent(logEvent, ref ecsDocument);
			//Allow programmatic actions to enrich before serializing
			EnrichAction?.Invoke(ecsDocument, logEvent);
			return ecsEvent;
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
					if (!TryPopulateWhenSafe(metadata, propertyName, propertyValue))
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
					if (!TryPopulateWhenSafe(metadata, key, propertyValue))
					{
						Populate(metadata, key, propertyValue.ToString());
					}
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
				OriginFunction = !string.IsNullOrEmpty(logOriginMethod) ? logOriginMethod : null,
				OriginFileName = !string.IsNullOrEmpty(logOriginSourceFile) ? logOriginSourceFile : null,
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
			if (Tags.Count == 0)
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

			return tags.Count > 0
				? tags.ToArray()
				: null;
		}

		private static string[] GetTagsSplit(string tags) =>
			string.IsNullOrEmpty(tags)
				? Array.Empty<string>()
				: tags.Split(new[] { ';', ',', ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

		private Labels GetLabels(LogEventInfo e)
		{
			if (Labels.Count == 0)
				return null;

			var labels = new Labels();
			for (var i = 0; i < Labels.Count; ++i)
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
			var eventAction = EventAction?.Render(logEventInfo);
			var eventKind = EventKind?.Render(logEventInfo);

			var evnt = new Event
			{
				Created = logEventInfo.TimeStamp,
				Category = !string.IsNullOrEmpty(eventCategory) ? new[] { eventCategory } : null,
				Action = !string.IsNullOrEmpty(eventAction) ? eventAction : null,
				Id = EventId?.Render(logEventInfo),
				Code = eventCode,
				Kind = !string.IsNullOrEmpty(eventKind) ? eventKind : null,
				Severity = !string.IsNullOrEmpty(eventSeverity)
					? long.Parse(eventSeverity)
					: GetSysLogSeverity(logEventInfo.Level),
				Timezone = TimeZoneInfo.Local.StandardName,
			};

			if (!string.IsNullOrEmpty(eventDurationMs) && double.TryParse(eventDurationMs, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out var durationMs))
				evnt.Duration = (long)(durationMs * 1000000.0);   // milliseconds to nanoseconds

			return evnt;
		}

		private Agent GetAgent(LogEventInfo logEventInfo, Agent defaultAgent)
		{
			var agentId = AgentId?.Render(logEventInfo);
			var agentName = AgentName?.Render(logEventInfo);
			var agentType = AgentType?.Render(logEventInfo);
			var agentVersion = AgentVersion?.Render(logEventInfo);

			var previousAgent = _previousAgent ?? defaultAgent;
			if ((string.IsNullOrEmpty(agentId) || agentId == previousAgent?.Id)
			  && (string.IsNullOrEmpty(agentName) || agentName == previousAgent?.Name)
			  && (string.IsNullOrEmpty(agentType) || agentType == previousAgent?.Type)
			  && (string.IsNullOrEmpty(agentVersion) || agentVersion == previousAgent?.Version))
				return previousAgent;

			var agent = new Agent
			{
				Id = string.IsNullOrEmpty(agentId) ? previousAgent?.Id : agentId,
				Name = string.IsNullOrEmpty(agentName) ? previousAgent?.Name : agentName,
				Type = string.IsNullOrEmpty(agentType) ? previousAgent?.Type : agentType,
				Version = string.IsNullOrEmpty(agentVersion) ? previousAgent?.Version : agentVersion,
			};
			_previousAgent = agent;
			return agent;
		}

		private Process GetProcess(LogEventInfo logEventInfo)
		{
			var processId = ProcessId?.Render(logEventInfo);
			var processName = ProcessName?.Render(logEventInfo);
			var processTitle = ProcessTitle?.Render(logEventInfo);
			var processExecutable = ProcessExecutable?.Render(logEventInfo);
			var processThreadId = ProcessThreadId?.Render(logEventInfo);
			var processThreadName = ProcessThreadName?.Render(logEventInfo);

			var previousProcess = _previousProcess;
			if (string.IsNullOrEmpty(processThreadId) && string.IsNullOrEmpty(processThreadName))
			{
				// Only attempt to reuse Process-object when not including Thread-details
				if ((string.IsNullOrEmpty(processTitle) || processTitle == previousProcess?.Title)
				  && (string.IsNullOrEmpty(processName) || processName == previousProcess?.Name)
				  && (string.IsNullOrEmpty(processId) || long.Parse(processId) == previousProcess?.Pid)
				  && (string.IsNullOrEmpty(processExecutable) || processExecutable == previousProcess?.Executable))
					return previousProcess;
			}

			var process = new Process
			{
				Title = string.IsNullOrEmpty(processTitle) ? previousProcess?.Title : processTitle,
				Name = string.IsNullOrEmpty(processName) ? previousProcess?.Name : processName,
				Executable = string.IsNullOrEmpty(processExecutable) ? previousProcess?.Executable : processExecutable,
				Pid = string.IsNullOrEmpty(processId) ? previousProcess?.Pid : long.Parse(processId),
				ThreadId = string.IsNullOrEmpty(processThreadId) ? null : long.Parse(processThreadId),
				ThreadName = string.IsNullOrEmpty(processThreadName) ? null : processThreadName,
			};

			if (!process.ThreadId.HasValue && string.IsNullOrEmpty(process.ThreadName))
			{
				_previousProcess = process;
			}

			return process;
		}

		private Server GetServer(LogEventInfo logEventInfo, Server defaultServer)
		{
			var serverUser = ServerUser?.Render(logEventInfo);
			var serverAddress = ServerAddress?.Render(logEventInfo);
			var serverDomain = ServerDomain?.Render(logEventInfo);
			var serverIp = ServerIp?.Render(logEventInfo);

			var previousServer = _previousServer ?? defaultServer;
			if ((string.IsNullOrEmpty(serverUser) || serverUser == previousServer?.User?.Name)
			  && (string.IsNullOrEmpty(serverAddress) || serverAddress == previousServer?.Address)
			  && (string.IsNullOrEmpty(serverDomain) || serverDomain == previousServer?.Domain)
			  && (string.IsNullOrEmpty(serverIp) || serverIp == previousServer?.Ip))
				return previousServer;

			var server = new Server
			{
				User = string.IsNullOrEmpty(serverUser) ? previousServer?.User : new User() { Name = serverUser },
				Address = string.IsNullOrEmpty(serverAddress) ? previousServer?.Address : serverAddress,
				Domain = string.IsNullOrEmpty(serverDomain) ? previousServer?.Domain : serverDomain,
				Ip = string.IsNullOrEmpty(serverIp) ? previousServer?.Ip : serverIp,
			};
			_previousServer = server;
			return server;
		}

		private Service GetService(LogEventInfo logEventInfo, Service defaultService)
		{
			var serviceName = ApmServiceName?.Render(logEventInfo);
			if (string.IsNullOrEmpty(serviceName))
				return defaultService;

			var serviceNodeName = ApmServiceNodeName?.Render(logEventInfo);
			var serviceVersion = ApmServiceVersion?.Render(logEventInfo);
			var serviceEnvironment = ServiceEnvironment?.Render(logEventInfo);

			var previousService = _previousService ?? defaultService;
			if ( (string.IsNullOrEmpty(serviceName) || serviceName == previousService?.Name)
			  && (string.IsNullOrEmpty(serviceNodeName) || serviceNodeName == previousService?.NodeName)
			  && (string.IsNullOrEmpty(serviceVersion) || serviceVersion == previousService?.Version)
			  && (string.IsNullOrEmpty(serviceEnvironment) || serviceEnvironment == previousService?.Environment))
				return previousService;

			var service = new Service
			{
				Name = string.IsNullOrEmpty(serviceName) ? previousService?.Name : serviceName,
				NodeName = string.IsNullOrEmpty(serviceNodeName) ? previousService?.NodeName : serviceNodeName,
				Version = string.IsNullOrEmpty(serviceVersion) ? previousService?.Version : serviceVersion,
				Environment = string.IsNullOrEmpty(serviceEnvironment) ? previousService?.Environment : serviceEnvironment,
				Type = previousService?.Type,
			};
			_previousService = service;
			return service;
		}

		private Host GetHost(LogEventInfo logEventInfo, Host defaultHost)
		{
			var hostId = HostId?.Render(logEventInfo);
			var hostName = HostName?.Render(logEventInfo);
			var hostIp = HostIp?.Render(logEventInfo);

			var previousHost = _previousHost ?? defaultHost;
			if ((string.IsNullOrEmpty(hostId) || hostId == previousHost?.Id)
			  && (string.IsNullOrEmpty(hostName) || hostName == previousHost?.Hostname)
			  && (string.IsNullOrEmpty(hostIp) || (previousHost?.Ip?.Length == 1 && hostIp == previousHost.Ip[0])))
				return previousHost;

			var host = new Host
			{
				Id = string.IsNullOrEmpty(hostId) ? previousHost?.Id : hostId,
				Hostname = string.IsNullOrEmpty(hostName) ? previousHost?.Hostname : hostName,
				Ip = string.IsNullOrEmpty(hostIp) ? previousHost?.Ip : new[] { hostIp },
				Type = previousHost?.Type,
				Architecture = previousHost?.Architecture,
				Os = previousHost?.Os,
			};
			_previousHost = host;
			return host;
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

		private static bool TryPopulateWhenSafe(IDictionary<string, object> propertyBag, string key, object value)
		{
			if (value is null or IConvertible || value.GetType().IsValueType)
			{
				if (value is Enum)
					value = value.ToString();
				Populate(propertyBag, key, value);
				return true;
			}

			return false;
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

		private static string ResolveTraceId() => Activity.Current?.GetTraceId();

		private static string ResolveSpanId() => Activity.Current?.GetSpanId();

		/// <summary>
		/// A subclass of <see cref="EcsDocument"/> that adds additional properties related to Extensions logging.
		/// <para>For instance it adds scope information to each logged event</para>
		/// </summary>
		[JsonConverter(typeof(EcsDocumentJsonConverterFactory))]
		public class NLogEcsDocument : EcsDocument
		{
			// Custom fields; use capitalisation as per ECS
			private const string MessageTemplatePropertyName = nameof(MessageTemplate);

			/// <summary>
			/// Custom field with the original template used to generate the message, with token placeholders
			/// for inserted label values, e.g. "Unexpected error processing customer {CustomerId}."
			/// </summary>
			[JsonPropertyName(MessageTemplatePropertyName), DataMember(Name = MessageTemplatePropertyName)]
			public string MessageTemplate { get; set; }

			/// <summary>
			/// If <see cref="TryRead" /> returns <c>true</c> this will be called with the deserialized <paramref name="value" />
			/// </summary>
			/// <param name="propertyName">The additional property <see cref="EcsDocumentJsonConverter" /> encountered</param>
			/// <param name="value">
			/// The deserialized boxed value you will have to manually unbox to the type that
			/// <see cref="TryRead" /> set
			/// </param>
			/// <returns></returns>
			protected override bool ReceiveProperty(string propertyName, object value) =>
				propertyName switch
				{
					MessageTemplatePropertyName => null != (MessageTemplate = value as string),
					_ => false
				};

			/// <summary>
			/// If implemented in a subclass, this allows you to hook into <see cref="EcsDocumentJsonConverter" />
			/// and make it aware of properties on a subclass of <see cref="EcsDocument" />.
			/// If <paramref name="propertyName" /> is known, set <paramref name="type" /> to the correct type and return true.
			/// </summary>
			/// <param name="propertyName">The additional property that <see cref="EcsDocumentJsonConverter" /> encountered</param>
			/// <param name="type">Set this to the type you wish to deserialize to</param>
			/// <returns>Return true if <paramref name="propertyName" /> is handled</returns>
			protected override bool TryRead(string propertyName, out Type type)
			{
				type = propertyName switch
				{
					MessageTemplatePropertyName => typeof(string),
					_ => null
				};
				return type != null;
			}

			/// <summary>
			/// Write any additional properties in your subclass during <see cref="EcsDocumentJsonConverter" /> serialization.
			/// </summary>
			/// <param name="write">An action taking a <c>property name</c> and <c>boxed value</c> to write to the output</param>
			protected override void WriteAdditionalProperties(Action<string, object> write)
			{
				if (MessageTemplate != null)
					write(MessageTemplatePropertyName, MessageTemplate);
			}
		}
	}
}
