// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Linq;
using System.Text.Json.Serialization;
using Elastic.CommonSchema.Serialization;
using FluentAssertions;
using Xunit;

namespace Elastic.CommonSchema.Tests;

public class PriorityTests
{
	/// <summary> Reimplementation of logic in IndexTemplate.cs in the generator. </summary>
	private int GetPriorityFromVersion(string version)
	{
		var v = version.Split('.')
			.Select(s => uint.Parse(s))
			.ToArray();

		uint versionInteger = 0;
		versionInteger |= v[0] << 16;
		versionInteger |= v[1] << 8;
		versionInteger |= v[2];
		return (int)versionInteger;
	}

	[Fact]
	public void PriorityIsAStableIntegerRepresentationOfVersion()
	{
		GetPriorityFromVersion("8.6.0").Should().BeGreaterThan(GetPriorityFromVersion("8.5.200"));
		GetPriorityFromVersion("9.0.0").Should().BeGreaterThan(GetPriorityFromVersion("8.9.200"));
		GetPriorityFromVersion("9.0.0").Should().BeGreaterThan(GetPriorityFromVersion("8.9.999"));

		GetPriorityFromVersion("1.0.0").Should().Be(GetPriorityFromVersion("1.0.0"));
		GetPriorityFromVersion("9.9.9").Should().BeGreaterThan(GetPriorityFromVersion("2.999.999"));
		GetPriorityFromVersion("999.999.999").Should().BeGreaterThan(GetPriorityFromVersion("999.999.998"));
		GetPriorityFromVersion("0.0.002").Should().BeGreaterThan(GetPriorityFromVersion("0.0.001"));

	}
}
