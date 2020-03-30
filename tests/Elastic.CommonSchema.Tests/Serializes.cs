// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Runtime.Serialization;
using Elastic.CommonSchema.Serialization;
using FluentAssertions;
using Xunit;

namespace Elastic.CommonSchema.Tests
{
	public class Serializes
	{
		private readonly Log _log = new Log { Level = "debug" };

		[Fact]
		public void SerializesSomethingToString()
		{
			var b = new Base { Agent = new Agent { Name = "some-agent" }, Log = _log};

			var serialized = b.Serialize();
			serialized.Should().NotBeNullOrWhiteSpace();
			serialized.Should().Contain("log.level\":\"debug\"");

			var deserialized = Base.Deserialize(serialized);
			deserialized.Agent.Should().NotBeNull();
			deserialized.Agent.Name.Should().Be("some-agent");
			deserialized.Log.Should().NotBeNull();
			deserialized.Log.Level.Should().Be("debug");
		}

		public class SubclassedBase : Base
		{
			[DataMember(Name = "agent2")]
			public Agent Agent2 { get; set; }

			protected override bool TryRead(string propertyName, out Type type)
			{
				type = propertyName switch
				{
					"agent2" => typeof(Agent),
					_ => null
				};
				return type != null;
			}

			protected override bool ReceiveProperty(string propertyName, object value) =>
				propertyName switch
				{
					"agent2" => null != (Agent2 = value as Agent),
					_ => false
				};

			protected override void WriteAdditionalProperties(Action<string, object> write) => write("agent2", Agent2);
		}

		public class SubClassedAgent : Agent
		{
			[DataMember(Name = "another_name")]
			public string Name2 { get; set; }
		}

		[Fact]
		public void SerializesSubClass()
		{
			var b = new SubclassedBase { Timestamp = DateTimeOffset.Now, Agent2 = new Agent { Name = "some-agent" }, Log =  _log};

			var serialized = b.Serialize();

			serialized.Should().NotBeNullOrWhiteSpace();
			serialized.Should().Contain("agent2");
			serialized.Should().Contain("log.level\":\"debug\"");

			var deserialized = EcsSerializerFactory<SubclassedBase>.Deserialize(serialized);
			deserialized.Log.Should().NotBeNull();
			deserialized.Agent2.Should().NotBeNull();
		}

		[Fact]
		public void SerializesSubClassProperties()
		{
			var b = new Base { Agent = new SubClassedAgent { Name2 = "some-agent" }, Log =  _log};

			var serialized = b.Serialize();
			serialized.Should().NotBeNullOrWhiteSpace();
			serialized.Should().Contain("some-agent");
			serialized.Should().Contain("log.level\":\"debug\"");

			var deserialized = EcsSerializerFactory<SubclassedBase>.Deserialize(serialized);
			deserialized.Log.Should().NotBeNull();
			deserialized.Log.Level.Should().Be("debug");
			deserialized.Agent.Should().NotBeNull();
		}

		[Fact]
		public void SerializesSubClassPropertiesOnSubclass()
		{
			var b = new SubclassedBase
			{
				Agent = new SubClassedAgent { Name2 = "some-agent", Id = "X"},
				Agent2 = new Agent { Name = "some-agent" },
				Log =  _log
			};

			var serialized = b.Serialize();

			serialized.Should().NotBeNullOrWhiteSpace();
			serialized.Should().Contain("some-agent");
			serialized.Should().Contain("log.level\":\"debug\"");

			var deserialized = EcsSerializerFactory<SubclassedBase>.Deserialize(serialized);
			deserialized.Log.Should().NotBeNull();
			deserialized.Log.Level.Should().Be("debug");
			deserialized.Agent.Should().NotBeNull();
			deserialized.Agent.Id.Should().Be("X");
			deserialized.Agent2.Should().NotBeNull();
			deserialized.Agent2.Name.Should().Be("some-agent");
		}
	}
}
