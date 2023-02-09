using Microsoft.Extensions.Logging;

namespace Elasticsearch.Extensions.Logging
{
	internal static class LogEventToEcsHelper
	{
		public static int GetSeverity(LogLevel logLevel) =>
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

		public static string GetLogLevelString(LogLevel logLevel) =>
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
