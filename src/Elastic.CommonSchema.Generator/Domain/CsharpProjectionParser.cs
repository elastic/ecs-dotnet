using System.Collections.Generic;
using System.Linq;
using Elastic.CommonSchema.Generator.Schema;
using Elastic.CommonSchema.Generator.Schema.DTO;

namespace Elastic.CommonSchema.Generator.Domain
{
	public class CsharpProjectionParser
	{
		public static CsharpProjection Parse(EcsSchema schema)
		{
			//In order to correctly support ECS nesting we project the fields into the following different
			//.NET structures. This ensures ECS properties can not be arbitrarily nested.

			// EntityFieldsBaseClass						- ProcessFieldsBase
			// -- value types								- e.g process.uptime
			// -- InlineObjectDefinition					- e.g process.tty, process.thread, process.entry_metadata

			// InlineObjectDefinition						- ProcessEntryMetaData
			// -- value types								- e.g process.entry_metadata.type
			// -- InlineObjectDefinition					-
			// -- EntityClass reference						- e.g process.entry_metadata.source

			// EntityClass extends FieldBaseClass			- Process : ProcessFieldsBase
			// -- EntityClassReference						- e.g process.elf
			// -- NestedEntityClass							- e.g process.entry_leader

			// NestedEntityClass extends FieldBaseClass		- EntryLeaderProcess : ProcessFieldsBase
			// -- NestedEntityClass							- e.g process.entry_leader.parent


			var entityFieldsBaseClasses = schema.Entities.ToDictionary(k => k.Name, v => (v, new EntityFieldsBaseClass(v.Name)));
			var allInlineObjects = new Dictionary<string, InlineObjectDefinition>();
			ExtractValueTypesAndInlineObjectDefinitions(entityFieldsBaseClasses, allInlineObjects);

			CreateEntityTypes(schema, entityFieldsBaseClasses, allInlineObjects);


			var projection = new CsharpProjection
			{
				EntityFieldsBaseDefinitions = entityFieldsBaseClasses.Values.Select(t => t.Item2).ToList(),
				InlineObjectDefinitions = allInlineObjects
			};
			return projection;
		}

		private static void CreateEntityTypes(EcsSchema schema, Dictionary<string, (EntityFieldSet v, EntityFieldsBaseClass)> entityFieldsBaseClasses, Dictionary<string, InlineObjectDefinition> allInlineObjects)
		{
			// Create concrete entity instances of base field sets to reference
			var entityClasses = schema.Entities.ToDictionary(k => k.Name, v => (v, new EntityClass(v.Name, entityFieldsBaseClasses[v.Name].Item2)));
			foreach (var (name, (ecsEntity, entityFieldsBaseClass)) in entityFieldsBaseClasses)
			{
				var entityClass = entityClasses[name].Item2;
				if (ecsEntity.ReusedHere == null) continue;
				// some references are easy, they go directly on the current entityClass
				//process.user.*

				// some references go on nested inline objects instead
				//process.entry_meta.source.*

				// some references refer to the current schema and can be arbitrarily nested.
				// - process.entry_leader.*
				// - process.entry_leader.parent.*
				// - process.entry_leader.parent.session_leader.*
				//
				// Here we need to create intermediate NestedEntityClasses
				// EntryLeaderProcess with a parent property, EntryLeaderParentProcess with a session_leader property
				// We don't need to generate EntryLeaderParentSessionLeaderProcess since that simply refers to the ProcessFieldSet

				foreach (var reuse in ecsEntity.ReusedHere)
				{
					var fieldTokens = reuse.Full.Split('.').ToArray();
					// most common case a reference to a different schema
					if (fieldTokens.Length <= 2 && reuse.SchemaName != name)
					{
						entityClass.EntityReferences[reuse.Full] = new EntityPropertyReference(reuse.Full, entityClasses[reuse.SchemaName].Item2);
					}
					else
					{
						var basePath = string.Join('.', fieldTokens.SkipLast(1));
						// check if this deeply nested reference refers to an inline object
						if (allInlineObjects.ContainsKey(basePath))
						{
							allInlineObjects[basePath].EntityReferences[reuse.Full] = new EntityPropertyReference(reuse.Full, entityClasses[reuse.SchemaName].Item2);
						}
						else if (reuse.SchemaName != name)
						{

						}

					}
				}
			}
		}
		private static void ExtractValueTypesAndInlineObjectDefinitions(Dictionary<string, (EntityFieldSet v, EntityFieldsBaseClass)> entityFieldsBaseClasses, Dictionary<string, InlineObjectDefinition> allInlineObjects)
		{
			foreach (var (name, (ecsEntity, entityClass)) in entityFieldsBaseClasses)
			{
				var fieldSet = entityClass.Fields;
				foreach (var (fullPath, field) in ecsEntity.Fields)
				{
					var currentPropertyReferences = fieldSet;
					//always in the format of `entityname.[field]` where field can have dots too;
					var fieldTokens = fullPath.Split('.').ToArray();
					if (fieldTokens.Length <= 2)
					{
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
						foreach (var path in inlineObjectPaths)
						{
							// path is referencing an embedded nested ECS entity
							if (ecsEntity.Nestings != null && ecsEntity.Nestings.Any(nesting => path.StartsWith($"{nesting}"))) continue;

							allInlineObjects[path] = allInlineObjects.TryGetValue(path, out var o) ? o : new InlineObjectDefinition(path, field);

							currentPropertyReferences[path] =
								currentPropertyReferences.TryGetValue(path, out var p)
									? p
									: new InlineObjectPropertyReference(path, allInlineObjects[path]);
							currentPropertyReferences = allInlineObjects[path].Fields;
						}
						currentPropertyReferences[fullPath] = new ValueTypePropertyReference(fullPath, field);
					}
				}
			}
		}
	}

	public class CsharpProjection
	{
		public IReadOnlyCollection<EntityFieldsBaseClass> EntityFieldsBaseDefinitions { get; set; }
		public Dictionary<string, InlineObjectDefinition> InlineObjectDefinitions { get; set; }
	}


	public record EntityFieldsBaseClass(string Name)
	{
		public Dictionary<string, PropertyReference> Fields { get; } = new();
	}

	public record InlineObjectDefinition(string Name, Field Field)
	{
		public Dictionary<string, PropertyReference> Fields { get; } = new();
		public Dictionary<string, EntityPropertyReference> EntityReferences { get; } = new();
	}

	public record EntityClass(string Name, EntityFieldsBaseClass BaseFieldSet)
	{
		public Dictionary<string, EntityPropertyReference> EntityReferences { get; } = new();
	}
}
