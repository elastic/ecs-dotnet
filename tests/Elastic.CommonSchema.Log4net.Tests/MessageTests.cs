// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Linq;
using FluentAssertions;
using log4net;
using log4net.Core;
using Xunit;

namespace Elastic.CommonSchema.Log4net.Tests
{
	public class MessageTests : LogTestsBase
	{
		[Fact]
		public void ToEcs_AnyEvent_PopulatesBaseFields() => TestLogger((log, getLogEvents) =>
		{
			log.Info("DummyText");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var (_, info) = ToEcsEvents(logEvents).First();

			info.Should().NotBeNull();

			info.Timestamp.Should().BeWithin(TimeSpan.FromSeconds(5));
			info.Ecs.Version.Should().Be(EcsDocument.Version);
			info.Message.Should().Be("DummyText");
		});

		[Fact]
		public void ToEcs_AnyEvent_PopulatesLogField() => TestLogger((log, getLogEvents) =>
		{
			log.Info("DummyText");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var (_, info) = ToEcsEvents(logEvents).First();

			info.Log.Should().NotBeNull();

			info.Log.Level.Should().Be("INFO");
			info.Log.Logger.Should().Be(GetType().Name);
			info.Log.OriginFunction.Should().NotBeNullOrEmpty();
		});

		[Fact]
		public void ToEcs_AnyEvent_PopulatesEventField() => TestLogger((log, getLogEvents) =>
		{
			log.Info("DummyText");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var (_, info) = ToEcsEvents(logEvents).First();

			info.Event.Should().NotBeNull();
			info.Event.Created.Should().BeWithin(TimeSpan.FromSeconds(5));
			info.Event.Timezone.Should().Be(TimeZoneInfo.Local.StandardName);
		});

		[Fact]
		public void ToEcs_AnyEvent_PopulatesProcessField() => TestLogger((log, getLogEvents) =>
		{
			var loggingEvent = new LoggingEvent(GetType(), log.Logger.Repository, log.Logger.Name, Level.Info, "DummyText", null);
			log.Logger.Log(loggingEvent);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var (_, info) = ToEcsEvents(logEvents).First();

			info.Process.Should().NotBeNull();
			if (int.TryParse(loggingEvent.ThreadName, out var threadId))
				info.Process.ThreadId.Should().Be(threadId);
			else
				info.Process.ThreadName.Should().Be(loggingEvent.ThreadName);
		});

		[Fact]
		public void ToEcs_AnyEvent_PopulatesHostField() => TestLogger((log, getLogEvents) =>
		{
			var loggingEvent = new LoggingEvent(GetType(), log.Logger.Repository, log.Logger.Name, Level.Info, "DummyText", null);
			log.Logger.Log(loggingEvent);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var (_, info) = ToEcsEvents(logEvents).First();

			info.Host.Should().NotBeNull();
			info.Host.Hostname.Should().Be(loggingEvent.LookupProperty(LoggingEvent.HostNameProperty).ToString());
		});

		[Fact]
		public void ToEcs_EventWithException_PopulatesErrorField() => TestLogger((log, getLogEvents) =>
		{
			var innerException = new ArgumentException("Wrong argument");
			try
			{
				try
				{
					throw innerException;
				}
				catch (Exception e)
				{
					throw new InvalidOperationException("Oops", e);
				}
			}
			catch (Exception e)
			{
				log.Info("DummyText", e);

				var logEvents = getLogEvents();
				logEvents.Should().HaveCount(1);

				var (_, info) = ToEcsEvents(logEvents).First();

				info.Error.Should().NotBeNull();
				info.Error.Message.Should().Be(e.Message);
				info.Error.Type.Should().Be(e.GetType().FullName);

				info.Error.StackTrace.Should().Contain(e.Message);
				info.Error.StackTrace.Should().Contain("at void");

				info.Error.StackTrace.Should().Contain(innerException.Message);
				info.Error.StackTrace.Should().Contain("at void");
			}
		});

		[Fact]
		public void ToEcs_EventWithFormat_MetadataContainsTemplateAndArgs() => TestLogger((log, getLogEvents) =>
		{
			log.InfoFormat("Log with {0}", "format");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var (_, info) = ToEcsEvents(logEvents).First();

			info.Should().NotBeNull();
			info.Labels.Should().NotBeNull();

			info.Labels["MessageTemplate"].Should().Be("Log with {0}");
			info.Labels["0"].Should().Be("format");
		});

