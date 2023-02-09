// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Serilog.Tests
{
	public class EcsFieldsInTemplateTests : LogTestsBase
	{
		public EcsFieldsInTemplateTests(ITestOutputHelper output) : base(output) =>
			LoggerConfiguration = LoggerConfiguration;

		[Fact]
		public void EcsFieldsDoNotEndUpAsLabelsOrMetadata() => TestLogger((logger, getLogEvents) =>
		{
			logger.Information("Info {TraceId} {FaasColdstart}", "trace-123", true);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.TraceId.Should().Be("trace-123");
			info.Faas.Coldstart.Should().BeTrue();
		});

		[Fact]
		public void EcsFieldsRequireType() => TestLogger((logger, getLogEvents) =>
		{
			logger.Information("Info {TraceId} {FaasColdstart}", 1, "NotABoolean");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.TraceId.Should().BeNull();
			info.Faas.Should().BeNull();

			info.Labels.Should().ContainKey("FaasColdstart");
			info.Metadata.Should().ContainKey("TraceId");
		});

		[Fact]
		public void SupportsStringification() => TestLogger((logger, getLogEvents) =>
		{
			logger.Information("Info {$TraceId} {FaasColdstart}", 1, "NotABoolean");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.TraceId.Should().NotBeNull();
			info.TraceId.Should().Be("1");
		});

		[Fact]
		public void SupportsStructureCapturing() => TestLogger((logger, getLogEvents) =>
		{
			logger.Information("Info {TraceId} {@FaasColdstart}", new { x = 1 }, new { y = 2 });

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
