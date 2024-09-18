using Microsoft.Extensions.Logging;

namespace Elastic.Extensions.Logging.Console;

/// <summary> Extensions to <see cref="ILoggingBuilder"/> to ease setting up ECS formatted logs to console. </summary>
public static class LoggingBuilderExtensions
{
	/// <summary> Adds ECS output to console output</summary>
	public static ILoggingBuilder AddEcsConsole(this ILoggingBuilder builder, Action<EcsConsoleFormatterOptions>? configure = null, LogLevel stdErrorThreshold = LogLevel.Warning)
	{
		builder.AddConsole(c=>
		{
			c.FormatterName = "ecs";
			c.LogToStandardErrorThreshold = stdErrorThreshold;
		});
		builder.AddConsoleFormatter<EcsConsoleFormatter, EcsConsoleFormatterOptions>(configure ?? (_ => { }));
		return builder;
	}
}
