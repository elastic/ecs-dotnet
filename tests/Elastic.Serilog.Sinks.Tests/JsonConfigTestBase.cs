using System.Reflection;
using Elastic.CommonSchema;
using Elastic.CommonSchema.Serilog;
using Elastic.Ingest.Elasticsearch.CommonSchema;
using Elastic.Transport;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Core;

namespace Elastic.Serilog.Sinks.Tests;

public class JsonConfigTestBase
{
	protected static void GetBits(string json,
		out ElasticsearchSink<EcsDocument> sink,
		out EcsTextFormatterConfiguration<EcsDocument> formatterConfig,
		out EcsDataStreamChannel<EcsDocument> channel,
		out ITransportConfiguration transportConfig)
	{
		var config = new ConfigurationBuilder()
			.AddJsonString(json)
			.Build();

		var loggerConfig = new LoggerConfiguration()
			.ReadFrom.Configuration(config);

		var field = loggerConfig.GetType().GetField("_logEventSinks", BindingFlags.Instance | BindingFlags.NonPublic);
		var sinks = field?.GetValue(loggerConfig) as IList<ILogEventSink>;
		sinks.Should().HaveCount(1);
		sink = sinks?.FirstOrDefault() as ElasticsearchSink<EcsDocument> ?? throw new NullReferenceException();
		formatterConfig = Reflect<EcsTextFormatterConfiguration<EcsDocument>>(sink, "_formatterConfiguration");
		channel = Reflect<EcsDataStreamChannel<EcsDocument>>(sink, "_channel");
		var transport = channel.Options.Transport;
		transportConfig = transport.GetType().GetProperty("Configuration")?.GetValue(transport) as TransportConfiguration ?? throw new NullReferenceException();

		sink.Should().NotBeNull();
		formatterConfig.Should().NotBeNull();
		channel.Should().NotBeNull();
		transportConfig.Should().NotBeNull();


	}
	private static TReturn Reflect<TReturn>(object obj, string fieldName) where TReturn : class =>
		obj.GetType().BaseType?.GetRuntimeFields().FirstOrDefault(f => f.Name == fieldName)?.GetValue(obj) as TReturn ?? throw new NullReferenceException(fieldName);

	protected string CreateJson(string to, string argsBlock) =>
		// language=json
		$$"""
		  {
		  	"Serilog": {
		  		"Using": [ "Elastic.Serilog.Sinks" ],
		  		"MinimumLevel": { "Default": "Information" },
		  		"WriteTo": [
		  			{
		  				"Name": "{{to}}",
		  				"Args": {{argsBlock}}
		  			}
		  		]
		  	}
		  }
		  """;
}
