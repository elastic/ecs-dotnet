// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using log4net;
using log4net.Core;
using Xunit;

namespace Elastic.CommonSchema.Log4net.Tests
{
	[CollectionDefinition("EcsProperties", DisableParallelization = true)]
	public class EcsFieldsAsPropertiesTests : LogTestsBase
	{
		private const string FixedTraceId = "my-trace-id";

		[Fact]
		public void EcsFieldInLogProperties()
		{
			void LogAndAssert(ILog log, Func<List<string>> getLogEvents)
			{
				log.Info("DummyText");

				var logEvents = getLogEvents();
				logEvents.Should().HaveCount(1);

				var (_, info) = ToEcsEvents(logEvents).First();
				info.TraceId.Should().Be(FixedTraceId);
			}

			// Testing these in one unit test because ThreadContext overwrites LogicalThreadContext which overwrites GlobalContext.
			// Testing these in isolation introduces race issues when we remove the property

			LogicalThreadContext.Properties[LogTemplateProperties.TraceId] = FixedTraceId;
			try
			{
				TestLogger(LogAndAssert);
			}
			finally
			{
				LogicalThreadContext.Properties.Remove(LogTemplateProperties.TraceId);
			}

			ThreadContext.Properties[LogTemplateProperties.TraceId] = FixedTraceId;
			try
			{
				TestLogger(LogAndAssert);
			}
			finally
			{
				ThreadContext.Properties.Remove(LogTemplateProperties.TraceId);
			}
			TestLogger((log, getLogEvents) =>
			{
				var loggingEvent = new LoggingEvent(GetType(), log.Logger.Repository, log.Logger.Name, Level.Info, "DummyText", null);
				loggingEvent.Properties[LogTemplateProperties.TraceId] = FixedTraceId;
				log.Logger.Log(loggingEvent);

				var logEvents = getLogEvents();
				logEvents.Should().HaveCount(1);

				var (_, info) = ToEcsEvents(logEvents).First();
				info.TraceId.Should().Be(FixedTraceId);
			});

			GlobalContext.Properties[LogTemplateProperties.TraceId] = FixedTraceId;
			try
			{
				TestLogger(LogAndAssert);
			}
			finally
			{
				GlobalContext.Properties.Remove(LogTemplateProperties.TraceId);
			}

		}


		[Fact]
		public void EcsFieldsInThreadContextStack() => TestLogger((log, getLogEvents) =>
		{
			using var _ = ThreadContext.Stacks[LogTemplateProperties.TraceId].Push(FixedTraceId);

			log.Info("DummyText");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var (_, info) = ToEcsEvents(logEvents).First();
			info.TraceId.Should().Be(FixedTraceId);
		});

		[Fact]
		public void EcsFieldsInLogicalTheadContextStack() => TestLogger((log, getLogEvents) =>
		{
			using var _ = LogicalThreadContext.Stacks[LogTemplateProperties.TraceId].Push(FixedTraceId);

			log.Info("DummyText");

			var logEvents = getLogEvents();
			logEvents.Should().HaveCount(1);

			var (_, info) = ToEcsEvents(logEvents).First();
			info.TraceId.Should().Be(FixedTraceId);
		});

	}
}
