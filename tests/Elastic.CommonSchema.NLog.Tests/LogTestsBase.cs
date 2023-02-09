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

		protected void TestLogger(Action<ILogger, Func<List<string>>> act)
		{
			// These layout renderers need to registered statically as ultimately ConfigurationItemFactory.Default is called in the call stack.
			LayoutRenderer.Register<ApmTraceIdLayoutRenderer>(ApmTraceIdLayoutRenderer.Name); //generic
			LayoutRenderer.Register<ApmTransactionIdLayoutRenderer>(ApmTransactionIdLayoutRenderer.Name); //generic
			LayoutRenderer.Register<ApmSpanIdLayoutRenderer>(ApmSpanIdLayoutRenderer.Name); //generic
			LayoutRenderer.Register<ApmServiceNameLayoutRenderer>(ApmServiceNameLayoutRenderer.Name); //generic
			LayoutRenderer.Register<ApmServiceVersionLayoutRenderer>(ApmServiceVersionLayoutRenderer.Name); //generic
			LayoutRenderer.Register<ApmServiceNodeNameLayoutRenderer>(ApmServiceNodeNameLayoutRenderer.Name); //generic

			var logFactory = new LogFactory();
			var logConfig = new Config.LoggingConfiguration(logFactory);
			var ecsLayout = new EcsLayout { IncludeScopeProperties = true };
			ecsLayout.ExcludeProperties.Add("NotX");
			var memoryTarget = new MemoryTarget { Layout = ecsLayout, OptimizeBufferReuse = true };
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
			act(logger, GetAndValidateLogEvents);
		}


	}
}
