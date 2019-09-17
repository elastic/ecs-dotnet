using System.Collections.Generic;
using Newtonsoft.Json;

namespace Generator.Schema
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Reusable
    {
        [JsonProperty("top_level")] public bool? TopLevel { get; set; }

        [JsonProperty("expected")] public List<string> Expected { get; set; }
    }
}