// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Elastic.CommonSchema.Generator.Schema.DTO
{
	public enum OTelRelation
	{
		[EnumMember(Value = "match")] Match,
		[EnumMember(Value = "equivalent")] Equivalent,
		[EnumMember(Value = "otlp")] Otlp,
		[EnumMember(Value = "metric")] Metric,
		[EnumMember(Value = "related")] Related,
		[EnumMember(Value = "conflict")] Conflict,
		[EnumMember(Value = "na")] Na,
	}

	public enum OTelStability
	{
		[EnumMember(Value = "stable")] Stable,
		[EnumMember(Value = "experimental")] Experimental,
		[EnumMember(Value = "development")] Development,
	}

	[JsonObject(MemberSerialization.OptIn)]
	public class FieldOTelMapping
	{
		[JsonProperty("attribute")]
		public string Attribute { get; set; }

		[JsonProperty("otlp_field")]
		public string OtlpField { get; set; }

		[JsonProperty("metric")]
		public string Metric { get; set; }

		[JsonProperty("relation")]
		[JsonConverter(typeof(StringEnumConverter))]
		public OTelRelation Relation { get; set; }

		[JsonProperty("stability")]
		[JsonConverter(typeof(StringEnumConverter))]
		public OTelStability Stability { get; set; }

		[JsonProperty("note")]
		public string Note { get; set; }

		/// <summary>
		/// Returns whichever source key is set: attribute, otlp_field, or metric.
		/// </summary>
		public string OTelFieldName => Attribute ?? OtlpField ?? Metric;

		/// <summary>
		/// True for match/equivalent relations which support bidirectional mapping.
		/// </summary>
		public bool IsBidirectional => Relation is OTelRelation.Match or OTelRelation.Equivalent;
	}
}
