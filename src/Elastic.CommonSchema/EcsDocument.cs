// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
#if !NETFRAMEWORK
using System.Runtime.InteropServices;
#endif

namespace Elastic.CommonSchema;

/// <summary>
/// Control how <see cref="EcsDocument.CreateNewWithDefaults{TEcsDocument}"/> should enrich the newly instantiated document
/// </summary>
public interface IEcsDocumentCreationOptions
{
	/// <summary>
	/// Gets or sets a flag indicating whether host details should be included in the message. Defaults to <c>true</c>.
	/// </summary>
	public bool IncludeHost { get; set; }

	/// <summary>
	/// Gets or sets a flag indicating whether process details should be included in the message. Defaults to <c>true</c>.
	/// </summary>
	public bool IncludeProcess { get; set; }

	/// <summary>
	/// Gets or sets a flag indicating whether user details should be included in the message. Defaults to <c>true</c>.
	/// </summary>
	public bool IncludeUser { get; set; }
}

public partial class EcsDocument
{
	private static readonly Ecs EcsFieldDefault = new() { Version = Version };

	/// <summary>
	/// Create an instance of <typeparamref name="TEcsDocument"/> and enrich it with as many fields as possible.
	/// <para>use <paramref name="options"/> to control how much should be enriched</para>
	/// </summary>
	public static TEcsDocument CreateNewWithDefaults<TEcsDocument>(
		DateTimeOffset? timestamp = null,
		Exception exception = null,
		IEcsDocumentCreationOptions options = null
	)
		where TEcsDocument : EcsDocument, new()
	{
		var doc = new TEcsDocument
		{
			Timestamp = timestamp ?? DateTimeOffset.UtcNow, Ecs = EcsFieldDefault, Error = GetError(exception), Service = GetService()
		};
		SetActivityData(doc);

		if (options?.IncludeHost is null or true) doc.Host = GetHost();
		if (options?.IncludeProcess is null or true) doc.Process = GetProcess();
		if (options?.IncludeUser is null or true) doc.User = GetUser();

		return doc;
	}

	private static Service CachedService;

	private static Service GetService()
	{
		if (CachedService is not null) return CachedService;

		var entryAssembly = Assembly.GetEntryAssembly();
		var (type, version) = GetAssemblyVersion(entryAssembly);
		CachedService = new Service { Type = type, Version = version };
		return CachedService;
	}

	/// <summary>
	/// Create an instance of <see cref="Agent"/> that defaults to the assembly from
	/// <paramref name="typeFromAgentLibrary"/> as the agent in control of generating the data
	/// </summary>
	public static Agent CreateAgent(Type typeFromAgentLibrary)
	{
		var assembly = typeFromAgentLibrary.Assembly;
		var (type, version) = GetAssemblyVersion(assembly);
		return new Agent { Type = type, Version = version };
	}

	private static (string, string) GetAssemblyVersion(Assembly assembly)
	{
		var name = assembly.GetName();
		var type = name.Name;
		var versionAttribute = assembly.GetCustomAttributes(false)
			.OfType<AssemblyInformationalVersionAttribute>()
			.FirstOrDefault();
		var version = versionAttribute?.InformationalVersion ?? name.Version.ToString();
		return (type, version);
	}

	private static Host CachedHost;

	private static Host GetHost()
	{
		if (CachedHost is not null) return CachedHost;

		CachedHost = new Host
		{
			Hostname = Environment.MachineName,
#if !NETFRAMEWORK
			Architecture = RuntimeInformation.OSArchitecture.ToString(),
#endif
			Os = new Os
			{
#if !NETFRAMEWORK
				Full = RuntimeInformation.OSDescription,
#endif
				Platform = Environment.OSVersion.Platform.ToString(),
				Version = Environment.OSVersion.Version.ToString()
			}
		};

		return CachedHost;
	}

	private static bool ProcessLookupFailed;
	private static int ProcessId;
	private static string ProcessName;
	private static string MainWindowTitle;

	private static Process GetProcess()
	{
		if (ProcessName is null && !ProcessLookupFailed)
		{
			try
			{
				var process = System.Diagnostics.Process.GetCurrentProcess();
				ProcessId = process.Id;
				ProcessName = process.ProcessName;
				MainWindowTitle = process.MainWindowTitle;
			}
			catch
			{
				ProcessLookupFailed = true;
			}
		}

		var currentThread = Thread.CurrentThread;
		return new Process
		{
			Title = MainWindowTitle,
			Name = ProcessName,
			Executable = ProcessName,
			Pid = ProcessId,
			ThreadName = currentThread.Name,
			ThreadId = currentThread.ManagedThreadId
		};
	}

	private static readonly string UserName = Environment.UserName;
	private static readonly string UserDomainName = Environment.UserDomainName;

	//Can not cache current thread's identity as it's used for role based security, different threads can have different identities
	private static User GetUser() => new User { Id = Thread.CurrentPrincipal?.Identity.Name, Name = UserName, Domain = UserDomainName };

	private static Error GetError(Exception exception)
	{
		if (exception == null)
			return null;

		// see: https://github.com/elastic/apm-agent-dotnet/pull/847
		// see: https://github.com/elastic/apm-agent-dotnet/issues/6
		// Mentions observed exceptions however this extension method itself is wrapped in try/catch
		var exString = exception.ToStringDemystified();

		return new Error { Message = exception.Message, Type = exception.GetType().FullName, StackTrace = exString };
	}

	/// <summary>
	/// Mutates <paramref name="doc"/> and sets tracing information based on <paramref name="activity" /> or <see cref="Activity.Current"/>
	/// <para>Note this will not override any explicitly set properties</para>
	/// </summary>
	private static void SetActivityData(EcsDocument doc, Activity activity = null)
	{
		activity ??= Activity.Current;
		if (activity == null)
		{
			if (!Trace.CorrelationManager.ActivityId.Equals(Guid.Empty))
				doc.TraceId ??= Trace.CorrelationManager.ActivityId.ToString();
			return;
		}
		if (activity.IdFormat == ActivityIdFormat.W3C)
		{
			doc.TraceId ??= activity.TraceId.ToString();
			doc.SpanId ??= activity.SpanId.ToString();
		}
		else
		{
			if (activity.RootId != null) doc.TraceId ??= activity.RootId;
			if (activity.Id != null) doc.SpanId ??= activity.Id;
		}

		// TODO Should we copy more data over?
		// e.g can we infer OpenTelemetry resource from Activity?
		// For now we just do the minimum to enable log correlation
	}
}
