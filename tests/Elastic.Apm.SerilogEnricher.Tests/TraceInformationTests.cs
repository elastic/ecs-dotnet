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

namespace Elastic.Apm.SerilogEnricher.Tests
{
	public class TraceInformationTests : IDisposable
	{
		private readonly string[] _tracingKeys = { "ElasticApmSpanId", "ElasticApmTransactionId", "ElasticApmTraceId" };

		public TraceInformationTests() => TestApmAgent.Configure();

		/// <summary>
		/// Creates 1 simple transaction and span and makes sure that the log line created within the transaction has
		/// the transaction, span and trace ids, and logs prior to and after the transaction do not have those.
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
			string spanId = null;

			logger.Information("Line1");

			Agent.Tracer.CaptureTransaction("Test", "Test", (t) =>
			{
				t.CaptureSpan("Span", "Test", s =>
				{
					traceId = t.TraceId;
					transactionId = t.Id;
					spanId = s.Id;
					logger.Information("Line2");
				});

				logger.Information("Line3");
			});

			logger.Information("Line4");

			traceId.Should().NotBeNullOrEmpty();
			transactionId.Should().NotBeNullOrEmpty();
			spanId.Should().NotBeNullOrEmpty();

			InMemorySink.Instance
				.LogEvents.Should()
				.HaveCount(4);

			InMemorySink.Instance
				.LogEvents.ElementAt(0)
				.Properties.Keys.Should()
				.NotContain(_tracingKeys);

			var logEvent1 = InMemorySink.Instance.LogEvents.ElementAt(1);

			logEvent1
				.Properties["ElasticApmTraceId"]
				.ToString()
				.Should()
				.Be($"\"{traceId}\"");

			logEvent1
				.Properties["ElasticApmTransactionId"]
				.ToString()
				.Should()
				.Be($"\"{transactionId}\"");

			logEvent1
				.Properties["ElasticApmSpanId"]
				.ToString()
				.Should()
				.Be($"\"{spanId}\"");

			var logEvent2 = InMemorySink.Instance.LogEvents.ElementAt(2);

			logEvent2
				.Properties["ElasticApmTraceId"]
				.ToString()
				.Should()
				.Be($"\"{traceId}\"");

			logEvent2
				.Properties["ElasticApmTransactionId"]
				.ToString()
				.Should()
				.Be($"\"{transactionId}\"");

			logEvent2
				.Properties.Should()
				.NotContain(kv => kv.Key == "ElasticApmSpanId");

			InMemorySink.Instance
				.LogEvents.ElementAt(3)
				.Properties.Keys.Should()
				.NotContain(_tracingKeys);
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
				.Properties.Keys.Should()
				.NotContain(_tracingKeys);

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
				.Properties.Keys.Should()
				.NotContain(_tracingKeys);
		}

		public void Dispose() => InMemorySink.Instance.Dispose();
	}
}
