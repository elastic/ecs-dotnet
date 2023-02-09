// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Diagnostics;

namespace Elastic.CommonSchema;

public static class EcsDocumentExtensions
{
	/// <summary>
	/// Mutates <see cref="doc"/> and sets tracing information based on <see cref="activity" /> or <see cref="Activity.Current"/>
	/// <para>Note this will not override any explicitly set properties</para>
	/// </summary>
	public static void SetActivityData(this EcsDocument doc, Activity activity = null)
	{
		activity ??= Activity.Current;
		if (activity == null)
		{
			if (!Trace.CorrelationManager.ActivityId.Equals(Guid.Empty))
				doc.TraceId ??= Trace.CorrelationManager.ActivityId.ToString();
			return;
		}
		if (activity.IdFormat == ActivityIdFormat.W3C)
		{
			doc.TraceId ??= activity.TraceId.ToString();
			doc.SpanId ??= activity.SpanId.ToString();
		}
		else
		{
			if (activity.RootId != null) doc.TraceId ??= activity.RootId;
			if (activity.Id != null) doc.SpanId ??= activity.Id;
		}

		//TODO Should we copy more data over?
		//For now we just do the minimum to enable log correlation
	}
}
