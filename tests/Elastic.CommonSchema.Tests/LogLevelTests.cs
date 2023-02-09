// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Tests
{
	public class LogLevelTests
	{
		public LogLevelTests(ITestOutputHelper output) => _output = output;

		private readonly ITestOutputHelper _output;

		[Fact] public void SerializesLogLevelAtRoot()
		{
			var b = new EcsDocument { Log = new Log { Level = "debug" } };

			var serialized = b.Serialize();
			_output.WriteLine(serialized);
			serialized.Should().NotBeNullOrWhiteSpace();
			serialized.Should().Be(@$"{{""log.level"":""debug"",""ecs.version"":""{EcsDocument.Version}""}}");

			var deserialized = EcsDocument.Deserialize(serialized);
			deserialized.Log.Should().NotBeNull();
			deserialized.Log.Level.Should().Be("debug");
		}

		[Fact] public void DeserializesFromNestedLevel()
		{
			var json = "{\"log\": { \"level\":\"DEBUG\"} }";

			var deserialized = EcsDocument.Deserialize(json);
			deserialized.Log.Should().NotBeNull();
			deserialized.Log.Level.Should().Be("DEBUG");
		}
		[Fact] public void DeserializesFromBoth()
		{
			var json = "{\"log.level\": \"INFO\", \"log\": { \"level\":\"DEBUG\"} }";

			var deserialized = EcsDocument.Deserialize(json);
			deserialized.Log.Should().NotBeNull();
			deserialized.Log.Level.Should().Be("INFO");
		}

		[Fact] public void SerializesLogProperties()
		{
			var b = new EcsDocument { Log = new Log { Level = "debug", Logger = "x"} };

			var serialized = b.Serialize();
			_output.WriteLine(serialized);
			serialized.Should().NotBeNullOrWhiteSpace();
			serialized.Should().Be(@$"{{""log.level"":""debug"",""ecs.version"":""{EcsDocument.Version}"",""log"":{{""logger"":""x""}}}}");

			var deserialized = EcsDocument.Deserialize(serialized);
			deserialized.Log.Should().NotBeNull();
			deserialized.Log.Level.Should().Be("debug");
			deserialized.Log.Logger.Should().Be("x");
			deserialized.Ecs.Should().NotBeNull();
			deserialized.Ecs.Version.Should().Be(EcsDocument.Version);
		}

		[Fact] public void EcsVersionCanBeOverriden()
		{
			var b = new EcsDocument { Ecs = new Ecs { Version = "x"} };

			var serialized = b.Serialize();
			_output.WriteLine(serialized);
			serialized.Should().NotBeNullOrWhiteSpace();
			serialized.Should().Be(@$"{{""ecs.version"":""x""}}");

			var deserialized = EcsDocument.Deserialize(serialized);
			deserialized.Ecs.Should().NotBeNull();
			deserialized.Ecs.Version.Should().Be("x");
		}
	}
}
