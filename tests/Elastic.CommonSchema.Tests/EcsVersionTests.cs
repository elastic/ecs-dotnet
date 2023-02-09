// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Tests
{
	public class EcsVersionTests
	{
		public EcsVersionTests(ITestOutputHelper output) => _output = output;

		private readonly ITestOutputHelper _output;

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

		[Fact] public void DeserializesFromNestedLevel()
		{
			var json = "{\"ecs\": { \"version\":\"1.2.9\"} }";

			var deserialized = EcsDocument.Deserialize(json);
			deserialized.Ecs.Should().NotBeNull();
			deserialized.Ecs.Version.Should().Be("1.2.9");
		}
		[Fact] public void DeserializesFromBoth()
		{
			var json = "{\"ecs.version\": \"1.2.8\", \"ecs\": { \"version\":\"1.2.9\"} }";

			var deserialized = EcsDocument.Deserialize(json);
			deserialized.Ecs.Should().NotBeNull();
			deserialized.Ecs.Version.Should().Be("1.2.8");
		}
	}
}
