// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Elastic.CommonSchema.Generator.Schema.DTO
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Field
	{
		/// <summary>
		///  Name of the field.
		/// </summary>
		[JsonProperty("name", Required = Required.Always)]
		public string Name { get; set; }

		/// <summary>
		///  indicates the beta header appropriate for this field
		/// </summary>
		[JsonProperty("beta")]
		public string Beta { get; set; }

		/// <summary>
		///  The name of this field, separated by hyphens.
		/// </summary>
		[JsonProperty("dashed_name", Required = Required.Always)]
		public string DashedName { get; set; }

		/// <summary>
		///  The name of this field, separated by dots.
		/// </summary>
		[JsonProperty("flat_name", Required = Required.Always)]
		public string FlatName { get; set; }

		/// <summary>
		///  Description of the field (required)
		/// </summary>
		[JsonProperty("description", Required = Required.Always)]
		public string Description { get; set; }

		/// <summary>
		///  Shorter definition, for display in tight spaces (optional)
		/// </summary>
		[JsonProperty("short")]
		public string Short { get; set; }

		/// <summary>
		///  Type of the field (required)
		/// </summary>
		[JsonProperty("type", Required = Required.Always)]
		[JsonConverter(typeof(StringEnumConverter))]
		public FieldType Type { get; set; }

		/// <summary>
		///  Elasticsearch Type of the field.
		/// </summary>
		[JsonProperty("object_type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public FieldType? ObjectType { get; set; }

		/// <summary>
		///  A single value example of what can be expected in this field.
		/// </summary>
		[JsonProperty("example")]
		public object Example { get; set; }

		/// <summary>
		///  The format for this field. e.g. "bytes"
		/// </summary>
		[JsonProperty("format")]
		public string Format { get; set; }

		/// <summary>
		///  Determines the input format. e.g. "nanoseconds"
		/// </summary>
		[JsonProperty("input_format")]
		public string InputFormat { get; set; }

		/// <summary>
		///  Is this field required?
		/// </summary>
		[JsonProperty("required")]
		public string IsRequired { get; set; }

		/// <summary>
		///  ECS Level of maturity of the field (required)
		/// </summary>
		[JsonProperty("level", Required = Required.Always)]
		[JsonConverter(typeof(StringEnumConverter))]
		public FieldLevel Level { get; set; }

		/// <summary>
		///  Allowed values for this field.
		/// </summary>
		[JsonProperty("allowed_values")]
		public List<FieldAllowedValue> AllowedValues { get; set; }

		/// <summary>
		///  Allowed values for this field.
		/// </summary>
		[JsonProperty("expected_values")]
		public List<string> ExpectedValues { get; set; }

		/// <summary>
		/// Describes the normalisation of this field (e.g. array)
		/// </summary>
		[JsonProperty("normalize")]
		public string[] Normalize { get; set; }

		/// <summary>
		///  Reference to the original fieldset used by this field.
		/// </summary>
		[JsonProperty("original_fieldset")]
		public string OriginalFieldset { get; set; }

		/// <summary>
		///  Output format. e.g. asMilliseconds
		/// </summary>
		[JsonProperty("output_format")]
		public string OutputFormat { get; set; }

		/// <summary>
		///  Output format precision
		/// </summary>
		[JsonProperty("output_precision")]
		public int? OutputPrecision { get; set; }

		/// <summary>
		/// https://www.elastic.co/guide/en/elasticsearch/reference/current/doc-values.html
		/// </summary>
		[JsonProperty("doc_values")]
		public bool? DocValues { get; set; }

		/// <summary>
		///  https://www.elastic.co/guide/en/elasticsearch/reference/current/ignore-above.html
		/// </summary>
		[JsonProperty("ignore_above")]
		public int? IgnoreAbove { get; set; } //

		/// <summary>
		/// https://www.elastic.co/guide/en/elasticsearch/reference/current/mapping-index.html
		/// </summary>
		[JsonProperty("index")]
		public bool? Indexed { get; set; }

		/// <summary>
		///  https://www.elastic.co/guide/en/elasticsearch/reference/current/multi-fields.html
		/// </summary>
		[JsonProperty("multi_fields")]
		public List<FieldMultiField> MultiFields { get; set; }

		/// <summary>
		///  https://www.elastic.co/guide/en/elasticsearch/reference/current/norms.html
		/// </summary>
		[JsonProperty("norms")]
		public bool? Norms { get; set; }

		/// <summary>
		///  If <see cref="Type"/> is set to <see cref="FieldType.ScaledFloat"/> this configures the scaling factor
		/// </summary>
		[JsonProperty("scaling_factor")]
		public int? ScalingFactor { get; set; }

		/// <summary>
		///  Validation (regex) pattern
		/// </summary>
		[JsonProperty("pattern")]
		public string Pattern { get; set; }

	}
}
