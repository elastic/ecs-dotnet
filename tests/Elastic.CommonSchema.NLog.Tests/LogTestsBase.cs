// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using Config=NLog.Config;
using NLog.Layouts;
using NLog.Targets;

namespace Elastic.CommonSchema.NLog.Tests
{
	public abstract class LogTestsBase
	{
		private class EventInfoMemoryTarget : TargetWithLayout
		{
			public readonly IList<LogEventInfo> Events = new List<LogEventInfo>();
			protected override void Write(LogEventInfo logEvent) => Events.Add(logEvent);
		}

		protected List<string> ToFormattedStrings(IEnumerable<LogEventInfo> logEvents) =>
			logEvents
				.Select(l => new EcsLayout().Render(l))
				.ToList();

		protected List<(string Json, Base Base)> ToEcsEvents(IEnumerable<LogEventInfo> logEvents) =>
			ToFormattedStrings(logEvents)
				.Select(s => (s, Base.Deserialize(s)))
				.ToList();

		protected static void TestLogger(Action<ILogger, Func<List<LogEventInfo>>> act)
		{
			Layout.Register<EcsLayout>("EcsLayout");
			var config = new Config.LoggingConfiguration();
			var memoryTarget = new EventInfoMemoryTarget { Layout = Layout.FromString("EcsLayout") };
			config.AddRule(LogLevel.Debug, LogLevel.Fatal, memoryTarget);
			var factory = new LogFactory(config);
			List<LogEventInfo> GetLogEvents() => memoryTarget.Events.ToList();
			var logger = factory.GetCurrentClassLogger();
			act(logger, GetLogEvents);
		}
	}
}
