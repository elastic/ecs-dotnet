// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Tests;

public class EcsServiceTests
{
	public EcsServiceTests(ITestOutputHelper output) => _output = output;

	private readonly ITestOutputHelper _output;

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

	[Fact] public void Defaults()
	{
		var b = EcsDocument.CreateNewWithDefaults<EcsDocument>();
		b.Service.Should().NotBeNull();
		b.Service.Name.Should().NotBeNull();
		b.Service.Version.Should().NotBeNull(b.Service.Name);
	}

	[Fact] public void UsesApmServiceEnvVar()
	{
		using var env1 = new Env("ELASTIC_APM_SERVICE_NAME", "test-service");
		using var env2 = new Env("ELASTIC_APM_SERVICE_VERSION", "0.0.2");
		var b = EcsDocument.CreateNewWithDefaults<EcsDocument>(initialCache: new EcsDocumentCreationCache());
		b.Service.Should().NotBeNull();
		b.Service.Name.Should().Be("test-service");
		b.Service.Version.Should().NotBeNull("0.0.2");
	}
	[Fact] public void OtelEnvHasPrecedence()
	{
		using var env1 = new Env("OTEL_SERVICE_NAME", "test-service-otel");
		using var env2 = new Env("ELASTIC_APM_SERVICE_NAME", "test-service");
		using var env3 = new Env("ELASTIC_APM_SERVICE_VERSION", "0.0.2");
		var b = EcsDocument.CreateNewWithDefaults<EcsDocument>(initialCache: new EcsDocumentCreationCache());
		b.Service.Should().NotBeNull();
		b.Service.Name.Should().Be("test-service-otel");
		b.Service.Version.Should().NotBeNull("0.0.2");
	}
	[Fact] public void OtelResourceAttrEnvHasPrecedence()
	{
		using var env1 = new Env("OTEL_RESOURCE_ATTRIBUTES", "service.name=test-service-otel-attr,some-other=x,y");
		using var env2 = new Env("ELASTIC_APM_SERVICE_NAME", "test-service");
		using var env3 = new Env("ELASTIC_APM_SERVICE_VERSION", "0.0.2");
		var b = EcsDocument.CreateNewWithDefaults<EcsDocument>(initialCache: new EcsDocumentCreationCache());
		b.Service.Should().NotBeNull();
		b.Service.Name.Should().Be("test-service-otel-attr");
		b.Service.Version.Should().NotBeNull("0.0.2");
	}
	[Fact] public void OtelServiceEnvHasPrecedenceOverAttributes()
	{
		using var env1 = new Env("OTEL_RESOURCE_ATTRIBUTES", "service.name=otel-attr,some-other=x,y");
		using var env2 = new Env("OTEL_SERVICE_NAME", "otel-service");
		using var env3 = new Env("ELASTIC_APM_SERVICE_VERSION", "0.0.2");
		var b = EcsDocument.CreateNewWithDefaults<EcsDocument>(initialCache: new EcsDocumentCreationCache());
		b.Service.Should().NotBeNull();
		b.Service.Name.Should().Be("otel-service");
		b.Service.Version.Should().NotBeNull("0.0.2");
	}
	[Fact] public void ApmServiceEnvironment()
	{
		using var env1 = new Env("ELASTIC_APM_ENVIRONMENT", "staging");
		var b = EcsDocument.CreateNewWithDefaults<EcsDocument>(initialCache: new EcsDocumentCreationCache());
		b.Service.Should().NotBeNull();
		b.Service.Environment.Should().Be("staging");
	}
	[Fact] public void OtelAttributePrecedenceOverApmServiceEnvironment()
	{
		using var env1 = new Env("ELASTIC_APM_ENVIRONMENT", "staging");
		using var env2 = new Env("OTEL_RESOURCE_ATTRIBUTES", "deployment.environment=production");
		var b = EcsDocument.CreateNewWithDefaults<EcsDocument>(initialCache: new EcsDocumentCreationCache());
		b.Service.Should().NotBeNull();
		b.Service.Environment.Should().Be("production");
	}
}
