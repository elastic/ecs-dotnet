// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Elastic.CommonSchema.NLog.Tests
{
	public class MessageTests : LogTestsBase
	{
		[Fact]
		public void SeesMessage() => TestLogger((logger, getLogEvents) =>
		{
			logger.Info("My log message!");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().Be("My log message!");
		});

		[Fact]
		public void SeesMessageWithProp() => TestLogger((logger, getLogEvents) =>
		{
			logger.Info("Info {ValueX} {SomeY}", "X", 2.2);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().Be("Info \"X\" 2.2");
			info.Metadata.Should().ContainKey("value_x");
			info.Metadata.Should().ContainKey("some_y");

			var x = info.Metadata["value_x"] as string;
			x.Should().NotBeNull().And.Be("X");

			var y = info.Metadata["some_y"] as double?;
			y.Should().HaveValue().And.Be(2.2);
		});

		[Fact]
		public void SeesMessageWithException() => TestLogger((logger, getLogEvents) =>
		{
			try
			{
				if (logger != null)
					throw new ArgumentException("Logger Exception");
			}
			catch (Exception ex)
			{
				logger.Error(ex, "My Exception!");
			}

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Log.Origin.Function.Should().Contain(nameof(SeesMessageWithException));
			info.Error.Message.Should().Be("Logger Exception");
			info.Error.Type.Should().Be(typeof(ArgumentException).ToString());
		});
	}
}
