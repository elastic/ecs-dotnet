// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Diagnostics;
using System.IO;
using log4net.Core;
using log4net.Util;

namespace Elastic.CommonSchema.Log4net;

internal static class LoggingEventConverter
{
	public static EcsDocument ToEcs(this LoggingEvent loggingEvent)
	{
		var ecsDocument = new EcsDocument()
		{
			Timestamp = loggingEvent.TimeStamp,
			Ecs = new Ecs { Version = EcsDocument.Version },
			Message = loggingEvent.RenderedMessage,
			Log = GetLog(loggingEvent),
			Event = GetEvent(loggingEvent),
			Error = GetError(loggingEvent),
			Process = GetProcess(loggingEvent),
			Host = GetHost(loggingEvent),
		};
		var metadata = GetMetadata(loggingEvent);
		if (metadata == null) return ecsDocument;

		foreach(var kv in metadata)
			ecsDocument.AssignField(kv.Key, kv.Value);
		return ecsDocument;
	}

	private static Log GetLog(LoggingEvent loggingEvent)
	{
		var log = new Log
		{
			Level = loggingEvent.Level.DisplayName,
			Logger = loggingEvent.LoggerName,
			OriginFunction = loggingEvent.LocationInformation.MethodName
		};

		if (!string.IsNullOrEmpty(loggingEvent.LocationInformation.FileName))
		{
			log.OriginFileName = loggingEvent.LocationInformation.FileName;
		}
		if (int.TryParse(loggingEvent.LocationInformation.LineNumber, out var ln) && ln > 0)
		{
			log.OriginFileLine = ln;
		}

		return log;
	}

	private static Event GetEvent(LoggingEvent loggingEvent) =>
		new()
		{
			Created = loggingEvent.TimeStamp,
			Timezone = TimeZoneInfo.Local.StandardName
		};

	private static Error GetError(LoggingEvent loggingEvent)
	{
		var exception = loggingEvent.ExceptionObject;
		if (exception == null)
		{
			return null;
		}

		return new Error
		{
			Message = exception.Message,
			Type = exception.GetType().FullName,
			StackTrace = GetStackTrace(exception)
		};
	}

	private static string GetStackTrace(Exception exception)
	{
		var i = 1;
		var fullText = new StringWriter();
		var frame = new StackTrace(exception, true).GetFrame(0);

		fullText.WriteLine($"Exception {i++:D2} ===================================");
		fullText.WriteLine($"Type: {exception.GetType()}");
		fullText.WriteLine($"Source: {exception.TargetSite?.DeclaringType?.AssemblyQualifiedName}");
		fullText.WriteLine($"Message: {exception.Message}");
		fullText.WriteLine($"Trace: {exception.StackTrace}");
		if (frame != null)
		{
			fullText.WriteLine($"Location: {frame.GetFileName()}");
			fullText.WriteLine($"Method: {frame.GetMethod()} ({frame.GetFileLineNumber()}, {frame.GetFileColumnNumber()})");
		}

		var innerException = exception.InnerException;
		while (innerException != null)
		{
			frame = new StackTrace(innerException, true).GetFrame(0);
			fullText.WriteLine($"\tException {i++:D2} inner --------------------------");
			fullText.WriteLine($"\tType: {innerException.GetType()}");
			fullText.WriteLine($"\tSource: {innerException.TargetSite?.DeclaringType?.AssemblyQualifiedName}");
			fullText.WriteLine($"\tMessage: {innerException.Message}");
			fullText.WriteLine($"\tTrace: {innerException.StackTrace}");
			if (frame != null)
			{
				fullText.WriteLine($"\tLocation: {frame.GetFileName()}");
				fullText.WriteLine($"\tMethod: {frame.GetMethod()} ({frame.GetFileLineNumber()}, {frame.GetFileColumnNumber()})");
			}

			innerException = innerException.InnerException;
		}

		return fullText.ToString();
	}

	private static Process GetProcess(LoggingEvent loggingEvent)
	{
		var threadName = loggingEvent.ThreadName;
		if (string.IsNullOrEmpty(threadName))
		{
			return null;
		}

		var isNumericThreadName = int.TryParse(threadName, out var id);
		return new Process
		{
			ThreadId = isNumericThreadName ? id : null,
			ThreadName = !isNumericThreadName ? threadName : null
		};
	}

	private static Host GetHost(LoggingEvent loggingEvent)
	{
		var hostName = loggingEvent.LookupProperty(LoggingEvent.HostNameProperty);
		return hostName != null ? new Host { Hostname = hostName.ToString() } : null;
	}

	private static MetadataDictionary GetMetadata(LoggingEvent loggingEvent)
	{
		var properties = loggingEvent.GetProperties();
		if (properties.Count == 0)
			return null;

		var metadata = new MetadataDictionary();

		foreach (var property in properties.GetKeys())
		{
			switch (property)
			{
				case LoggingEvent.HostNameProperty:
				case LoggingEvent.IdentityProperty:
				case LoggingEvent.UserNameProperty:
					continue;
			}

			var value = properties[property];

			// use string representation of stacks because:
			// - if stack is empty then null is returned
			// - if stack contains one item log4net anyway supports only string values
			// - if stack contains several items then we need all of them
			if (value is ThreadContextStack tcs)
			{
				value = tcs.ToString();
			}
			else if (value is LogicalThreadContextStack ltcs)
			{
				value = ltcs.ToString();
			}

			if (value != null)
			{
				metadata[property] = value;
			}
		}

		if (loggingEvent.MessageObject is SystemStringFormat format)
		{
			metadata["MessageTemplate"] = format.Format;
			for (var i = 0; i < format.Args.Length; i++)
			{
				metadata[i.ToString()] = format.Args[0];
			}
		}

		return metadata.Count > 0 ? metadata : null;
	}
}
