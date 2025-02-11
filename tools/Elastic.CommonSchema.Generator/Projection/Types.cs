using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Elastic.CommonSchema.Generator.Schema.DTO;

namespace Elastic.CommonSchema.Generator.Projection
{
	public class FieldSetBaseClass(FieldSet fieldSet)
	{
		public FieldSet FieldSet { get; } = fieldSet;
		public string Name => $"{FieldSet.Name.PascalCase()}FieldSet";

		public Dictionary<string, PropertyReference> Properties { get; } = new();

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
		: EntityClass
	{
		public SelfReferentialReusedEntityClass(string name, FieldSetBaseClass baseFieldSet, string reuseDescription, bool isArray)
			: base(name, baseFieldSet)
		{
			ReuseDescription = reuseDescription;
			IsArray = isArray;

			Find = baseFieldSet.FieldSet.Name;
			Replace = name;
		}

		public string Replace { get; set; }
		public string Find { get; set; }
		public string ReuseDescription { get; }
		public bool IsArray { get; }

		protected override IEnumerable<ValueTypePropertyReference> OwnProperties =>
			BaseFieldSet.ValueProperties.Where(p => p.IsAssignable)
				.Select(v=>
				{
					var localPath = Replace;
					var fullPath = Regex.Replace(v.FullPath, $@"^{Find}\.", $"{Replace}.");

					return new ValueTypePropertyReference(v, localPath, fullPath);
				});
	}


	public class EntityClass
	{
		public EntityClass(string name, FieldSetBaseClass baseFieldSet)
		{
			OriginalName = name;
			Name = name.PascalCase();
			if (Name == "Base") Name = "EcsDocument";
			BaseFieldSet = baseFieldSet;
		}

		internal string OriginalName { get; }
		public string Name { get; }
		public FieldSetBaseClass BaseFieldSet { get; }
		public bool Partial => Name is "EcsDocument" or "Log" or "Ecs";

		public Dictionary<string, EntityPropertyReference> EntityReferences { get; } = new();

		public IEnumerable<EntityPropertyReference> EntityProperties => EntityReferences.Values;

		protected virtual IEnumerable<ValueTypePropertyReference> OwnProperties =>
			BaseFieldSet.ValueProperties.Where(p => p.IsAssignable);

		public IEnumerable<ValueTypePropertyReference> SettableProperties
		{
			get
			{
				if (Name is "EcsDocument")
					return OwnProperties;
				return OwnProperties
					.Concat(EntityProperties
						.Where(p => p.IsAssignable)
						.SelectMany(e => e.Entity.SettableProperties
							.Select(s => s.CreateSettableTypePropertyReference(e))
						)
					)
					.DistinctBy(e => e.Name);
			}
		}

		public IList<DispatchProperty> DispatchProperties => SettableProperties.Select(s=> new DispatchProperty(s)).ToList();


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

	/// <summary>
	/// Represents an interface for entities that can set a particular nested property.
	/// E.g. both EcsDocument and Client have an `As` property of type `As`.
	/// </summary>
	public class AssignableEntityInterface(string name, EntityPropertyReference property, List<EntityClass> entities)
	{
		public EntityPropertyReference Property { get; } = property;
		public List<EntityClass> Entities { get; } = entities;
		public string Name { get; } = $"I{name}";
	}


	public class DispatchProperty
	{
		public bool IsEntityDispatch { get; }
		public string FullPath { get; }
		public string LogTemplateAlternative { get; }
		public string CastFromObject { get; }
		public string ContainerPath { get; } = string.Empty;
		public string ContainerPathEntity { get; } = string.Empty;

		public string Name { get; }
		public string JsonProperty { get; }
		public bool SelfReferential { get; }

		public DispatchProperty(PropertyReference property)
		{
			JsonProperty = property.JsonProperty;
			FullPath = property.FullPath;
			LogTemplateAlternative = property.LogTemplateAlternative;
			Name = property.Name;
			switch (property)
			{
				case NestedValueTypePropertyReference nested:
					IsEntityDispatch = true;
					CastFromObject = $"TryAssign{nested.Entity.Name}";
					ContainerPath = nested.ContainerPath;
					ContainerPathEntity = nested.ContainerPathEntity;
					SelfReferential = nested.SelfReferential;
					break;
				case ValueTypePropertyReference value:
					CastFromObject = value.Field.GetCastFromObject();
					SelfReferential = value.SelfReferential;
					break;
			}
		}
	}

	public class PropDispatch
	{
		public string Name { get; }
		public string FuncTarget { get; }
		public string AssignTarget { get; }
		public EntityClass Entity { get; }
		public string AssignParameter { get; }
		public string AssignEntity { get; set; }
		public List<DispatchProperty> AssignableProperties { get; set; }

		public PropDispatch(EntityClass entity, AssignableEntityInterface assignable)
		{

			Name = entity.Name;
			FuncTarget = entity.Name;
			AssignEntity = entity.Name;
			Entity = entity;
			AssignTarget = entity.Name;
			AssignableProperties = Entity.SettableProperties.Select(e => new DispatchProperty(e)).ToList();
			AssignParameter = "EcsDocument";
			if (assignable is not null)
			{
				AssignParameter = $"I{Name}";
				AssignTarget = assignable.Property.Name;
			}
		}
	}
}
