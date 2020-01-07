using System;
using System.Runtime.Serialization;
using FluentAssertions;
using Xunit;

namespace Elastic.CommonSchema.Tests
{
	public class Serializes
	{
		private Log _log = new Log { Level = "debug" };

		[Fact]
		public void SerializesSomethingToString()
		{
			var b = new Base { Agent = new Agent { Name = "some-agent" }, Log =  _log};

			var serialized = b.Serialize();

			serialized.Should().NotBeNullOrWhiteSpace();
			serialized.Should().Contain("log.level\":\"debug\"");
		}

		public class SubclassedBase : Base
		{
			[DataMember(Name = "agent2")]
			public Agent Agent2 { get; set; }

			protected override bool TryRead(string propertyName, object readProperty)
			{
				if (propertyName != "agent2") return false;

				Agent2 = readProperty as Agent;
				return true;
			}

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
			var b = new SubclassedBase { Agent2 = new Agent { Name = "some-agent" }, Log =  _log};

			var serialized = b.Serialize();

			serialized.Should().NotBeNullOrWhiteSpace();
			serialized.Should().Contain("agent2");
			serialized.Should().Contain("log.level\":\"debug\"");
		}

		[Fact]
		public void SerializesSubClassProperties()
		{
			var b = new Base { Agent = new SubClassedAgent { Name2 = "some-agent" }, Log =  _log};

			var serialized = b.Serialize();

			serialized.Should().NotBeNullOrWhiteSpace();
			serialized.Should().Contain("some-agent");
			serialized.Should().Contain("log.level\":\"debug\"");
		}

		[Fact]
		public void SerializesSubClassPropertiesOnSubclass()
		{
			var b = new SubclassedBase
			{
				Agent = new SubClassedAgent { Name2 = "some-agent" },
				Agent2 = new Agent { Name = "some-agent" },
				Log =  _log
			};

			var serialized = b.Serialize();

			serialized.Should().NotBeNullOrWhiteSpace();
			serialized.Should().Contain("some-agent");
			serialized.Should().Contain("log.level\":\"debug\"");
		}

	}
}
