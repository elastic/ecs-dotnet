// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;

namespace Elastic.CommonSchema.Generator.Schema.DTO
{
	/// <summary>
	///  The Elasticsearch field type.
	/// </summary>
	public enum FieldType
	{
		[EnumMember(Value = "keyword")] Keyword,
		[EnumMember(Value = "constant_keyword")] ConstantKeyword,
		[EnumMember(Value = "match_only_text")] MatchOnlyText,
		[EnumMember(Value = "flattened")] Flattened,
		[EnumMember(Value = "wildcard")] Wildcard,
		[EnumMember(Value = "long")] Long,
		[EnumMember(Value = "integer")] Integer,
		[EnumMember(Value = "scaled_float")] ScaledFloat,
		[EnumMember(Value = "date")] Date,
		[EnumMember(Value = "ip")] Ip,
		[EnumMember(Value = "object")] Object,
		[EnumMember(Value = "nested")] Nested,
		[EnumMember(Value = "text")] Text,
		[EnumMember(Value = "float")] Float,
		[EnumMember(Value = "geo_point")] GeoPoint,
		[EnumMember(Value = "boolean")] Boolean,
	}
}
