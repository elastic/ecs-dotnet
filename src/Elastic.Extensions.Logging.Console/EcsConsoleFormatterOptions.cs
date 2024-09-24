using Elastic.CommonSchema;
using Elastic.Extensions.Logging.Common;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Elastic.Extensions.Logging.Console;

/// <summary>  </summary>
public class EcsConsoleFormatterOptions : ConsoleFormatterOptions, ILogEventCreationOptions<LogEvent>
{
	/// <inheritdoc cref="IEcsDocumentCreationOptions.IncludeHost"/>
	public bool IncludeHost { get; set; } = true;

	/// <inheritdoc cref="IEcsDocumentCreationOptions.IncludeProcess"/>
	public bool IncludeProcess { get; set; } = true;

	/// <inheritdoc cref="IEcsDocumentCreationOptions.IncludeUser"/>
	public bool IncludeUser { get; set; } = true;

	/// <inheritdoc cref="IEcsDocumentCreationOptions.IncludeActivityData"/>
	public bool IncludeActivityData { get; set; } = true;

	/// <inheritdoc cref="ILogEventCreationOptions.Tags"/>
	public string[]? Tags { get; set; }

	/// <inheritdoc cref="ILogEventCreationOptions.ListSeparator"/>
	public string ListSeparator { get; set; } = ", ";

	/// <inheritdoc cref="ILogEventCreationOptions{TEcsDocument}.MapCustom"/>
	public Action<LogEvent>? MapCustom { get; set; }
}
