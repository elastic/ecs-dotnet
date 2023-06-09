// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Diagnostics;
using System.Linq;
using Elastic.Apm;
using Elastic.Apm.SerilogEnricher;
using Elastic.Apm.Test.Common;
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
				.Enrich.WithEnvironmentUserName()
				.Enrich.WithElasticApmCorrelationInfo();

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

			info.Host.Should().NotBeNull();
			info.Host.Name.Should().NotBeEmpty();

			info.Process.Should().NotBeNull();
			info.Process.Name.Should().NotBeEmpty();
			info.Process.Pid.Should().BeGreaterThan(0);
			info.Process.ThreadId.Should().NotBeNull().And.NotBe(info.Process.Pid);

			// We can not reliably test this on CI as the username variable is set but empty
			// info.Server.Should().BeNull();
			// info.Server.User.Name.Should().NotBeEmpty();
		});

		[Fact]
		public void ElasticApmEnrichmentsEndUpOnEcsLog() => TestLogger((logger, getLogEvents) =>
		{
			var configuration = new MockConfiguration("my-service", "my-service-node-name", "0.2.1");
			if (!Apm.Agent.IsConfigured)
				Apm.Agent.Setup(new AgentComponents(payloadSender: new NoopPayloadSender(),configurationReader:configuration));

			string traceId = null;
			string transactionId = null;
			string spanId = null;

			// Start a new activity to make sure it does not override Tracing.Trace.Id
			Activity.Current = new Activity("test").Start();

			Apm.Agent.Tracer.CaptureTransaction("test", "test", t =>
			{
				t.CaptureSpan("span", "test", s =>
				{
					traceId = t.TraceId;
					transactionId = t.Id;
					spanId = s.Id;
					logger.Information("My log message!");
				});
			});

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);
			var (_, info) = ecsEvents.First();

			info.TraceId.Should().Be(traceId);
			info.TransactionId.Should().Be(transactionId);
			info.SpanId.Should().Be(spanId);
			info.Service.Name.Should().Be("my-service");
			info.Service.NodeName.Should().Be("my-service-node-name");
			info.Service.Version.Should().Be("0.2.1");


		});
	}
}
