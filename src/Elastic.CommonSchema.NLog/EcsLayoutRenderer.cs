// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Text;
using NLog;
using NLog.Config;
using NLog.LayoutRenderers;

namespace Elastic.CommonSchema
{
	[LayoutRenderer("ecs")]
	public class EcsLayoutRenderer : LayoutRenderer
	{
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			var ecs = LogEventConverter.ConvertToEcs(logEvent);
			var output = ecs.Serialize();
			builder.Append(output);
		}
	}
}
