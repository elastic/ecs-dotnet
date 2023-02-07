using System;
using System.Collections.Generic;
using Serilog;
using Serilog.Configuration;

namespace Elastic.CommonSchema.Serilog.Sink
{
	public static class ElasticsearchSinkExtensions
	{
		public static LoggerConfiguration Elasticsearch(this LoggerSinkConfiguration loggerConfiguration, ElasticsearchSchemaSinkOptions? options = null) =>
			loggerConfiguration.Sink(new ElasticsearchSink(options ?? new ElasticsearchSchemaSinkOptions()));

		public static LoggerConfiguration Elasticsearch<TEcsDocument>(this LoggerSinkConfiguration loggerConfiguration, ElasticsearchSchemaSinkOptions<TEcsDocument>? options = null)
			where TEcsDocument : EcsDocument, new() =>
			loggerConfiguration.Sink(new ElasticsearchSink<TEcsDocument>(options ?? new ElasticsearchSchemaSinkOptions<TEcsDocument>()));

		public static LoggerConfiguration Elasticsearch(
			this LoggerSinkConfiguration loggerConfiguration,
			ICollection<Uri> nodes,
			Action<ElasticsearchSchemaSinkOptions>? configureOptions = null,
			bool useSniffing = true
		)
		{
			var sinkOptions = new ElasticsearchSchemaSinkOptions(useSniffing ? TransportHelper.Static(nodes) : TransportHelper.Sniffing(nodes));
			configureOptions?.Invoke(sinkOptions);

			return loggerConfiguration.Sink(new ElasticsearchSink(sinkOptions));
		}

		public static LoggerConfiguration Elasticsearch<TEcsDocument>(
			this LoggerSinkConfiguration loggerConfiguration,
			ICollection<Uri> nodes,
			Action<ElasticsearchSchemaSinkOptions<TEcsDocument>>? configureOptions = null,
			bool useSniffing = true
		) where TEcsDocument : EcsDocument, new()
		{
			var sinkOptions = new ElasticsearchSchemaSinkOptions<TEcsDocument>(useSniffing ? TransportHelper.Static(nodes) : TransportHelper.Sniffing(nodes));
			configureOptions?.Invoke(sinkOptions);

			return loggerConfiguration.Sink(new ElasticsearchSink<TEcsDocument>(sinkOptions));
		}

		public static LoggerConfiguration ElasticCloud(
			this LoggerSinkConfiguration loggerConfiguration,
			string endpoint,
			string apiKey,
			Action<ElasticsearchSchemaSinkOptions>? configureOptions = null
		)
		{
			var sinkOptions = new ElasticsearchSchemaSinkOptions(TransportHelper.Cloud(endpoint, apiKey));
			configureOptions?.Invoke(sinkOptions);

			return loggerConfiguration.Sink(new ElasticsearchSink(sinkOptions));
		}
		public static LoggerConfiguration ElasticCloud<TEcsDocument>(
			this LoggerSinkConfiguration loggerConfiguration,
			string endpoint,
			string apiKey,
			Action<ElasticsearchSchemaSinkOptions<TEcsDocument>>? configureOptions = null
		) where TEcsDocument : EcsDocument, new()
		{
			var sinkOptions = new ElasticsearchSchemaSinkOptions<TEcsDocument>(TransportHelper.Cloud(endpoint, apiKey));
			configureOptions?.Invoke(sinkOptions);

			return loggerConfiguration.Sink(new ElasticsearchSink<TEcsDocument>(sinkOptions));
		}

		public static LoggerConfiguration ElasticCloud(
			this LoggerSinkConfiguration loggerConfiguration,
			string endpoint,
			string username,
			string password,
			Action<ElasticsearchSchemaSinkOptions>? configureOptions = null
		)
		{
			var sinkOptions = new ElasticsearchSchemaSinkOptions(TransportHelper.Cloud(endpoint, username, password));
			configureOptions?.Invoke(sinkOptions);

			return loggerConfiguration.Sink(new ElasticsearchSink(sinkOptions));
		}

		public static LoggerConfiguration ElasticCloud<TEcsDocument>(
			this LoggerSinkConfiguration loggerConfiguration,
			string endpoint,
			string username,
			string password,
			Action<ElasticsearchSchemaSinkOptions<TEcsDocument>>? configureOptions = null
		) where TEcsDocument : EcsDocument, new()
		{
			var sinkOptions = new ElasticsearchSchemaSinkOptions<TEcsDocument>(TransportHelper.Cloud(endpoint, username, password));
			configureOptions?.Invoke(sinkOptions);

			return loggerConfiguration.Sink(new ElasticsearchSink<TEcsDocument>(sinkOptions));
		}
	}
}
