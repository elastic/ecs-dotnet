// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Text.Json;
using FluentAssertions;
using Xunit;

namespace Elastic.CommonSchema.Tests;

[Collection("EnvironmentVariables")]
public class OTelTests
{
	private class Env : IDisposable
	{
		private readonly string _key;

		public Env(string key, string value)
		{
			_key = key;
			Environment.SetEnvironmentVariable(key, value);
		}

		public void Dispose() => Environment.SetEnvironmentVariable(_key, null);
	}

	// ── 1. OTelMappings Static Dictionaries ──

	[Fact]
	public void EcsToOTel_ContainsKnownEquivalentMappings()
	{
		OTelMappings.EcsToOTel.Should().ContainKey("error.message")
			.WhoseValue.Should().Contain("exception.message");

		OTelMappings.EcsToOTel.Should().ContainKey("service.environment")
			.WhoseValue.Should().Contain("deployment.environment.name");

		OTelMappings.EcsToOTel.Should().ContainKey("error.stack_trace")
			.WhoseValue.Should().Contain("exception.stacktrace");
	}

	[Fact]
	public void OTelToEcs_ContainsKnownEquivalentMappings()
	{
		OTelMappings.OTelToEcs["exception.message"].Should().Be("error.message");
		OTelMappings.OTelToEcs["deployment.environment.name"].Should().Be("service.environment");
		OTelMappings.OTelToEcs["exception.stacktrace"].Should().Be("error.stack_trace");
	}

	[Fact]
	public void AllBidirectionalEcsFields_ContainsBothMatchAndEquivalent()
	{
		// Equivalent-relation field
		OTelMappings.AllBidirectionalEcsFields.Should().Contain("error.message");
		// Match-relation fields (OTel name = ECS name)
		OTelMappings.AllBidirectionalEcsFields.Should().Contain("service.name");
		OTelMappings.AllBidirectionalEcsFields.Should().Contain("host.name");
	}

	[Fact]
	public void EcsToOTel_DoesNotContainMatchRelations()
	{
		// Match relations have identical OTel and ECS names — they should not appear in EcsToOTel
		OTelMappings.EcsToOTel.Should().NotContainKey("service.name");
		OTelMappings.EcsToOTel.Should().NotContainKey("host.name");
		OTelMappings.EcsToOTel.Should().NotContainKey("container.id");
	}

	// ── 2. AssignOTelField Method ──

	[Fact]
	public void AssignOTelField_EquivalentMapping_PopulatesBothAttributesAndEcsField()
	{
		var doc = new EcsDocument();
		doc.AssignOTelField("exception.message", "boom");

		doc.Attributes.Should().NotBeNull();
		doc.Attributes.Should().ContainKey("exception.message");
		doc.Attributes["exception.message"].Should().Be("boom");

		doc.Error.Should().NotBeNull();
		doc.Error.Message.Should().Be("boom");
	}

	[Fact]
	public void AssignOTelField_UnknownAttribute_StoredInAttributes()
	{
		var doc = new EcsDocument();
		doc.AssignOTelField("custom.my_attr", "val");

		doc.Attributes.Should().NotBeNull();
		doc.Attributes.Should().ContainKey("custom.my_attr");
		doc.Attributes["custom.my_attr"].Should().Be("val");
	}

	// ── 3. JSON Deserialization of `attributes` ──

	[Fact]
	public void Deserialize_WithAttributes_PopulatesAttributesAndMappedEcsFields()
	{
		var json = @"{""attributes"":{""exception.message"":""test error"",""exception.stacktrace"":""at Foo.Bar()""}}";
		var doc = EcsDocument.Deserialize(json);

		doc.Attributes.Should().NotBeNull();
		doc.Attributes.Should().ContainKey("exception.message");
		doc.Attributes["exception.message"].Should().Be("test error");

		doc.Error.Should().NotBeNull();
		doc.Error.Message.Should().Be("test error");
		doc.Error.StackTrace.Should().Be("at Foo.Bar()");
	}

	[Fact]
	public void Deserialize_WithAttributes_UnknownKeys_StoredInAttributes()
	{
		var json = @"{""attributes"":{""my.custom.field"":""hello""}}";
		var doc = EcsDocument.Deserialize(json);

		doc.Attributes.Should().NotBeNull();
		doc.Attributes.Should().ContainKey("my.custom.field");
		doc.Attributes["my.custom.field"].Should().Be("hello");
	}

