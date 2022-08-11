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
			EcsTextFormatterConfiguration? textFormatterConfiguration = null
		) =>
			loggerConfiguration.Sink(new ElasticsearchSink(new ElasticsearchSchemaSinkOptions
			{
				EcsTextFormatterConfiguration = textFormatterConfiguration ?? new EcsTextFormatterConfiguration(),
				Transport = useSniffing ? TransportHelper.Static(nodes) : TransportHelper.Sniffing(nodes)
			}));

		public static LoggerConfiguration ElasticCloud(
			this LoggerSinkConfiguration loggerConfiguration,
			string endpoint,
			string apiKey,
			EcsTextFormatterConfiguration? textFormatterConfiguration = null
		) =>
			loggerConfiguration.Sink(new ElasticsearchSink(new ElasticsearchSchemaSinkOptions
			{
				EcsTextFormatterConfiguration = textFormatterConfiguration ?? new EcsTextFormatterConfiguration(),
				Transport = TransportHelper.Cloud(endpoint, apiKey)
			}));

		public static LoggerConfiguration ElasticCloud(
			this LoggerSinkConfiguration loggerConfiguration,
			string endpoint,
			string username,
			string password,
			EcsTextFormatterConfiguration? textFormatterConfiguration = null
		) =>
			loggerConfiguration.Sink(new ElasticsearchSink(new ElasticsearchSchemaSinkOptions
			{
				EcsTextFormatterConfiguration = textFormatterConfiguration ?? new EcsTextFormatterConfiguration(),
				Transport = TransportHelper.Cloud(endpoint, username, password)
			}));
	}
}
