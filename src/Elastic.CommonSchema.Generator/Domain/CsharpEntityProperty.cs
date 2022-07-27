using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Elastic.CommonSchema.Generator.Schema.DTO;
using Microsoft.Extensions.FileSystemGlobbing.Internal.PathSegments;

namespace Elastic.CommonSchema.Generator.Domain
{
	public class FieldSetBaseClass
	{
		public FieldSetBaseClass(FieldSet fieldSet) => FieldSet = fieldSet;

		public FieldSet FieldSet { get; }
		public string Name => $"{FieldSet.Name.PascalCase()}Base";

		public Dictionary<string, PropertyReference> Properties { get; } = new();

		public IEnumerable<ValueTypePropertyReference> ValueProperties =>
			Properties.Values.OfType<ValueTypePropertyReference>();

		public IEnumerable<InlineObjectPropertyReference> InlineObjectProperties =>
			Properties.Values.OfType<InlineObjectPropertyReference>();
	}

	public class InlineObject
	{
		public string Name { get; }
		public Field Field { get; }

		public InlineObject(string name, Field field)
		{
			Name = name.PascalCase();
			Field = field;
		}

		public Dictionary<string, PropertyReference> Properties { get; } = new();

		public Dictionary<string, EntityPropertyReference> EntityReferences { get; } = new();

		public IEnumerable<ValueTypePropertyReference> ValueProperties =>
			Properties.Values.OfType<ValueTypePropertyReference>();

		public IEnumerable<InlineObjectPropertyReference> InlineObjectProperties =>
			Properties.Values.OfType<InlineObjectPropertyReference>();

		public IEnumerable<EntityPropertyReference> EntityProperties => EntityReferences.Values;

		public bool IsDictionary => ValueProperties.Count() + EntityProperties.Count() == 0;
	}

	public class EntityClass
	{
		public EntityClass(string name, FieldSetBaseClass baseFieldSet)
		{
			Name = name.PascalCase();
			BaseFieldSet = baseFieldSet;
		}

		public string Name { get; }
		public FieldSetBaseClass BaseFieldSet { get; }
		public bool Partial => Name is "Base" or "Log";


		public Dictionary<string, EntityPropertyReference> EntityReferences { get; } = new();

		public IEnumerable<EntityPropertyReference> EntityProperties => EntityReferences.Values;
	}


	public abstract record PropertyReference
	{
		protected PropertyReference(string localPath, string fullPath)
		{
			LocalPath = localPath;
			FullPath = fullPath;
		}

		public string JsonProperty => FullPath.GetLocalProperty(LocalPath);
		public string Name => JsonProperty.PascalCase();


		public string LocalPath { get; }
		public string FullPath { get; set; }
	}

	public record ValueTypePropertyReference : PropertyReference
	{
		public ValueTypePropertyReference(string parentPath, string fullPath, Field field) : base(parentPath, fullPath)
		{
			ClrType = field.Type.GetClrType();
		}

		public string ClrType { get; }
	}

	public record InlineObjectPropertyReference : PropertyReference
	{
		public InlineObjectPropertyReference(string parentPath, string fullPath, InlineObject inlineObject) : base(parentPath, fullPath)
		{
			InlineObject = inlineObject;
		}

		public InlineObject InlineObject { get; }
	}

	public record EntityPropertyReference : PropertyReference
	{
		public EntityPropertyReference(string parentPath, string fullPath, EntityClass entity) : base(parentPath, fullPath)
		{
			Entity = entity;
		}

		public EntityClass Entity { get; }
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
		public static string PascalCase(this string s) => new CultureInfo("en-US")
			.TextInfo
			.ToTitleCase(s.ToLowerInvariant())
			.Replace("_", string.Empty)
			.Replace(".", string.Empty);

		private static readonly Regex LastPropertyRegex = new($"^.+\\.([^\\.]+)$");

		public static string GetLastProperty(this string s) => LastPropertyRegex.Replace(s, "$1");

		public static string GetLocalProperty(this string s, string prefix) =>
			new Regex($"^{prefix.Replace(".", "\\.")}\\.(.+)$").Replace(s, "$1");

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
