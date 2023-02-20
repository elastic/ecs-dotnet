// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using Elastic.Ingest.Elasticsearch;
using Elastic.Transport;
using Elasticsearch.Extensions.Logging.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;

namespace Elasticsearch.Extensions.Logging
{
	/// <summary>
	/// Provides builder extension methods to <see cref="ILoggingBuilder"/>
	/// </summary>
	public static class LoggingBuilderExtensions
	{
		/// <summary>
		/// Log to Elastic Cloud ( https://cloud.elastic.co/ )
		/// <para>using <paramref name="cloudId"/> to describe your running instance.</para>
		/// <para>Using <paramref name="apiKey"/> for authentication</para>
		/// </summary>
		// ReSharper disable once UnusedMember.Global
		public static ILoggingBuilder AddElasticCloud(this ILoggingBuilder builder, string cloudId, string apiKey)
		{
			if (string.IsNullOrEmpty(cloudId))
				throw new ArgumentException("cloudId may not be empty.", nameof(cloudId));

			if (string.IsNullOrEmpty(apiKey))
				throw new ArgumentException("apiKey may not be empty.", nameof(apiKey));

			builder.AddElasticsearch();

			void configure(ElasticsearchLoggerOptions options)
			{
				options.ShipTo.NodePoolType = NodePoolType.Cloud;
				options.ShipTo.CloudId = cloudId;
				options.ShipTo.ApiKey = apiKey;
			}

			builder.Services.Configure((Action<ElasticsearchLoggerOptions>)configure);
			return builder;
		}

		/// <summary>
		/// Log to Elastic Cloud ( https://cloud.elastic.co/ )
		/// <para>using <paramref name="cloudId"/> to describe your running instance.</para>
		/// <para>Using <paramref name="username"/> and <paramref name="password"/> for basic authentication</para>
		/// </summary>
		// ReSharper disable once UnusedMember.Global
		// ReSharper disable once UnusedMember.Global
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
				options.ShipTo.NodePoolType = NodePoolType.Cloud;
				options.ShipTo.CloudId = cloudId;
				options.ShipTo.Username = username;
				options.ShipTo.Password = password;
			}

			builder.Services.Configure((Action<ElasticsearchLoggerOptions>)configure);
			return builder;
		}

		/// <summary>
		/// Log to Elasticsearch
		/// <para>This overload will use the configured options provider to configure the output</para>
		/// </summary>
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

		/// <summary>
		/// Log to Elasticsearch
		/// <para>This overload will use the configured options provider to configure the output</para>
		/// <para>Further configuration can be provided through the <paramref name="configure"/> parameter</para>
		/// </summary>
		public static ILoggingBuilder AddElasticsearch(this ILoggingBuilder builder, Action<ElasticsearchLoggerOptions> configure)
		{
			if (configure == null) throw new ArgumentNullException(nameof(configure));

			builder.AddElasticsearch();
			builder.Services.Configure(configure);
			return builder;
		}

		/// <summary>
		/// Log to Elasticsearch
		/// <para>This overload will use the configured options provider to configure the output</para>
		/// <para>Further configuration can be provided through the <paramref name="configure"/> parameter</para>
		/// <para>Expert channel configuration can be provided to the <paramref name="configureChannel"/> parameter</para>
		/// </summary>
		public static ILoggingBuilder AddElasticsearch(this ILoggingBuilder builder, Action<ElasticsearchLoggerOptions> configure,
			Action<ElasticsearchChannelOptionsBase<LogEvent>> configureChannel
		)
		{
			if (configure == null) throw new ArgumentNullException(nameof(configure));
			if (configureChannel == null) throw new ArgumentNullException(nameof(configureChannel));

			builder.AddElasticsearch();
			builder.Services.Configure(configure);
			builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IChannelSetup>(new ChannelSetup(configureChannel)));
			return builder;
		}

		/// <summary>
		/// Log to Elasticsearch
		/// <para>This overload also allows you to reuse an instance of <see cref="HttpTransport"/></para>
		/// <para>Further configuration can be provided through the <paramref name="configure"/> parameter</para>
		/// <para>Expert channel configuration can be provided to the <paramref name="configureChannel"/> parameter</para>
		/// </summary>
		public static ILoggingBuilder AddElasticsearch(
			this ILoggingBuilder builder,
			HttpTransport transport,
			Action<ElasticsearchLoggerOptions>? configure = null,
			Action<ElasticsearchChannelOptionsBase<LogEvent>>? configureChannel = null
		)
		{
			builder.AddElasticsearch();
			builder.Services.Configure<ElasticsearchLoggerOptions>(opts =>
			{
				opts.Transport = transport;
				configure?.Invoke(opts);
			});
			configureChannel ??= b => { };
			builder.Services.TryAddEnumerable(ServiceDescriptor.Singleton<IChannelSetup>(new ChannelSetup(configureChannel)));
			return builder;
		}
	}
}
