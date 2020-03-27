using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;

namespace Essential.LoggerProvider
{
    public static class LoggingBuilderExtensions
    {
        public static ILoggingBuilder AddElasticsearch(this ILoggingBuilder builder)
        {
            builder.Services.TryAddEnumerable(ServiceDescriptor
                .Singleton<ILoggerProvider, ElasticsearchLoggerProvider>());
            builder.Services.TryAddEnumerable(ServiceDescriptor
                .Singleton<IConfigureOptions<ElasticsearchLoggerOptions>, ElasticsearchLoggerOptionsSetup>());
            builder.Services.TryAddEnumerable(ServiceDescriptor
                .Singleton<IOptionsChangeTokenSource<ElasticsearchLoggerOptions>, LoggerProviderOptionsChangeTokenSource
                    <
                        ElasticsearchLoggerOptions, ElasticsearchLoggerProvider>>());
            return builder;
        }

        public static ILoggingBuilder AddElasticsearch(this ILoggingBuilder builder,
            Action<ElasticsearchLoggerOptions> configure)
        {
            if (configure == null) throw new ArgumentNullException(nameof(configure));

            builder.AddElasticsearch();
            builder.Services.Configure(configure);
            return builder;
        }
    }
}
