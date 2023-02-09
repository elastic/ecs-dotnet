// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using log4net.Core;
using log4net.Util;

namespace Elastic.CommonSchema.Log4net;

internal static class LoggingEventConverter
{
	private static Agent DefaultAgent { get; } = EcsDocument.CreateAgent(typeof(LoggingEventConverter));

	public static EcsDocument ToEcs(this LoggingEvent logEvent)
	{
		var ecsEvent = EcsDocument.CreateNewWithDefaults<EcsDocument>(logEvent.TimeStamp, logEvent.ExceptionObject);
		ecsEvent.Agent = DefaultAgent;
		// Prefer logging provided name
		var hostName = logEvent.LookupProperty(LoggingEvent.HostNameProperty);
		if (hostName != null)
		{
			ecsEvent.Host ??= new Host();
			ecsEvent.Host.Name = hostName.ToString();
		}
		ecsEvent.Message = logEvent.RenderedMessage;
		ecsEvent.Log = GetLog(logEvent);
		ecsEvent.Event = GetEvent(logEvent);
		var metadata = GetMetadata(logEvent);
		if (metadata == null) return ecsEvent;

		foreach(var kv in metadata)
			ecsEvent.AssignField(kv.Key, kv.Value);
		return ecsEvent;
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
			log.OriginFileName = loggingEvent.LocationInformation.FileName;
		if (int.TryParse(loggingEvent.LocationInformation.LineNumber, out var ln) && ln > 0)
			log.OriginFileLine = ln;

		return log;
	}

	private static Event GetEvent(LoggingEvent loggingEvent) =>
		new()
		{
			Created = loggingEvent.TimeStamp,
			Timezone = TimeZoneInfo.Local.StandardName
		};

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
				value = tcs.ToString();
			else if (value is LogicalThreadContextStack ltcs)
				value = ltcs.ToString();

			if (value != null)
				metadata[property] = value;
		}

		if (loggingEvent.MessageObject is SystemStringFormat format)
		{
			metadata["MessageTemplate"] = format.Format;
			for (var i = 0; i < format.Args.Length; i++)
				metadata[i.ToString()] = format.Args[0];
		}

		return metadata.Count > 0 ? metadata : null;
	}
}