		[Fact]
		public void ToEcs_AnyEvent_PopulatesMetadataFieldWithoutLog4netProperties() => TestLogger((log, getLogEvents) =>
		{
			log.Info("DummyText");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var (_, info) = ToEcsEvents(logEvents).First();

			if (info.Metadata != null)
			{
				info.Metadata.Should().NotContainKey(LoggingEvent.IdentityProperty);
				info.Metadata.Should().NotContainKey(LoggingEvent.HostNameProperty);
				info.Metadata.Should().NotContainKey(LoggingEvent.UserNameProperty);
			}
			if (info.Labels != null)
			{
				info.Labels.Should().NotContainKey(LoggingEvent.IdentityProperty);
				info.Labels.Should().NotContainKey(LoggingEvent.HostNameProperty);
				info.Labels.Should().NotContainKey(LoggingEvent.UserNameProperty);
			}
		});

		[Fact]
		public void ToEcs_EventWithGlobalContextProperty_PopulatesMetadataField() => TestLogger((log, getLogEvents) =>
		{
			const string property = "global-prop";
			const string propertyValue = "global-value";
			GlobalContext.Properties[property] = propertyValue;

			try
			{
				log.Info("DummyText");

				var logEvents = getLogEvents();
				logEvents.Should().HaveCount(1);

				var (_, info) = ToEcsEvents(logEvents).First();

				info.Labels.Should().ContainKey(property);
				info.Labels[property].Should().Be(propertyValue);
			}
			finally
			{
				GlobalContext.Properties.Remove(property);
			}
		});

		[Fact]
		public void ToEcs_EventWithThreadContextStack_PopulatesMetadataField() => TestLogger((log, getLogEvents) =>
		{
			const string property = "thread-context-stack-prop";
			const string propertyValue = "thread-context-stack-value";
			using var _ = ThreadContext.Stacks[property].Push(propertyValue);

			log.Info("DummyText");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var (_, info) = ToEcsEvents(logEvents).First();

			info.Labels.Should().ContainKey(property);
			info.Labels[property].Should().Be(propertyValue);
		});

		[Fact]
		public void ToEcs_EventWithThreadContextProperty_PopulatesMetadataField() => TestLogger((log, getLogEvents) =>
		{
			const string property = "thread-context-prop";
			const string propertyValue = "thread-context-value";
			ThreadContext.Properties[property] = propertyValue;

			try
			{
				log.Info("DummyText");

				var logEvents = getLogEvents();
				logEvents.Should().HaveCount(1);

				var (_, info) = ToEcsEvents(logEvents).First();

				info.Labels.Should().ContainKey(property);
				info.Labels[property].Should().Be(propertyValue);
			}
			finally
			{
				ThreadContext.Properties.Remove(property);
			}
		});

		[Fact]
		public void ToEcs_EventInLogicalThreadContextStack_PopulatesMetadataField() => TestLogger((log, getLogEvents) =>
		{
			const string property = "logical-thread-context-stack-prop";
			const string propertyValue = "logical-thread-context-stack-value";
			using var _ = LogicalThreadContext.Stacks[property].Push(propertyValue);

			log.Info("DummyText");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var (_, info) = ToEcsEvents(logEvents).First();

			info.Metadata.Should().BeNull();
			info.Labels.Should().NotBeNull();

			info.Labels.Should().ContainKey(property);
			info.Labels[property].Should().Be(propertyValue);
		});

		[Fact]
		public void ToEcs_EventWithLogicalThreadContextProperty_PopulatesMetadataField() => TestLogger((log, getLogEvents) =>
		{
			const string property = "logical-thread-context-prop";
			const string propertyValue = "logical-thread-context-value";
			const string metadataProperty = "logical-thread-context-prop-metadata";
			LogicalThreadContext.Properties[property] = propertyValue;
			LogicalThreadContext.Properties[metadataProperty] = 2.0;

			try
			{
				log.Info("DummyText");

				var logEvents = getLogEvents();
				logEvents.Should().HaveCount(1);

				var (_, info) = ToEcsEvents(logEvents).First();

				info.Labels.Should().ContainKey(property);
				info.Labels[property].Should().Be(propertyValue);
				info.Metadata.Should().ContainKey(metadataProperty);
				info.Metadata[metadataProperty].Should().Be(2.0);
			}
			finally
			{
				LogicalThreadContext.Properties.Remove(property);
			}
		});

		[Fact]
		public void ToEcs_EventWithProperties_PopulatesMetadataField() => TestLogger((log, getLogEvents) =>
		{
			const string property = "additional-prop";
			const string propertyValue = "additional-value";

			var loggingEvent = new LoggingEvent(GetType(), log.Logger.Repository, log.Logger.Name, Level.Info, "DummyText", null);
			loggingEvent.Properties[property] = propertyValue;
			log.Logger.Log(loggingEvent);

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var (_, info) = ToEcsEvents(logEvents).First();

			info.Labels.Should().ContainKey(property);
			info.Labels[property].Should().Be(propertyValue);
		});
	}
}
