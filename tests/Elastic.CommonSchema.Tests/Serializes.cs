// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Text.Json.Serialization;
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
			var b = new EcsDocument { Agent = new Agent { Name = "some-agent" }, Log = _log };

			var serialized = b.Serialize();
			serialized.Should().NotBeNullOrWhiteSpace();
			serialized.Should().Contain("log.level\":\"debug\"");

			var deserialized = EcsDocument.Deserialize(serialized);
			deserialized.Agent.Should().NotBeNull();
			deserialized.Agent.Name.Should().Be("some-agent");
			deserialized.Log.Should().NotBeNull();
			deserialized.Log.Level.Should().Be("debug");
		}
		[Fact]
		public void SerializesNestedProperties()
		{
			var b = new EcsDocument { Http = new Http { RequestMethod = "GET" } };

			var serialized = b.Serialize();
			serialized.Should().NotBeNullOrWhiteSpace();
			serialized.Should().Contain("\"request.method\":\"GET\"");

			var deserialized = EcsDocument.Deserialize(serialized);
			deserialized.Http.Should().NotBeNull();
			deserialized.Http.RequestMethod.Should().Be("GET");
		}

		[Fact]
		public void MetaDataKeysAreSerializedVerbatim()
		{
			var b = new EcsDocument
			{
				Metadata = new MetadataDictionary
				{
					["MessageTemplate"] = "some-template",
					["WriteIO"] = "some-io",
					["User_Id"] = 1,
					["eventId"] = "some-id",
					["rule"] = "some-rule",
				}
			};

			var serialized = b.Serialize();
			var deserialized = EcsSerializerFactory<EcsDocument>.Deserialize(serialized);

			deserialized.Metadata.Should().ContainKey("MessageTemplate");
			deserialized.Metadata.Should().ContainKey("WriteIO");
			deserialized.Metadata.Should().ContainKey("User_Id");
			deserialized.Metadata.Should().ContainKey("eventId");
			deserialized.Metadata.Should().ContainKey("rule");
		}

		[JsonConverter(typeof(EcsDocumentJsonConverterFactory))]
		public class SubclassedDocument : EcsDocument
		{
			[JsonPropertyName("agent2")]
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
			[JsonPropertyName("another_name")]
			public string Name2 { get; set; }
		}

		[Fact]
		public void SerializesSubClass()
		{
			var b = new SubclassedDocument { Timestamp = DateTimeOffset.Now, Agent2 = new Agent { Name = "some-agent" }, Log = _log };

			var serialized = b.Serialize();

			serialized.Should().NotBeNullOrWhiteSpace();
			serialized.Should().Contain("agent2");
			serialized.Should().Contain("log.level\":\"debug\"");

			var deserialized = EcsSerializerFactory<SubclassedDocument>.Deserialize(serialized);
			deserialized.Log.Should().NotBeNull();
			deserialized.Agent2.Should().NotBeNull();
		}

		[Fact]
		public void SerializesSubClassProperties()
		{
			var b = new EcsDocument { Agent = new SubClassedAgent { Name2 = "some-agent" }, Log = _log };

			var serialized = b.Serialize();
			serialized.Should().NotBeNullOrWhiteSpace();
			serialized.Should().Contain("some-agent");
			serialized.Should().Contain("log.level\":\"debug\"");
			serialized.Should().Contain("another_name\":\"some-agent\"");

			var deserialized = EcsSerializerFactory<SubclassedDocument>.Deserialize(serialized);
			deserialized.Log.Should().NotBeNull();
			deserialized.Log.Level.Should().Be("debug");
			deserialized.Agent.Should().NotBeNull();
		}

		[Fact]
		public void SerializesSubClassPropertiesOnSubclass()
		{
			var b = new SubclassedDocument
			{
				Agent = new SubClassedAgent { Name2 = "some-agent", Id = "X" }, Agent2 = new Agent { Name = "some-agent" }, Log = _log
			};

			var serialized = b.Serialize();

			serialized.Should().NotBeNullOrWhiteSpace();
			serialized.Should().Contain("some-agent");
			serialized.Should().Contain("log.level\":\"debug\"");

			var deserialized = EcsSerializerFactory<SubclassedDocument>.Deserialize(serialized);
			deserialized.Log.Should().NotBeNull();
			deserialized.Log.Level.Should().Be("debug");
			deserialized.Agent.Should().NotBeNull();
			deserialized.Agent.Id.Should().Be("X");
			deserialized.Agent2.Should().NotBeNull();
			deserialized.Agent2.Name.Should().Be("some-agent");
		}

		[Fact]
		public void SerializesDocumentInTheReadMe()
		{
			var ecsDocument = new EcsDocument
			{
				Timestamp = DateTimeOffset.Parse("2019-10-23T19:44:38.485Z"),
				Dns = new Dns
				{
					Id = "23666",
					OpCode = "QUERY",
					Type = "answer",
					QuestionName = "www.example.com",
					QuestionType = "A",
					QuestionClass = "IN",
					QuestionRegisteredDomain = "example.com",
					HeaderFlags = new[] { "RD", "RA" },
					ResponseCode = "NOERROR",
					ResolvedIp = new[] { "10.0.190.47", "10.0.190.117" },
					Answers = new[]
					{
						new DnsAnswers
						{
							Data = "10.0.190.47",
							Name = "www.example.com",
							Type = "A",
							Class = "IN",
							Ttl = 59
						},
						new DnsAnswers
						{
							Data = "10.0.190.117",
							Name = "www.example.com",
							Type = "A",
							Class = "IN",
							Ttl = 59
						}
					}
				},
				Network = new Network
				{
					Type = "ipv4",
					Transport = "udp",
					Protocol = "dns",
					Direction = "outbound",
					CommunityId = "1:19beef+RWVW9+BEEF/Q45VFU+2Y=",
					Bytes = 126
				},
				Source = new Source { Ip = "192.168.86.26", Port = 5785, Bytes = 31 },
				Destination = new Destination { Ip = "8.8.4.4", Port = 53, Bytes = 95 },
				Client = new Client { Ip = "192.168.86.26", Port = 5785, Bytes = 31 },
				Server = new Server { Ip = "8.8.4.4", Port = 53, Bytes = 95 },
				Event = new Event
				{
					Duration = 122433000,
					Start = DateTimeOffset.Parse("2019-10-23T19:44:38.485Z"),
					End = DateTimeOffset.Parse("2019-10-23T19:44:38.607Z"),
					Kind = "event",
					Category = new[] { "network_traffic" }
				},
				Ecs = new Ecs { Version = "1.2.0" },
				Metadata = new MetadataDictionary { { "client", "ecs-dotnet" } }
			};

			var serialized = ecsDocument.Serialize();

			serialized.Should().NotBeNullOrWhiteSpace();
			serialized.Should().Contain("1:19beef+RWVW9+BEEF");
			serialized.Should().Contain("192.168.86.26");

			var deserialized = EcsSerializerFactory<SubclassedDocument>.Deserialize(serialized);
			deserialized.Dns.Should().NotBeNull();
			deserialized.Dns.Answers.Should().NotBeNull().And.HaveCount(2);
			deserialized.Dns.Answers[0].Name.Should().NotBeNull().And.Be("www.example.com");
			deserialized.Dns.Answers[1].Data.Should().NotBeNull().And.EndWith(".117");
			deserialized.Metadata.Should().NotBeNull().And.HaveCount(1);
		}
	}
}
