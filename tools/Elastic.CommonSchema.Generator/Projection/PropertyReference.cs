using System;
using System.Linq;
using System.Text.RegularExpressions;
using Elastic.CommonSchema.Generator.Schema.DTO;

namespace Elastic.CommonSchema.Generator.Projection
{
	public abstract class PropertyReference(Field field, string localPath, string fullPath)
	{
		protected string LocalPath { get; } = localPath;
		public string FullPath { get; } = fullPath;
		public string LogTemplateAlternative => FullPath.PascalCase();
		public string JsonProperty => FullPath.GetLocalProperty(LocalPath);
		public string Name => JsonProperty.PascalCase();

		public virtual bool IsArray { get; } = field?.Normalize.Contains("array") ?? false;
		public virtual string Description { get; } = GetFieldDescription(field);
		public virtual string Example { get; } = NormalizeDescription(field?.Example?.ToString() ?? string.Empty);
		public virtual string ClrType { get; } = field?.GetClrType();

		public virtual bool IsAssignable => !IsArray && !string.IsNullOrWhiteSpace(ClrType);

		protected static string NormalizeDescription(string description)
		{
			if (description == null) return string.Empty;
			var multiLineDescription = Regex.Replace(description, @"\n", "\r\n		/// ");
			multiLineDescription = multiLineDescription.Replace("<", "&lt;").Replace(">", "&gt;");
			multiLineDescription = multiLineDescription.Replace("ATT&CK", "ATT&amp;CK");
			return multiLineDescription;
		}

		/// <summary>
		/// <list type="bullet">
		///	<item>a</item>
		/// </list>
		/// </summary>
		/// <param name="field"></param>
		/// <returns></returns>
		private static string GetFieldDescription(Field field)
		{
			if (field == null) return string.Empty;
			var multiLineDescription = NormalizeDescription(field.Description);

			var description = $@"{multiLineDescription}";
			if (!field.Indexed.GetValueOrDefault(true))
				description += "\r\n		/// <para><br/>Stored but not available for search in Elasticsearch by default</para>";
			if (!string.IsNullOrEmpty(field.Beta))
				description += $"\r\n		/// <para><br/>{field.Beta}</para>";
			if (!string.IsNullOrEmpty(field.IsRequired))
				description += $"\r\n		/// <para><br/>This is a required field</para>";
			if (!string.IsNullOrEmpty(field.Pattern))
				description += $"\r\n		/// <para>pattern: {field.Indexed}</para>";
			if (field.AllowedValues?.Count > 0)
			{
				description += $"\r\n		/// <para><br/>Allowed Values:</para>";
				description += "\r\n		/// <list type=\"table\">";
				description += $"\r\n		/// <listheader><term>Value</term><description>Description</description></listheader>";
				foreach (var v in field.AllowedValues)
				{
					var ml = NormalizeDescription(v.Description);

					description += $"\r\n		/// <item><term>{v.Name}</term><description>{ml}</description></item>";
				}
				description += "\r\n		/// </list>";
			}
			if (field.ExpectedValues?.Count > 0)
			{
				description += $"\r\n		/// <para><br/>Expected Values:</para>";
				description += "\r\n		/// <list type=\"bullet\">";
				foreach (var value in field.ExpectedValues)
					description += $"\r\n		/// <item>{value}</item>";
				description += "\r\n		/// </list>";
			}
			return description;
		}

	}

	public class NestedValueTypePropertyReference : ValueTypePropertyReference
	{
		internal NestedValueTypePropertyReference(Field field, string parentPath, string fullPath, EntityPropertyReference property)
			: base(field, parentPath, fullPath)
		{
			Entity = property.Entity;
			ContainerPath = property.Name;
			ContainerPathEntity = property.Entity.Name;

		}
		public EntityClass Entity { get; }

		public string ContainerPath { get; }
		public string ContainerPathEntity { get; }
	}

	public class ValueTypePropertyReference
		: PropertyReference
	{
		public ValueTypePropertyReference(Field field, string parentPath, string fullPath) : base(field, parentPath, fullPath)
		{
			Field = field;
			ReadJsonType = field.GetClrType().PascalCase();
		}

		public ValueTypePropertyReference(ValueTypePropertyReference self, string localPath, string fullPath)
			: base(self.Field, localPath, fullPath)
		{
			Field = self.Field;
			ReadJsonType = self.ReadJsonType;
			SelfReferential = true;

		}

		public Field Field { get; }
		public string ReadJsonType { get; }
		public bool SelfReferential { get; }

		public override bool IsAssignable => base.IsAssignable && !SelfReferential;

		// creates deeply nested entity value type property references with updated paths
		public ValueTypePropertyReference CreateSettableTypePropertyReference(EntityPropertyReference property)
		{
			var propertyKey = property.FullPath.Split('.').First();
			var pre = string.Join('.', property.FullPath.Split('.')[1..]);
			var post = string.Join('.', FullPath.Split('.')[1..]);
			var entityKey = string.Join('.', property.FullPath.Split('.')[..^1]);
			var fullPath = $"{propertyKey}.{pre}.{post}";

			return new NestedValueTypePropertyReference(Field, entityKey, fullPath, property);
		}
	}

	public class InlineObjectPropertyReference(Field field, string parentPath, string fullPath, InlineObject inlineObject)
		: PropertyReference(field, parentPath, fullPath)
	{
		public InlineObject InlineObject { get; } = inlineObject;
		public Field Field { get; } = field;

		public override string ClrType => IsArray ? $"{InlineObject.Name}[]" : $"{InlineObject.Name}";
	}

	public class EntityPropertyReference : PropertyReference
	{
		public EntityPropertyReference(string parentPath, string fullPath, EntityClass entity, string description, bool isArray)
			: base(null, parentPath, fullPath)
		{
			var multiLineDescription = NormalizeDescription(description);
			Entity = entity;
			Description = multiLineDescription;
			Example = "";
			ClrType = Entity.Name;
			IsArray = isArray;
			if (isArray) ClrType = $"{Entity.Name}[]";
		}

		public EntityClass Entity { get; }

		public override bool IsAssignable => base.IsAssignable && Entity is not SelfReferentialReusedEntityClass;

		public override string ClrType { get; }
		public override bool IsArray { get; }
		public override string Description { get; }
		public override string Example { get; }
	}
}
