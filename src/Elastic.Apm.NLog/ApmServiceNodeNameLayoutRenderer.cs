using System.Text;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;

namespace Elastic.Apm.NLog;

[LayoutRenderer(Name)]
[ThreadSafe]
public class ApmServiceNodeNameLayoutRenderer : LayoutRenderer
{
	public const string Name = "ElasticApmServiceNodeName";

	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		if (!Agent.IsConfigured) return;
		builder.Append(Agent.Config.ServiceNodeName);
	}
}
