// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Linq;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Serilog;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Serilog.Tests.ExtensionsLogging
{
	public class SerilogWithExtensionsLoggerAdapter : LogTestsBase
	{
		public SerilogWithExtensionsLoggerAdapter(ITestOutputHelper output) : base(output) { }

		[Fact]
		public void EcsFieldsDoNotEndUpAsLabelsOrMetadata() => TestLogger((serilogLogger, getLogEvents) =>
		{
			ILoggerFactory loggerFactory = new LoggerFactory();
			loggerFactory.AddSerilog(serilogLogger);
			var logger = loggerFactory.CreateLogger<SerilogWithExtensionsLoggerAdapter>();
			logger.LogInformation("Info {TraceId} {FaasColdstart}", "trace-123", true);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.TraceId.Should().Be("trace-123");
			info.Faas.Coldstart.Should().BeTrue();
		});

		[Fact]
		public void SupportsEventId() => TestLogger((serilogLogger, getLogEvents) =>
		{
			ILoggerFactory loggerFactory = new LoggerFactory();
			loggerFactory.AddSerilog(serilogLogger);
			var logger = loggerFactory.CreateLogger<SerilogWithExtensionsLoggerAdapter>();
			logger.LogError(new EventId(123, "hello"), "Hello {World}", "Universe");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, error) = ecsEvents.First();
			error.Event.Should().NotBeNull();
			error.Event.Action.Should().Be("hello");
			error.Event.Code.Should().Be("123");
			error.Metadata.Should().BeNull();
		});
		[Fact]
		public void SupportsStructureCapturing() => TestLogger((serilogLogger, getLogEvents) =>
		{
			ILoggerFactory loggerFactory = new LoggerFactory();
			loggerFactory.AddSerilog(serilogLogger);
			var logger = loggerFactory.CreateLogger<SerilogWithExtensionsLoggerAdapter>();
			logger.LogInformation("Info {TraceId} {@FaasColdstart}", new { x = 1 }, new { y = 2 });

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.TraceId.Should().NotBeNull();
			info.TraceId.Should().Be("{ x = 1 }");
			info.Faas.Should().BeNull();
			info.Metadata.Should().ContainKey("FaasColdstart");
			var structured = info.Metadata["FaasColdstart"] as MetadataDictionary;
			structured.Should().NotBeNull();
			structured!["y"].Should().Be(2);
		});

	}
}
