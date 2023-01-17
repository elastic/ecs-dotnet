using System;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Elastic.CommonSchema.Generator.Schema.DTO;

namespace Elastic.CommonSchema.Generator.Projection
{
	public static class ProjectionTypeExtensions
	{
		public static string PascalCase(this string s) => new CultureInfo("en-US")
			.TextInfo
			.ToTitleCase(s.ToLowerInvariant())
			.Replace("?", string.Empty)
			.Replace("@", string.Empty)
			.Replace("_", string.Empty)
			.Replace(".", string.Empty);

		public static string GetLocalProperty(this string s, string prefix) =>
			new Regex($"^{prefix.Replace(".", "\\.")}\\.(.+)$").Replace(s, "$1");

		public static string GetClrType(this Field field)
		{
			var baseType = field.Type.GetClrType();
			return field.Normalize.Contains("array") ? $"{baseType}[]" : baseType;
		}

		public static string GetCastFromObject(this Field field)
		{
			if (field.Normalize.Contains("array")) return null;
			switch (field.Type)
			{
				case FieldType.Keyword:
				case FieldType.ConstantKeyword:
				case FieldType.Flattened:
				case FieldType.MatchOnlyText:
				case FieldType.Wildcard:
				case FieldType.Text:
				case FieldType.Ip:
					return "TrySetString";
				case FieldType.Boolean:
					return "TrySetBool";
				case FieldType.ScaledFloat:
				case FieldType.Float:
					return "TrySetFloat";
				case FieldType.Long:
					return "TrySetLong";
				case FieldType.Integer:
					return "TrySetInt";
				case FieldType.Date:
					return "TrySetDateTimeOffset";
				default: return null;
			}

		}

		private static string GetClrType(this FieldType fieldType)
		{
			switch (fieldType)
			{
				case FieldType.Keyword:
				case FieldType.ConstantKeyword:
				case FieldType.Flattened:
				case FieldType.MatchOnlyText:
				case FieldType.Wildcard:
				case FieldType.Text:
				case FieldType.Ip:
					return "string";
				case FieldType.Long:
					return "long?";
				case FieldType.Integer:
					return "int?";
				case FieldType.Date:
					return "DateTimeOffset?";
				case FieldType.Nested:
				case FieldType.Object:
					return "object";
				case FieldType.ScaledFloat:
				case FieldType.Float:
					return "float?";
				case FieldType.GeoPoint:
					return "Location";
				case FieldType.Boolean:
					return "bool?";
				default: throw new ArgumentOutOfRangeException(fieldType.ToString());
			}
		}
	}
}
