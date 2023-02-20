using System.Linq;
using System.Text.RegularExpressions;
using Elastic.CommonSchema.Generator.Schema.DTO;

namespace Elastic.CommonSchema.Generator.Projection
{
	public abstract class PropertyReference
	{
		protected PropertyReference(string localPath, string fullPath)
		{
			LocalPath = localPath;
			FullPath = fullPath;
		}

		public string JsonProperty => FullPath.GetLocalProperty(LocalPath);
		public string Name => JsonProperty.PascalCase();


		public string LocalPath { get; }
		public string FullPath { get; }
		public string LogTemplateAlternative => FullPath.PascalCase();

		public abstract string Description { get; }
		public abstract string Example { get; }

		protected static string NormalizeDescription(string description)
		{
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
		protected static string GetFieldDescription(Field field)
		{
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

	public class ValueTypePropertyReference : PropertyReference
	{
		public ValueTypePropertyReference(string parentPath, string fullPath, Field field) : base(parentPath, fullPath)
		{
			ClrType = field.GetClrType();
			ReadJsonType = ClrType.PascalCase();
			CastFromObject = field.GetCastFromObject();
			Description = GetFieldDescription(field);
			Example = NormalizeDescription(field.Example?.ToString() ?? string.Empty);
		}

		public string CastFromObject { get; }
		public string ReadJsonType { get; }
		public string ClrType { get; }
		public override string Description { get; }
		public override string Example { get; }
	}

	public class InlineObjectPropertyReference : PropertyReference
	{
		public InlineObjectPropertyReference(string parentPath, string fullPath, InlineObject inlineObject, Field field) : base(parentPath, fullPath)
		{
			InlineObject = inlineObject;
			Field = field;
			Description = GetFieldDescription(field);
			Example = NormalizeDescription(field.Example?.ToString() ?? string.Empty);
		}

		public InlineObject InlineObject { get; }
		public Field Field { get; }

		public string ClrType => Field.Normalize.Contains("array") ? $"{InlineObject.Name}[]" : $"{InlineObject.Name}";
		public override string Description { get; }
		public override string Example { get; }
	}

	public class EntityPropertyReference : PropertyReference
	{
		public EntityPropertyReference(string parentPath, string fullPath, EntityClass entity, string description, bool isArray) : base(parentPath, fullPath)
		{
			var multiLineDescription = NormalizeDescription(description);
			Entity = entity;
			Description = multiLineDescription;
			Example = "";
			ClrType = Entity.Name;
			if (isArray) ClrType += "[]";

		}

		public EntityClass Entity { get; }

		public string ClrType { get; }
		public override string Description { get; }
		public override string Example { get; }
	}
}
