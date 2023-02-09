// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.NLog.Tests
{
	public class EcsFieldsInTemplateTests : LogTestsBase
	{
		public EcsFieldsInTemplateTests(ITestOutputHelper output) : base(output) { }

		[Fact]
		public void CanUseEcsFieldNamesAsTemplateProperty() => TestLogger((logger, getLogEvents) =>
		{
			logger.Info($"Info {{TraceId}}: {{{LogTemplateProperties.FaasColdstart}}}", "my-trace-id", true);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().Be("Info \"my-trace-id\": true");
			info.Labels.Should().BeNull();
			info.Metadata.Should().BeNull();

			info.TraceId.Should().Be("my-trace-id");
			info.Faas.Should().NotBeNull();
			info.Faas.Coldstart.Should().BeTrue();
		});

	}
}
