using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Serilog.Events;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Serilog.Tests
{
	public class OutputTests : LogTestsBase
	{
		public OutputTests(ITestOutputHelper output) : base(output) { }

		[Fact]
		public void LogMultiple() => TestLogger((logger, getLogEvents) =>
		{
			logger.Information("My log message!");
			logger.Information("Test output to Serilog!");
			Action sketchy = () => throw new Exception("I threw up.");
			var exception = Record.Exception(sketchy);
			logger.Error(exception, "Here is an error.");
			Assert.NotNull(exception);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(3);

			var ecsEvents = ToEcsEvents(logEvents);
			var error = ecsEvents.Last();
			error.Base.Error.Should().NotBeNull();
			var informational = ecsEvents.First();
			informational.Base.Error.Should().BeNull();
		});
	}
}
