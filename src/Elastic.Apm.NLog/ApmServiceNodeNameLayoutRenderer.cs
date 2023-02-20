using System.Text;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;

namespace Elastic.Apm.NLog;

/// <summary>
/// Provides ElasticApmServiceNodeName as special logging variable to render the current Elastic APM Service Node Name
/// </summary>
[LayoutRenderer(Name)]
[ThreadSafe, ThreadAgnostic]
public class ApmServiceNodeNameLayoutRenderer : LayoutRenderer
{
	/// <summary>
	/// ElasticApmServiceNodeName - the variable to use to inject into your logs
	/// </summary>
	public const string Name = "ElasticApmServiceNodeName";

	/// <inheritdoc cref="LayoutRenderer.Append"/>
	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		if (!Agent.IsConfigured) return;

		builder.Append(Agent.Config.ServiceNodeName);
	}
}
