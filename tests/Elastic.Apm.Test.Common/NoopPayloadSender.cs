// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

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
