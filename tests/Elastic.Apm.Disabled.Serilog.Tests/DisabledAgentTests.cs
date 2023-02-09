// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elastic.Apm.SerilogEnricher;
using Elastic.Apm.Test.Common;
using FluentAssertions;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.InMemory;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.Apm.Disabled.Serilog.Tests
{
	public class DisabledAgentTests : IDisposable
	{
		private readonly ITestOutputHelper _output;
		private readonly string[] _tracingKeys = { "ElasticApmSpanId", "ElasticApmTransactionId", "ElasticApmTraceId" };

		public DisabledAgentTests(ITestOutputHelper output)
		{
			_output = output;
			TestDisabledApmAgent.Configure();
		}

		[Fact]
		public void DisabledAgentShouldNeverInjectTracingProperties()
		{
			var template = "{Message:lj} ({ElasticApmServiceName}) ({ElasticApmTraceId})";
			var logger = new LoggerConfiguration()
				.Enrich.WithElasticApmCorrelationInfo()
				.WriteTo.InMemory(outputTemplate: template)
				.WriteTo.TestOutput(_output, LogEventLevel.Verbose, outputTemplate: template)
				.CreateLogger();

			logger.Information("Before Transaction");

			Agent.Tracer.CaptureTransaction("Test", "Test", t =>
			{
				t.CaptureSpan("Span", "Test", _ =>
				{
					logger.Information("During Span");
				});

				logger.Information("During Transaction");
			});

			logger.Information("After Transaction");

			InMemorySink.Instance
				.LogEvents.Should()
				.HaveCount(4);

			foreach (var log in InMemorySink.Instance.LogEvents)
				log.Properties.Keys.Should().NotContain(_tracingKeys);

		}

		public void Dispose() => InMemorySink.Instance.Dispose();
	}
}
