// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Linq;
using FluentAssertions;
using Serilog;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Serilog.Tests
{
	public class MessageTests : LogTestsBase
	{
		public MessageTests(ITestOutputHelper output) : base(output) =>
			LoggerConfiguration = LoggerConfiguration
				.Enrich.WithThreadId()
				.Enrich.WithThreadName()
				.Enrich.WithMachineName()
				.Enrich.WithProcessId()
				.Enrich.WithProcessName()
				.Enrich.WithEnvironmentUserName();

		[Fact]
		public void SeesMessage() => TestLogger((logger, getLogEvents) =>
		{
			logger.Information("My log message!");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().Be("My log message!");
		});

		[Fact]
		public void SeesMessageWithProp() => TestLogger((logger, getLogEvents) =>
		{
			logger.Information("Info {ValueX} {SomeY}", "X", 2.2);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().Be("Info \"X\" 2.2");
			info.Metadata.Should().ContainKey("value_x");
			info.Metadata.Should().ContainKey("some_y");

			var x = info.Metadata["value_x"] as string;
			x.Should().NotBeNull().And.Be("X");

			var y = info.Metadata["some_y"] as double?;
			y.Should().HaveValue().And.Be(2.2);

		});
	}
}
