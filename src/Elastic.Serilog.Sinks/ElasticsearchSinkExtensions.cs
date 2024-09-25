using System;
using System.Collections.Generic;
using Elastic.CommonSchema;
using Elastic.Transport;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;

namespace Elastic.Serilog.Sinks
{
	/// <summary>
	/// Extension methods on <see cref="LoggerSinkConfiguration"/> to aid with serilog log configuration building
	/// </summary>
	public static class ElasticsearchSinkExtensions
	{
		/// <summary>
		/// Write logs directly to Elasticsearch.
		/// <para>Use <paramref name="loggerConfiguration"/> configure where and how data should be written</para>
		/// </summary>
		public static LoggerConfiguration Elasticsearch(this LoggerSinkConfiguration loggerConfiguration, ElasticsearchSinkOptions? options = null) =>
			loggerConfiguration.Sink(
				new ElasticsearchSink(options ?? new ElasticsearchSinkOptions())
				, restrictedToMinimumLevel: options?.MinimumLevel ?? LevelAlias.Minimum
				, levelSwitch: options?.LevelSwitch
			);

		/// <summary>
		/// Write logs directly to Elasticsearch.
		/// <para>Use <paramref name="loggerConfiguration"/> configure where and how data should be written</para>
		/// <para>This generic overload using <typeparamref name="TEcsDocument"/> allows you to use your own <see cref="EcsDocument"/> subclasses</para>
		/// </summary>
		public static LoggerConfiguration Elasticsearch<TEcsDocument>(this LoggerSinkConfiguration loggerConfiguration, ElasticsearchSinkOptions<TEcsDocument>? options = null)
			where TEcsDocument : EcsDocument, new() =>
			loggerConfiguration.Sink(
				new ElasticsearchSink<TEcsDocument>(options ?? new ElasticsearchSinkOptions<TEcsDocument>())
				, restrictedToMinimumLevel: options?.MinimumLevel ?? LevelAlias.Minimum
				, levelSwitch: options?.LevelSwitch
			);

		/// <summary>
		/// Write logs directly to Elasticsearch.
		/// <para>This overload makes it easy to directly specify the endpoint <paramref name="nodes"/></para>
		/// <para>Use <paramref name="loggerConfiguration"/> configure where and how data should be written</para>
		/// </summary>
		public static LoggerConfiguration Elasticsearch(
			this LoggerSinkConfiguration loggerConfiguration,
			ICollection<Uri> nodes,
			Action<ElasticsearchSinkOptions>? configureOptions = null,
			Action<TransportConfiguration>? configureTransport = null,
			bool useSniffing = false,
			LoggingLevelSwitch? levelSwitch = null,
			LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum
		)
		{
			var transportConfig = useSniffing ? TransportHelper.Sniffing(nodes) : TransportHelper.Static(nodes) ;
			configureTransport?.Invoke(transportConfig);

			var sinkOptions = new ElasticsearchSinkOptions(new DistributedTransport(transportConfig));
			configureOptions?.Invoke(sinkOptions);

			return loggerConfiguration.Sink(new ElasticsearchSink(sinkOptions), restrictedToMinimumLevel, levelSwitch);
		}

		/// <summary>
		/// Write logs directly to Elasticsearch.
		/// <para>This overload makes it easy to directly specify the endpoint <paramref name="nodes"/></para>
		/// <para>Use <paramref name="loggerConfiguration"/> configure where and how data should be written</para>
		/// <para>This generic overload using <typeparamref name="TEcsDocument"/> allows you to use your own <see cref="EcsDocument"/> subclasses</para>
		/// </summary>
		public static LoggerConfiguration Elasticsearch<TEcsDocument>(
			this LoggerSinkConfiguration loggerConfiguration,
			ICollection<Uri> nodes,
			Action<ElasticsearchSinkOptions<TEcsDocument>>? configureOptions = null,
			Action<TransportConfiguration>? configureTransport = null,
			bool useSniffing = false,
			LoggingLevelSwitch? levelSwitch = null,
			LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum
		) where TEcsDocument : EcsDocument, new()
		{
			var transportConfig = useSniffing ? TransportHelper.Sniffing(nodes) :  TransportHelper.Static(nodes);
			configureTransport?.Invoke(transportConfig);
			var sinkOptions = new ElasticsearchSinkOptions<TEcsDocument>(new DistributedTransport(transportConfig));
			configureOptions?.Invoke(sinkOptions);

			return loggerConfiguration.Sink(new ElasticsearchSink<TEcsDocument>(sinkOptions), restrictedToMinimumLevel, levelSwitch);
		}

