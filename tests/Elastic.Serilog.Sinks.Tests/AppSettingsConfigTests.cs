using System.Threading.Channels;
using Elastic.Ingest.Elasticsearch;
using FluentAssertions;
using Xunit;

namespace Elastic.Serilog.Sinks.Tests;

public class AppSettingsConfigTests : JsonConfigTestBase
{
	[Fact]
	public void SimpleConfiguration()
	{
		var json =
			CreateJson("Elasticsearch", // language=json
				$$"""
				  	{
				  		"nodes": [ "http://elastichost:9200" ]
				  	}
				  """);

		GetBits(json, out var sink, out var formatterConfig, out var channel, out var transportConfig);

		transportConfig.NodePool.Nodes.Should().NotBeNullOrEmpty()
			.And.Contain(n => n.Uri.ToString() == "http://elastichost:9200/");
	}

	[Fact]
	public void ComplexElasticsearchOptions()
	{
		var json =
			CreateJson("Elasticsearch", // language=json
				$$"""
					{
						"bootstrapMethod": "Silent",
						"nodes": [ "http://elastichost:9200" ],
						"useSniffing": false,
						"ilmPolicy" : "my-policy",
						"dataStream" : "logs-myapplication-default",
						"includeHost" : false,
						"includeUser" : false,
						"includeProcess" : true,
						"includeActivity" : false,
						"filterProperties" : [ "prop1", "prop2" ],
						"proxy": "http://localhost:8200",
						"proxyUsername": "x",
						"proxyPassword": "y",
						"debugMode": true,
						"apiKey": "api-key",
						"maxRetries": 2,
						"maxConcurrency": 20,
						"maxInflight": 1000000,
						"maxExportSize": 10000,
						"maxLifeTime": "00:01:00",
						"fullMode": "DropNewest"
					}
				""");

		GetBits(json, out var sink, out var formatterConfig, out var channel, out var transportConfig);

		sink.Options.BootstrapMethod.Should().Be(BootstrapMethod.Silent);
		sink.Options.IlmPolicy.Should().Be("my-policy");
		sink.Options.DataStream.ToString().Should().Be("logs-myapplication-default");
		sink.Options.EcsTextFormatterConfiguration.LogEventPropertiesToFilter.Should().BeEquivalentTo("prop1", "prop2");
		sink.Options.EcsTextFormatterConfiguration.IncludeHost.Should().Be(false);
		sink.Options.EcsTextFormatterConfiguration.IncludeActivityData.Should().Be(false);
		sink.Options.EcsTextFormatterConfiguration.IncludeProcess.Should().Be(true);
		sink.Options.EcsTextFormatterConfiguration.IncludeUser.Should().Be(false);
		formatterConfig.IncludeUser.Should().Be(sink.Options.EcsTextFormatterConfiguration.IncludeUser);
		formatterConfig.IncludeProcess.Should().Be(sink.Options.EcsTextFormatterConfiguration.IncludeProcess);

		channel.Options.DataStream.ToString().Should().Be("logs-myapplication-default");

		channel.Options.BufferOptions.ExportMaxRetries.Should().Be(2);
		channel.Options.BufferOptions.ExportMaxConcurrency.Should().Be(20);
		channel.Options.BufferOptions.InboundBufferMaxSize.Should().Be(1_000_000);
		channel.Options.BufferOptions.OutboundBufferMaxSize.Should().Be(10_000);
		channel.Options.BufferOptions.OutboundBufferMaxLifetime.Should().Be(TimeSpan.FromMinutes(1));
		channel.Options.BufferOptions.BoundedChannelFullMode.Should().Be(BoundedChannelFullMode.DropNewest);

		transportConfig.NodePool.Nodes.Should().NotBeNullOrEmpty()
			.And.Contain(n => n.Uri.ToString() == "http://elastichost:9200/");

		transportConfig.ProxyAddress.Should().Be("http://localhost:8200/");
		transportConfig.ProxyUsername.Should().Be("x");
		transportConfig.ProxyPassword.Should().Be("y");
		//because debugMode was set
		transportConfig.DisableDirectStreaming.Should().Be(true);
		transportConfig.Authentication.Should().NotBeNull();
	}

	[Fact]
	public void ComplexCloudOptions()
	{
		var json =
			CreateJson("ElasticCloud", // language=json
				$$"""
					{
						"bootstrapMethod": "Silent",
						"endpoint": "http://elastichost:9200",
						"apiKey": "api-key",
						"ilmPolicy" : "my-policy",
						"dataStream" : "logs-myapplication-default",
						"includeHost" : false,
						"includeUser" : false,
						"includeProcess" : true,
						"includeActivity" : false,
						"filterProperties" : [ "prop1", "prop2" ],
						"proxy": "http://localhost:8200",
						"proxyUsername": "x",
						"proxyPassword": "y",
						"debugMode": true,
						"maxRetries": 2,
						"maxConcurrency": 20,
						"maxInflight": 1000000,
						"maxExportSize": 10000,
						"maxLifeTime": "00:01:00",
						"fullMode": "DropNewest"
					}
				""");

		GetBits(json, out var sink, out var formatterConfig, out var channel, out var transportConfig);

		sink.Options.BootstrapMethod.Should().Be(BootstrapMethod.Silent);
		sink.Options.IlmPolicy.Should().Be("my-policy");
		sink.Options.DataStream.ToString().Should().Be("logs-myapplication-default");
		sink.Options.EcsTextFormatterConfiguration.LogEventPropertiesToFilter.Should().BeEquivalentTo("prop1", "prop2");
		sink.Options.EcsTextFormatterConfiguration.IncludeHost.Should().Be(false);
		sink.Options.EcsTextFormatterConfiguration.IncludeActivityData.Should().Be(false);
		sink.Options.EcsTextFormatterConfiguration.IncludeProcess.Should().Be(true);
		sink.Options.EcsTextFormatterConfiguration.IncludeUser.Should().Be(false);
		formatterConfig.IncludeUser.Should().Be(sink.Options.EcsTextFormatterConfiguration.IncludeUser);
		formatterConfig.IncludeProcess.Should().Be(sink.Options.EcsTextFormatterConfiguration.IncludeProcess);

		channel.Options.DataStream.ToString().Should().Be("logs-myapplication-default");

		channel.Options.BufferOptions.ExportMaxRetries.Should().Be(2);
		channel.Options.BufferOptions.ExportMaxConcurrency.Should().Be(20);
		channel.Options.BufferOptions.InboundBufferMaxSize.Should().Be(1_000_000);
		channel.Options.BufferOptions.OutboundBufferMaxSize.Should().Be(10_000);
		channel.Options.BufferOptions.OutboundBufferMaxLifetime.Should().Be(TimeSpan.FromMinutes(1));
		channel.Options.BufferOptions.BoundedChannelFullMode.Should().Be(BoundedChannelFullMode.DropNewest);

		transportConfig.NodePool.Nodes.Should().NotBeNullOrEmpty()
			.And.Contain(n => n.Uri.ToString() == "http://elastichost:9200/");

		transportConfig.ProxyAddress.Should().Be("http://localhost:8200/");
		transportConfig.ProxyUsername.Should().Be("x");
		transportConfig.ProxyPassword.Should().Be("y");
		//because debugMode was set
		transportConfig.DisableDirectStreaming.Should().Be(true);
		transportConfig.Authentication.Should().NotBeNull();
	}
}
