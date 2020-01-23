// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Linq;
using System.Threading.Tasks;
using Elastic.Apm.Api;
using Elastic.Apm.Test.Common;
using FluentAssertions;
using Serilog;
using Serilog.Sinks.InMemory;
using Xunit;

namespace Elastic.Apm.SerilogEnricher.Test
{
	public class SerilogTests : IDisposable
	{
		public SerilogTests()
		{
			if (!Agent.IsConfigured)
				Agent.Setup(new AgentComponents(payloadSender: new NoopPayloadSender()));
		}

		/// <summary>
		/// Creates 1 simple transaction and makes sure that the log line created within the transaction has
		/// the transaction and trace ids, and logs prior to and after the transaction do not have those.
		/// </summary>
		[Fact]
		public void SerilogEnricherWithSimpleSyncTransaction()
		{
			var logger = new LoggerConfiguration()
				.Enrich.WithElasticApmCorrelationInfo()
				.WriteTo.InMemory()
				.CreateLogger();

			string traceId = null;
			string transactionId = null;

			logger.Information("Line1");

			Agent.Tracer.CaptureTransaction("Test", "Test", (t) =>
			{
				traceId = t.TraceId;
				transactionId = t.Id;
				logger.Information("Line2");
			});

			logger.Information("Line3");

			InMemorySink.Instance
				.LogEvents.Should()
				.HaveCount(3);

			InMemorySink.Instance
				.LogEvents.ElementAt(0)
				.Properties.Should()
				.BeEmpty();

			InMemorySink.Instance
				.LogEvents.ElementAt(1)
				.Properties["ElasticApmTraceId"]
				.ToString()
				.Should()
				.Be($"\"{traceId}\"");

			InMemorySink.Instance
				.LogEvents.ElementAt(1)
				.Properties["ElasticApmTransactionId"]
				.ToString()
				.Should()
				.Be($"\"{transactionId}\"");

			InMemorySink.Instance
				.LogEvents.ElementAt(2)
				.Properties.Should()
				.BeEmpty();
		}

		/// <summary>
		/// Same as <see cref="SerilogEnricherWithSimpleSyncTransaction" />, but this time in an async method
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task SerilogEnricherWithSimpleAsyncTransaction()
		{
			var logger = new LoggerConfiguration()
				.Enrich.WithElasticApmCorrelationInfo()
				.WriteTo.InMemory()
				.CreateLogger();

			string traceId;
			string transactionId;

			logger.Information("Line1");

			ITransaction transaction = null;

			try
			{
				transaction = Agent.Tracer.StartTransaction("Test", "Test");
				traceId = transaction.TraceId;
				transactionId = transaction.Id;
				logger.Information("Line2");
				await Task.Delay(10);
				logger.Information("Line3");
			}
			finally
			{
				transaction?.End();
			}

			logger.Information("Line4");

			InMemorySink.Instance
				.LogEvents.Should()
				.HaveCount(4);

			InMemorySink.Instance
				.LogEvents.ElementAt(0)
				.Properties.Should()
				.BeEmpty();

			InMemorySink.Instance
				.LogEvents.ElementAt(1)
				.Properties["ElasticApmTraceId"]
				.ToString()
				.Should()
				.Be($"\"{traceId}\"");

			InMemorySink.Instance
				.LogEvents.ElementAt(1)
				.Properties["ElasticApmTransactionId"]
				.ToString()
				.Should()
				.Be($"\"{transactionId}\"");

			InMemorySink.Instance
				.LogEvents.ElementAt(2)
				.Properties["ElasticApmTraceId"]
				.ToString()
				.Should()
				.Be($"\"{traceId}\"");

			InMemorySink.Instance
				.LogEvents.ElementAt(2)
				.Properties["ElasticApmTransactionId"]
				.ToString()
				.Should()
				.Be($"\"{transactionId}\"");

			InMemorySink.Instance
				.LogEvents.ElementAt(3)
				.Properties.Should()
				.BeEmpty();
		}

		public void Dispose() => InMemorySink.Instance.Dispose();
	}
}
