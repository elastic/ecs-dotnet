// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;

namespace Elastic.CommonSchema
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
					<ElasticsearchLoggerOptions, ElasticsearchLoggerProvider>>());
			return builder;
		}

		public static ILoggingBuilder AddElasticsearch(this ILoggingBuilder builder,
			Action<ElasticsearchLoggerOptions> configure
		)
		{
			if (configure == null) throw new ArgumentNullException(nameof(configure));

			builder.AddElasticsearch();
			builder.Services.Configure(configure);
			return builder;
		}
	}
}
