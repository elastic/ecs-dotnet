using System.Diagnostics;

namespace Elastic.CommonSchema.NLog
{
	/// <summary>
	/// Helpers for getting the right values from Activity no matter the format (w3c or hierarchical)
	/// </summary>
	internal static class ActivityExtensions
	{
		private static readonly string EmptySpanIdToHexString = default(System.Diagnostics.ActivitySpanId).ToHexString();
		private static readonly string EmptyTraceIdToHexString = default(System.Diagnostics.ActivityTraceId).ToHexString();

		public static string GetSpanId(this Activity activity) =>
			activity.IdFormat == ActivityIdFormat.W3C ?
				SpanIdToHexString(activity.SpanId) :
				activity.Id;

		public static string GetTraceId(this Activity activity) =>
			activity.IdFormat == ActivityIdFormat.W3C ?
				TraceIdToHexString(activity.TraceId) :
				activity.RootId;

		public static string GetParentId(this Activity activity) =>
			activity.IdFormat == ActivityIdFormat.W3C ?
				SpanIdToHexString(activity.ParentSpanId) :
				activity.ParentId;

		private static string SpanIdToHexString(ActivitySpanId spanId)
		{
			var spanIdString = spanId.ToHexString();
			if (ReferenceEquals(EmptySpanIdToHexString, spanIdString))
				return string.Empty;
			else
				return spanIdString;
		}

		private static string TraceIdToHexString(ActivityTraceId traceId)
		{
			var traceIdString = traceId.ToHexString();
			if (ReferenceEquals(EmptyTraceIdToHexString, traceIdString))
				return string.Empty;
			else
				return traceIdString;
		}
	}
}
