// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Text;
using NLog;
using NLog.LayoutRenderers;

namespace Elastic.CommonSchema
{
	[LayoutRenderer("ecs")]
	public class EcsLayoutRenderer : LayoutRenderer
	{
		protected Func<Base, LogEventInfo, Base> MapCustom { get; set; }

		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			var ecsEvent = LogEventConverter.ConvertToEcs(logEvent);

			if (MapCustom != null)
				ecsEvent = MapCustom(ecsEvent, logEvent);

			var output = ecsEvent.Serialize();
			builder.AppendLine(output);
		}
	}
}
