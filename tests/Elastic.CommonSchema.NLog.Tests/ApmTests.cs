// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Diagnostics;
using System.Linq;
using Elastic.Apm;
using Elastic.Apm.Test.Common;
using FluentAssertions;
using Xunit;

namespace Elastic.CommonSchema.NLog.Tests
{
	public class ApmTests : LogTestsBase
	{
		[Fact]
		public void ElasticApmEndUpOnEcsLog() => TestLogger((logger, getLogEvents) =>
		{
			var configuration = new MockConfiguration("my-service", "my-service-node-name", "0.2.1");
			if (!Apm.Agent.IsConfigured)
				Apm.Agent.Setup(new AgentComponents(payloadSender: new NoopPayloadSender(), configurationReader: configuration));

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
					logger.Info("My log message!");
				});
			});

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);
			var (_, info) = ecsEvents.First();

			info.TraceId.Should().Be(traceId);
			info.TransactionId.Should().Be(transactionId);
			info.SpanId.Should().Be(spanId);
			info.Service.Should().NotBeNull();
			info.Service.Name.Should().Be("my-service");
			info.Service.NodeName.Should().Be("my-service-node-name");
			info.Service.Version.Should().Be("0.2.1");
		});
	}
}
