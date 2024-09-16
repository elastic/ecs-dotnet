using Microsoft.Extensions.Logging;

namespace Elastic.Extensions.Logging.Console;

/// <summary> Extensions to <see cref="ILoggingBuilder"/> to ease setting up ECS formatted logs to console. </summary>
public static class LoggingBuilderExtensions
{
	/// <summary> Adds ECS output to console output</summary>
	public static ILoggingBuilder AddEcsConsole(this ILoggingBuilder builder, LogLevel stdErrorThreshold = LogLevel.Warning, Action<EcsConsoleFormatterOptions>? configure = null)
	{
		builder.AddConsole(c=>
		{
			c.FormatterName = "ecs";
			c.LogToStandardErrorThreshold = LogLevel.Warning;
		});
		builder.AddConsoleFormatter<EcsConsoleFormatter, EcsConsoleFormatterOptions>(configure ?? (_ => { }));
		return builder;
	}

	/// <summary> Adds ECS output to console output</summary>
	public static ILoggingBuilder AddEcsConsole(this ILoggingBuilder builder, Action<EcsConsoleFormatterOptions>? configure = null) =>
		builder.AddEcsConsole(LogLevel.Warning, configure);
}
