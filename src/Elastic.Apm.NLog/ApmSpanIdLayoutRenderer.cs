using System.Text;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;

namespace Elastic.Apm.NLog;

/// <summary>
/// Provides ElasticApmSpanId as special logging variable to render the current Elastic APM Span Id
/// </summary>
[LayoutRenderer(Name)]
[ThreadSafe]
public class ApmSpanIdLayoutRenderer : LayoutRenderer
{
	/// <summary>
	/// ElasticApmSpanId - the variable to use to inject into your logs
	/// </summary>
	public const string Name = "ElasticApmSpanId";

	/// <inheritdoc cref="LayoutRenderer.Append"/>
	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		if (!Agent.IsConfigured) return;
		if (!Agent.Config.Enabled) return;
		builder.Append(Agent.Tracer?.CurrentSpan?.Id);
	}
}
