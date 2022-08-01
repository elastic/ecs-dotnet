// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Elastic.CommonSchema.Generator.Schema.DTO
{
	[JsonObject(MemberSerialization.OptIn)]
	public class FieldSet
	{
		/// <summary>
		/// Description of the field set
		/// </summary>
		[JsonProperty("description", Required = Required.Always)]
		public string Description { get; set; }

		/// <summary>
		///  Indicates the beta notification appropriate for this asset
		/// </summary>
		[JsonProperty("beta")]
		public string Beta { get; set; }

		/// <summary>
		///  The fields within the schema
		/// </summary>
		[JsonProperty("fields", Required = Required.Always)]
		public Dictionary<string, Field> Fields { get; set; }

		/// <summary>
		///  Footnote of this schema.
		/// </summary>
		[JsonProperty("footnote")]
		public string Footnote { get; set; }

		/// <summary>
		///     TBD. Just set it to 2, for now ;-)
		/// </summary>
		[JsonProperty("group", Required = Required.Always)]
		public int Group { get; set; } = 2;

		/// <summary>
		///     Name of the field set (required)
		/// </summary>
		[JsonProperty("name", Required = Required.Always)]
		public string Name { get; set; }

		[JsonProperty("nestings")]
		public string[] Nestings { get; set; }

		[JsonProperty("prefix")]
		public string Prefix { get; set; }

		/// <summary>
		///     Optional
		/// </summary>
		[JsonProperty("reusable")]
		public YamlSchemaReusable Reusable { get; set; }

		/// <summary>
		///     Optional
		/// </summary>
		[JsonProperty("reused_here")]
		public List<YamlSchemaReusedHere> ReusedHere { get; set; }

		/// <summary>
		///     Whether or not the fields of this field set should be nested under the field set name. (optional)
		/// </summary>
		[JsonProperty("root")]
		public bool? Root { get; set; }

		/// <summary>
		///     Shorter definition, for display in tight spaces
		/// </summary>
		[JsonProperty("short")]
		public string Short { get; set; }

		/// <summary>
		///     Rendered name of the field set (e.g. for documentation) Must be correctly capitalized (required)
		/// </summary>
		[JsonProperty("title", Required = Required.Always)]
		public string Title { get; set; }

		/// <summary>
		///     At this level, should always be group
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

	}
}
