// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Text;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;

namespace Elastic.Apm.NLog;

/// <summary>
/// Provides ElasticApmTransactionId as special logging variable to render the current Elastic APM Transaction Id
/// </summary>
[LayoutRenderer(Name)]
[ThreadSafe]
public class ApmTransactionIdLayoutRenderer : LayoutRenderer
{
	/// <summary>
	/// ElasticApmTransactionId - the variable to use to inject into your logs
	/// </summary>
	public const string Name = "ElasticApmTransactionId";

	/// <inheritdoc cref="LayoutRenderer.Append"/>
	protected override void Append(StringBuilder builder, LogEventInfo logEvent)
	{
		if (!Agent.IsConfigured) return;
		if (!Agent.Config.Enabled) return;
		builder.Append(Agent.Tracer?.CurrentTransaction?.Id);
	}
}
