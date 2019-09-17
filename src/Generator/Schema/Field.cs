using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Generator.Schema
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Field
    {
        /// <summary>
        ///     Name of the field (required)
        /// </summary>
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        public string Extras
        {
            get
            {
                var builder = new StringBuilder();

                if (Type == FieldType.Keyword)
                {
                    builder.AppendFormat(".IgnoreAbove(1024)");
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
                    || Type == FieldType.Float)
                {
                    builder.AppendFormat(".Type(NumberType.{0:f})", Type);
                }
                
                return builder.ToString();
            }
        }
        
        public string ClrType
        {
            get
            {
                // Special cases.
                if (Name == "args" && Type == FieldType.Keyword) return "string[]";

                switch (Type)
                {
                    case FieldType.Keyword:
                    case FieldType.Text:
                        return "string";
                    case FieldType.Long:
                        return "long?";
                    case FieldType.Date:
                        return "DateTimeOffset?";
                    case FieldType.Ip:
                        return "IPAddress";
                    case FieldType.Object:
                        return "object";
                    case FieldType.Float:
                        return "float?";
                    case FieldType.GeoPoint:
                        return "GeoPoint";
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

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

        public string DescriptionSanitized => Regex.Replace(Description, @"\r\n?|\n", " ");

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

        [JsonProperty("doc_values")] public bool? DocValues { get; set; }

        [JsonProperty("format")] public string Format { get; set; }

        [JsonProperty("input_format")] public string InputFormat { get; set; }

        [JsonProperty("output_format")] public string OutputFormat { get; set; }

        [JsonProperty("output_precision")] public int? OutputPrecision { get; set; }
    }
}