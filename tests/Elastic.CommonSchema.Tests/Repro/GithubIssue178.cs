using System;
using FluentAssertions;
using Xunit;

namespace Elastic.CommonSchema.Tests.Repro
{
	public class GithubIssue178
	{
		[Fact]
		public void Reproduce()
		{
			var x = new EcsDocument
			{
				Timestamp = DateTime.UtcNow,
				Organization = new Organization { Id = Guid.NewGuid().ToString() }
			};

			var serialized = x.Serialize();
			var deserialized = EcsDocument.Deserialize(serialized);

			deserialized.Should().NotBeNull();
			deserialized.Organization.Should().NotBeNull();
			deserialized.Organization.Id.Should().NotBeNullOrEmpty();
			deserialized.Agent.Should().BeNull();
		}
	}
}
