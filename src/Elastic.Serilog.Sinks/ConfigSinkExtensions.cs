using System;
using System.Collections.Generic;
using System.Threading.Channels;
using Elastic.Channels;
using Elastic.CommonSchema;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Transport;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;

namespace Elastic.Serilog.Sinks
{
	/// <summary>
	/// Extension methods on <see cref="LoggerSinkConfiguration"/> to aid with serilog log configuration building
	/// <para>These overloads exists entirely to make configuration through <c>Serilog.Settings.Configuration</c> easier</para>
	/// </summary>
	public static class ConfigSinkExtensions
	{
		/// <summary>
		/// Write logs directly to Elasticsearch.
		/// <para>This overload makes it easy to directly specify the endpoint <paramref name="nodes"/></para>
		/// <para>Use <paramref name="loggerConfiguration"/> configure where and how data should be written</para>
		/// </summary>
		public static LoggerConfiguration Elasticsearch(
			this LoggerSinkConfiguration loggerConfiguration,
			BootstrapMethod bootstrapMethod,
			ICollection<Uri> nodes,
			bool useSniffing = true,
			string? dataStream = null,
			string? ilmPolicy = null,
			string? apiKey = null,
			string? username = null,
			string? password = null,

			bool? includeHost = null,
			bool? includeActivity = null,
			bool? includeProcess = null,
			bool? includeUser = null,
			ICollection<string>? filterProperties = null,

			int? maxRetries = null,
			int? maxConcurrency = null,
			int? maxInflight = null,
			int? maxExportSize = null,
			TimeSpan? maxLifeTime = null,
			BoundedChannelFullMode? fullMode = null,

			Uri? proxy = null,
			string? proxyUsername = null,
			string? proxyPassword = null,
			string? fingerprint = null,
			bool debugMode = false,

			LoggingLevelSwitch? levelSwitch = null,
			LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum
		)
		{
			var transportConfig = !useSniffing ? TransportHelper.Static(nodes) : TransportHelper.Sniffing(nodes);
			SetTransportConfig(transportConfig, apiKey, username, password, proxy, proxyUsername, proxyPassword, fingerprint, debugMode
			);

			var sinkOptions = CreateSinkOptions(transportConfig,
				bootstrapMethod, dataStream, ilmPolicy, includeHost, includeActivity, includeProcess, includeUser, filterProperties
			);

			SetBufferOptions(sinkOptions, maxRetries, maxConcurrency, maxInflight, maxExportSize, maxLifeTime, fullMode);

			return loggerConfiguration.Sink(new ElasticsearchSink(sinkOptions), restrictedToMinimumLevel, levelSwitch);
		}

		/// <summary>
		/// Write logs directly to Elastic Cloud ( https://cloud.elastic.co/ ).
		/// <para><paramref name="cloudId"/> describes your deployments endpoints (can be found in the Admin Console)</para>
		/// <para><paramref name="apiKey"/> is used for authentication.</para>
		/// <para>Use <paramref name="loggerConfiguration"/> configure where and how data should be written</para>
		/// </summary>
		public static LoggerConfiguration ElasticCloud(
			this LoggerSinkConfiguration loggerConfiguration,
			BootstrapMethod bootstrapMethod,
			Uri? endpoint = null,
			string? cloudId = null,
			string? apiKey = null,
			string? username = null,
			string? password = null,
			string? dataStream = null,
			string? ilmPolicy = null,

			bool? includeHost = null,
			bool? includeActivity = null,
			bool? includeProcess = null,
			bool? includeUser = null,
			ICollection<string>? filterProperties = null,

			int? maxRetries = null,
			int? maxConcurrency = null,
			int? maxInflight = null,
			int? maxExportSize = null,
			TimeSpan? maxLifeTime = null,
			BoundedChannelFullMode? fullMode = null,

			Uri? proxy = null,
			string? proxyUsername = null,
			string? proxyPassword = null,
			string? fingerprint = null,
			bool debugMode = false,

			LoggingLevelSwitch? levelSwitch = null,
			LogEventLevel restrictedToMinimumLevel = LevelAlias.Minimum
		)
		{
			var transportConfig = (endpoint, cloudId, apiKey, username, password) switch
			{
				({ } s, null, _, _, _) => TransportHelper.Static(new[] { s }),
				(null, { } id, { } k, _, _) => TransportHelper.Cloud(id, k),
				(null, { } id, null, { } u, { } p) => TransportHelper.Cloud(id, u, p),
				_ => throw new ArgumentException("Invalid cloud configuration")
			};

			SetTransportConfig(transportConfig, apiKey, username, password, proxy, proxyUsername, proxyPassword, fingerprint, debugMode);

			var sinkOptions = CreateSinkOptions(transportConfig,
				bootstrapMethod, dataStream, ilmPolicy, includeHost, includeActivity, includeProcess, includeUser, filterProperties
			);

			SetBufferOptions(sinkOptions, maxRetries, maxConcurrency, maxInflight, maxExportSize, maxLifeTime, fullMode);

			return loggerConfiguration.Sink(new ElasticsearchSink(sinkOptions), restrictedToMinimumLevel, levelSwitch);
		}

