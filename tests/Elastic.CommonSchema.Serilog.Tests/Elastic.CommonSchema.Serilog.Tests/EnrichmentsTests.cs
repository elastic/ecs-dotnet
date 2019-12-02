using System;
using System.Linq;
using FluentAssertions;
using Serilog;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Serilog.Tests
{
	public class EnrichmentsTests : LogTestsBase
	{
		public EnrichmentsTests(ITestOutputHelper output) : base(output) =>
			LoggerConfiguration = LoggerConfiguration
				.Enrich.WithThreadId()
				.Enrich.WithThreadName()
				.Enrich.WithMachineName()
				.Enrich.WithProcessId()
				.Enrich.WithProcessName()
				.Enrich.WithEnvironmentUserName();

		[Fact]
		public void EnrichmentsEndUpOnEcsLog() => TestLogger((logger, getLogEvents) =>
		{
			logger.Information("My log message!");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Log.Level.Should().Be("Information");
			info.Error.Should().BeNull();

			info.Host.Name.Should().NotBeEmpty();
			info.Process.Name.Should().NotBeEmpty();
			info.Process.Pid.Should().BeGreaterThan(0);
			info.Process.Thread.Id.Should().NotBeNull().And.NotBe(info.Process.Pid);
		});
	}
}
