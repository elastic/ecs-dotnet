using System;
using System.Linq;
using FluentAssertions;
using Serilog.Context;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Serilog.Tests.Repro;

public class GithubIssue402 : LogTestsBase
{
	public GithubIssue402(ITestOutputHelper output) : base(output) { }

	private void Setup<T>(string key, T value, Action<EcsDocument, T> assert) => TestLogger((logger, getLogEvents) =>
	{
		LogTemplateProperties.All.Should().Contain(key);
		using (LogContext.PushProperty(key, value))
			logger.Information("Logging something with log context");

		var logEvents = getLogEvents();
		logEvents.Should().HaveCount(1);

		var ecsEvents = ToEcsEvents(logEvents);

		var (_, info) = ecsEvents.First();
		info.Message.Should().Be("Logging something with log context");
		assert(info, value);

		//info.Labels.Should().NotBeNull().And.ContainKey("client.user.id");
		//info.Labels["ShipmentId"].Should().Be("my-shipment-id");

		//info.Metadata.Should().NotBeNull().And.ContainKey("ShipmentAmount");
		//info.Metadata["ShipmentAmount"].Should().Be(2.3);
	});

	[Fact]
	public void CanAssignNestedAs() => Setup("client.as.number", 1, (info, v) =>
	{
		info.Client.Should().NotBeNull();
		info.Client!.As.Should().NotBeNull();
		info.Client!.As!.Number.Should().Be(v);
	});

	[Fact]
	public void CanAssignDeeplyNestedThreatX509() => Setup("threat.indicator.x509.serial_number", "123", (info, v) =>
	{
		info.Threat.Should().NotBeNull();
		info.Threat!.IndicatorX509.Should().NotBeNull();
		info.Threat!.IndicatorX509!.SerialNumber.Should().Be(v);
	});

	[Fact]
	public void CanAssignThreatIndicatorAs() => Setup("threat.indicator.as.number", 123, (info, v) =>
	{
		info.Threat.Should().NotBeNull();
		info.Threat!.IndicatorAs.Should().NotBeNull();
		info.Threat!.IndicatorAs!.Number.Should().Be(v);
	});

	[Fact(Skip = "self referential process parent not (yet) supported")]
	public void CanAssignProcesssParent() => Setup("process.parent.executable", "bin", (info, v) =>
	{
		info.Process.Should().NotBeNull();
	});
}
