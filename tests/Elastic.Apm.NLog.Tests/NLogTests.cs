// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elastic.Apm.Test.Common;
using FluentAssertions;
using NLog;
using NLog.Targets;
using Xunit;

namespace Elastic.Apm.NLog.Tests
{
	public class NLogTests
	{
		public NLogTests()
		{
			var assembly = typeof(ApmTraceIdLayoutRenderer).Assembly;
			global::NLog.Config.ConfigurationItemFactory.Default.RegisterItemsFromAssembly(assembly);

			var configuration = new MockConfiguration("my-service", "my-service-node-name", "0.2.1");
			if (!Agent.IsConfigured)
				Agent.Setup(new AgentComponents(payloadSender: new NoopPayloadSender(), configurationReader: configuration));
		}


		/// <summary>
		/// Creates 1 simple transaction and span and makes sure that the log line created within the transaction and span have
		/// the transaction, trace and span ids, and logs prior to and after the transaction do not have those.
		/// </summary>
		[Fact]
		public void NLogWithTransaction()
		{
			var target = new MemoryTarget();
			target.Layout = "${ElasticApmTraceId}|${ElasticApmTransactionId}|${ElasticApmSpanId}|${message}";

			global::NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(target, LogLevel.Debug);

			var logger = LogManager.GetLogger("Example");

			logger.Debug("PreTransaction");

			string traceId = null;
			string transactionId = null;
			string spanId = null;

			Agent.Tracer.CaptureTransaction("TestTransaction", "Test", t =>
			{
				traceId = t.TraceId;
				transactionId = t.Id;
				logger.Debug("InTransaction");

				t.CaptureSpan("TestSpan", "Test", s =>
				{
					spanId = s.Id;
					logger.Debug("InSpan");
				});
			});

			logger.Debug("PostTransaction");

			target.Logs.Count.Should().Be(4);
			target.Logs[0].Should().Be("|||PreTransaction");
			target.Logs[1].Should().Be($"{traceId}|{transactionId}||InTransaction");
			spanId.Should().NotBeNullOrWhiteSpace();
			target.Logs[2].Should().Be($"{traceId}|{transactionId}|{spanId}|InSpan");
			target.Logs[3].Should().Be("|||PostTransaction");
		}

		[Fact]
		public void NLogWithServiceName()
		{
			var target = new MemoryTarget();
			target.Layout = "${ElasticApmServiceName}|${ElasticApmServiceNodeName}|${ElasticApmServiceVersion}|${message}";

			global::NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(target, LogLevel.Debug);

			var logger = LogManager.GetLogger("Example");

			logger.Debug("Some log");

			target.Logs.Count.Should().Be(1);
			target.Logs[0].Should().Be("my-service|my-service-node-name|0.2.1|Some log");
		}
	}
}
