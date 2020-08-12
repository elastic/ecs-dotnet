// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;
using Elastic.Ingest;

namespace Elasticsearch.Extensions.Logging
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

		public static ILoggingBuilder AddElasticsearch(this ILoggingBuilder builder, Action<ElasticsearchLoggerOptions> configure)
		{
			if (configure == null) throw new ArgumentNullException(nameof(configure));

			builder.AddElasticsearch();
			builder.Services.Configure(configure);
			return builder;
		}

		public static ILoggingBuilder AddElasticCloud(this ILoggingBuilder builder, string cloudId, string apiKey)
		{
			if (string.IsNullOrEmpty(cloudId))
				throw new ArgumentException("cloudId may not be empty.", nameof(cloudId));

			if (string.IsNullOrEmpty(apiKey))
				throw new ArgumentException("apiKey may not be empty.", nameof(apiKey));

			builder.AddElasticsearch();

			void configure(ElasticsearchLoggerOptions options)
			{
				options.ShipTo = new ShipTo(cloudId, apiKey);
			}

			builder.Services.Configure((Action<ElasticsearchLoggerOptions>)configure);
			return builder;
		}

		public static ILoggingBuilder AddElasticCloud(this ILoggingBuilder builder, string cloudId, string username, string password)
		{
			if (string.IsNullOrEmpty(cloudId))
				throw new ArgumentException("cloudId may not be empty.", nameof(cloudId));

			if (string.IsNullOrEmpty(username))
				throw new ArgumentException("username may not be empty.", nameof(username));

			if (string.IsNullOrEmpty(password))
				throw new ArgumentException("password may not be empty.", nameof(password));

			builder.AddElasticsearch();

			void configure(ElasticsearchLoggerOptions options)
			{
				options.ShipTo = new ShipTo(cloudId, username, password);
			}

			builder.Services.Configure((Action<ElasticsearchLoggerOptions>)configure);
			return builder;
		}
	}
}
