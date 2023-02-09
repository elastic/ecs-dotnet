// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Collections.Generic;
using System.IO;
using log4net.Appender;
using log4net.Core;

namespace Elastic.CommonSchema.Log4net.Tests;

internal class TestAppender : AppenderSkeleton
{
	public List<string> Events { get; } = new();

	protected override void Append(LoggingEvent loggingEvent)
	{
		using var writer = new StringWriter();


		if (Layout == null)
			loggingEvent.WriteRenderedMessage(writer);
		else
			Layout.Format(writer, loggingEvent);

		Events.Add(writer.ToString());
	}
}
