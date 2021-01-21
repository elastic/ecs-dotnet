// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using Elastic.Apm.NLog;
using Elastic.CommonSchema.Tests.Specs;
using NLog;
using NLog.LayoutRenderers;
using Config=NLog.Config;
using NLog.Targets;

namespace Elastic.CommonSchema.NLog.Tests
{
	public abstract class LogTestsBase
	{
		protected List<(string Json, Base Base)> ToEcsEvents(List<string> logEvents) =>
			logEvents.Select(s => (s, Base.Deserialize(s)))
				.ToList();

		protected static void TestLogger(Action<ILogger, Func<List<string>>> act)
		{
			// These layout renderers need to registered statically as ultimately ConfigurationItemFactory.Default is called in the call stack.
			LayoutRenderer.Register<ApmTraceIdLayoutRenderer>(ApmTraceIdLayoutRenderer.Name); //generic
			LayoutRenderer.Register<ApmTransactionIdLayoutRenderer>(ApmTransactionIdLayoutRenderer.Name); //generic

			var logFactory = new LogFactory();
			var logConfig = new Config.LoggingConfiguration(logFactory);
			var ecsLayout = new EcsLayout();
			ecsLayout.ExcludeProperties.Add("NotX");
			var memoryTarget = new MemoryTarget { Layout = ecsLayout, OptimizeBufferReuse = true };
			logConfig.AddRule(LogLevel.Trace, LogLevel.Fatal, memoryTarget);
			logConfig.DefaultCultureInfo = System.Globalization.CultureInfo.InvariantCulture;
			logFactory.Configuration = logConfig;

			List<string> GetAndValidateLogEvents()
			{
				foreach (var log in memoryTarget.Logs)
					Spec.Validate(log);

				return memoryTarget.Logs.ToList();
			}

			var logger = logFactory.GetCurrentClassLogger();
			act(logger, GetAndValidateLogEvents);
		}


	}
}
