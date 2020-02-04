// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Text;
using NLog;
using NLog.LayoutRenderers;

namespace Elastic.CommonSchema
{
	[LayoutRenderer("ecs")]
	public class EcsLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Application Identifier
		/// </summary>
		public string ApplicationId { get; set; }

		/// <summary>
		/// Application Name
		/// </summary>
		public string ApplicationName { get; set; }

		/// <summary>
		/// Application Type
		/// </summary>
		public string ApplicationType { get; set; }

		/// <summary>
		/// Application Version
		/// </summary>
		public string ApplicationVersion { get; set; }

		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			var ecs = LogEventConverter.ConvertToEcs(logEvent, this);
			var output = ecs.Serialize();
			builder.Append(output);
		}
	}
}
