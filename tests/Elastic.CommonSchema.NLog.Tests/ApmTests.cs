// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Diagnostics;
using System.Linq;
using Elastic.Apm;
using FluentAssertions;
using Xunit;

namespace Elastic.CommonSchema.NLog.Tests
{
	public class ApmTests : LogTestsBase
	{
		[Fact]
		public void ElasticApmEndUpOnEcsLog() => TestLogger((logger, getLogEvents) =>
		{
			if (!Apm.Agent.IsConfigured)
				Apm.Agent.Setup(new AgentComponents());

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

			info.Trace.Id.Should().Be(traceId);
			info.Transaction.Id.Should().Be(transactionId);
			info.Span.Id.Should().Be(spanId);
		});
	}
}
