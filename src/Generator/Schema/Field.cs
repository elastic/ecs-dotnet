using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Generator.Schema
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Field
    {
        public YamlSchema Schema { get; set; }
        
        /// <summary>
        ///     Name of the field (required)
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }
        
        [JsonProperty("flat_name", Required = Required.Always)]
        public string FlatName { get; set; }

        [JsonIgnore]
        public string JsonFieldName
        {
            get
            {
                if (string.IsNullOrEmpty(Schema.Prefix))
                    return FlatName;
                
                return TrimStart(FlatName, Schema.Prefix);
            }
        }
        
        public static string TrimStart(string target, string trimString)
        {
            if (string.IsNullOrEmpty(trimString)) return target;

            var result = target;
            while (result.StartsWith(trimString))
            {
                result = result.Substring(trimString.Length);
            }

            return result;
        }
        
        [JsonIgnore]
        public string PropertyName => FileGenerator.PascalCase(JsonFieldName).TrimStart('@');

        [JsonIgnore]
        public string Extras
        {
            get
            {
                var builder = new StringBuilder();

                if (IgnoreAbove.HasValue)
                {
                    builder.AppendFormat(".IgnoreAbove({0})", IgnoreAbove.Value);
                }
                
                if (Norms.HasValue)
                {
                    builder.AppendFormat(".Norms({0})", Norms.Value.ToString().ToLower());
                }
                
                if (Indexed.HasValue)
                {
                    builder.AppendFormat(".Index({0})", Indexed.Value.ToString().ToLower());
                }

                if (DocValues.HasValue)
                {
                    builder.AppendFormat(".DocValues({0})", DocValues.Value.ToString().ToLower());
                }

                if (Type == FieldType.Long
                    || Type == FieldType.Integer
                    || Type == FieldType.Float)
                {
                    builder.AppendFormat(".Type(NumberType.{0:f})", Type);
                }
                
                return builder.ToString();
            }
        }
        
        [JsonIgnore]
        public string ClrType
        {
            get
            {
                // Special cases.
                if (Name == "args" && Type == FieldType.Keyword) return "string[]";
                if (Schema.Name == "dns" && Name == "header_flags") return "string[]";
                if (Schema.Name == "dns" && Name == "resolved_ip") return "string[]";
                if (Schema.Name == "user" && FlatName == "user.id") return "string[]";
                if (Schema.Name == "base" && Name == "tags") return "string[]";
                if (Schema.Name == "base" && Name == "labels") return "IDictionary<string, object>";
                if (Schema.Name == "base" && Name == "_metadata") return "IDictionary<string, object>";

                switch (Type)
                {
                    case FieldType.Keyword:
                    case FieldType.Text:
                        return "string";
                    case FieldType.Long:
                        return "long?";
                    case FieldType.Integer:
                        return "int?";
                    case FieldType.Date:
                        return "DateTimeOffset?";
                    case FieldType.Ip:
                        return "string";
                    case FieldType.Object:
                        return "object";
                    case FieldType.Float:
                        return "float?";
                    case FieldType.GeoPoint:
                        return "Location";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        [JsonIgnore]
        public string MappingType
        {
            get
            {
                switch(Type)
                {
                    case FieldType.Keyword:
                        return "Keyword";
                    case FieldType.Long:
                        return "Number";
                    case FieldType.Integer:
                        return "Number";
                    case FieldType.Date:
                        return "Date";
                    case FieldType.Ip:
                        return "Ip";
                    case FieldType.Object:
                        return "Object<" + ClrType + ">";
                    case FieldType.Text:
                        return "Text";
                    case FieldType.Float:
                        return "Number";
                    case FieldType.GeoPoint:
                        return "GeoPoint";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// <summary>
        ///     ECS Level of maturity of the field (required)
        /// </summary>
        [JsonProperty("level", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public FieldLevel Level { get; set; }

        /// <summary>
        ///     Type of the field (required)
        /// </summary>
        [JsonProperty("type", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public FieldType Type { get; set; }

        /// <summary>
        ///     Type of the field (required)
        /// </summary>
        [JsonProperty("object_type")]
        [JsonConverter(typeof(StringEnumConverter))]
        public FieldType? ObjectType { get; set; }

        /// <summary>
        ///     TBD
        /// </summary>
        [JsonProperty("required")]
        [Obsolete("TBD if still relevant.")]
        public string IsRequired { get; set; }

        /// <summary>
        ///     Shorter definition, for display in tight spaces (optional)
        /// </summary>
        [JsonProperty("short")]
        public string Short { get; set; }

        /// <summary>
        ///     Description of the field (required)
        /// </summary>
        [JsonProperty("description", Required = Required.Always)]
        public string Description { get; set; }
        
        [JsonProperty("order", Required = Required.Always)]
        public int Order { get; set; }

        [JsonIgnore]
        public string DescriptionSanitized => Regex.Replace(Description, @"\r\n?|\n", "<para/>");

        /// <summary>
        ///     A single value example of what can be expected in this field (optional)
        /// </summary>
        [JsonProperty("example")]
        public object Example { get; set; }

        /// <summary>
        ///     Optional
        /// </summary>
        [JsonProperty("multi_fields")]
        public List<MultiField> MultiFields { get; set; }

        /// <summary>
        ///     If false, means field is not indexed (overrides type) (optional)
        /// </summary>
        [JsonProperty("index")]
        public bool? Indexed { get; set; }

        [JsonProperty("doc_values")] public bool? DocValues { get; set; } //
        
        [JsonProperty("norms")] public bool? Norms { get; set; } //

        [JsonProperty("format")] public string Format { get; set; }

        [JsonProperty("input_format")] public string InputFormat { get; set; }

        [JsonProperty("output_format")] public string OutputFormat { get; set; }

        [JsonProperty("output_precision")] public int? OutputPrecision { get; set; }
        
        [JsonProperty("original_fieldset")] public string OriginalFieldset { get; set; }
        
        [JsonProperty("ignore_above")] public int? IgnoreAbove { get; set; } //
    }
}