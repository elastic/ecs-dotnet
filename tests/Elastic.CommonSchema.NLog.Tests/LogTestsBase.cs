// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using Elastic.Apm.NLog;
using Elastic.CommonSchema.Tests.Specs;
using NLog;
using Config=NLog.Config;
using NLog.Targets;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.NLog.Tests
{
	public abstract class LogTestsBase
	{
		protected LogTestsBase(ITestOutputHelper output) => TestOut = output;

		private ITestOutputHelper TestOut { get; }

		protected List<(string Json, EcsDocument Base)> ToEcsEvents(List<string> logEvents) =>
			logEvents.Select(s => (s, EcsDocument.Deserialize(s)))
				.ToList();

		protected void TestLogger(Action<ILogger, Func<List<string>>> act) =>
			TestLoggerAndLayout(null, (layout, logger, events) => act(logger, events));

		protected void TestLoggerAndLayout(Action<EcsLayout> setup, Action<EcsLayout, ILogger, Func<List<string>>> act)
		{
			// These layout renderers need to registered statically as ultimately ConfigurationItemFactory.Default is called in the call stack.
			LogManager.Setup().SetupExtensions(ext =>
			{
				ext.RegisterLayout<EcsLayout>();
				ext.RegisterLayoutRenderer<ApmTraceIdLayoutRenderer>(ApmTraceIdLayoutRenderer.Name);
				ext.RegisterLayoutRenderer<ApmTransactionIdLayoutRenderer>(ApmTransactionIdLayoutRenderer.Name);
				ext.RegisterLayoutRenderer<ApmSpanIdLayoutRenderer>(ApmSpanIdLayoutRenderer.Name);
				ext.RegisterLayoutRenderer<ApmServiceNameLayoutRenderer>(ApmServiceNameLayoutRenderer.Name);
				ext.RegisterLayoutRenderer<ApmServiceVersionLayoutRenderer>(ApmServiceVersionLayoutRenderer.Name);
				ext.RegisterLayoutRenderer<ApmServiceNodeNameLayoutRenderer>(ApmServiceNodeNameLayoutRenderer.Name);
			});

			var logFactory = new LogFactory();
			var logConfig = new Config.LoggingConfiguration(logFactory);
			var ecsLayout = new EcsLayout { IncludeScopeProperties = true };
			ecsLayout.ExcludeProperties.Add("NotX");
			setup?.Invoke(ecsLayout);
			var memoryTarget = new MemoryTarget { Layout = ecsLayout };
			logConfig.AddRule(LogLevel.Trace, LogLevel.Fatal, memoryTarget);
			logConfig.DefaultCultureInfo = System.Globalization.CultureInfo.InvariantCulture;
			logFactory.Configuration = logConfig;

			List<string> GetAndValidateLogEvents()
			{
				foreach (var log in memoryTarget.Logs)
				{
					TestOut.WriteLine(log);
					Spec.Validate(log);
				}

				return memoryTarget.Logs.ToList();
			}

			var logger = logFactory.GetCurrentClassLogger();
			act(ecsLayout, logger, GetAndValidateLogEvents);
		}
	}
}
