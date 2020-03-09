// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Generator.Schema
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Field
	{
		[JsonIgnore]
		public YamlSchema Schema { get; set; }

		[JsonProperty("allowed_values")]
		public List<FieldAllowedValue> AllowedValues { get; set; }

		[JsonProperty("dashed_name")]
		public string DashedName { get; set; }

		/// <summary>
		///     Description of the field (required)
		/// </summary>
		[JsonProperty("description", Required = Required.Always)]
		public string Description { get; set; }

		[JsonProperty("doc_values")]
		public bool? DocValues { get; set; }

		/// <summary>
		///  A single value example of what can be expected in this field (optional)
		/// </summary>
		[JsonProperty("example")]
		public object Example { get; set; }

		[JsonProperty("flat_name", Required = Required.Always)]
		public string FlatName { get; set; }

		[JsonProperty("format")]
		public string Format { get; set; }

		[JsonProperty("ignore_above")]
		public int? IgnoreAbove { get; set; } //

		/// <summary>
		///     If false, means field is not indexed (overrides type) (optional)
		/// </summary>
		[JsonProperty("index")]
		public bool? Indexed { get; set; }

		[JsonProperty("input_format")]
		public string InputFormat { get; set; }

		/// <summary>
		///     TBD
		/// </summary>
		[JsonProperty("required")]
		[Obsolete("TBD if still relevant.")]
		public string IsRequired { get; set; }

		/// <summary>
		///  ECS Level of maturity of the field (required)
		/// </summary>
		[JsonProperty("level", Required = Required.Always)]
		[JsonConverter(typeof(StringEnumConverter))]
		public FieldLevel Level { get; set; }

		/// <summary>
		///  Optional
		/// </summary>
		[JsonProperty("multi_fields")]
		public List<FieldMultiField> MultiFields { get; set; }

		/// <summary>
		///  Name of the field (required)
		/// </summary>
		[JsonProperty("name", Required = Required.Always)]
		public string Name { get; set; }

		[JsonProperty("normalize")]
		public string[] Normalize { get; set; }

		[JsonProperty("norms")]
		public bool? Norms { get; set; } //

		/// <summary>
		///  Type of the field (required)
		/// </summary>
		[JsonProperty("object_type")]
		[JsonConverter(typeof(StringEnumConverter))]
		public FieldType? ObjectType { get; set; }

		[JsonProperty("order", Required = Required.Always)]
		public int Order { get; set; }

		[JsonProperty("original_fieldset")]
		public string OriginalFieldset { get; set; }

		[JsonProperty("output_format")]
		public string OutputFormat { get; set; }

		[JsonProperty("output_precision")]
		public int? OutputPrecision { get; set; }

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
	}
}
