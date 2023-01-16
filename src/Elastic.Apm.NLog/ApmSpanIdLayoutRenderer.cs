using System.Text;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;

namespace Elastic.Apm.NLog
{
	[LayoutRenderer(Name)]
	[ThreadSafe]
	public class ApmSpanIdLayoutRenderer : LayoutRenderer
	{
		public const string Name = "ElasticApmSpanId";

		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			if (!Agent.IsConfigured) return;
			builder.Append(Agent.Tracer?.CurrentSpan?.Id);
		}
	}
}
