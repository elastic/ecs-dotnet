// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Newtonsoft.Json;

namespace Elastic.CommonSchema.Generator.Schema.DTO
{
	public class FieldAllowedValue
	{
		/// <summary>
		///  Name of the allowed value.
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///  Description of the allowed value.
		/// </summary>
		[JsonProperty("description")]
		public string Description { get; set; }

		/// <summary>
		///  List of allowed values.
		/// </summary>
		[JsonProperty("expected_event_types")]
		public string[] ExpectedEventTypes { get; set; }
	}
}
