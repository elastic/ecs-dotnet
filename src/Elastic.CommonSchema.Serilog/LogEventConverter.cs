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
				Metadata = GetMetadata(logEvent)
			};

			//TODO investigate
			//Serilog sinks with default enrichments where do these end up?
			//logEvent.Properties

			if (configuration.MapCurrentThread)
			{
				var currentThread = Thread.CurrentThread;
				ecsEvent.Process = GetProcess(currentThread);
			}

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

			if (configuration.MapCustom != null) ecsEvent = configuration.MapCustom(ecsEvent);

			return ecsEvent;
		}

		private static IDictionary<string, object> GetMetadata(LogEvent logEvent)
		{
			var dict = new Dictionary<string, object>();

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
						dict.Add(item.Key, item.Value);
				}
			}

			foreach (var logEventPropertyValue in logEvent.Properties)
			{
				if (logEventPropertyValue.Value is SequenceValue values)
				{
					dict.Add(logEventPropertyValue.Key, values.Elements.Select(e => e.ToString()).ToArray());
					continue;
				}

				dict.Add(logEventPropertyValue.Key, logEventPropertyValue.Value.ToString());
			}

			return dict;
		}


		private static Server GetServer(LogEvent e, IEcsTextFormatterConfiguration configuration)
		{
			var server = configuration.MapHttpAdapter != null ? configuration.MapHttpAdapter.Server : new Server();
			server.User = e.Properties.TryGetValue("EnvironmentUserName", out var environmentUserName)
				? new User { Name = environmentUserName.ToString() }
				: null;

			var hasHost = e.Properties.TryGetValue("Host", out var host);
			server.Address = hasHost ? host.ToString() : null;
			server.Ip = hasHost ? host.ToString() : null;
			return server;
		}

		private static Process GetProcess(Thread currentThread)
		{
			if (currentThread == null)
				return null;

			return new Process
			{
				Title = currentThread.Name,
				Name = currentThread.Name,
				Executable = currentThread.ExecutionContext.GetType().ToString(),
				Thread = new ProcessThread { Id = currentThread.ManagedThreadId }
			};
		}

		private static Log GetLog(LogEvent e, IReadOnlyList<Exception> exceptions, IEcsTextFormatterConfiguration configuration)
		{
			var log = new Log { Level = e.Level.ToString("F"), Logger = "Elastic.CommonSchema.Serilog" };

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
			var evnt = new Event
			{
				Created = e.Timestamp,
				Category = e.Properties.ContainsKey("ActionCategory")
					? e.Properties["ActionCategory"].ToString()
					: null,
				Action = e.Properties.ContainsKey("ActionName")
					? e.Properties["ActionName"].ToString().Replace("\"", "")
					: null,
				Id = e.Properties.ContainsKey("ActionId")
					? e.Properties["ActionId"].ToString().Replace("\"", "")
					: null,
				Kind = e.Properties.ContainsKey("ActionKind")
					? e.Properties["ActionKind"].ToString().Replace("\"", "")
					: null,
				Severity = e.Properties.ContainsKey("ActionSeverity")
					? long.Parse(e.Properties["ActionSeverity"].ToString())
					: 0
			};

#if NETSTANDARD
            evnt.Timezone = TimeZoneInfo.Local.StandardName;
#else
			evnt.Timezone = TimeZone.CurrentTimeZone.StandardName;
#endif

			return evnt;
		}

		private static Agent GetAgent(LogEvent e) =>
			e.Properties.ContainsKey("ApplicationId")
			|| e.Properties.ContainsKey("ApplicationName")
			|| e.Properties.ContainsKey("ApplicationType")
			|| e.Properties.ContainsKey("ApplicationVersion")
				? new Agent
				{
					Id = e.Properties.ContainsKey("ApplicationId")
						? e.Properties["ApplicationId"].ToString()
						: null,
					Name = e.Properties.ContainsKey("ApplicationName")
						? e.Properties["ApplicationName"].ToString()
						: null,
					Type = e.Properties.ContainsKey("ApplicationType")
						? e.Properties["ApplicationType"].ToString()
						: null,
					Version = e.Properties.ContainsKey("ApplicationVersion")
						? e.Properties["ApplicationVersion"].ToString()
						: null
				}
				: null;

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