	[Fact]
	public void Deserialize_WithNullAttributes_NoError()
	{
		var json = @"{""attributes"":null}";
		var doc = EcsDocument.Deserialize(json);

		doc.Should().NotBeNull();
	}

	[Fact]
	public void Deserialize_WithEmptyAttributes_NoError()
	{
		var json = @"{""attributes"":{}}";
		var doc = EcsDocument.Deserialize(json);

		doc.Should().NotBeNull();
	}

	// ── 4. Serialize with Attributes ──

	[Fact]
	public void Serialize_WithAttributes_WritesAttributesObject()
	{
		var doc = new EcsDocument
		{
			Timestamp = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
			Attributes = new MetadataDictionary
			{
				[SemConv.ExceptionMessage] = "boom"
			}
		};

		var json = doc.Serialize();
		json.Should().Contain("\"attributes\":");
		json.Should().Contain("\"exception.message\":\"boom\"");
	}

	[Fact]
	public void Serialize_EcsFieldsStayEcsFields()
	{
		var doc = new EcsDocument
		{
			Timestamp = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
			Message = "hello",
			Log = new Log { Level = "info" },
			Error = new Error { Message = "something failed" }
		};

		var json = doc.Serialize();

		// ECS fields should be serialized with their ECS names, NOT renamed to OTel names
		using var jsonDoc = JsonDocument.Parse(json);
		var root = jsonDoc.RootElement;

		root.TryGetProperty("@timestamp", out _).Should().BeTrue();
		root.TryGetProperty("message", out _).Should().BeTrue();
		root.TryGetProperty("log.level", out _).Should().BeTrue();
		root.TryGetProperty("ecs.version", out _).Should().BeTrue();

		// error should be a nested object at root, not inside attributes
		root.TryGetProperty("error", out var errorEl).Should().BeTrue();
		errorEl.TryGetProperty("message", out _).Should().BeTrue();

		// No attributes object when Attributes is null
		root.TryGetProperty("attributes", out _).Should().BeFalse();
	}

	[Fact]
	public void Serialize_RoundTrip_WithAttributes()
	{
		var original = new EcsDocument
		{
			Timestamp = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
			Message = "test message",
			Log = new Log { Level = "warn" },
			Attributes = new MetadataDictionary
			{
				[SemConv.ExceptionMessage] = "otel error",
				["custom.field"] = "custom value"
			}
		};

		var json = original.Serialize();
		var deserialized = EcsDocument.Deserialize(json);

		// ECS fields round-trip
		deserialized.Message.Should().Be("test message");
		deserialized.Log.Should().NotBeNull();
		deserialized.Log.Level.Should().Be("warn");

		// Attributes round-trip and OTel-mapped attributes also set ECS fields
		deserialized.Attributes.Should().NotBeNull();
		deserialized.Attributes.Should().ContainKey("exception.message");
		deserialized.Attributes["exception.message"].Should().Be("otel error");
		deserialized.Attributes.Should().ContainKey("custom.field");
		deserialized.Attributes["custom.field"].Should().Be("custom value");

		// Mapped attribute sets the ECS property on deserialization
		deserialized.Error.Should().NotBeNull();
		deserialized.Error.Message.Should().Be("otel error");
	}

	[Fact]
	public void Serialize_WithoutAttributes_NoAttributesInOutput()
	{
		var doc = new EcsDocument
		{
			Timestamp = DateTimeOffset.Parse("2024-01-01T00:00:00Z"),
			Message = "hello"
		};

		var json = doc.Serialize();
		json.Should().NotContain("\"attributes\"");
	}

	// ── 5. SemConv Constants ──

	[Fact]
	public void SemConv_HasExpectedEquivalentConstants()
	{
		SemConv.ExceptionMessage.Should().Be("exception.message");
		SemConv.ExceptionStacktrace.Should().Be("exception.stacktrace");
		SemConv.DeploymentEnvironmentName.Should().Be("deployment.environment.name");
		SemConv.CloudPlatform.Should().Be("cloud.platform");
		SemConv.ServiceInstanceId.Should().Be("service.instance.id");
	}

