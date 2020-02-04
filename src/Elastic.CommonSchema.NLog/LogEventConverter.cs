// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using NLog;

namespace Elastic.CommonSchema
{
	public class LogEventConverter
	{
		private static class SpecialKeys
		{
			public const string DefaultLogger = "Elastic.CommonSchema.NLog";
		}

		public static Base ConvertToEcs(LogEventInfo logEvent, EcsLayoutRenderer ecsLayoutRenderer)
		{
			var exceptions = logEvent.Exception != null
				? new List<Exception> { logEvent.Exception }
				: new List<Exception>();

			var ecsEvent = new Base
			{
				Timestamp = logEvent.TimeStamp,
				Message = logEvent.FormattedMessage,
				Ecs = new Ecs { Version = Base.Version },
				Log = GetLog(logEvent, exceptions),
				Agent = GetAgent(ecsLayoutRenderer),
				Event = GetEvent(logEvent),
				Metadata = GetMetadata(logEvent),
				Process = GetProcess(logEvent),
				Trace = GetTrace(logEvent),
				Transaction = GetTransaction(logEvent)
			};

			return ecsEvent;
		}

		private static Transaction GetTransaction(LogEventInfo logEvent) =>
			new Transaction { Id = "" }; //TODO! solve this

		private static Trace GetTrace(LogEventInfo logEvent) =>
			new Trace { Id = "" }; //TODO! solve this

		private static IDictionary<string, object> GetMetadata(LogEventInfo logEvent) =>
			logEvent.Properties.ToDictionary(pair => pair.Key.ToString(), pair => pair.Value);

		private static Event GetEvent(LogEventInfo e)
		{
			var evnt = new Event
			{
				Created = e.TimeStamp,
				Timezone = TimeZoneInfo.Local.StandardName
			};

			//Why does this get overriden in full framework?
#if FULLFRAMEWORK
			evnt.Timezone = TimeZone.CurrentTimeZone.StandardName;
#endif
			return evnt;
		}

		private static Agent GetAgent(EcsLayoutRenderer ecsLayoutRenderer)
		{
			if (ecsLayoutRenderer.ApplicationId == null
				&& ecsLayoutRenderer.ApplicationName == null
				&& ecsLayoutRenderer.ApplicationType == null
				&& ecsLayoutRenderer.ApplicationVersion == null)
				return null;

			return new Agent
			{
				Id = ecsLayoutRenderer.ApplicationId,
				Name = ecsLayoutRenderer.ApplicationName,
				Type = ecsLayoutRenderer.ApplicationType,
				Version = ecsLayoutRenderer.ApplicationVersion,
			};
		}

		private static Log GetLog(LogEventInfo e, IReadOnlyList<Exception> exceptions)
		{
			var log = new Log
			{
				Level = e.Level.ToString(),
				Logger = SpecialKeys.DefaultLogger,
				Original = e.Message
			};

			return log;
		}

		private static Process GetProcess(LogEventInfo e)
		{
			var currentThread = Thread.CurrentThread;
			var process = System.Diagnostics.Process.GetCurrentProcess();

			return new Process
			{
				Title = string.IsNullOrEmpty(process?.MainWindowTitle) ? null : process?.MainWindowTitle,
				Name = process?.ProcessName,
				Pid = process?.Id,
				Executable = process?.ProcessName,
				Thread = new ProcessThread { Id = currentThread.ManagedThreadId }
			};
		}
	}
}
