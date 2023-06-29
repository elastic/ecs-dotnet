// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using static System.StringSplitOptions;
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
	bool IncludeHost { get; set; }

	/// <summary>
	/// Gets or sets a flag indicating whether process details should be included in the message. Defaults to <c>true</c>.
	/// </summary>
	bool IncludeProcess { get; set; }

	/// <summary>
	/// Gets or sets a flag indicating whether user details should be included in the message. Defaults to <c>true</c>.
	/// </summary>
	bool IncludeUser { get; set; }
}

/// <summary>
/// A bucket to optionally provide <see cref="EcsDocument.CreateNewWithDefaults{TEcsDocument}"/> a 'local' version to cache
/// various ECS fields. This allows you to cache-bust any default caching the method does out-of-the-box.
/// <para>If any of the properties are null they will be set by <see cref="EcsDocument.CreateNewWithDefaults{TEcsDocument}"/></para>
/// </summary>
public sealed class EcsDocumentCreationCache
{
	/// <summary> Cached <see cref="Host"/> for reuse </summary>
	public Host? Host { get; set; }
	/// <summary> Cached <see cref="Service"/> for reuse </summary>
	public Service? Service { get; set; }
	/// <summary> Cached <see cref="Process"/> for reuse </summary>
	public Process? Process { get; set; }
	/// <summary> Cached <see cref="Ecs"/> for reuse </summary>
	public Ecs Ecs { get; } = new() { Version = EcsDocument.Version };

	/// <summary> Cached parsed OpenTelemetry resource attributes </summary>
	public IDictionary<string, string>? OTelResourceAttributes { get; set; }
}

public partial class EcsDocument
{
	private static readonly EcsDocumentCreationCache DefaultCache = new()
	{
		OTelResourceAttributes = GetOTelResourceAttributes()
	};

	/// <summary>
	/// Create an instance of <typeparamref name="TEcsDocument"/> and enrich it with as many fields as possible.
	/// <para>use <paramref name="options"/> to control how much should be enriched</para>
	/// </summary>
	public static TEcsDocument CreateNewWithDefaults<TEcsDocument>(
		DateTimeOffset? timestamp = null,
		Exception? exception = null,
		IEcsDocumentCreationOptions? options = null,
		EcsDocumentCreationCache? initialCache = null
	)
		where TEcsDocument : EcsDocument, new()
	{
		initialCache ??= DefaultCache;
		initialCache.OTelResourceAttributes ??= GetOTelResourceAttributes();

		var doc = new TEcsDocument
		{
			Timestamp = timestamp ?? DateTimeOffset.UtcNow,
			Ecs = initialCache.Ecs,
			Error = GetError(exception),
			Service = GetService(initialCache)
		};
		SetActivityData(doc);

		if (options?.IncludeHost is null or true) doc.Host = GetHost(initialCache);
		if (options?.IncludeProcess is null or true) doc.Process = GetProcess(initialCache);
		if (options?.IncludeUser is null or true) doc.User = GetUser();

		return doc;
	}

	internal static IDictionary<string, string> GetOTelResourceAttributes()
	{
		var resourceAttributes = Environment.GetEnvironmentVariable("OTEL_RESOURCE_ATTRIBUTES");
		return ParseOTelResourceAttributes(resourceAttributes);
	}

	private static IDictionary<string, string> ParseOTelResourceAttributes(string resourceAttributes)
	{
		if (string.IsNullOrEmpty(resourceAttributes)) return new Dictionary<string, string>();

		var keyValues = resourceAttributes
			.Split(new[] { ',' }, RemoveEmptyEntries)
			.Select(k => k.Split(new[] { '=' }, 2, RemoveEmptyEntries))
			.Where(kv => kv.Length == 2)
			.ToDictionary(kv => kv[0].Trim().ToLowerInvariant(), kv => kv[1].Trim());

		return keyValues;
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

	private static Host GetHost(EcsDocumentCreationCache cache)
	{
		if (cache.Host is not null) return cache.Host;

		var hostName = Environment.MachineName;
		var apmHostName = Environment.GetEnvironmentVariable("ELASTIC_APM_HOST_NAME");
		var resourceAttributes = cache.OTelResourceAttributes ?? new Dictionary<string, string>();
		if (resourceAttributes.TryGetValue("host.name", out var resourceHostName))
			hostName = resourceHostName;
		else if (!string.IsNullOrWhiteSpace(apmHostName))
			hostName = apmHostName;

		var host = new Host
		{
			Hostname = hostName,
#if !NETFRAMEWORK
			Architecture = RuntimeInformation.OSArchitecture.ToString(),
#endif
			Os = new Os
			{
#if !NETFRAMEWORK
				Full = RuntimeInformation.OSDescription,
#endif
				Platform = Environment.OSVersion.Platform.ToString(), Version = Environment.OSVersion.Version.ToString()
			}
		};
		if (resourceAttributes.TryGetValue("host.type", out var hostType))
			host.Type = hostType;
		if (resourceAttributes.TryGetValue("host.arch", out var hostArch))
			host.Architecture = hostArch;

		cache.Host = host;
		return cache.Host;
	}

	private static bool ProcessLookupFailed;

	private static Process? GetProcess(EcsDocumentCreationCache cache)
	{
		Process ReturnFromCache()
		{
			var thread = Thread.CurrentThread;
			return new Process
			{
				Title = cache.Process.Title,
				Name = cache.Process.Name,
				Executable = cache.Process.Executable,
				Pid = cache.Process.Pid,
				ThreadName = thread.Name,
				ThreadId = thread.ManagedThreadId
			};
		}

		if (cache.Process is not null) return ReturnFromCache();
		if (ProcessLookupFailed) return null;

		try
		{
			var p = System.Diagnostics.Process.GetCurrentProcess();
			cache.Process = new Process { Title = p.MainWindowTitle, Name = p.ProcessName, Pid = p.Id, };
			return ReturnFromCache();
		}
		catch
		{
			ProcessLookupFailed = true;
		}
		return null;
	}

	private static readonly string UserName = Environment.UserName;
	private static readonly string UserDomainName = Environment.UserDomainName;

	//Can not cache current thread's identity as it's used for role based security, different threads can have different identities
	private static User GetUser() => new () { Id = Thread.CurrentPrincipal?.Identity.Name, Name = UserName, Domain = UserDomainName };

	private static Error? GetError(Exception? exception)
	{
		if (exception == null) return null;

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
	private static void SetActivityData(EcsDocument doc, Activity? activity = null)
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
