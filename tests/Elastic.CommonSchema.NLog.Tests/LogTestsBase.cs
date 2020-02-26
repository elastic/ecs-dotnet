// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Elastic.Apm.NLog;
using NLog;
using NLog.LayoutRenderers;
using Config=NLog.Config;
using NLog.Layouts;
using NLog.Targets;

namespace Elastic.CommonSchema.NLog.Tests
{
	public abstract class LogTestsBase
	{
		private class EventInfoMemoryTarget : TargetWithContext
		{
			public readonly IList<LogEventInfo> Events = new List<LogEventInfo>();
			protected override void Write(LogEventInfo logEvent) => Events.Add(logEvent);
		}

		protected List<string> ToFormattedStrings(List<LogEventInfo> logEvents) =>
			logEvents
				.Select(l => new EcsLayout().Render(l))
				.ToList();

		protected List<(string Json, Base Base)> ToEcsEvents(List<LogEventInfo> logEvents) =>
			ToFormattedStrings(logEvents)
				.Select(s => (s, Base.Deserialize(s)))
				.ToList();

		protected static void TestLogger(Action<ILogger, Func<List<LogEventInfo>>> act)
		{
			var configurationItemFactory = new Config.ConfigurationItemFactory();
			configurationItemFactory.LayoutRenderers.RegisterDefinition(ApmTraceIdLayoutRenderer.Name, typeof(ApmTraceIdLayoutRenderer));
			configurationItemFactory.LayoutRenderers.RegisterDefinition(ApmTransactionIdLayoutRenderer.Name, typeof(ApmTransactionIdLayoutRenderer));
			configurationItemFactory.RegisterItemsFromAssembly(Assembly.GetAssembly(typeof(EcsLayout)));

			// These layout renderers need to registered statically
			LayoutRenderer.Register<ApmTraceIdLayoutRenderer>(ApmTraceIdLayoutRenderer.Name); //generic
			LayoutRenderer.Register<ApmTransactionIdLayoutRenderer>(ApmTransactionIdLayoutRenderer.Name); //generic

			var layout = new SimpleLayout(EcsLayout.Name, configurationItemFactory);

			var memoryTarget = new EventInfoMemoryTarget { Layout = layout };

			var loggingConfiguration = new Config.LoggingConfiguration();
			loggingConfiguration.AddRule(LogLevel.Trace, LogLevel.Fatal, memoryTarget);

			var factory = new LogFactory(loggingConfiguration);

			List<LogEventInfo> GetLogEvents() => memoryTarget.Events.ToList();
			var logger = factory.GetCurrentClassLogger();
			act(logger, GetLogEvents);
		}
	}
}
