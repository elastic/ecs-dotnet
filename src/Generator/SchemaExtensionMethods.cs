// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace Generator.Schema
{
	public static class SchemaExtensionMethods
	{
		public static string NamePCased(this YamlSchema value) =>
			FileGenerator.PascalCase(value.Name);

		public static string ExampleSanitized(this Field value) =>
			value.Example.ToString().StartsWith("{") && value.Example.ToString().Contains("lat")
				? value.Example.ToString()
				: value.Example.ToString().StartsWith("[")
						? "[" + string.Join(',', value.Example.ToString().Trim('[').Trim(']').Split(',').Select(s => s.Trim())) + "]"
						: JsonConvert.SerializeObject(value.Example).Trim('"');

		public static string Sanitized(this string value) =>
			Regex.Replace(value.TrimEnd(), @"[\r\n]+", "<para/><para/>");

		public static string DescriptionSanitized(this Field value) =>
			value.Description.Sanitized();

		public static string DescriptionSanitized(this YamlSchema value) =>
			value.Description.Sanitized();

		public static string DescriptionSanitized(this FieldAllowedValue value) =>
			value.Description.Sanitized();

		public static string GetEnumClrTypeName(this Field value) =>
			FileGenerator.PascalCase(value.FlatName);

		public static bool IsCustomEnum(this Field value) =>
			value.AllowedValues != null && value.AllowedValues.Any();

		public static bool IsArray(this Field value) => value.Normalize != null && value.Normalize.Contains("array");

		public static string ClrType(this Field value)
		{
			if (!string.IsNullOrEmpty(value.ClrType))
				return value.ClrType;

			var isArray = value.IsArray() ||
				value.FlatName == "registry.data.strings";

			// Special cases.
			if (value.FlatName == "labels") return "IDictionary<string, string>";

			if (value.FlatName == "container.labels") return "IDictionary<string, string>";

			// C# custom property
			if (value.Name == "metadata") return "IDictionary<string, object>";

			string clrType;
			switch (value.Type)
			{
				case FieldType.Keyword:
				case FieldType.Text:
				case FieldType.Ip:
					clrType = "string";
					break;
				case FieldType.Long:
					clrType = "long?";
					break;
				case FieldType.Integer:
					clrType = "int?";
					break;
				case FieldType.Date:
					clrType = "DateTimeOffset?";
					break;
				case FieldType.Object:
					clrType = "object";
					break;
				case FieldType.Float:
					clrType = "float?";
					break;
				case FieldType.GeoPoint:
					clrType = "Location";
					break;
				case FieldType.Boolean:
					clrType = "bool?";
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}

			return isArray ? $"{clrType}[]" : clrType;
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
