// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Linq;
using Elastic.Apm.Test.Common;
using FluentAssertions;
using Serilog;
using Serilog.Sinks.InMemory;
using Xunit;

namespace Elastic.Apm.SerilogEnricher.Tests
{
	public class ServiceInformationTests : IDisposable
	{
		public ServiceInformationTests() => TestApmAgent.Configure();

		[Fact]
		public void ServiceIsExposedToSerilog()
		{
			var logger = new LoggerConfiguration()
				.Enrich.WithElasticApmCorrelationInfo()
				.WriteTo.InMemory()
				.CreateLogger();

			logger.Information("Line1");

			Agent.Tracer.CaptureTransaction("Test", "Test", t =>
			{
				t.CaptureSpan("Span", "Test", _ =>
				{
					logger.Information("Line2");
				});
			});

			// service information should always be available because the agent IsConfigured
			var logEvent0 = InMemorySink.Instance.LogEvents.ElementAt(0);
			logEvent0.Properties["ElasticApmServiceName"].ToString().Should().Be("\"my-service\"");
			logEvent0.Properties["ElasticApmServiceNodeName"].ToString().Should().Be("\"my-service-node-name\"");
			logEvent0.Properties["ElasticApmServiceVersion"].ToString().Should().Be("\"0.2.1\"");


			var logEvent1 = InMemorySink.Instance.LogEvents.ElementAt(1);
			logEvent1.Properties["ElasticApmServiceName"].ToString().Should().Be("\"my-service\"");
			logEvent1.Properties["ElasticApmServiceNodeName"].ToString().Should().Be("\"my-service-node-name\"");
			logEvent1.Properties["ElasticApmServiceVersion"].ToString().Should().Be("\"0.2.1\"");
		}

		public void Dispose() => InMemorySink.Instance.Dispose();
	}
}