		private static void SetBufferOptions(ElasticsearchSinkOptions sinkOptions, int? maxRetries, int? maxConcurrency, int? maxInflight, int? maxExportSize,
			TimeSpan? maxLifeTime, BoundedChannelFullMode? fullMode
		) =>
			sinkOptions.ConfigureChannel = channelOpts =>
			{
				var b = channelOpts.BufferOptions;
				if (maxRetries.HasValue)
					b.ExportMaxRetries = maxRetries.Value;
				if (maxConcurrency.HasValue)
					b.ExportMaxConcurrency = maxConcurrency.Value;
				if (maxInflight.HasValue)
					b.InboundBufferMaxSize = maxInflight.Value;
				if (maxExportSize.HasValue)
					b.OutboundBufferMaxSize = maxExportSize.Value;
				if (maxLifeTime.HasValue)
					b.OutboundBufferMaxLifetime = maxLifeTime.Value;
				if (fullMode.HasValue)
					b.BoundedChannelFullMode = fullMode.Value;
			};

		private static ElasticsearchSinkOptions CreateSinkOptions(
			TransportConfiguration transportConfig,
			BootstrapMethod bootstrapMethod, string? dataStream, string? ilmPolicy, bool? includeHost,
			bool? includeActivity, bool? includeProcess, bool? includeUser, ICollection<string>? filterProperties
		)
		{
			var sinkOptions = new ElasticsearchSinkOptions(new DistributedTransport(transportConfig));
			if (dataStream != null)
			{
				var tokens = dataStream.Split('-');
				if (tokens.Length > 3)
					throw new ArgumentOutOfRangeException(nameof(dataStream), $"Data stream name should be at most 3 tokens: {dataStream}");
				if (tokens.Length == 3)
					sinkOptions.DataStream = new DataStreamName(tokens[0], tokens[1], tokens[2]);
				if (tokens.Length == 2)
					sinkOptions.DataStream = new DataStreamName(tokens[0], tokens[1]);
				if (tokens.Length == 1)
					sinkOptions.DataStream = new DataStreamName(tokens[0]);
			}
			sinkOptions.BootstrapMethod = bootstrapMethod;

			if (ilmPolicy != null)
				sinkOptions.IlmPolicy = ilmPolicy;

			if (includeHost.HasValue)
				sinkOptions.TextFormatting.IncludeHost = includeHost.Value;
			if (includeProcess.HasValue)
				sinkOptions.TextFormatting.IncludeProcess = includeProcess.Value;
			if (includeActivity.HasValue)
				sinkOptions.TextFormatting.IncludeActivityData = includeActivity.Value;
			if (includeUser.HasValue)
				sinkOptions.TextFormatting.IncludeUser = includeUser.Value;
			if (filterProperties != null)
				sinkOptions.TextFormatting.LogEventPropertiesToFilter = new HashSet<string>(filterProperties);
			return sinkOptions;
		}

		private static void SetTransportConfig(TransportConfiguration transportConfig,
			string? apiKey, string? username, string? password,
			Uri? proxy, string? proxyUsername, string? proxyPassword, string? fingerprint, bool debugMode
		)
		{
			if (proxy != null && proxyUsername != null && proxyPassword != null)
				transportConfig.Proxy(proxy, proxyUsername, proxyPassword);
			else if (proxy != null)
				transportConfig.Proxy(proxy);

			if (fingerprint != null)
				transportConfig.CertificateFingerprint(fingerprint);

			if (debugMode)
				transportConfig.EnableDebugMode();

			if (username != null && password != null)
				transportConfig.Authentication(new BasicAuthentication(username, password));
			if (apiKey != null)
				transportConfig.Authentication(new ApiKey(apiKey));
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
	}
}
