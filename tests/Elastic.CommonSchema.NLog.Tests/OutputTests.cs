// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.NLog.Tests
{
	public class OutputTests : LogTestsBase
	{
		public OutputTests(ITestOutputHelper output) : base(output) { }

		[Fact]
		public void LogMultiple() => TestLogger((logger, getLogEvents) =>
		{
			logger.Info("My log message!");
			logger.Info("Test output to NLog!");
			void sketchy() => throw new Exception("I threw up.");
			var exception = Record.Exception(sketchy);
			logger.Error(exception, "Here is an error.");
			Assert.NotNull(exception);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(3);

			var ecsEvents = ToEcsEvents(logEvents);
			var (_, error) = ecsEvents.Last();
			error.Log.Level.Should().Be("Error");
			error.Error.Should().NotBeNull();

			var (_, info) = ecsEvents.First();
			info.Log.Level.Should().Be("Info");
			info.Error.Should().BeNull();
		});
	}
}
