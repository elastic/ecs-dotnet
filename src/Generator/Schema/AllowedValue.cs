// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Generator.Schema
{
	public class AllowedValue
	{
		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("description")]
		public string Description { get; set; }

		[JsonIgnore]
		public string DescriptionSanitized => Regex.Replace(Description.TrimEnd(), @"\r\n?|\n", "<para/>");

		[JsonProperty("expected_event_types")]
		public string[] ExpectedEventTypes { get; set; }
	}
}
