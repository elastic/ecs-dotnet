// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.Tests;

public class EcsServiceTests
{
	public EcsServiceTests(ITestOutputHelper output) => _output = output;

	private readonly ITestOutputHelper _output;

	[Fact] public void Defaults()
	{
		var b = EcsDocument.CreateNewWithDefaults<EcsDocument>();
		b.Service.Should().NotBeNull();
		b.Service.Name.Should().NotBeNull();
		b.Service.Version.Should().NotBeNull(b.Service.Name);
	}
}