	[Fact]
	public void SemConv_HasExpectedMatchConstants()
	{
		SemConv.ServiceName.Should().Be("service.name");
		SemConv.HostName.Should().Be("host.name");
		SemConv.ContainerId.Should().Be("container.id");
		SemConv.ErrorType.Should().Be("error.type");
	}

	[Fact]
	public void AssignOTelField_WithSemConvConstant_Works()
	{
		var doc = new EcsDocument();
		doc.AssignOTelField(SemConv.ExceptionMessage, "boom");

		doc.Error.Should().NotBeNull();
		doc.Error.Message.Should().Be("boom");
		doc.Attributes.Should().ContainKey(SemConv.ExceptionMessage);
	}

	// ── 6. PropDispatch / Field Assignment ──

	[Fact]
	public void AssignField_OTelEquivalentName_GoesToAttributes()
	{
		// AssignField only recognizes ECS field names.
		// OTel equivalent names like "exception.message" are not in LogTemplateProperties,
		// so values fall through to Attributes. Use AssignOTelField for OTel names.
		var doc = new EcsDocument();
		doc.AssignField("exception.message", "dispatch test");

		// Not set as ECS property — stored in Attributes instead
		doc.Error.Should().BeNull();
		doc.Attributes.Should().NotBeNull();
		doc.Attributes.Should().ContainKey("exception.message");
	}

	[Fact]
	public void AssignOTelField_EquivalentName_SetsEcsProperty()
	{
		// AssignOTelField handles OTel→ECS mapping
		var doc = new EcsDocument();
		doc.AssignOTelField("exception.message", "dispatch test");

		doc.Error.Should().NotBeNull();
		doc.Error.Message.Should().Be("dispatch test");
		doc.Attributes.Should().ContainKey("exception.message");
	}

	[Fact]
	public void AssignField_EcsName_StillWorks()
	{
		var doc = new EcsDocument();
		doc.AssignField("error.message", "ecs dispatch test");

		doc.Error.Should().NotBeNull();
		doc.Error.Message.Should().Be("ecs dispatch test");
	}

	// ── 7. Resource Attributes via CreateNewWithDefaults ──

	[Fact]
	public void CreateNewWithDefaults_OTelResourceAttributes_EquivalentMapping()
	{
		using var env = new Env("OTEL_RESOURCE_ATTRIBUTES", "deployment.environment.name=production");
		var doc = EcsDocument.CreateNewWithDefaults<EcsDocument>(initialCache: new EcsDocumentCreationCache());

		doc.Service.Should().NotBeNull();
		doc.Service.Environment.Should().Be("production");

		doc.Attributes.Should().NotBeNull();
		doc.Attributes.Should().ContainKey("deployment.environment.name");
	}

	[Fact]
	public void CreateNewWithDefaults_OTelResourceAttributes_UnknownAttribute()
	{
		using var env = new Env("OTEL_RESOURCE_ATTRIBUTES", "my.custom.thing=hello");
		var doc = EcsDocument.CreateNewWithDefaults<EcsDocument>(initialCache: new EcsDocumentCreationCache());

		doc.Attributes.Should().NotBeNull();
		doc.Attributes.Should().ContainKey("my.custom.thing");
		doc.Attributes["my.custom.thing"].Should().Be("hello");
	}

	[Fact]
	public void CreateNewWithDefaults_OTelResourceAttributes_HandledAttributes_NotInAttributes()
	{
		using var env = new Env("OTEL_RESOURCE_ATTRIBUTES", "service.name=my-svc,host.name=my-host");
		var doc = EcsDocument.CreateNewWithDefaults<EcsDocument>(initialCache: new EcsDocumentCreationCache());

		// These are handled by GetService/GetHost, so should NOT appear in Attributes
		doc.Service.Should().NotBeNull();
		doc.Service.Name.Should().Be("my-svc");
		doc.Host.Should().NotBeNull();
		doc.Host.Hostname.Should().Be("my-host");

		// Attributes should be null or not contain these handled keys
		if (doc.Attributes != null)
		{
			doc.Attributes.Should().NotContainKey("service.name");
			doc.Attributes.Should().NotContainKey("host.name");
		}
	}
}
