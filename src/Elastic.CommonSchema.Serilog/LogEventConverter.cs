// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.Json.Serialization;
using Elastic.CommonSchema.Serialization;
using Serilog.Events;
using static Elastic.CommonSchema.Serilog.SpecialProperties;

namespace Elastic.CommonSchema.Serilog
{
	/// A specialized instance of <see cref="EcsDocument"/> that holds on to the original <see cref="LogEvent"/>
	/// <para> This property won't be emitted to JSON but is used to report back to serilog failure pipelines</para>
	[JsonConverter(typeof(EcsDocumentJsonConverterFactory))]
	public class LogEventEcsDocument : EcsDocument
	{
		/// The original <see cref="LogEvent"/> for bookkeeping, not send over to Elasticsearch
		[JsonIgnore]
		public LogEvent LogEvent { get; set; } = null!;
	}

	/// <summary>
	/// Elastic Common Schema converter for LogEvent
	/// </summary>
	public static class LogEventConverter
	{
		private static Agent DefaultAgent { get; } = EcsDocument.CreateAgent(typeof(LogEventConverter));

		/// <summary>
		/// Converts a <see cref="LogEvent"/> to an <typeparamref name="TEcsDocument"/>
		/// </summary>
		public static TEcsDocument ConvertToEcs<TEcsDocument>(LogEvent logEvent, IEcsTextFormatterConfiguration<TEcsDocument> configuration, EcsDocumentCreationCache? initialCache = null)
			where TEcsDocument : EcsDocument, new()
		{
			var ecsEvent = EcsDocument.CreateNewWithDefaults<TEcsDocument>(logEvent.Timestamp, logEvent.Exception, configuration, initialCache);

			if (logEvent.TryGetScalarString(SpecialKeys.MachineName, out var machineName))
			{
				ecsEvent.Host ??= new Host();
				ecsEvent.Host.Name = machineName;
			}

			// if we don't want to lookup up process through System.Diagnostics still include whatever information we get from
			// serilog
			if (!configuration.IncludeProcess)
				ecsEvent.Process = GetProcessFromProperties(logEvent);

			// prefer tracing information set by Elastic APM
			if (TryGetTrace(logEvent, out var traceId)) ecsEvent.TraceId = traceId;
			if (TryGetTransaction(logEvent, out var transactionId)) ecsEvent.TransactionId = transactionId;
			if (TryGetSpan(logEvent, out var spanId)) ecsEvent.SpanId = spanId;

			// prefer service information set by Elastic APM
			var service = GetService(logEvent);
			if (service != null) ecsEvent.Service = service;

			// prefer our own user information, especially in web contexts this is richer
			var user = GetUser(logEvent, configuration);
			if (user != null) ecsEvent.User = user;

			ecsEvent.Message = logEvent.RenderMessage(configuration.MessageFormatProvider);
			ecsEvent.Log = GetLog(logEvent);
			ecsEvent.Agent = GetAgent(logEvent) ?? DefaultAgent;
			ecsEvent.Event = GetEvent(logEvent);
			ecsEvent.Server = GetServer(logEvent, configuration);
			ecsEvent.Http = GetHttp(logEvent, configuration);
			ecsEvent.Url = GetUrl(logEvent, configuration);
			ecsEvent.UserAgent = GetUserAgent(logEvent, configuration);
			ecsEvent.Client = GetClient(logEvent, configuration);

			var metaData = GetMetadata(logEvent, configuration.LogEventPropertiesToFilter);
			foreach (var kv in metaData)
				ecsEvent.AssignField(kv.Key, kv.Value);

			if (configuration.MapCustom != null)
				ecsEvent = configuration.MapCustom(ecsEvent, logEvent);

			return ecsEvent;
		}

		private static Service? GetService(LogEvent logEvent)
		{
			if (!logEvent.TryGetScalarString("ElasticApmServiceName", out var serviceName))
				return null;

			return new Service
			{
				Name = serviceName,
				Version = logEvent.TryGetScalarString("ElasticApmServiceVersion", out var version) ? version : null,
				NodeName = logEvent.TryGetScalarString("ElasticApmServiceNodeName", out var name) ? name : null
			};
		}

		private static bool TryGetTrace(LogEvent logEvent, [NotNullWhen(true)]out string? traceId)
		{
			traceId = logEvent.TryGetScalarString("ElasticApmTraceId", out var id) ? id : null;
			return !string.IsNullOrWhiteSpace(traceId);
		}

