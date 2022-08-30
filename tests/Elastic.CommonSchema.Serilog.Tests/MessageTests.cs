// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using FluentAssertions;
using Serilog;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Serilog.Tests
{
	public class MessageTests : LogTestsBase
	{
		public MessageTests(ITestOutputHelper output) : base(output) =>
			LoggerConfiguration = LoggerConfiguration
				.Enrich.WithThreadId()
				.Enrich.WithThreadName()
				.Enrich.WithMachineName()
				.Enrich.WithProcessId()
				.Enrich.WithProcessName()
				.Enrich.WithEnvironmentUserName();

		[Fact]
		public void SeesMessage() => TestLogger((logger, getLogEvents) =>
		{
			logger.Information("My log message!");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().Be("My log message!");
		});

		[Fact]
		public void SeesMessageWithProp() => TestLogger((logger, getLogEvents) =>
		{
			logger.Information("Info {ValueX} {SomeY}", "X", 2.2);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().Be("Info \"X\" 2.2");
			info.Metadata.Should().ContainKey("value_x");
			info.Metadata.Should().ContainKey("some_y");

			var x = info.Metadata["value_x"] as string;
			x.Should().NotBeNull().And.Be("X");

			var y = info.Metadata["some_y"] as double?;
			y.Should().HaveValue().And.Be(2.2);

		});

		[Fact]
		public void SeesMessageWithDictProp() => TestLogger((logger, getLogEvents) =>
		{
			logger.Information("Info {ValueX} {SomeY} {DictValue}", "X", 2.2, new Dictionary<string, string>() { { "fieldOne", "value1" }, { "fieldTwo", "value2" } });

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().Be("Info \"X\" 2.2 [(\"fieldOne\": \"value1\"), (\"fieldTwo\": \"value2\")]");
			info.Metadata.Should().ContainKey("value_x");
			info.Metadata.Should().ContainKey("some_y");
			info.Metadata.Should().ContainKey("dict_value");

			var x = info.Metadata["value_x"] as string;
			x.Should().NotBeNull().And.Be("X");

			var y = info.Metadata["some_y"] as double?;
			y.Should().HaveValue().And.Be(2.2);

			var dict = info.Metadata["dict_value"] as JsonElement?;
			dict.Should().NotBeNull();
			dict.Value.GetProperty("field_one").GetString().Should().Be("value1");
			dict.Value.GetProperty("field_two").GetString().Should().Be("value2");
		});

		[Fact]
		public void SeesMessageWithObjectProp() => TestLogger((logger, getLogEvents) =>
		{
			logger.Information("Info {@MyObj}", new { TestProp = "testing", Child = new { ChildProp = 3.3 } });

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().Be("Info { TestProp: \"testing\", Child: { ChildProp: 3.3 } }");
			info.Metadata.Should().ContainKey("my_obj");

			
			var json = info.Metadata["my_obj"] as JsonElement?;
			json.Should().NotBeNull();
			json.Value.GetProperty("test_prop").GetString().Should().Be("testing");
			json.Value.GetProperty("child").GetProperty("child_prop").GetDouble().Should().Be(3.3);
		});

		[Theory]
		[InlineData("Elapsed")]
		[InlineData("ElapsedMilliseconds")]
		public void SeesMessageWithElapsedProp(string property) => TestLogger((logger, getLogEvents) =>
		{
			logger.Information($"Info {{{property}}}", 2.2);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Event.Duration.Should().Be(2200000);
			info.Metadata.Should().NotContainKey(property);
		});

		[Theory]
		[InlineData("Method")]
		[InlineData("RequestMethod")]
		public void SeesMessageWithMethodProp(string property) => TestLogger((logger, getLogEvents) =>
		{
			logger.Information($"Request {{{property}}}", "GET");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Http.RequestMethod.Should().Be("GET");
			info.Metadata.Should().NotContainKey(property);
		});

		[Theory]
		[InlineData("Path")]
		[InlineData("RequestPath")]
		public void SeesMessageWithPathProp(string property) => TestLogger((logger, getLogEvents) =>
		{
			logger.Information($"Request {{{property}}}", "/");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Url.Path.Should().Be("/");
			info.Metadata.Should().NotContainKey(property);
		});

		[Fact]
		public void SeesMessageWithStatusCodeProp() => TestLogger((logger, getLogEvents) =>
		{
			logger.Information("Request {StatusCode}", 200);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Http.ResponseStatusCode.Should().Be(200);
			info.Metadata.Should().NotContainKey("StatusCode");
		});

		[Fact]
		public void SeesMessageWithSchemeProp() => TestLogger((logger, getLogEvents) =>
		{
			logger.Information("Request {Scheme}", "https");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Url.Scheme.Should().Be("https");
			info.Metadata.Should().NotContainKey("Scheme");
		});

		[Theory]
		[InlineData("QueryString", "", null)]
		[InlineData("QueryString", "?", "")]
		[InlineData("QueryString", "?p=1&q=2", "p=1&q=2")]
		public void SeesMessageWithQueryStringProp(string property, string value, object expectedValue) => TestLogger((logger, getLogEvents) =>
		{
			logger.Information($"Request {{{property}}}", value);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Url.Query.Should().Equals(expectedValue);
			info.Metadata.Should().NotContainKey(property);
		});

		[Fact]
		public void SeesMessageWithRequestIdProp() => TestLogger((logger, getLogEvents) =>
		{
			logger.Information("Request {RequestId}", "34985y39y6tg95");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Http.RequestId.Should().Be("34985y39y6tg95");
			info.Metadata.Should().NotContainKey("RequestId");
		});
	}
}
