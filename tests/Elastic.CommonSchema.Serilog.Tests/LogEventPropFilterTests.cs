// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Elastic.Apm;
using Elastic.Apm.SerilogEnricher;
using FluentAssertions;
using Serilog;
using Serilog.Events;
using Serilog.Parsing;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Serilog.Tests
{
	public class LogEventPropFilterTests : LogTestsBase
	{
		public LogEventPropFilterTests(ITestOutputHelper output) : base(output)
		{
			LoggerConfiguration = LoggerConfiguration
				.Enrich.WithThreadId()
				.Enrich.WithThreadName()
				.Enrich.WithMachineName()
				.Enrich.WithProcessId()
				.Enrich.WithProcessName()
				.Enrich.WithEnvironmentUserName()
				.Enrich.WithElasticApmCorrelationInfo();

			Formatter = new EcsTextFormatter(new EcsTextFormatterConfiguration()
			{
				LogEventPropertiesToFilter = new List<string>(){{ "foo" }}
			});
		}

		[Fact]
		public void FilterLogEventProperty() => TestLogger((logger, getLogEvents) =>
		{
			var parser = new MessageTemplateParser();
			var evnt = new LogEvent(
				DateTimeOffset.Now,
				LogEventLevel.Information,
				null,
				parser.Parse("My Log message!"),
				new LogEventProperty[]
				{
					new LogEventProperty("foo", new ScalarValue("aaa")),
					new LogEventProperty("bar", new ScalarValue("bbb")),
				});
			logger.Write(evnt);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Log.Level.Should().Be("Information");
			info.Error.Should().BeNull();
			info.Metadata.Should().Contain("bar", "bbb");
			info.Metadata.Should().NotContainKey("foo", "Should have been filtered");
		});
	}
}
