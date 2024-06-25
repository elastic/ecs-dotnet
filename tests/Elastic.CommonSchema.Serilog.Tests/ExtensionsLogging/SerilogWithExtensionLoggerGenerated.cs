// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Serilog;
using Xunit;
using Xunit.Abstractions;
using ILogger = Microsoft.Extensions.Logging.ILogger;

namespace Elastic.CommonSchema.Serilog.Tests.ExtensionsLogging;

public static partial class GeneratedLogs
{
	[LoggerMessage(Level = LogLevel.Information, Message = "Message")]
	public static partial void UpdateEcsDocument(this ILogger logger, Event @event);
}

public class SerilogWithExtensionsLoggerGenerated : LogTestsBase
{
	public SerilogWithExtensionsLoggerGenerated(ITestOutputHelper output) : base(output) { }

	[Fact(Skip = "Need to update solution to net8.0 and use LogProperties attribute on generated log messages to preserve object")]
	public void CanSpecifyEventInGeneratedLogger() => TestLogger((serilogLogger, getLogEvents) =>
	{
		ILoggerFactory loggerFactory = new LoggerFactory();
		loggerFactory.AddSerilog(serilogLogger);
		var logger = loggerFactory.CreateLogger<SerilogWithExtensionsLoggerAdapter>();

		logger.UpdateEcsDocument(new Event { Timezone = "testing" });

		var logEvents = getLogEvents();
		logEvents.Should().HaveCount(1);

		var ecsEvents = ToEcsEvents(logEvents);

		var (_, info) = ecsEvents.First();
		info.Event.Should().NotBeNull();
		info.Event.Timezone.Should().Be("testing");

		info.Labels.Should().HaveCount(1).And.NotContainKey("event");
	});

	[Fact]
	public void CanSpecifyEventInLogger() => TestLogger((serilogLogger, getLogEvents) =>
	{
		ILoggerFactory loggerFactory = new LoggerFactory();
		loggerFactory.AddSerilog(serilogLogger);
		var logger = loggerFactory.CreateLogger<SerilogWithExtensionsLoggerAdapter>();

		logger.LogInformation("{@event} is not null", new Event { Timezone = "testing" });

		var logEvents = getLogEvents();
		logEvents.Should().HaveCount(1);

		var ecsEvents = ToEcsEvents(logEvents);

		var (_, info) = ecsEvents.First();
		info.Event.Should().NotBeNull();
		info.Event.Timezone.Should().Be("testing");

		info.Labels.Should().HaveCount(1);
		info.Labels.Should().HaveCount(1).And.NotContainKey("event");
	});

}
