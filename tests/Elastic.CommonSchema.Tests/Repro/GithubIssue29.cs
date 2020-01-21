using System;
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Elastic.CommonSchema.Tests.Repro
{
	public class GithubIssue29
	{
		[Fact]
		public void Reproduce()
		{
			// Metadata properties with null values should be serialised
			var uniqueName = Guid.NewGuid().ToString();
			var root = new Base
			{
				Metadata = new Dictionary<string, object>
				{
					{ uniqueName, null }
				}
			};

			var serialised = root.Serialize();
			serialised.Should().Contain($"\"{uniqueName}\":null");
		}
	}
}
