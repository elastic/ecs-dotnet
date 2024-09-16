using System.Collections;
using System.Text;
using Elastic.CommonSchema;
using Microsoft.Extensions.Logging;

namespace Elastic.Extensions.Logging.Common;

/// <summary> </summary>
public static class LogEventBuilderExtensions
{
	/// <summary> </summary>
	public static void AddScopeValues(this LogEvent logEvent, IExternalScopeProvider? scopeProvider, ILogEventCreationOptions options)
	{
		void AddScopeValue<TLocalState>(TLocalState scope, LogEvent log)
		{
			if (scope is null) return;

			log.Labels ??= new Labels();
			log.Scopes ??= new List<string>();


			var scopeValues = (scope as IEnumerable<KeyValuePair<string, object>>)?.ToList();
			var scopeName = scopeValues != null && scopeValues.Any(kv => kv.Key == "{OriginalFormat}")
				? scope.ToString()
				: FormatValue(scope, options, 0, scope.GetType().Name);
			log.Scopes.Add(scopeName);

			if (scopeValues == null) return;

			foreach (var kvp in scopeValues)
				AssignStateOrScopeLabels(logEvent, kvp, options);
		}

		scopeProvider?.ForEachScope((o, @event) => AddScopeValue(o, @event), logEvent);
	}

	/// <summary> </summary>
	public static void AddStateValues<TState>(this LogEvent logEvent, TState state, ILogEventCreationOptions options)
	{
		if (state is not IEnumerable<KeyValuePair<string, object>> stateValues) return;

		foreach (var kvp in stateValues)
			AssignStateOrScopeLabels(logEvent, kvp, options);
	}


	private static void AssignStateOrScopeLabels(LogEvent logEvent, KeyValuePair<string, object> kvp, ILogEventCreationOptions options)
	{
		if (kvp.Key == "{OriginalFormat}")
		{
			// we explicitly want this to override, preferring OriginalFormat from current state over scope
			logEvent.MessageTemplate = kvp.Value.ToString();
			return;
		}
		var value = FormatValue(kvp.Value, options);
		if (!AssignKnownHttpKeys(logEvent, kvp.Key, value))
			logEvent.AssignField(kvp.Key, value);
	}

	private static bool AssignKnownHttpKeys(LogEvent logEvent, string key, object value)
	{
		switch (key)
		{
			case "RequestId" when value is string requestId:
				logEvent.Http ??= new Http();
				logEvent.Http.RequestId = requestId;
				return true;
			case "RequestPath" when value is string path:
				logEvent.Url ??= new Url();
				logEvent.Url.Path = path;
				return true;
			// ReSharper disable once UnusedVariable
			case "Protocol" when value is string protocol:
				// TODO protocol
				//logEvent.Http ??= new Http();
				//logEvent.Http. = requestId;
				return true;
			case "Method" when value is string method:
				logEvent.Http ??= new Http();
				logEvent.Http.RequestMethod = method;
				return true;
			case "ContentType" when value is string contentType:
				logEvent.Http ??= new Http();
				logEvent.Http.RequestMimeType = contentType;
				return true;
			case "ContentLength" when value is string contentLength:
				logEvent.Http ??= new Http();
				logEvent.Http.RequestBytes = long.TryParse(contentLength, out var l) ? l : (long?)null;
				return true;
			case "Scheme" when value is string scheme:
				logEvent.Url ??= new Url();
				logEvent.Url.Scheme = scheme;
				return true;
			case "Host" when value is string host:
				logEvent.Url ??= new Url();
				logEvent.Url.Domain = host;
				return true;
			case "Path":
			case "PathBase":
				//covered by 'RequestPath'
				return true;
			case "QueryString" when value is string qs:
				logEvent.Url ??= new Url();
				logEvent.Url.Query = qs;
				return true;
			default: return false;
		}
	}

	private static string FormatValue(object value, ILogEventCreationOptions options, int depth = 0, string? defaultFallback = null)
	{
		switch (value)
		{
			case null:
				return string.Empty;
			case byte b:
				return b.ToString("X2");
			case byte[] bytes:
				var builder = new StringBuilder("0x");
				foreach (var b in bytes) builder.Append(b.ToString("X2"));

				return builder.ToString();
			case DateTime dateTime:
				if (dateTime.TimeOfDay.Equals(TimeSpan.Zero))
					return dateTime.ToString("yyyy'-'MM'-'dd");

				return dateTime.ToString("o");
			case DateTimeOffset dateTimeOffset:
				return dateTimeOffset.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.ffffffzzz");
			case string s:
				// since 'string' implements IEnumerable, special case it
				return s;
			default:
				// need to special case dictionary before IEnumerable
				if (depth < 1 && value is IDictionary<string, object> dictionary)
					return FormatStringDictionary(dictionary, depth, options);

				// if the value implements IEnumerable, build a comma separated string
				if (depth < 1 && value is IEnumerable enumerable)
					return FormatEnumerable(enumerable, depth, options);

				return defaultFallback ?? value.ToString();
		}
	}

	private static string FormatEnumerable(IEnumerable enumerable, int depth, ILogEventCreationOptions options)
	{
		var stringBuilder = new StringBuilder();

		// The standard array.ToString() isn't very interesting, so render the elements
		depth = depth + 1;
		var index = 0;
		foreach (var item in enumerable)
		{
			if (index > 0) stringBuilder.Append(options.ListSeparator);

			var value = FormatValue(item, options, depth);
			stringBuilder.Append(value);
			index++;
		}

		return stringBuilder.ToString();
	}

	private static string FormatStringDictionary(IDictionary<string, object> dictionary, int depth, ILogEventCreationOptions options)
	{
		// The standard dictionary.ToString() isn't very interesting, so render the key-value pairs
		var stringBuilder = new StringBuilder();
		depth = depth + 1;
		var index = 0;
		foreach (var kvp in dictionary)
		{
			if (index > 0) stringBuilder.Append(" ");

			WriteName(stringBuilder, kvp.Key);
			stringBuilder.Append('=');
			stringBuilder.Append('"');
			WriteValue(stringBuilder, FormatValue(kvp.Value, options, depth));
			stringBuilder.Append('"');
			index++;
		}

		return stringBuilder.ToString();
	}

	private static void WriteName(StringBuilder stringBuilder, string name)
	{
		foreach (var c in name)
		{
			if (c == ' ')
				stringBuilder.Append('_');
			else if (c == '=')
				stringBuilder.AppendFormat("_x{0:X2}_", (int)c);
			else
				stringBuilder.Append(c);
		}
	}

	private static void WriteValue(StringBuilder stringBuilder, string value)
	{
		foreach (var c in value)
		{
			if (c == '"' || c == '\\')
			{
				stringBuilder.Append('\\');
				stringBuilder.Append(c);
			}
			else
				stringBuilder.Append(c);
		}
	}
}
