namespace Elastic.CommonSchema.Serilog;

/// <summary> Defines known keys and types to read from serilog properties </summary>
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
public static class SpecialProperties
{
	public class HttpContextEnrichments
	{
		public Client? Client { get; set; }
		public Http? Http { get; set; }
		public Server? Server { get; set; }
		public Url? Url { get; set; }
		public User? User { get; set; }
		public UserAgent? UserAgent { get; set; }
	}

	public static class SpecialKeys
	{
		public const string DefaultLogger = "Elastic.CommonSchema.Serilog";

		public const string SourceContext = nameof(SourceContext);
		public const string EnvironmentUserName = nameof(EnvironmentUserName);
		public const string Host = nameof(Host);
		public const string ActionCategory = nameof(ActionCategory);
		public const string ActionName = nameof(ActionName);
		public const string ActionId = nameof(ActionId);
		public const string ActionKind = nameof(ActionKind);
		public const string ActionSeverity = nameof(ActionSeverity);
		public const string EventId = nameof(EventId);
		public const string ApplicationId = nameof(ApplicationId);
		public const string ApplicationName = nameof(ApplicationName);
		public const string ApplicationType = nameof(ApplicationType);
		public const string ApplicationVersion = nameof(ApplicationVersion);
		public const string ProcessName = nameof(ProcessName);
		public const string ProcessId = nameof(ProcessId);
		public const string ThreadId = nameof(ThreadId);
		public const string MachineName = nameof(MachineName);
		public const string Elapsed = nameof(Elapsed);
		public const string ElapsedMilliseconds = nameof(ElapsedMilliseconds);
		public const string Method = nameof(Method);
		public const string RequestMethod = nameof(RequestMethod);
		public const string Path = nameof(Path);
		public const string RequestPath = nameof(RequestPath);
		public const string StatusCode = nameof(StatusCode);
		public const string Scheme = nameof(Scheme);
		public const string ContentType = nameof(ContentType);
		public const string QueryString = nameof(QueryString);
		public const string RequestId = nameof(RequestId);
		public const string HttpContext = nameof(HttpContext);

		// a known ASP.NET key we don't want to emit under labels.*
		public const string HostingRequestFinishedLog = nameof(HostingRequestFinishedLog);
	}
}
