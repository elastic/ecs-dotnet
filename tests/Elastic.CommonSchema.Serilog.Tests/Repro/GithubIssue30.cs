using System.Linq;
using FluentAssertions;
using Serilog;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Serilog.Tests.Repro
{
	public class GithubIssue30 : LogTestsBase
	{
		public GithubIssue30(ITestOutputHelper output) : base(output) =>
			LoggerConfiguration = LoggerConfiguration
				.Enrich.WithThreadId()
				.Enrich.WithThreadName()
				.Enrich.WithMachineName()
				.Enrich.WithProcessId()
				.Enrich.WithProcessName()
				.Enrich.WithEnvironmentUserName();

		[Fact]
		public void DoesNotCaptureSurroundingDoubleQuotes() => TestLogger((logger, getLogEvents) =>
		{
			logger.Information("My log message!");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Log.Level.Should().Be("Information");
			info.Error.Should().BeNull();

			info.Host.Name.Should().NotBeEmpty().And.NotContain("\"");
			info.Process.Name.Should().NotBeEmpty().And.NotContain("\"");
			info.Process.Pid.Should().BeGreaterThan(0);
			info.Process.ThreadId.Should().NotBeNull().And.NotBe(info.Process.Pid);
		});
	}
}
