using Newtonsoft.Json;

namespace Generator.Schema
{
	[JsonObject(MemberSerialization.OptIn)]
	public class MultiField
	{
		/// <summary>
		///     Name of the field, defaults to multi_fields type (optional)
		/// </summary>
		[JsonProperty("name")]
		public string Name { get; set; }

		/// <summary>
		///     Type of the multi_fields (required)
		/// </summary>
		[JsonProperty("type", Required = Required.Always)]
		public string Type { get; set; }
	}
}
