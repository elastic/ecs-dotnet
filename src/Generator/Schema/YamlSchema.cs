using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Generator.Schema
{
    [JsonObject(MemberSerialization.OptIn)]
    public class YamlSchema
    {
        /// <summary>
        ///     Name of the field set (required)
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        /// <summary>
        ///     Whether or not the fields of this field set should be nested under the field set name. (optional)
        /// </summary>
        [JsonProperty("root")]
        public bool? Root { get; set; }

        /// <summary>
        ///     Rendered name of the field set (e.g. for documentation) Must be correctly capitalized (required)
        /// </summary>
        [JsonProperty("title", Required = Required.Always)]
        public string Title { get; set; }

        /// <summary>
        ///     TBD. Just set it to 2, for now ;-)
        /// </summary>
        [JsonProperty("group", Required = Required.Always)]
        public int Group { get; set; } = 2;

        /// <summary>
        ///     Shorter definition, for display in tight spaces
        /// </summary>
        [JsonProperty("short")]
        public string Short { get; set; }

        /// <summary>
        ///     Description of the field set
        /// </summary>
        [JsonProperty("description", Required = Required.Always)]
        public string Description { get; set; }

        public string DescriptionSanitized => Regex.Replace(Description, @"\r\n?|\n", string.Empty);

        /// <summary>
        ///     Additional footnote
        /// </summary>
        [JsonProperty("footnote")]
        public string Footnote { get; set; }

        /// <summary>
        ///     At this level, should always be group
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        ///     Array of fields
        /// </summary>
        [JsonProperty("fields", Required = Required.Always)]
        public List<Field> Fields { get; set; }
        
        /// <summary>
        ///     Optional
        /// </summary>
        [JsonProperty("reusable")]
        public Reusable Reusable { get; set; }
    }
}