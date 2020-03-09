// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Collections.Generic;
using Newtonsoft.Json;

namespace Generator.Schema
{
	[JsonObject(MemberSerialization.OptIn)]
	public class Reusable
	{
		[JsonProperty("expected")]
		public List<string> Expected { get; set; }

		[JsonProperty("top_level")]
		public bool? TopLevel { get; set; }
	}
}
