using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Serilog.Tests
{
	public class GithubIssue31 : LogTestsBase
	{
		public GithubIssue31(ITestOutputHelper output) : base(output) { }

		[Fact]
		public void Reproduce() => TestLogger((logger, getLogEvents) =>
		{
			logger.Information("Язык", new { Значение = "Русский" });

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().Be("Язык");

			var infoString = info.Serialize();
			infoString.Should().Contain("Язык");
		});
	}
}
