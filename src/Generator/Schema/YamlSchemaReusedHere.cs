using Newtonsoft.Json;

namespace Generator.Schema
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
	}
}
