// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using Serilog.Events;

namespace Elastic.CommonSchema.Serilog
{
	/// <summary>
	/// Elastic Common Schema converter for LogEvent
	/// </summary>
	public static class LogEventConverter
	{
		private static Agent DefaultAgent { get; } = EcsDocument.CreateAgent(typeof(LogEventConverter));

		/// <summary>
		/// Converts a <see cref="LogEvent"/> to an <typeparamref name="TEcsDocument"/>
		/// </summary>
		public static TEcsDocument ConvertToEcs<TEcsDocument>(LogEvent logEvent, IEcsTextFormatterConfiguration<TEcsDocument> configuration)
			where TEcsDocument : EcsDocument, new()
		{
			var ecsEvent = EcsDocument.CreateNewWithDefaults<TEcsDocument>(logEvent.Timestamp, logEvent.Exception, configuration);

			if (logEvent.TryGetScalarPropertyValue(SpecialKeys.MachineName, out var machineName))
			{
				ecsEvent.Host ??= new Host();
				ecsEvent.Host.Name = machineName.Value.ToString();
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

			ecsEvent.Message = logEvent.RenderMessage();
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

		private static Service GetService(LogEvent logEvent)
		{
			if (!logEvent.TryGetScalarPropertyValue("ElasticApmServiceName", out var serviceName))
				return null;

			return new Service
			{
				Name = serviceName.Value.ToString(),
				Version = logEvent.TryGetScalarPropertyValue("ElasticApmServiceVersion", out var version) ? version.Value.ToString() : null,
				NodeName = logEvent.TryGetScalarPropertyValue("ElasticApmServiceNodeName", out var name) ? name.Value.ToString() : null
			};
		}

		private static bool TryGetTrace(LogEvent logEvent, out string traceId)
		{
			traceId = logEvent.TryGetScalarPropertyValue("ElasticApmTraceId", out var prop) ? prop.Value.ToString() : null;
			return !string.IsNullOrWhiteSpace(traceId);
		}

		private static bool TryGetTransaction(LogEvent logEvent, out string transactionId)
		{
			transactionId = logEvent.TryGetScalarPropertyValue("ElasticApmTransactionId", out var prop) ? prop.Value.ToString() : null;
			return !string.IsNullOrWhiteSpace(transactionId);
		}

		private static bool TryGetSpan(LogEvent logEvent, out string spanId)
		{
			spanId = logEvent.TryGetScalarPropertyValue("ElasticApmSpanId", out var prop) ? prop.Value.ToString() : null;
			return !string.IsNullOrWhiteSpace(spanId);
		}

		private static MetadataDictionary GetMetadata(LogEvent logEvent, ISet<string> logEventPropertiesToFilter)
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

			return dict.Count == 0 ? new MetadataDictionary() : dict;
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
			switch (propertyValue)
			{
				case SequenceValue values:
					return values.Elements.Select(PropertyValueToObject).ToArray();
				case ScalarValue sv:
					return sv.Value;
				case DictionaryValue dv:
					return dv.Elements.ToDictionary(keySelector: kvp => kvp.Key.Value.ToString(),
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

		private static Process GetProcessFromProperties(LogEvent e)
		{
			e.TryGetScalarPropertyValue(SpecialKeys.ProcessName, out var processNameProp);
			e.TryGetScalarPropertyValue(SpecialKeys.ProcessId, out var processIdProp);
			e.TryGetScalarPropertyValue(SpecialKeys.ThreadId, out var threadIdProp);
			if (processNameProp == null && processIdProp == null && threadIdProp == null)
				return null;

			var processName = processNameProp?.Value.ToString();
			var processId = processIdProp?.Value.ToString();
			var threadId = threadIdProp?.Value.ToString();
			var pid = int.TryParse(processId ?? "", out var p)
				? p
				: (int?)null;
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
			var source = e.TryGetScalarPropertyValue(SpecialKeys.SourceContext, out var context)
				? context.Value.ToString()
				: SpecialKeys.DefaultLogger;

			var log = new Log { Level = e.Level.ToString("F"), Logger = source };

			return log;
		}

		private static Event GetEvent(LogEvent e)
		{
			var elapsedMs = e.TryGetScalarPropertyValue(SpecialKeys.Elapsed, out var elapsed)
				? elapsed.Value
				: e.TryGetScalarPropertyValue(SpecialKeys.ElapsedMilliseconds, out elapsed)
					? elapsed.Value
					: null;

			var evnt = new Event
			{
				Created = e.Timestamp,
				Category = e.TryGetScalarPropertyValue(SpecialKeys.ActionCategory, out var actionCategoryProperty)
					? new[] { actionCategoryProperty.Value.ToString() }
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


		private static Http GetHttp(LogEvent e, IEcsTextFormatterConfiguration configuration)
		{
			if (e.TryGetScalarPropertyValue(SpecialKeys.HttpContext, out var httpContext)
			    && httpContext?.Value is HttpContextEnricher.HttpContextEnrichments enriched)
				return enriched.Http;

			var http = configuration.MapHttpAdapter?.Http;

			if ((e.TryGetScalarPropertyValue(SpecialKeys.Method, out var method) || e.TryGetScalarPropertyValue(SpecialKeys.RequestMethod, out method)) && method != null)
			{
				http ??= new Http();
				http.RequestMethod = method.Value?.ToString();
			}

			if (e.TryGetScalarPropertyValue(SpecialKeys.RequestId, out var requestId) && requestId != null)
			{
				http ??= new Http();
				http.RequestId = requestId.Value?.ToString();
			}

			if (e.TryGetScalarPropertyValue(SpecialKeys.StatusCode, out var statusCode) && statusCode != null)
			{
				http ??= new Http();
				http.ResponseStatusCode = statusCode.Value is int s ? s : null;
			}
			if (e.TryGetScalarPropertyValue(SpecialKeys.ContentType, out var contentType) && contentType != null)
			{
				http ??= new Http();
				http.ResponseMimeType = contentType.Value?.ToString();
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
