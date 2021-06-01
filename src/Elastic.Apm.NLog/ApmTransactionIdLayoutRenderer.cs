// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Text;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;

namespace Elastic.Apm.NLog
{
	[LayoutRenderer(Name)]
	[ThreadSafe]
	public class ApmTransactionIdLayoutRenderer : LayoutRenderer
	{
		public const string Name = "ElasticApmTransactionId";

		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			if (!Agent.IsConfigured) return;
			if (Agent.Tracer?.CurrentTransaction is null) return;

			builder.Append(Agent.Tracer.CurrentTransaction.Id);
		}
	}
}
