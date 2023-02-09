// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

namespace Elastic.CommonSchema.Serilog;

internal static class SpecialKeys
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
