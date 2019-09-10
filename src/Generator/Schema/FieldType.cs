using System.Runtime.Serialization;

namespace Generator.Schema
{
    public enum FieldType
    {
        [EnumMember(Value = "keyword")] Keyword,
        [EnumMember(Value = "long")] Long,
        [EnumMember(Value = "date")] Date,
        [EnumMember(Value = "ip")] Ip,
        [EnumMember(Value = "object")] Object,
        [EnumMember(Value = "text")] Text,
        [EnumMember(Value = "float")] Float,
        [EnumMember(Value = "geo_point")] GeoPoint
    }
}