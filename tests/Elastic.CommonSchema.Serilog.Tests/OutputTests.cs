using System;
using System.Linq;
using FluentAssertions;
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
			var (_, error) = ecsEvents.Last();
			error.Log.Level.Should().Be("Error");
			error.Error.Should().NotBeNull();

			var (_, info) = ecsEvents.First();
			info.Log.Level.Should().Be("Information");
			info.Error.Should().BeNull();
		});
	}
}
