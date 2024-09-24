using System.Collections.Generic;
using System.Linq;
using Elastic.CommonSchema.Generator.Schema.DTO;

namespace Elastic.CommonSchema.Generator.Projection
{
	public class FieldSetBaseClass(FieldSet fieldSet)
	{
		public FieldSet FieldSet { get; } = fieldSet;
		public string Name => $"{FieldSet.Name.PascalCase()}FieldSet";

		public Dictionary<string, PropertyReference> Properties { get; } = new();

		public IEnumerable<ValueTypePropertyReference> SettableProperties =>
			ValueProperties.Where(p => !string.IsNullOrEmpty(p.CastFromObject));

		public IEnumerable<ValueTypePropertyReference> ValueProperties =>
			Properties.Values.OfType<ValueTypePropertyReference>();

		public IEnumerable<InlineObjectPropertyReference> InlineObjectProperties =>
			Properties.Values.OfType<InlineObjectPropertyReference>();
	}

	public class InlineObject(string name, Field field)
	{
		public string Name { get; } = name.PascalCase();
		public Field Field { get; } = field;

		public Dictionary<string, PropertyReference> Properties { get; } = new();

		public Dictionary<string, EntityPropertyReference> EntityReferences { get; } = new();

		public IEnumerable<ValueTypePropertyReference> ValueProperties =>
			Properties.Values.OfType<ValueTypePropertyReference>();

		public IEnumerable<EntityPropertyReference> EntityProperties => EntityReferences.Values;

		public bool IsDictionary => ValueProperties.Count() + EntityProperties.Count() == 0;
	}

	public class SelfReferentialReusedEntityClass
		(string name, FieldSetBaseClass baseFieldSet, string reuseDescription, bool isArray)
		: EntityClass(name, baseFieldSet)
	{
		public string ReuseDescription { get; } = reuseDescription;
		public bool IsArray { get; } = isArray;
	}


	public class EntityClass
	{
		public EntityClass(string name, FieldSetBaseClass baseFieldSet)
		{
			Name = name.PascalCase();
			if (Name == "Base") Name = "EcsDocument";
			BaseFieldSet = baseFieldSet;
		}

		public string Name { get; }
		public FieldSetBaseClass BaseFieldSet { get; }
		public bool Partial => Name is "EcsDocument" or "Log" or "Ecs";

		public Dictionary<string, EntityPropertyReference> EntityReferences { get; } = new();

		public IEnumerable<EntityPropertyReference> EntityProperties => EntityReferences.Values;
		//provided later
		public List<AssignableEntityInterface> AssignableInterfaces { get; set; } = new();

		public string AssignableInterfacesAsString
		{
			get
			{
				if (!AssignableInterfaces.Any()) return string.Empty;
				return $", {string.Join(", ", AssignableInterfaces.Select(i => i.Name))}";
			}
		}
	}


	public class AssignableEntityInterface
	{
		public AssignableEntityInterface(string name, EntityPropertyReference property, List<EntityClass> entities)
		{
			Name = $"I{name}";
			Property = property;
			Entities = entities;
		}

		public EntityPropertyReference Property { get; }
		public List<EntityClass> Entities { get; }
		public string Name { get; }
	}

}
