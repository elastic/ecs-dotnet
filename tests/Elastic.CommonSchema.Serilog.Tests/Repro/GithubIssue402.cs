using System.Linq;
using FluentAssertions;
using Serilog.Context;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Serilog.Tests.Repro;

public class GithubIssue402 : LogTestsBase
{
	public GithubIssue402(ITestOutputHelper output) : base(output) { }

	[Fact]
	public void Reproduce() => TestLogger((logger, getLogEvents) =>
	{
		using (LogContext.PushProperty("client.user.id", "regis"))
			logger.Information("Logging something with log context");

		var logEvents = getLogEvents();
		logEvents.Should().HaveCount(1);

		var ecsEvents = ToEcsEvents(logEvents);

		var (_, info) = ecsEvents.First();
		info.Message.Should().Be("Logging something with log context");

		info.Client.User.Id.Should().Be("regis");
		//info.Labels.Should().NotBeNull().And.ContainKey("client.user.id");
		//info.Labels["ShipmentId"].Should().Be("my-shipment-id");

		//info.Metadata.Should().NotBeNull().And.ContainKey("ShipmentAmount");
		//info.Metadata["ShipmentAmount"].Should().Be(2.3);

	});
}
