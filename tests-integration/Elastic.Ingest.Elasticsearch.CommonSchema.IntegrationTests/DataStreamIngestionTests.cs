// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Text.Json;
using Elastic.Channels;
using Elastic.Clients.Elasticsearch.IndexManagement;
using Elastic.CommonSchema;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Transport;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;
using HttpMethod = Elastic.Transport.HttpMethod;

namespace Elastic.Ingest.Elasticsearch.CommonSchema.IntegrationTests;

public class DataStreamIngestionTests : IntegrationTestBase
{
	public DataStreamIngestionTests(IngestionCluster cluster, ITestOutputHelper output) : base(cluster, output)
	{
	}

	[Fact]
	public async Task EnsureDocumentsEndUpInDataStream()
	{
		var targetDataStream = new DataStreamName("timeseriesdocs", "dotnet");
		var slim = new CountdownEvent(1);
		var options = new DataStreamChannelOptions<TimeSeriesDocument>(Client.Transport)
		{
			DataStream = targetDataStream,
			BufferOptions = new BufferOptions { WaitHandle = slim, OutboundBufferMaxSize = 1 },
		};
		var channel = new EcsDataStreamChannel<TimeSeriesDocument>(options);

		var bootstrapped = await channel.BootstrapElasticsearchAsync(BootstrapMethod.Failure, "7-days-default");
		bootstrapped.Should().BeTrue("Expected to be able to bootstrap data stream channel");

		var dataStream =
			await Client.Indices.GetDataStreamAsync(new GetDataStreamRequest(targetDataStream.ToString()));
		dataStream.DataStreams.Should().BeNullOrEmpty();

		channel.TryWrite(new TimeSeriesDocument { Timestamp = DateTimeOffset.Now, Message = "hello-world" });
		if (!slim.WaitHandle.WaitOne(TimeSpan.FromSeconds(10)))
			throw new Exception($"No flush occurred in 10 seconds: {channel}", channel.DiagnosticsListener?.ObservedException);

		var refreshResult = await Client.Indices.RefreshAsync(targetDataStream.ToString());
		refreshResult.IsValidResponse.Should().BeTrue("{0}", refreshResult.DebugInformation);
		var searchResult = await Client.SearchAsync<TimeSeriesDocument>(s => s.Indices(targetDataStream.ToString()));
		searchResult.Total.Should().Be(1);

		var storedDocument = searchResult.Documents.First();
		storedDocument.Message.Should().Be("hello-world");

		var hit = searchResult.Hits.First();
		hit.Index.Should().StartWith($".ds-{targetDataStream}-");

		// the following throws in the 8.0.4 version of the client
		// The JSON value could not be converted to Elastic.Clients.Elasticsearch.HealthStatus. Path: $.data_stre...
		// await Client.Indices.GetDataStreamAsync(new GetDataStreamRequest(targetDataStream.ToString())
		var getDataStream =
			await Client.Transport.RequestAsync<StringResponse>(HttpMethod.GET, $"/_data_stream/{targetDataStream}");

		getDataStream.ApiCallDetails.HttpStatusCode.Should()
			.Be(200, "{0}", getDataStream.ApiCallDetails.DebugInformation);

		//this ensures the data stream was setup using the expected bootstrapped template
		getDataStream.ApiCallDetails.DebugInformation.Should()
			.Contain(@$"""template"" : ""{targetDataStream.GetTemplateName()}""");

		//this ensures the data stream is managed by the expected ilm_policy
		getDataStream.ApiCallDetails.DebugInformation.Should()
			.Contain(@"""ilm_policy"" : ""7-days-default""");
	}

	[Fact]
	public async Task UseCustomEventWriter()
	{
		var targetDataStream = new DataStreamName("customtimeseriesdocs", "dotnet");
		var slim = new CountdownEvent(1);
		var options = new DataStreamChannelOptions<TimeSeriesDocument>(Client.Transport)
		{
			DataStream = targetDataStream,
			BufferOptions = new BufferOptions { WaitHandle = slim, OutboundBufferMaxSize = 1 },
			EventWriter = new CustomEventWriter<TimeSeriesDocument>()
		};
		var channel = new EcsDataStreamChannel<TimeSeriesDocument>(options);

		var bootstrapped = await channel.BootstrapElasticsearchAsync(BootstrapMethod.Failure, "7-days-default");
		bootstrapped.Should().BeTrue("Expected to be able to bootstrap data stream channel");

		var dataStream =
			await Client.Indices.GetDataStreamAsync(new GetDataStreamRequest(targetDataStream.ToString()));
		dataStream.DataStreams.Should().BeNullOrEmpty();

		channel.TryWrite(new TimeSeriesDocument
		{
			Timestamp = DateTimeOffset.Parse("2024-05-27T23:56:15.785Z"),
			Message = "Hello World!",
			Metadata = new MetadataDictionary { { "MyEnum", MyEnum.Two } }
		});

		if (!slim.WaitHandle.WaitOne(TimeSpan.FromSeconds(10)))
			throw new Exception($"No flush occurred in 10 seconds: {channel}", channel.DiagnosticsListener?.ObservedException);

		var refreshResult = await Client.Indices.RefreshAsync(targetDataStream.ToString());
		refreshResult.IsValidResponse.Should().BeTrue("{0}", refreshResult.DebugInformation);

		var searchResult = await Client.SearchAsync<JsonDocument>(s => s.Indices(targetDataStream.ToString()));
		searchResult.Total.Should().Be(1);

		var root = searchResult.Documents.First().RootElement;
		root.GetProperty("@timestamp").GetString().Should().Be("2024-05-27T23:56:15.785+00:00");
		root.GetProperty("message").GetString().Should().Be("Hello World!");
		root.GetProperty("metadata").GetProperty("MyEnum").GetString().Should().Be("Two");
	}
}
