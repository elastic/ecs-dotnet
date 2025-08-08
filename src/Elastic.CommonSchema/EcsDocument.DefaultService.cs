using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace Elastic.CommonSchema;

public partial class EcsDocument
{
	private static Service GetService(EcsDocumentCreationCache cache)
	{
		if (cache.Service is not null) return cache.Service;

		var entryAssembly = GetEntryAssembly();
		var serviceName = DiscoverDefaultServiceName(entryAssembly);
		var serviceVersion = DiscoverServiceVersion(entryAssembly);
		var service = new Service { Name = serviceName, Version = serviceVersion, Type = "dotnet"};
		var resourceAttributes = cache.OTelResourceAttributes ?? new Dictionary<string, string>();
		UpdateServiceWithEnvironmentConfig(service, resourceAttributes);
		cache.Service = service;
		return cache.Service;
	}

	private static void UpdateServiceWithEnvironmentConfig(Service service, IDictionary<string, string> resourceAttributes)
	{
		//ServiceName
		var oTelServiceName = Environment.GetEnvironmentVariable("OTEL_SERVICE_NAME");
		var apmServiceName = Environment.GetEnvironmentVariable("ELASTIC_APM_SERVICE_NAME");
		if (!string.IsNullOrEmpty(oTelServiceName))
			service.Name = oTelServiceName;
		else if (resourceAttributes.TryGetValue("service.name", out var resourceServiceName))
			service.Name = resourceServiceName;
		else if (!string.IsNullOrEmpty(apmServiceName))
			service.Name = apmServiceName;

		//ServiceVersion
		var apmServiceVersion = Environment.GetEnvironmentVariable("ELASTIC_APM_SERVICE_VERSION");
		if (resourceAttributes.TryGetValue("service.version", out var resourceServiceVersion))
			service.Version = resourceServiceVersion;
		else if (!string.IsNullOrEmpty(apmServiceVersion))
			service.Version = apmServiceVersion;

		//ServiceNodeName
		var apmServiceNodeName = Environment.GetEnvironmentVariable("ELASTIC_APM_SERVICE_NODE_NAME");
		if (resourceAttributes.TryGetValue("service.instance.id", out var resourceServiceNodeName))
			service.NodeName = resourceServiceNodeName;
		else if (!string.IsNullOrEmpty(apmServiceNodeName))
			service.NodeName = apmServiceNodeName;

		// Environment
		var apmEnvironment = Environment.GetEnvironmentVariable("ELASTIC_APM_ENVIRONMENT");
		if (resourceAttributes.TryGetValue("deployment.environment", out var resourceEnvironment))
			service.Environment = resourceEnvironment;
		else if (!string.IsNullOrWhiteSpace(apmEnvironment))
			service.Environment = apmEnvironment;
	}

	internal static string? DiscoverDefaultServiceName(Assembly? entryAssembly)
	{
		var name = entryAssembly?.GetName().Name;
		return name;
	}

	private static string? DiscoverServiceVersion(Assembly? entryAssembly) =>
		entryAssembly is not null && !IsMsOrElastic(entryAssembly.GetName().GetPublicKeyToken())
			? entryAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion
			: null;

	[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "We always provide a static JsonTypeInfoResolver")]
	[UnconditionalSuppressMessage("AotAnalysis", "IL3050:RequiresDynamicCode", Justification = "We always provide a static JsonTypeInfoResolver")]
	private static Assembly? GetEntryAssembly()
	{
		var entryAssembly = Assembly.GetEntryAssembly();
		var entryAssemblyName = entryAssembly?.GetName();
		if (entryAssemblyName != null && !IsMsOrElastic(entryAssemblyName.GetPublicKeyToken()))
			return entryAssembly;

		var stackFrames = new StackTrace().GetFrames();
		if (stackFrames == null) return null;

		var assemblies =
			from frame in stackFrames
			let assembly = frame?.GetMethod()?.DeclaringType?.Assembly
			where assembly != null
			let bytes = assembly.GetName()?.GetPublicKeyToken()
			where bytes != null && !IsMsOrElastic(bytes)
			select assembly;

		return assemblies.FirstOrDefault();
	}


	internal static bool IsMsOrElastic(byte[]? array)
	{
		if (array == null) return false;

		var elasticApmToken = new byte[] { 174, 116, 0, 210, 193, 137, 207, 34 };
		var mscorlibToken = new byte[] { 183, 122, 92, 86, 25, 52, 224, 137 };
		var systemWebToken = new byte[] { 176, 63, 95, 127, 17, 213, 10, 58 };
		var systemPrivateCoreLibToken = new byte[] { 124, 236, 133, 215, 190, 167, 121, 142 };
		var msAspNetCoreHostingToken = new byte[] { 173, 185, 121, 56, 41, 221, 174, 96 };

		if (array.Length != 8)
			return false;

		var isMsCorLib = true;
		var isElasticApm = true;
		var isSystemWeb = true;
		var isSystemPrivateCoreLib = true;
		var isMsAspNetCoreHosting = true;

		for (var i = 0; i < 8; i++)
		{
			if (array[i] != elasticApmToken[i])
				isElasticApm = false;
			if (array[i] != mscorlibToken[i])
				isMsCorLib = false;
			if (array[i] != systemWebToken[i])
				isSystemWeb = false;
			if (array[i] != systemPrivateCoreLibToken[i])
				isSystemPrivateCoreLib = false;
			if (array[i] != msAspNetCoreHostingToken[i])
				isMsAspNetCoreHosting = false;

			if (!isMsCorLib && !isElasticApm && !isSystemWeb && !isSystemPrivateCoreLib && !isMsAspNetCoreHosting)
				return false;
		}

		return true;
	}

}
