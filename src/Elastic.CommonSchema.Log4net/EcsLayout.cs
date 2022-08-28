// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.IO;
using log4net.Core;
using log4net.Layout;

namespace Elastic.CommonSchema.Log4net;

/// <summary>
/// Formats log events into a JSON representation that adheres to Elastic Common Schema specification
/// </summary>
public class EcsLayout : LayoutSkeleton
{
    public override string ContentType => "application/json";

	public override void ActivateOptions() => IgnoresException = false;

	public override void Format(TextWriter writer, LoggingEvent loggingEvent)
    {
        var ecsEvent = loggingEvent.ToEcs();
        writer.WriteLine(ecsEvent.Serialize());
    }
}
