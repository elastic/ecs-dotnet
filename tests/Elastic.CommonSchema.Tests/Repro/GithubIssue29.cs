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
			// Metadata properties with null values should not be serialised
			var uniqueName = new Guid().ToString();
			var root = new Base
			{
				Metadata = new Dictionary<string, object>
				{
					{ uniqueName, null }
				}
			};

			var serialised = root.Serialize();
			serialised.Should().NotContain(uniqueName);
		}
	}
}