		private static bool TryGetTransaction(LogEvent logEvent, [NotNullWhen(true)]out string? transactionId)
		{
			transactionId = logEvent.TryGetScalarString("ElasticApmTransactionId", out var id) ? id : null;
			return !string.IsNullOrWhiteSpace(transactionId);
		}

		private static bool TryGetSpan(LogEvent logEvent, [NotNullWhen(true)]out string? spanId)
		{
			spanId = logEvent.TryGetScalarString("ElasticApmSpanId", out var id) ? id : null;
			return !string.IsNullOrWhiteSpace(spanId);
		}

		private static MetadataDictionary GetMetadata(LogEvent logEvent, ISet<string>? logEventPropertiesToFilter)
		{
			var dict = new MetadataDictionary { { "MessageTemplate", logEvent.MessageTemplate.Text } };

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

			return dict;
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
				case SpecialKeys.EventId:
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

		private static object? PropertyValueToObject(LogEventPropertyValue propertyValue)
		{
			switch (propertyValue)
			{
				case SequenceValue values:
					return values.Elements.Select((e) => PropertyValueToObject(e)).ToArray();
				case ScalarValue sv:
					return sv.Value;
				case DictionaryValue dv:
					return dv.Elements.ToDictionary(keySelector: kvp => kvp.Key?.Value?.ToString() ?? string.Empty,
						elementSelector: (kvp) => PropertyValueToObject(kvp.Value));
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

		private static Server? GetServer(LogEvent e, IEcsTextFormatterConfiguration configuration)
		{
			e.TryGetScalarString(SpecialKeys.EnvironmentUserName, out var environmentUserName);
			e.TryGetScalarString(SpecialKeys.Host, out var host);

			var server = configuration.MapHttpAdapter?.Server;
			if (server == null && environmentUserName == null && host == null)
				return null;

			server ??= new Server();
			server.User = environmentUserName != null
				? new User { Name = environmentUserName }
				: null;
			server.Address = host;

			return server;
		}

		private static Process? GetProcessFromProperties(LogEvent e)
		{
			e.TryGetScalarString(SpecialKeys.ProcessName, out var processName);
			e.TryGetScalarString(SpecialKeys.ProcessId, out var processId);
			e.TryGetScalarString(SpecialKeys.ThreadId, out var threadId);
			if (processName == null && processId == null && threadId== null)
				return null;

			var pid = int.TryParse(processId ?? "", out var p) ? p : (int?)null;
			return new Process
			{
				Title = string.IsNullOrEmpty(processName) ? null : processName,
				Name = processName,
				Pid = pid,
				ThreadId = int.TryParse(threadId ?? processId, out var id) ? id : null,
			};
		}

		private static Log GetLog(LogEvent e)
		{
			var source = e.TryGetScalarString(SpecialKeys.SourceContext, out var context)
				? context
				: SpecialKeys.DefaultLogger;

			var log = new Log { Level = e.Level.ToString("F"), Logger = source };

			return log;
		}

		private static Event GetEvent(LogEvent e)
		{
			var hasElapsedMs = e.TryGetScalarPropertyValue(SpecialKeys.Elapsed, out var elapsedMsObj)
				|| e.TryGetScalarPropertyValue(SpecialKeys.ElapsedMilliseconds, out elapsedMsObj);

			var elapsedMs = hasElapsedMs ? (double?)Convert.ToDouble(elapsedMsObj!.Value) : null;

			var evnt = new Event
			{
				Created = e.Timestamp,
				Category = e.TryGetScalarString(SpecialKeys.ActionCategory, out var actionCategory)
					? new[] { actionCategory }
					: null,
				Action = e.TryGetScalarString(SpecialKeys.ActionName, out var action)
					? action
					: null,
				Id = e.TryGetScalarString(SpecialKeys.ActionId, out var actionId)
					? actionId
					: null,
				Kind = e.TryGetScalarString(SpecialKeys.ActionKind, out var actionKind) ? actionKind : null,
				Severity = e.TryGetScalarString(SpecialKeys.ActionSeverity, out var actionSev)
					? long.Parse(actionSev)
					: (int)e.Level,
				Timezone = TimeZoneInfo.Local.StandardName,
				Duration = elapsedMs != null ? (long)(elapsedMs * 1000000) : null
			};

			if (e.Properties.TryGetValue(SpecialKeys.EventId, out var eventData) && eventData is StructureValue dv)
			{
				var idProp = dv.Properties.FirstOrDefault(p => p.Name == "Id");
				var eventId = idProp?.Value is ScalarValue i ? i.Value as int? : null;
				if (eventId != null)
					evnt.Code = eventId.ToString();

				var nameProp = dv.Properties.FirstOrDefault(p => p.Name == "Name");
				var eventAction = nameProp?.Value is ScalarValue n ? n.Value as string : null;
				if (eventAction != null)
					evnt.Action = eventAction;
			}

			return evnt;
		}

		private static Agent? GetAgent(LogEvent e)
		{
			Agent? agent = null;

			void Assign(string key, Action<Agent, string> assign)
			{
				if (!e.TryGetScalarString(key, out var v)) return;

				agent ??= new Agent();
				assign(agent, v);
			}

			Assign(SpecialKeys.ApplicationId, (a, v) => a.Id = v);
			Assign(SpecialKeys.ApplicationName, (a, v) => a.Name = v);
			Assign(SpecialKeys.ApplicationType, (a, v) => a.Type = v);
			Assign(SpecialKeys.ApplicationVersion, (a, v) => a.Version = v);
			return agent;
		}


		private static Http? GetHttp(LogEvent e, IEcsTextFormatterConfiguration configuration)
		{
			if (e.TryGetScalarPropertyValue(SpecialKeys.HttpContext, out var httpContext)
			    && httpContext.Value is HttpContextEnrichments enriched)
				return enriched.Http;

			var http = configuration.MapHttpAdapter?.Http;

			if (e.TryGetScalarString(SpecialKeys.Method, out var method) || e.TryGetScalarString(SpecialKeys.RequestMethod, out method))
			{
				http ??= new Http();
				http.RequestMethod = method;
			}

			if (e.TryGetScalarString(SpecialKeys.RequestId, out var requestId))
			{
				http ??= new Http();
				http.RequestId = requestId;
			}

			if (e.TryGetScalarPropertyValue(SpecialKeys.StatusCode, out var statusCode))
			{
				http ??= new Http();
				http.ResponseStatusCode = statusCode.Value is int s ? s : null;
			}
			if (e.TryGetScalarString(SpecialKeys.ContentType, out var contentType))
			{
				http ??= new Http();
				http.ResponseMimeType = contentType;
			}

			return http;
		}

		private static Url? GetUrl(LogEvent e, IEcsTextFormatterConfiguration configuration)
		{
			if (e.TryGetScalarPropertyValue(SpecialKeys.HttpContext, out var httpContext)
			    && httpContext.Value is HttpContextEnrichments enriched)
				return enriched.Url;

			var url = configuration.MapHttpAdapter?.Url;

			if (e.TryGetScalarString(SpecialKeys.Path, out var path) || e.TryGetScalarString(SpecialKeys.RequestPath, out path))
			{
				url ??= new Url();
				url.Path = path;
			}

			if (e.TryGetScalarString(SpecialKeys.Scheme, out var scheme))
			{
				url ??= new Url();
				url.Scheme = scheme;
			}

			if (e.TryGetScalarString(SpecialKeys.QueryString, out var queryString))
			{
				url ??= new Url();
				url.Query = string.IsNullOrEmpty(queryString) ? null : queryString.TrimStart('?');
			}

			return url;
		}

		private static UserAgent? GetUserAgent(LogEvent e, IEcsTextFormatterConfiguration configuration)
		{
			if (e.TryGetScalarPropertyValue(SpecialKeys.HttpContext, out var httpContext)
			    && httpContext.Value is HttpContextEnrichments enriched)
				return enriched.UserAgent;

			return configuration.MapHttpAdapter?.UserAgent;
		}

		private static User? GetUser(LogEvent e, IEcsTextFormatterConfiguration configuration)
		{
			if (e.TryGetScalarPropertyValue(SpecialKeys.HttpContext, out var httpContext)
			    && httpContext.Value is HttpContextEnrichments enriched)
				return enriched.User;

			return configuration.MapHttpAdapter?.User;
		}

		private static Client? GetClient(LogEvent e, IEcsTextFormatterConfiguration configuration)
		{
			if (e.TryGetScalarPropertyValue(SpecialKeys.HttpContext, out var httpContext)
			    && httpContext.Value is HttpContextEnrichments enriched)
				return enriched.Client;

			return configuration.MapHttpAdapter?.Client;
		}
	}
}
