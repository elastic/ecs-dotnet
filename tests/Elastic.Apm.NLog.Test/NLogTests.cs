using Elastic.Apm.Test.Common;
using FluentAssertions;
using NLog;
using NLog.Targets;
using Xunit;

namespace Elastic.Apm.NLog.Test
{
	public class NLogTests
	{
		/// <summary>
		/// Creates 1 simple transaction and makes sure that the log line created within the transaction has
		/// the transaction and trace ids, and logs prior to and after the transaction do not have those.
		/// </summary>
		[Fact]
		public void NLogWithTransaction()
		{
			var assembly = typeof(ApmTraceIdLayoutRenderer).Assembly;
			global::NLog.Config.ConfigurationItemFactory.Default.RegisterItemsFromAssembly(assembly);
			Agent.Setup(new AgentComponents(payloadSender: new NoopPayloadSender()));

			var target = new MemoryTarget();
			target.Layout = "${ElasticApmTraceId}|${ElasticApmTransactionId}|${message}";

			global::NLog.Config.SimpleConfigurator.ConfigureForTargetLogging(target, LogLevel.Debug);

			var logger = LogManager.GetLogger("Example");

			logger.Debug("PreTransaction");

			string traceId = null;
			string transactionId = null;

			Agent.Tracer.CaptureTransaction("TestTransaction", "Test", t =>
			{
				traceId = t.TraceId;
				transactionId = t.Id;
				logger.Debug("InTransaction");
			});

			logger.Debug("PostTransaction");

			target.Logs.Count.Should().Be(3);

			target.Logs[0].Should().Be("||PreTransaction");
			target.Logs[1].Should().Be($"{traceId}|{transactionId}|InTransaction");
			target.Logs[2].Should().Be("||PostTransaction");
		}
	}
}
