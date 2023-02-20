using System.Text;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;

namespace Elastic.Apm.NLog;

/// <summary>
/// Provides ElasticApmServiceVersion as special logging variable to render the current Elastic APM Service Version
/// </summary>
[LayoutRenderer(Name)]
[ThreadSafe, ThreadAgnostic]
public class ApmServiceVersionLayoutRenderer : LayoutRenderer
{
	/// <summary>
	/// ElasticApmServiceVersion - the variable to use to inject into your logs
	/// </summary>
	public const string Name = "ElasticApmServiceVersion";

	/// <inheritdoc cref="LayoutRenderer.Append"/>
	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		if (!Agent.IsConfigured) return;
		builder.Append(Agent.Config.ServiceVersion);
	}
}
