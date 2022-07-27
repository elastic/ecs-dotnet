using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Elastic.CommonSchema.Generator.Schema;
using Elastic.CommonSchema.Generator.Schema.DTO;

namespace Elastic.CommonSchema.Generator.Domain
{
	public class CsharpProjection
	{
		public IReadOnlyCollection<FieldSetBaseClass> FieldSets { get; set; }
		public Dictionary<string, InlineObject> InlineObjects { get; set; }
		public Dictionary<string, EntityClass> EntityClasses { get; set; }
		public Dictionary<string, EntityClass> NestedEntityClasses { get; set; }
		public ReadOnlyCollection<string> Warnings { get; set; }
	}

	public record FieldSetBaseClass(string Name)
	{
		public Dictionary<string, PropertyReference> Fields { get; } = new();
	}

	public record InlineObject(string Name, Field Field)
	{
		public Dictionary<string, PropertyReference> Fields { get; } = new();
		public Dictionary<string, EntityPropertyReference> EntityReferences { get; } = new();
	}

	public record EntityClass(string Name, FieldSetBaseClass BaseFieldSet)
	{
		public Dictionary<string, EntityPropertyReference> EntityReferences { get; } = new();
	}

	public class CsharpProjectionParser
	{
		public CsharpProjectionParser(EcsSchema schema)
		{
			Schema = schema;
			var entityFieldsBaseClasses = schema.Entities.ToDictionary(k => k.Name, v => (v, new FieldSetBaseClass(v.Name)));
			FieldSetsBaseClasses = new ReadOnlyDictionary<string, (FieldSet v, FieldSetBaseClass)>(entityFieldsBaseClasses);
			ExtractValueTypesAndInlineObjectDefinitions();

			var entityClasses = Schema.Entities.ToDictionary(k => k.Name, v => (v, new EntityClass(v.Name, FieldSetsBaseClasses[v.Name].Item2)));
			EntityClasses = new ReadOnlyDictionary<string, (FieldSet, EntityClass)>(entityClasses);

		}

		private ReadOnlyDictionary<string, (FieldSet v, FieldSetBaseClass)> FieldSetsBaseClasses { get; }
		private ReadOnlyDictionary<string, (FieldSet v, EntityClass)> EntityClasses { get; }
		private Dictionary<string, InlineObject> InlineObjects { get; } = new();
		private CsharpProjection Projection { get; set; }
		private List<string> Warnings { get; } = new();

		private EcsSchema Schema { get; }

		/// <summary>
		/// <para>
		/// Creates an intermediate projection model <see cref="CsharpProjection"/> of the raw <see cref="EcsSchema"/>.
		/// </para>
		/// <para>
		/// <see cref="FieldSetBaseClass"/> projects ECS <see cref="FieldSet"/>'s as reusable base classes <br/>
		/// <see cref="FieldSetBaseClass.Fields"/> exposes: <br/>
		/// -- Fields holding value types e.g <c>process.uptime</c> <br/>
		/// -- Reference to <see cref="InlineObject"/> for embedded inline objects in the fieldset e.g <c>process.tty, network.inner</c> <br/>
		/// </para>
		/// <para>
		/// <see cref="InlineObject"/> groups all related inner object fields together under <see cref="InlineObject.Fields"/><br/>
		/// An example of fields that would be grouped would be <c>dns.answers.class, dns.answers.name, etc</c> under <c>dns.answers</c><br />
		/// A <see cref="InlineObject"/> never extends from <see cref="FieldSetBaseClass"/> but can hold fields that reference fieldsets<br/>
		/// These are exposed under <see cref="InlineObject.EntityReferences"/> an example of this is <c>email.attachments.file.hash</c> where
		/// <c>file.hash</c> is a reference to the hash ECS entity on the inner object definition <c>email.attachments</c>
		/// </para>
		/// <para>
		/// <see cref="EntityClass"/> models the various ways fieldsets get exposed in the spec.<br/>
		/// By default each <see cref="FieldSet"/> has one concrete entity implementation e.g <c>cloud, event, hash, geo, etc</c><br/>
		/// These inherit their fields from <see cref="EntityClass.BaseFieldSet"/> and further exposes fieldset references under <see cref="EntityClass.EntityReferences"/><br/>
		/// e.g <c>cloud.origin</c> which allows the <c>cloud</c> fieldset to be embedded within itself.<br/>
		/// </para>
		/// <para>
		/// To prevent endless recursive nesting such as <c>cloud.origin.origin.origin</c> to canonical model will create a special type for <c>cloud.origin</c>
		/// which inherits the <c>cloud</c> field set without any of the nested references. These are exposed seperately under <see cref="CsharpProjection.NestedEntityClasses"/><br />
		/// </para>
		/// <para>
		/// These nested entities can hold reference to other nested <see cref="EntityClass"/>'s
		/// <code>
		/// process.session_leader
		/// process.session_leader.parent
		///	process.session_leader.parent.session_leader
		/// </code>
		/// All implement the <c>process</c> field set but hold different <see cref="EntityClass.EntityReferences"/>
		/// </para>
		/// </summary>
		/// <returns></returns>
		public CsharpProjection CreateCanonicalModel()
		{
			if (Projection != null) return Projection;

			var nestedEntityTypes = CreateEntityTypes();

			Projection = new CsharpProjection
			{
				FieldSets = FieldSetsBaseClasses.Values.Select(t => t.Item2).ToList(),
				InlineObjects = InlineObjects,
				EntityClasses = EntityClasses.ToDictionary(k=>k.Key, v=>v.Value.Item2),
				NestedEntityClasses = nestedEntityTypes,
				Warnings = Warnings.AsReadOnly()
			};
			return Projection;
		}

