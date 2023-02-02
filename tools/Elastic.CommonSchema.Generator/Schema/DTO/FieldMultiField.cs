// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Newtonsoft.Json;

namespace Elastic.CommonSchema.Generator.Schema.DTO
{
	[JsonObject(MemberSerialization.OptIn)]
	public class FieldMultiField
	{
		/// <summary>
		///  Name of the field, defaults to multi_fields type (optional)
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///  Type of the multi_fields (required)
		/// </summary>
		[JsonProperty("type", Required = Required.Always)]
		public string Type { get; set; }

		/// <summary>
		///  The name of this field, separated by dots.
		/// </summary>
		[JsonProperty("flat_name")]
		public string FlatName { get; set; }

		/// <summary>
		///  https://www.elastic.co/guide/en/elasticsearch/reference/current/norms.html
		/// </summary>
		[JsonProperty("norms")]
		public bool? Norms { get; set; }
	}
}
