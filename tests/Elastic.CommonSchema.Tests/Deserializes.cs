// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using FluentAssertions;
using Xunit;

namespace Elastic.CommonSchema.Tests
{
	public class Deserializes
	{

		[Fact]
		public void DeserializeEmptyObject()
		{
			var serialized = @$"{{}}";
			var deserialized = EcsDocument.Deserialize(serialized);
			deserialized.Should().NotBeNull();
		}

		[Fact]
		public void DeserializeNullTimestamp()
		{
			var serialized = @$"{{ ""timestamp"": null }}";
			var deserialized = EcsDocument.Deserialize(serialized);
			deserialized.Should().NotBeNull();
		}

		[Fact]
		public void DeserializesNullAgent()
		{
			var serialized = @$"{{ ""agent"": null }}";
			var deserialized = EcsDocument.Deserialize(serialized);
			deserialized.Should().NotBeNull();
		}

		[Fact]
		public void DeserializesAgentWithUnknownKeys()
		{
			var serialized = @$"{{ ""agent"": {{ ""unknown"": ""value"" }} }}";
			var deserialized = EcsDocument.Deserialize(serialized);
			deserialized.Should().NotBeNull();
			deserialized.Agent.Should().NotBeNull();
		}

		[Fact]
		public void DeserializesAgentWithUnknownArray()
		{
			var serialized = @$"{{ ""agent"": {{ ""unknown"": [""value""] }} }}";
			var deserialized = EcsDocument.Deserialize(serialized);
			deserialized.Should().NotBeNull();
			deserialized.Agent.Should().NotBeNull();
		}

		[Fact]
		public void DeserializesWithUnknownKeys()
		{
			var serialized = @$"{{ ""unknown"": ""value"" }}";
			var deserialized = EcsDocument.Deserialize(serialized);
			deserialized.Should().NotBeNull();
		}

		[Fact]
		public void DeserializesWithUnknownObject()
		{
			var serialized = @$"{{ ""unknown"": {{ ""prop"": ""value"" }} }}";
			var deserialized = EcsDocument.Deserialize(serialized);
			deserialized.Should().NotBeNull();
		}

		[Fact]
		public void DeserializesWithUnknownObjectBeforeAgent()
		{
			var serialized = @$"{{ ""unknown"": {{ ""prop"": ""value"" }}, ""agent"" : {{}} }}";
			var deserialized = EcsDocument.Deserialize(serialized);
			deserialized.Should().NotBeNull();
			deserialized.Agent.Should().NotBeNull();
		}

		[Fact]
		public void DeserializesWithUnknownObjectAfterAgent()
		{
			var serialized = @$"{{ ""agent"" : {{}}, ""unknown"": {{ ""prop"": ""value"" }} }}";
			var deserialized = EcsDocument.Deserialize(serialized);
			deserialized.Should().NotBeNull();
			deserialized.Agent.Should().NotBeNull();
		}
	}
}
