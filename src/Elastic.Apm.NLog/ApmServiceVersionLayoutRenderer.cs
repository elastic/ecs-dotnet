using System.Text;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;

namespace Elastic.Apm.NLog;

[LayoutRenderer(Name)]
[ThreadSafe, ThreadAgnostic]
public class ApmServiceVersionLayoutRenderer : LayoutRenderer
{
	public const string Name = "ElasticApmServiceVersion";

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		if (!Agent.IsConfigured) return;
		builder.Append(Agent.Config.ServiceVersion);
	}
}