		/// <summary>
		/// Write logs directly to Elastic Cloud ( https://cloud.elastic.co/ ).
		/// <para><paramref name="cloudId"/> describes your deployments endpoints (can be found in the Admin Console)</para>
		/// <para><paramref name="apiKey"/> is used for authentication.</para>
		/// <para>Use <paramref name="loggerConfiguration"/> configure where and how data should be written</para>
		/// </summary>
		public static LoggerConfiguration ElasticCloud(
			this LoggerSinkConfiguration loggerConfiguration,
			string cloudId,
			string apiKey,
			Action<ElasticsearchSinkOptions>? configureOptions = null,
			Action<TransportConfiguration>? configureTransport = null,
			LoggingLevelSwitch? levelSwitch = null,
			LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum
		)
		{
			var transportConfig = TransportHelper.Cloud(cloudId, apiKey);
			configureTransport?.Invoke(transportConfig);
			var sinkOptions = new ElasticsearchSinkOptions(new DistributedTransport(transportConfig));
			configureOptions?.Invoke(sinkOptions);

			return loggerConfiguration.Sink(new ElasticsearchSink(sinkOptions), restrictedToMinimumLevel, levelSwitch);
		}

		/// <summary>
		/// Write logs directly to Elastic Cloud ( https://cloud.elastic.co/ ).
		/// <para><paramref name="cloudId"/> describes your deployments endpoints (can be found in the Admin Console)</para>
		/// <para><paramref name="apiKey"/> is used for authentication.</para>
		/// <para>Use <paramref name="loggerConfiguration"/> configure where and how data should be written</para>
		/// <para>This generic overload using <typeparamref name="TEcsDocument"/> allows you to use your own <see cref="EcsDocument"/> subclasses</para>
		/// </summary>
		public static LoggerConfiguration ElasticCloud<TEcsDocument>(
			this LoggerSinkConfiguration loggerConfiguration,
			string cloudId,
			string apiKey,
			Action<ElasticsearchSinkOptions<TEcsDocument>>? configureOptions = null,
			Action<TransportConfiguration>? configureTransport = null,
			LoggingLevelSwitch? levelSwitch = null,
			LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum
		) where TEcsDocument : EcsDocument, new()
		{
			var transportConfig = TransportHelper.Cloud(cloudId, apiKey);
			configureTransport?.Invoke(transportConfig);
			var sinkOptions = new ElasticsearchSinkOptions<TEcsDocument>(new DistributedTransport(transportConfig));
			configureOptions?.Invoke(sinkOptions);

			return loggerConfiguration.Sink(new ElasticsearchSink<TEcsDocument>(sinkOptions), restrictedToMinimumLevel, levelSwitch);
		}

		/// <summary>
		/// Write logs directly to Elastic Cloud ( https://cloud.elastic.co/ ).
		/// <para><paramref name="cloudId"/> describes your deployments endpoints (can be found in the Admin Console)</para>
		/// <para><paramref name="username"/> and <paramref name="password"/> are used for basic authentication.</para>
		/// <para>Use <paramref name="loggerConfiguration"/> configure where and how data should be written</para>
		/// </summary>
		public static LoggerConfiguration ElasticCloud(
			this LoggerSinkConfiguration loggerConfiguration,
			string cloudId,
			string username,
			string password,
			Action<ElasticsearchSinkOptions>? configureOptions = null,
			Action<TransportConfiguration>? configureTransport = null,
			LoggingLevelSwitch? levelSwitch = null,
			LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum
		)
		{
			var transportConfig = TransportHelper.Cloud(cloudId, username, password);
			configureTransport?.Invoke(transportConfig);
			var sinkOptions = new ElasticsearchSinkOptions(new DistributedTransport(transportConfig));
			configureOptions?.Invoke(sinkOptions);

			return loggerConfiguration.Sink(new ElasticsearchSink(sinkOptions), restrictedToMinimumLevel, levelSwitch);
		}

		/// <summary>
		/// Write logs directly to Elastic Cloud ( https://cloud.elastic.co/ ).
		/// <para><paramref name="cloudId"/> describes your deployments endpoints (can be found in the Admin Console)</para>
		/// <para><paramref name="username"/> and <paramref name="password"/> are used for basic authentication.</para>
		/// <para>Use <paramref name="loggerConfiguration"/> configure where and how data should be written</para>
		/// <para>This generic overload using <typeparamref name="TEcsDocument"/> allows you to use your own <see cref="EcsDocument"/> subclasses</para>
		/// </summary>
		public static LoggerConfiguration ElasticCloud<TEcsDocument>(
			this LoggerSinkConfiguration loggerConfiguration,
			string cloudId,
			string username,
			string password,
			Action<ElasticsearchSinkOptions<TEcsDocument>>? configureOptions = null,
			Action<TransportConfiguration>? configureTransport = null,
			LoggingLevelSwitch? levelSwitch = null,
			LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum
		) where TEcsDocument : EcsDocument, new()
		{
			var transportConfig = TransportHelper.Cloud(cloudId, username, password);
			configureTransport?.Invoke(transportConfig);
			var sinkOptions = new ElasticsearchSinkOptions<TEcsDocument>(new DistributedTransport(transportConfig));
			configureOptions?.Invoke(sinkOptions);

			return loggerConfiguration.Sink(new ElasticsearchSink<TEcsDocument>(sinkOptions), restrictedToMinimumLevel, levelSwitch);
		}
	}
}
