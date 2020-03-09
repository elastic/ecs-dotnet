// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Generator.Schema
{
	public static class SchemaExtensionMethods
	{
		public static string DescriptionSanitized(this Field value) =>
			Regex.Replace(value.Description.TrimEnd(), @"[\r\n]+", "<para/>");

		public static string DescriptionSanitized(this YamlSchema value) =>
			Regex.Replace(value.Description.TrimEnd(), @"[\r\n]+", "<para/>");

		public static string DescriptionSanitized(this FieldAllowedValue value) =>
			Regex.Replace(value.Description.TrimEnd(), @"[\r\n]+", "<para/>");

		public static string GetEnumClrTypeName(this Field value) =>
			FileGenerator.PascalCase(value.FlatName);

		public static bool IsCustomEnum(this Field value) =>
			value.AllowedValues != null && value.AllowedValues.Any();

		public static string ClrType(this Field value)
		{
			var isArray = value.Normalize != null && value.Normalize.Contains("array") ||
				value.FlatName == "user.id" ||
				value.FlatName == "registry.data.strings";

			// Special cases.
			if (value.FlatName == "labels") return "IDictionary<string, object>";

			// C# custom property
			if (value.Name == "_metadata") return "IDictionary<string, object>";

			var tipe = "";
			switch (value.Type)
			{
				case FieldType.Keyword:
				case FieldType.Text:
				case FieldType.Ip:
					tipe = "string";
					break;
				case FieldType.Long:
					tipe = "long?";
					break;
				case FieldType.Integer:
					tipe = "int?";
					break;
				case FieldType.Date:
					tipe = "DateTimeOffset?";
					break;
				case FieldType.Object:
					tipe = "object";
					break;
				case FieldType.Float:
					tipe = "float?";
					break;
				case FieldType.GeoPoint:
					tipe = "Location";
					break;
				case FieldType.Boolean:
					tipe = "bool?";
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			return isArray ? $"{tipe}[]" : tipe;
		}

		public static string Extras(this Field value)
		{
			var builder = new StringBuilder();

			if (value.IgnoreAbove.HasValue)
				builder.AppendFormat(".IgnoreAbove({0})", value.IgnoreAbove.Value);

			if (value.Norms.HasValue)
				builder.AppendFormat(".Norms({0})", value.Norms.Value.ToString().ToLower());

			if (value.Indexed.HasValue)
				builder.AppendFormat(".Index({0})", value.Indexed.Value.ToString().ToLower());

			if (value.DocValues.HasValue)
				builder.AppendFormat(".DocValues({0})", value.DocValues.Value.ToString().ToLower());

			if (value.Type == FieldType.Long
				|| value.Type == FieldType.Integer
				|| value.Type == FieldType.Float)
				builder.AppendFormat(".Type(NumberType.{0:f})", value.Type);

			return builder.ToString();
		}

		public static string JsonFieldName(this Field value) =>
			string.IsNullOrEmpty(value.Schema.Prefix)
				? value.FlatName
				: value.FlatName.TrimStart(value.Schema.Prefix);

		public static string MappingType(this Field value) =>
			value.Type switch
			{
				FieldType.Keyword => "Keyword",
				FieldType.Long => "Number",
				FieldType.Integer => "Number",
				FieldType.Date => "Date",
				FieldType.Ip => "Ip",
				FieldType.Object => $"Object<{value.ClrType()}>",
				FieldType.Text => "Text",
				FieldType.Float => "Number",
				FieldType.GeoPoint => "GeoPoint",
				FieldType.Boolean => "Boolean",
				_ => throw new ArgumentOutOfRangeException()
			};

		public static string PropertyName(this Field value)  =>
			FileGenerator.PascalCase(value.JsonFieldName()).TrimStart('@');
	}
}
