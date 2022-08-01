using Newtonsoft.Json;

namespace Elastic.CommonSchema.Generator.Schema.DTO
{
	[JsonObject(MemberSerialization.OptIn)]
	public class YamlSchemaReusedHere
	{
		[JsonProperty("full")]
		public string Full { get; set; }

		[JsonProperty("schema_name")]
		public string SchemaName { get; set; }

		[JsonProperty("short")]
		public string Short { get; set; }

		[JsonProperty("beta")]
		public string Beta { get; set; }

		[JsonProperty("normalize")]
		public string[] Normalize { get; set; }
	}
}
