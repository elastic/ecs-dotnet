using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace Elastic.CommonSchema;

public partial class EcsDocument
{
	private static Service CachedService;

	private static Service GetService()
	{
		if (CachedService is not null) return CachedService;

		var entryAssembly = GetEntryAssembly();
		var serviceName = DiscoverDefaultServiceName(entryAssembly);
		var serviceVersion = DiscoverServiceVersion(entryAssembly);
		CachedService = new Service { Name = serviceName, Version = serviceVersion, Type = "dotnet"};
		return CachedService;
	}

	internal static string DiscoverDefaultServiceName(Assembly entryAssembly)
	{
		var name = entryAssembly?.GetName().Name;
		if (name != null) return name;

		var stackFrames = new StackTrace().GetFrames();
		if (stackFrames == null) return null;

		var assemblyNamesOnStack =
			from frame in stackFrames
			let nameOnStack = frame?.GetMethod()?.DeclaringType?.Assembly.GetName()
			where nameOnStack != null && !IsMsOrElastic(nameOnStack.GetPublicKeyToken())
			select nameOnStack.Name;

		return assemblyNamesOnStack.FirstOrDefault();
	}

	private static string DiscoverServiceVersion(Assembly entryAssembly)
	{
		if (entryAssembly != null && !IsMsOrElastic(entryAssembly.GetName().GetPublicKeyToken()))
			return entryAssembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion;

		return null;
	}

	private static Assembly GetEntryAssembly()
	{
		var entryAssembly = Assembly.GetEntryAssembly();
		var entryAssemblyName = entryAssembly?.GetName();
		if (entryAssemblyName != null && !IsMsOrElastic(entryAssemblyName.GetPublicKeyToken()))
			return entryAssembly;

		return null;
	}


	internal static bool IsMsOrElastic(byte[] array)
	{
		var elasticToken = new byte[] { 174, 116, 0, 210, 193, 137, 207, 34 };
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
			if (array[i] != elasticToken[i])
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
