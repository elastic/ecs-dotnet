using System.Buffers;
using System.IO;
using System.Text;
using NLog;
using NLog.LayoutRenderers;

namespace Elastic.CommonSchema
{
	[LayoutRenderer("ecs")]
	public class EcsLayoutRenderer : LayoutRenderer
	{
		public const string DefaultLogger = "Elastic.CommonSchema.NLog";

		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			var ecs = new Base
			{
				Timestamp = logEvent.TimeStamp,
				Message = logEvent.FormattedMessage,
				Log = new Log
				{
					Level = logEvent.Level.ToString(),
					Logger = DefaultLogger,
					Original = logEvent.Message,
				}
			};

			var output = ecs.Serialize();
			builder.Append(output);
		}
	}
}
