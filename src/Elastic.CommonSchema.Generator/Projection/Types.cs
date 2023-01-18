using System.Collections.Generic;
using System.Linq;
using Elastic.CommonSchema.Generator.Schema.DTO;

namespace Elastic.CommonSchema.Generator.Projection
{
	public class FieldSetBaseClass
	{
		public FieldSetBaseClass(FieldSet fieldSet) => FieldSet = fieldSet;

		public FieldSet FieldSet { get; }
		public string Name => $"{FieldSet.Name.PascalCase()}FieldSet";

		public Dictionary<string, PropertyReference> Properties { get; } = new();

		public IEnumerable<ValueTypePropertyReference> SettableProperties =>
			ValueProperties.Where(p => !string.IsNullOrEmpty(p.CastFromObject));

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

	public class SelfReferentialReusedEntityClass : EntityClass
	{
		public SelfReferentialReusedEntityClass(string name, FieldSetBaseClass baseFieldSet, string reuseDescription, bool isArray)
			: base(name, baseFieldSet)
		{
			ReuseDescription = reuseDescription;
			IsArray = isArray;
		}

		public string ReuseDescription { get; }
		public bool IsArray { get; }
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
	}


}
