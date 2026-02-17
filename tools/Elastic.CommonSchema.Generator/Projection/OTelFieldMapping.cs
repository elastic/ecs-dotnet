// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elastic.CommonSchema.Generator.Schema.DTO;

namespace Elastic.CommonSchema.Generator.Projection
{
	public enum OTelMappingKind
	{
		Attribute,
		OtlpField,
		Metric,
	}

	public class OTelFieldMapping
	{
		public string EcsFieldPath { get; set; }
		public string OTelFieldName { get; set; }
		public OTelRelation Relation { get; set; }
		public OTelStability Stability { get; set; }
		public OTelMappingKind Kind { get; set; }
		public string Note { get; set; }
	}
}
