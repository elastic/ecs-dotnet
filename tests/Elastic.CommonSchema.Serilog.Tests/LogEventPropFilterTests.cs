// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
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

			var config = new EcsTextFormatterConfiguration { LogEventPropertiesToFilter = new HashSet<string> { "foo" } };
			Formatter = new EcsTextFormatter(config);
		}

		private LogEvent BuildLogEvent()
		{
			var parser = new MessageTemplateParser();
			return new LogEvent(
				DateTimeOffset.Now,
				LogEventLevel.Information,
				null,
				parser.Parse("My Log message!"),
				new[]
				{
					new LogEventProperty("foo", new ScalarValue("aaa")),
					new LogEventProperty("bar", new ScalarValue("bbb")),
				});
		}

		/// <summary>
		/// Test the default <see cref="EcsTextFormatterConfiguration.LogEventPropertiesToFilter"/> via a hashset
		/// </summary>
		[Fact]
		public void FilterLogEventProperty() => TestLogger((logger, getLogEvents) =>
		{
			var evnt = BuildLogEvent();
			logger.Write(evnt);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Log.Level.Should().Be("Information");
			info.Error.Should().BeNull();
			info.Labels.Should().Contain("bar", "bbb");
			info.Labels.Should().NotContainKey("foo", "Should have been filtered");
		});
		/// <summary>
		/// Test that null <see cref="EcsTextFormatterConfiguration.LogEventPropertiesToFilter"/> does not cause any critical errors
		/// </summary>
		[Fact]
		public void NullFilterLogEventProperty() => TestLogger((logger, getLogEvents) =>
		{
			var config = new EcsTextFormatterConfiguration { LogEventPropertiesToFilter = null };
			Formatter = new EcsTextFormatter(config);

			var evnt = BuildLogEvent();
			logger.Write(evnt);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Log.Level.Should().Be("Information");
			info.Error.Should().BeNull();
			info.Labels.Should().Contain("bar", "bbb");
			info.Labels.Should().Contain("foo", "aaa");
		});

		/// <summary>
		/// Test that <see cref="EcsTextFormatterConfiguration.LogEventPropertiesToFilter"/> can be empty and does not cause any critical errors
		/// </summary>
		[Fact]
		public void EmptyFilterLogEventProperty() => TestLogger((logger, getLogEvents) =>
		{
			var config = new EcsTextFormatterConfiguration { LogEventPropertiesToFilter = new HashSet<string>() };
			Formatter = new EcsTextFormatter(config);

			var evnt = BuildLogEvent();
			logger.Write(evnt);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Log.Level.Should().Be("Information");
			info.Error.Should().BeNull();
			info.Labels.Should().Contain("bar", "bbb");
			info.Labels.Should().Contain("foo", "aaa");
		});
		/// <summary>
		/// Test that <see cref="EcsTextFormatterConfiguration.LogEventPropertiesToFilter"/> can be case insensitive
		/// </summary>
		[Fact]
		public void CaseInsensitiveFilterLogEventProperty() => TestLogger((logger, getLogEvents) =>
		{
			var config = new EcsTextFormatterConfiguration { LogEventPropertiesToFilter = new HashSet<string>(StringComparer.OrdinalIgnoreCase){{ "FOO" }} };
			Formatter = new EcsTextFormatter(config);

			var evnt = BuildLogEvent();
			logger.Write(evnt);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Log.Level.Should().Be("Information");
			info.Error.Should().BeNull();
			info.Labels.Should().Contain("bar", "bbb");
			info.Labels.Should().NotContainKey("foo", "Should have been filtered");
		});
		/// <summary>
		/// Test that <see cref="EcsTextFormatterConfiguration.LogEventPropertiesToFilter"/> can be case sensitive
		/// </summary>
		[Fact]
		public void CaseSensitiveFilterLogEventProperty() => TestLogger((logger, getLogEvents) =>
		{
			var config = new EcsTextFormatterConfiguration { LogEventPropertiesToFilter = new HashSet<string>(StringComparer.Ordinal){{ "FOO" }} };
			Formatter = new EcsTextFormatter(config);

			var evnt = BuildLogEvent();
			logger.Write(evnt);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Log.Level.Should().Be("Information");
			info.Error.Should().BeNull();
			info.Labels.Should().Contain("bar", "bbb");
			info.Labels.Should().Contain("foo", "aaa");
		});
	}
}
