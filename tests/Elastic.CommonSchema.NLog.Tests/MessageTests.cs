// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;
using NLog;
using Xunit.Abstractions;

namespace Elastic.CommonSchema.NLog.Tests
{
	public class MessageTests : LogTestsBase
	{
		public MessageTests(ITestOutputHelper output) : base(output) { }

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
			info.Message.Should().Be("Info X 2.2 42");
			info.Attributes.Should().ContainKey("ValueX");
			info.Attributes.Should().ContainKey("SomeY");
			info.Attributes.Should().NotContainKey("NotX");

			var x = info.Attributes["ValueX"];
			x.Should().NotBeNull().And.Be("X");

			var y = info.Attributes["SomeY"] as double?;
			y.Should().HaveValue().And.Be(2.2);
		});

		[Fact]
		public void SeesMessageWithSafeProp() => TestLogger((logger, getLogEvents) =>
		{
			logger.Info("Info {@SafeValue}", new NiceObject { ValueX = "X", SomeY = 2.2 });

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().Be("Info {\"ValueX\":\"X\", \"SomeY\":2.2}");
			info.Attributes.Should().ContainKey("SafeValue");

			var x = info.Attributes["SafeValue"] as Dictionary<string, object>;
			x.Should().NotBeNull().And.NotBeEmpty();
		});

		[Fact]
		public void SeesMessageWithUnsafeProp() => TestLogger((logger, getLogEvents) =>
		{
			logger.Info("Info {UnsafeValue}", new NiceObject{ ValueX = "X", SomeY = 2.2 });

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().Be("Info X=X");
			info.Attributes.Should().NotBeNull();
			info.Attributes.Should().ContainKey("UnsafeValue");

			var x = info.Attributes["UnsafeValue"];
			x.Should().NotBeNull().And.Be("X=X");
		});

		public class NiceObject
		{
			public string ValueX { get; set; }
			public double SomeY { get; set; }

			public override string ToString() => $"X={ValueX}";
		}

		[Fact]
		public void SeesMessageWithStructuredProperty() => TestLogger((logger, getLogEvents) =>
		{
			logger.Info("Info {@SafeValue}", new NiceObject { ValueX = "X", SomeY = 2.2 });

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().Be("Info {\"ValueX\":\"X\", \"SomeY\":2.2}");
			info.Attributes.Should().ContainKey("SafeValue");

			var x = info.Attributes["SafeValue"] as Dictionary<string, object>;
			x.Should().NotBeNull().And.NotBeEmpty();
		});

		[Fact]
		public void SeesMessageWithStructuredPropAsString() => TestLogger((logger, getLogEvents) =>
		{
			logger.Info("Info {StructuredValue}", new NiceObject { ValueX = "X", SomeY = 2.2 });

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().Be("Info X=X");
			info.Attributes.Should().NotBeNull();
			info.Attributes.Should().ContainKey("StructuredValue");

			var x = info.Attributes["StructuredValue"];
			x.Should().NotBeNull().And.Be("X=X");
		});

		[Fact]
		public void SerializesKnownBadObject() => TestLogger((logger, getLogEvents) =>
		{
			logger.Info("Info {@EvilValue}", new BadObject());

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().StartWith("Info {\"TypeProperty");
			info.Attributes.Should().ContainKey("EvilValue");

			var x = info.Attributes["EvilValue"] as Dictionary<string, object>;
			x.Should().NotBeNull().And.NotBeEmpty();
		});

		[Fact]
		public void SerializesObjectThatThrowsOnGetter() => TestLogger((logger, getLogEvents) =>
		{
			logger.Info("Info {@EvilValue}", new BadObject(true));

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var ecsEvents = ToEcsEvents(logEvents);

			var (_, info) = ecsEvents.First();
			info.Message.Should().StartWith("Info {\"TypeProperty");
			info.Attributes.Should().NotContainKey("EvilValue");
			info.Attributes.Should().ContainKey("__failures__");

			var failures = info.Attributes["__failures__"] as List<object>;
			failures.Should().NotBeNull().And.HaveCount(1);
			var failure = failures![0] as MetadataDictionary;
			failure!["reason"].Should().NotBeNull();
			failure["key"].Should().Be("EvilValue");
		});

		private class BadObject
		{
			private readonly bool _throws;
			// public IEnumerable<object> Recursive => new List<object>(new[] { "Hello", (object)this })

			public BadObject() => _throws = false;
			public BadObject(bool @throw) => _throws = @throw;

			// ReSharper disable UnusedMember.Local
			public Type TypeProperty { get; } = typeof(BadObject);

			public System.Reflection.MethodInfo MethodInfoProperty { get; } = typeof(BadObject).GetProperty(nameof(MethodInfoProperty))?.GetMethod;

			public Action DelegateProperty { get; } = () => throw new NotSupportedException();

			public System.Collections.IEqualityComparer ComparerProperty { get; } = StringComparer.OrdinalIgnoreCase;

			public IFormatProvider CultureProperty { get; } = System.Globalization.CultureInfo.InvariantCulture;

			public string EvilProperty => _throws ? throw new NotSupportedException() : "EvilProperty";
			// ReSharper restore UnusedMember.Local
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
				logger?.Error(ex, "My Exception!");
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
			using (ScopeContext.PushProperty("DupKey", "Mdlc"))
			{
				logger.Info("Info {DupKey}", "LoggerArg");

				var logEvents = getLogEvents();
				logEvents.Should().HaveCount(1);

				var ecsEvents = ToEcsEvents(logEvents);

				var (json, info) = ecsEvents.First();

				info.Message.Should().Be("Info LoggerArg");
				info.Attributes.Should().Contain("DupKey", (object)"LoggerArg");
				info.Attributes.Should().Contain("DupKey_1", (object)"Mdlc");

				var x = info.Attributes["DupKey"];
				x.Should().NotBeNull().And.Be("LoggerArg");

				var y = info.Attributes["DupKey_1"];
				y.Should().NotBeNull().And.Be("Mdlc");
			}
		});

	}
}
