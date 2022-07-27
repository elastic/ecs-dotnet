using System;
using System.Text.RegularExpressions;
using Elastic.CommonSchema.Generator.Schema.DTO;

namespace Elastic.CommonSchema.Generator.Domain
{
	public abstract record PropertyReference(string FullPath)
	{
		public string Name { get; } = FullPath.GetLastProperty();
	}

	public record ValueTypePropertyReference : PropertyReference
	{
		public ValueTypePropertyReference(string fullPath, Field field) : base(fullPath) => ClrType = field.Type.GetClrType();

		public string ClrType { get; }
	}

	public record InlineObjectPropertyReference(string FullPath, InlineObject InlineObject) : PropertyReference(FullPath)
	{
		public InlineObject InlineObject { get; } = InlineObject;
	}

	public record EntityPropertyReference(string FullPath, EntityClass Entity) : PropertyReference(FullPath)
	{
	}

	public record NestedEntityClassPropertyReference : PropertyReference
	{
		public NestedEntityClassPropertyReference(string fullPath) : base(fullPath) { }
	}


	public class CsharpEntityProperty
	{
		public CsharpEntityProperty(string name, string fullPath)
		{
			Name = name;
			FullPath = fullPath;
		}

		public string Name { get; }
		public string FullPath { get; }
	}

	public static class CsharpPropertyExtensions
	{
		private static readonly Regex LastPropertyRegex = new($"^.+\\.([^\\.]+)$");

		public static string GetLastProperty(this string s) => LastPropertyRegex.Replace(s, "$1");

		public static string GetClrType(this FieldType fieldType)
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
					return "long";
				case FieldType.Integer:
					return "int";
				case FieldType.Date:
					return "DateTimeOffset";
				case FieldType.Nested:
				case FieldType.Object:
					return "object";
				case FieldType.ScaledFloat:
				case FieldType.Float:
					return "float";
				case FieldType.GeoPoint:
					return "Location";
				case FieldType.Boolean:
					return "bool";
				default: throw new ArgumentOutOfRangeException(fieldType.ToString());
			}
		}
	}
}
