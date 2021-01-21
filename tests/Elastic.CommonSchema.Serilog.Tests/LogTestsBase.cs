// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Elastic.CommonSchema.Tests.Specs;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.TestCorrelator;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Serilog.Tests
{
	public abstract class LogTestsBase
	{
		protected LoggerConfiguration LoggerConfiguration { get; set; }

		protected EcsTextFormatter Formatter { get; set; } = new EcsTextFormatter();

		protected LogTestsBase(ITestOutputHelper output) =>
			LoggerConfiguration = new LoggerConfiguration()
				.MinimumLevel.Verbose()
				.WriteTo.Console(Formatter)
				.WriteTo.TestOutput(output, formatter: Formatter, LogEventLevel.Verbose)
				.WriteTo.TestCorrelator();

		protected ILogger CreateLogger<T>() => LoggerConfiguration.CreateLogger().ForContext<T>();

		protected void TestLogger(Action<ILogger, Func<List<LogEvent>>> act)
		{
			// Do not delete this line
			using var context = TestCorrelator.CreateContext();

			List<LogEvent> GetAndValidateLogEvents()
			{
				var logEvents = TestCorrelator.GetLogEventsFromCurrentContext().ToList();

				foreach (var logEvent in ToFormattedStrings(logEvents))
					Spec.Validate(logEvent);

				return logEvents;
			}

			act(LoggerConfiguration.CreateLogger().ForContext(GetType()), GetAndValidateLogEvents);
		}

		private List<string> ToFormattedStrings(List<LogEvent> logEvents) =>
			logEvents
				.Select(l =>
				{
					using var stringWriter = new StringWriter();
					Formatter.Format(l, stringWriter);
					return stringWriter.ToString();
				})
				.ToList();

		protected List<(string Json, Base Base)> ToEcsEvents(List<LogEvent> logEvents) =>
			ToFormattedStrings(logEvents)
				.Select(s => (s, Base.Deserialize(s)))
				.ToList();
	}
}
