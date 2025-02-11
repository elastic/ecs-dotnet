using Elastic.CommonSchema;
using Microsoft.Extensions.Logging;

namespace Elastic.Extensions.Logging.Common
{
	/// <summary> Extensions for <see cref="LogLevel"/> so they can be projected into ECS format in different formats </summary>
	public static class LogLevelExtensions
	{
		/// <summary> projects to <see cref="LogTemplateProperties.EventSeverity"/></summary>
		public static int ToEcsSeverity(this LogLevel logLevel) =>
			logLevel switch
			{
				LogLevel.Critical => 2,
				LogLevel.Error => 3,
				LogLevel.Warning => 4,
				LogLevel.Information => 6,
				LogLevel.Trace => 7,
				LogLevel.Debug => 7,
				LogLevel.None => 8,
				_ => 7
			};

		/// <summary> projects to <see cref="LogTemplateProperties.LogLevel"/></summary>
		public static string ToEcsLogLevelString(this LogLevel logLevel) =>
			logLevel switch
			{
				LogLevel.Critical => nameof(LogLevel.Critical),
				LogLevel.Error => nameof(LogLevel.Error),
				LogLevel.Warning => nameof(LogLevel.Warning),
				LogLevel.Information => nameof(LogLevel.Information),
				LogLevel.Trace => nameof(LogLevel.Trace),
				LogLevel.Debug => nameof(LogLevel.Debug),
				LogLevel.None => nameof(LogLevel.None),
				_ => "Unknown"
			};

	}
}