		private Dictionary<string, EntityClass> CreateEntityTypes()
		{
			// Create concrete entity instances of base field sets to reference
			var nestedEntityClasses = new Dictionary<string, EntityClass>();
			foreach (var (name, (ecsEntity, entityFieldsBaseClass)) in FieldSetsBaseClasses)
			{
				var entityClass = EntityClasses[name].Item2;
				if (ecsEntity.ReusedHere == null) continue;

				foreach (var reuse in ecsEntity.ReusedHere)
				{
					var fieldTokens = reuse.Full.Split('.').ToArray();
					// most common case a reference to a different schema
					if (fieldTokens.Length <= 2 && reuse.SchemaName != name)
					{
						entityClass.EntityReferences[reuse.Full] = new EntityPropertyReference(reuse.Full, EntityClasses[reuse.SchemaName].Item2);
					}
					else
					{
						// We can't assume the direct parent is an ECS field e.g
						// email.attachments.file.hash -> file.hash is a property on email.attachments

						var basePaths = fieldTokens.Select((token, i) => string.Join('.', fieldTokens.Take(i + 1))).Reverse().ToArray();
						var inlineObjectPath = basePaths.FirstOrDefault(p => InlineObjects.ContainsKey(p));
						var entityObjectPath = basePaths.FirstOrDefault(p => EntityClasses.ContainsKey(p));
						// check if this deeply nested reference refers to an inline object
						if (!string.IsNullOrEmpty(inlineObjectPath))
						{
							InlineObjects[inlineObjectPath].EntityReferences[reuse.Full] =
								new EntityPropertyReference(reuse.Full, EntityClasses[reuse.SchemaName].Item2);
						}
						else if (!string.IsNullOrWhiteSpace(entityObjectPath) && reuse.SchemaName != name)
						{
							EntityClasses[entityObjectPath].Item2.EntityReferences[reuse.Full] =
								new EntityPropertyReference(reuse.Full, EntityClasses[reuse.SchemaName].Item2);
						}
						else if (!string.IsNullOrWhiteSpace(entityObjectPath))
						{
							var nestedEntityClass = new EntityClass(reuse.Full, EntityClasses[reuse.SchemaName].Item2.BaseFieldSet);
							nestedEntityClasses[reuse.Full] = nestedEntityClass;
						}
						else Warnings.Add($"Unable to project reuse of: ${reuse.Full}");
					}
				}
			}

			foreach (var (fullName, entity) in nestedEntityClasses)
			{
				var fieldTokens = fullName.Split('.').ToArray();
				var parentPaths = fieldTokens.Select((token, i) => string.Join('.', fieldTokens.Take(i + 1))).Reverse().Skip(1).ToArray();
				var nestedPath = parentPaths.FirstOrDefault(p => nestedEntityClasses.ContainsKey(p));
				var entityPath = parentPaths.FirstOrDefault(p => EntityClasses.ContainsKey(p));
				if (!string.IsNullOrEmpty(nestedPath))
				{
					var nestedEntityClassRef = new EntityPropertyReference(fullName, entity);
					nestedEntityClasses[nestedPath].EntityReferences[fullName] = nestedEntityClassRef;
				}
				else if (!string.IsNullOrEmpty(entityPath))
				{
					var nestedEntityClassRef = new EntityPropertyReference(fullName, entity);
					EntityClasses[entityPath].Item2.EntityReferences[fullName] = nestedEntityClassRef;
				}
				else
				{
					Warnings.Add($"Unable find host to hold the entity reference ${fullName}");
				}
			}

			return nestedEntityClasses;
		}

		private void ExtractValueTypesAndInlineObjectDefinitions()
		{
			foreach (var (name, (ecsEntity, entityClass)) in FieldSetsBaseClasses)
			{
				var fieldSet = entityClass.Fields;
				foreach (var (fullPath, field) in ecsEntity.Fields)
				{
					var currentPropertyReferences = fieldSet;
					//always in the format of `entityname.[field]` where field can have dots too;
					var fieldTokens = fullPath.Split('.').ToArray();
					if (fieldTokens.Length <= 2)
					{
						if (field.Type is FieldType.Object or FieldType.Nested)
						{
							InlineObjects[fullPath] = InlineObjects.TryGetValue(fullPath, out var o)
								? o
								: new InlineObject(fullPath, field);
							currentPropertyReferences[fullPath] =
								currentPropertyReferences.TryGetValue(fullPath, out var p)
									? p
									: new InlineObjectPropertyReference(fullPath, InlineObjects[fullPath]);
						}
						else
							currentPropertyReferences[fullPath] = new ValueTypePropertyReference(fullPath, field);
					}
					else
					{
						var allPaths = fieldTokens.Aggregate(new List<string>(), (list, s) =>
						{
							if (list.Count == 0) list.Add(s);
							else list.Add($"{list.Last()}.{s}");
							return list;
						});
						var inlineObjectPaths = allPaths.Skip(1).SkipLast(1).ToArray();

						// path is referencing an embedded nested ECS entity
						if (ecsEntity.Nestings != null && ecsEntity.Nestings.Any(nesting => fullPath.StartsWith($"{nesting}.")))
						{
							continue;
						}

						foreach (var path in inlineObjectPaths)
						{
							if (!fieldSet.ContainsKey(path))
							{
								continue;
							}

							InlineObjects[path] = InlineObjects.TryGetValue(path, out var o) ? o : new InlineObject(path, field);

							currentPropertyReferences[path] =
								currentPropertyReferences.TryGetValue(path, out var p)
									? p
									: new InlineObjectPropertyReference(path, InlineObjects[path]);
							currentPropertyReferences = InlineObjects[path].Fields;
						}
						currentPropertyReferences[fullPath] = new ValueTypePropertyReference(fullPath, field);
					}
				}
			}
		}
	}
}
