using System;
using Serilog;
using Serilog.Configuration;

namespace Elastic.CommonSchema.Serilog.Sink
{
	public static class ElasticsearchSinkExtensions
	{
		public static LoggerConfiguration Elasticsearch(
			this LoggerSinkConfiguration loggerConfiguration,
			ElasticsearchSchemaSinkOptions? options = null
		) =>
			loggerConfiguration.Sink(new ElasticsearchSink(options ?? new ElasticsearchSchemaSinkOptions()));

		public static LoggerConfiguration Elasticsearch(
			this LoggerSinkConfiguration loggerConfiguration,
			string[] nodes,
			bool useSniffing = true,
			Action<ElasticsearchSchemaSinkOptions>? configureOptions = null
		)
		{
			var sinkOptions = new ElasticsearchSchemaSinkOptions(useSniffing ? TransportHelper.Static(nodes) : TransportHelper.Sniffing(nodes));
			configureOptions?.Invoke(sinkOptions);

			return loggerConfiguration.Sink(new ElasticsearchSink(sinkOptions));
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
	}
}
