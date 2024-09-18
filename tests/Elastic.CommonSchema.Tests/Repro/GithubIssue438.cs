using System;
using FluentAssertions;
using Xunit;

namespace Elastic.CommonSchema.Tests.Repro
{
	public class GithubIssue438
	{
		[Fact]
		public void Reproduce()
		{
			// language=json
			var json =
				"""
				{
					"@timestamp":"2022-11-08T09:36:37.249Z",
					"log.level":"info",
					"message":"['vo_phi_pkg\\\\runtime_recon.py']",
					"ecs":{"version":"1.6.0"},
					"log":{
						"logger":"root",
						"origin":{"file":{"line":90,"name":"main.py"},"function":"prepare_logging"},
						"original":"['vo_phi_pkg\\\\runtime_recon.py']"},
						"process":{"name":"MainProcess","pid":35436,"thread":{"id":13180,"name":"MainThread"}}
					}
				""";
			var entry1 = System.Text.Json.JsonSerializer.Deserialize<EcsDocument>(json);
		}
	}
}
