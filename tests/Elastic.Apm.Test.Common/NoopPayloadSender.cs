using Elastic.Apm.Api;
using Elastic.Apm.Report;

namespace Elastic.Apm.Test.Common
{
	public class NoopPayloadSender : IPayloadSender
	{
		public void QueueError(IError error) { }

		public void QueueMetrics(IMetricSet metrics) { }

		public void QueueSpan(ISpan span) { }

		public void QueueTransaction(ITransaction transaction) { }
	}
}
