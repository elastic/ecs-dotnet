// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Linq;
using FluentAssertions;
using Xunit;
using NLog;

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
			logger.Info("Info {ValueX} {SomeY} {NotX}", "X", 2.2, 42);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().Be("Info \"X\" 2.2 42");
			info.Metadata.Should().ContainKey("ValueX");
			info.Metadata.Should().ContainKey("SomeY");
			info.Metadata.Should().NotContainKey("NotX");

			var x = info.Metadata["ValueX"] as string;
			x.Should().NotBeNull().And.Be("X");

			var y = info.Metadata["SomeY"] as double?;
			y.Should().HaveValue().And.Be(2.2);
		});

		[Fact]
		public void SeesMessageWithSafeProp() => TestLogger((logger, getLogEvents) =>
		{
			logger.Info("Info {@SafeValue}", new NiceObject() { ValueX = "X", SomeY = 2.2 });

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().Be("Info {\"ValueX\":\"X\", \"SomeY\":2.2}");
			info.Metadata.Should().ContainKey("SafeValue");

			var x = info.Metadata["SafeValue"] as System.Collections.Generic.Dictionary<string, object>;
			x.Should().NotBeNull().And.NotBeEmpty();
		});

		[Fact]
		public void SeesMessageWithUnsafeProp() => TestLogger((logger, getLogEvents) =>
		{
			logger.Info("Info {UnsafeValue}", new NiceObject() { ValueX = "X", SomeY = 2.2 });

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().Be("Info X=X");
			info.Metadata.Should().ContainKey("UnsafeValue");

			var x = info.Metadata["UnsafeValue"] as string;
			x.Should().NotBeNull().And.Be("X=X");
		});

		public class NiceObject
		{
			public string ValueX { get; set; }
			public double SomeY { get; set; }

			public override string ToString() => $"X={ValueX}";
		}		 

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
			info.Log.OriginFunction.Should().Contain(nameof(SeesMessageWithException));
			info.Error.Message.Should().Be("Logger Exception");
			info.Error.Type.Should().Be(typeof(ArgumentException).ToString());
		});

		[Fact]
		public void MetadataWithSameKeys() => TestLogger((logger, getLogEvents) =>
		{
			using (MappedDiagnosticsLogicalContext.SetScoped("DupKey", "Mdlc"))
			{
				logger.Info("Info {DupKey}", "LoggerArg");

				var logEvents = getLogEvents();
				logEvents.Should().HaveCount(1);

				var ecsEvents = ToEcsEvents(logEvents);

				var (json, info) = ecsEvents.First();

				json.Should().Contain("\"metadata\":{\"DupKey\":\"LoggerArg\",\"DupKey_1\":\"Mdlc\"}");
				info.Message.Should().Be("Info \"LoggerArg\"");
				info.Metadata.Should().ContainKey("DupKey");
				info.Metadata.Should().ContainKey("DupKey_1");

				var x = info.Metadata["DupKey"] as string;
				x.Should().NotBeNull().And.Be("LoggerArg");

				var y = info.Metadata["DupKey_1"] as string;
				y.Should().NotBeNull().And.Be("Mdlc");
			}
		});
	}
}
