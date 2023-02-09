// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using Elastic.CommonSchema.Tests.Specs;
using log4net;
using log4net.Core;
using log4net.Repository.Hierarchy;


namespace Elastic.CommonSchema.Log4net.Tests
{
	public abstract class LogTestsBase
	{
		private static readonly object _lock = new();
		protected List<(string Json, EcsDocument Base)> ToEcsEvents(List<string> logEvents) =>
			logEvents.Select(s => (s, EcsDocument.Deserialize(s)))
				.ToList();

		protected void TestLogger(Action<ILog, Func<List<string>>> act)
		{
			lock (_lock)
			{
				var repositoryId = Guid.NewGuid().ToString();
				var hierarchy = (Hierarchy)LogManager.CreateRepository(repositoryId);
				var appender = new TestAppender
				{
					Layout = new EcsLayout()
				};
				hierarchy.Root.AddAppender(appender);
				hierarchy.Root.Level = Level.All;
				hierarchy.Configured = true;

				List<string> GetAndValidateLogEvents()
				{
					foreach (var log in appender.Events)
						Spec.Validate(log);

					return appender.Events;
				}

				var log = LogManager.GetLogger(repositoryId, GetType().Name);
				act(log, GetAndValidateLogEvents);
			}
		}
	}
}
