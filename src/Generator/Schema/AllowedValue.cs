using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Generator.Schema {
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
