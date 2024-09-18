using Microsoft.Extensions.Configuration;

namespace Elastic.Serilog.Sinks.Tests;

internal static class ConfigurationBuilderExtensions
{
	public static IConfigurationBuilder AddJsonString(this IConfigurationBuilder builder, string json) =>
		builder.Add(new JsonStringConfigSource(json));
}
