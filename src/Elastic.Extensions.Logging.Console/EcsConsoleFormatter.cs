using Elastic.CommonSchema;
using Elastic.Extensions.Logging.Common;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Options;

namespace Elastic.Extensions.Logging.Console;

/// <summary></summary>
public sealed class EcsConsoleFormatter : ConsoleFormatter, IDisposable
{
	private readonly IDisposable? _optionsReloadToken;
	private EcsConsoleFormatterOptions _options;

	private static Agent? DefaultAgent { get; } = EcsDocument.CreateAgent(typeof(EcsConsoleFormatter));

	/// <summary></summary>
	public EcsConsoleFormatter(IOptionsMonitor<EcsConsoleFormatterOptions> options) : base("ecs") =>
		(_optionsReloadToken, _options) = (options.OnChange(ReloadLoggerOptions), options.CurrentValue);

	private void ReloadLoggerOptions(EcsConsoleFormatterOptions options) =>
		_options = options;

	/// <summary></summary>
	public override void Write<TState>(in LogEntry<TState> logEntry, IExternalScopeProvider? scopeProvider, TextWriter textWriter)
	{
		var now = DateTime.UtcNow;
		var message = logEntry.Formatter?.Invoke(logEntry.State, logEntry.Exception);
		if (message is null)
			return;

		var logEvent = EcsDocument.CreateNewWithDefaults<LogEvent>(now, logEntry.Exception, _options);
		var logLevel = logEntry.LogLevel;
		var categoryName = logEntry.Category;
		var eventId = logEntry.EventId;
		logEvent.Log = new Log { Level = logLevel.ToEcsLogLevelString(), Logger = categoryName };
		logEvent.Event = new Event { Action = eventId.Name, Code = eventId.Id.ToString(), Severity = logLevel.ToEcsSeverity() };
		logEvent.Message = message;

		logEvent.Agent = DefaultAgent;

		if (_options.Tags is { Length: > 0 }) logEvent.Tags = _options.Tags;

		if (_options.IncludeScopes)
			logEvent.AddScopeValues(scopeProvider, _options);

		// These will overwrite any scope values with the same name
		logEvent.AddStateValues(logEntry.State, _options);

		textWriter.WriteLine(logEvent.Serialize());
	}

	/// <summary></summary>
	public void Dispose() => _optionsReloadToken?.Dispose();
}
