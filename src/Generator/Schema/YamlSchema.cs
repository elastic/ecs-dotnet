using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Generator.Schema;
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

        [JsonIgnore]
        public string DescriptionSanitized => Regex.Replace(Description, @"\r\n?|\n", "<para/>");

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

        [JsonProperty("prefix")]
        public string Prefix { get; set; }

        [JsonProperty("nestings")]
        public string[] Nestings { get; set; }

        /// <summary>
        ///     Array of fields
        /// </summary>
        [JsonProperty("fields", Required = Required.Always)]
        public Dictionary<string, Field> Fields { get; set; }

        public IEnumerable<Field> GetFilteredFields() =>
			Fields
				.Where(f => Nestings == null || !Nestings.Any(n => f.Key.StartsWith(n)))
				.Select(f => f.Value)
				.OrderBy(f => f.Order);

		public List<NestedFields> GetFieldsNested()
        {
            var nestedFields = new List<NestedFields>();
            foreach (var nestedField in GetFilteredFields().Where(f => f.JsonFieldName.Contains(".")))
            {
                var split = nestedField.JsonFieldName.Split('.').Select(FileGenerator.PascalCase).ToArray();
                var current = nestedFields.SingleOrDefault(n => n.ClassName == split.First());

                if (current != null)
                {
                    Add(current, split.Skip(1).ToArray(), nestedField);
                }
                else
                {
                    var newRoot = new NestedFields(this)
                    {
                        ClassName = split.First()
                    };
                    nestedFields.Add(newRoot);

                    Add(newRoot, split.Skip(1).ToArray(), nestedField);
                }
            }

            return nestedFields;
        }

        private void Add(NestedFields root, string[] properties, Field field)
        {
            if (properties.Length == 1)
            {
                root.Fields.Add(field);
                return;
            }

            var existingRoot = root.Children.SingleOrDefault(c => c.ClassName == properties.First());
            if (existingRoot != null)
            {
                Add(existingRoot, properties.Skip(1).ToArray(), field);
            }
            else
            {
                var newRoot = new NestedFields(this)
                {
                    ClassName = properties.First()
                };
                root.Children.Add(newRoot);

                Add(newRoot, properties.Skip(1).ToArray(), field);
            }
        }

        /// <summary>
        ///     Optional
        /// </summary>
        [JsonProperty("reusable")]
        public Reusable Reusable { get; set; }

        [JsonIgnore]
        public string DownloadBranch { get; set; }

        [JsonIgnore]
        public string FullVersion => DownloadBranch + ".0";

        public IEnumerable<Field> GetFieldsFlat()
        {
            var filtered = GetFilteredFields().Where(f => !f.JsonFieldName.Contains("."));

            // DNS Answers are handled as child objects
            filtered = filtered.Where(f => f.FlatName != "dns.answers");

            // Sys logs are handled as child objects
            filtered = filtered.Where(f => f.FlatName != "log.syslog");

            return filtered;
        }
    }
}
