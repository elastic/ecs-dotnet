using System.Diagnostics;

namespace Elastic.CommonSchema.NLog
{
	/// <summary>
	/// Helpers for getting the right values from Activity no matter the format (w3c or hierarchical)
	/// </summary>
	internal static class ActivityExtensions
	{
		private static readonly ActivitySpanId EmptySpanId = default;
		private static readonly ActivityTraceId EmptyTraceId = default;

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
			if (EmptySpanId.Equals(spanId))
				return string.Empty;

			var spanHexString = spanId.ToHexString();
			if (ReferenceEquals(spanHexString, EmptySpanId.ToHexString()))
				return string.Empty;

			return spanHexString;
		}

		private static string TraceIdToHexString(ActivityTraceId traceId)
		{
			if (EmptyTraceId.Equals(traceId))
				return string.Empty;

			var traceHexString = traceId.ToHexString();
			return ReferenceEquals(traceHexString, EmptyTraceId.ToHexString())
				? string.Empty
				: traceHexString;
		}
	}
}
