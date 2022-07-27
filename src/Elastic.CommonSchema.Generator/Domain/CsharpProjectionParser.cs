using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Elastic.CommonSchema.Generator.Schema;
using Elastic.CommonSchema.Generator.Schema.DTO;

namespace Elastic.CommonSchema.Generator.Domain
{
	public class CsharpProjection
	{
		public string VersionTag { get; set; }
		public IReadOnlyCollection<FieldSetBaseClass> FieldSets { get; set; }
		public IReadOnlyCollection<EntityClass> EntityClasses { get; set; }
		public EntityClass Base { get; set; }
		public IReadOnlyCollection<EntityClass> NestedEntityClasses { get; set; }
		public IReadOnlyCollection<InlineObject> InlineObjects { get; set; }
		public ReadOnlyCollection<string> Warnings { get; set; }
	}


	public class CsharpProjectionParser
	{
		public CsharpProjectionParser(EcsSchema schema)
		{
			Schema = schema;
			var entityFieldsBaseClasses = schema.Entities.ToDictionary(k => k.Name, v => new FieldSetBaseClass(v));
			FieldSetsBaseClasses = new ReadOnlyDictionary<string, FieldSetBaseClass>(entityFieldsBaseClasses);
			ExtractValueTypesAndInlineObjectDefinitions();

			var entityClasses = Schema.Entities.ToDictionary(k => k.Name, v => new EntityClass(v.Name, FieldSetsBaseClasses[v.Name]));
			EntityClasses = new ReadOnlyDictionary<string, EntityClass>(entityClasses);

		}

		private ReadOnlyDictionary<string, FieldSetBaseClass> FieldSetsBaseClasses { get; }
		private ReadOnlyDictionary<string, EntityClass> EntityClasses { get; }
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
		/// <see cref="FieldSetBaseClass.Properties"/> exposes: <br/>
		/// -- Fields holding value types e.g <c>process.uptime</c> <br/>
		/// -- Reference to <see cref="InlineObject"/> for embedded inline objects in the fieldset e.g <c>process.tty, network.inner</c> <br/>
		/// </para>
		/// <para>
		/// <see cref="InlineObject"/> groups all related inner object fields together under <see cref="InlineObject.Properties"/><br/>
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
				FieldSets = FieldSetsBaseClasses.Values.ToList(),
				EntityClasses = EntityClasses.Values.Where(e=>e.Name != "Base").ToList(),
				Base = EntityClasses.Values.First(e=>e.Name == "Base"),
				InlineObjects = InlineObjects.Values.ToList(),
				NestedEntityClasses = nestedEntityTypes.Values.ToList(),
				Warnings = Warnings.AsReadOnly(),
				VersionTag = Schema.VersionTag
			};
			return Projection;
		}

		private Dictionary<string, EntityClass> CreateEntityTypes()
		{
			// Create concrete entity instances of base field sets to reference
			var nestedEntityClasses = new Dictionary<string, EntityClass>();
			foreach (var (name, fieldSetBaseClass) in FieldSetsBaseClasses)
			{
				var fieldSet = fieldSetBaseClass.FieldSet;
				var entityClass = EntityClasses[name];
				var parentPath = name;
				if (fieldSet.ReusedHere == null) continue;

				foreach (var reuse in fieldSet.ReusedHere)
				{
					var fieldTokens = reuse.Full.Split('.').ToArray();
					// most common case a reference to a different schema
					if (fieldTokens.Length <= 2 && reuse.SchemaName != name)
					{
						entityClass.EntityReferences[reuse.Full] = new EntityPropertyReference(parentPath, reuse.Full, EntityClasses[reuse.SchemaName]);
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
								new EntityPropertyReference(inlineObjectPath, reuse.Full, EntityClasses[reuse.SchemaName]);
						}
						else if (!string.IsNullOrWhiteSpace(entityObjectPath) && reuse.SchemaName != name)
						{
							EntityClasses[entityObjectPath].EntityReferences[reuse.Full] =
								new EntityPropertyReference(entityObjectPath, reuse.Full, EntityClasses[reuse.SchemaName]);
						}
						else if (!string.IsNullOrWhiteSpace(entityObjectPath))
						{
							var nestedEntityClass = new EntityClass(reuse.Full, EntityClasses[reuse.SchemaName].BaseFieldSet);
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
					var nestedEntityClassRef = new EntityPropertyReference(nestedPath, fullName, entity);
					nestedEntityClasses[nestedPath].EntityReferences[fullName] = nestedEntityClassRef;
				}
				else if (!string.IsNullOrEmpty(entityPath))
				{
					var nestedEntityClassRef = new EntityPropertyReference(entityPath, fullName, entity);
					EntityClasses[entityPath].EntityReferences[fullName] = nestedEntityClassRef;
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
			foreach (var (name, fieldSetBaseClass) in FieldSetsBaseClasses)
			{
				var fieldSet = fieldSetBaseClass.FieldSet;
				var fields = fieldSetBaseClass.Properties;
				var parentPath = name;
				foreach (var (fullPath, field) in fieldSet.Fields)
				{
					if (fullPath == "trace.id")
					{

					}
					var currentPropertyReferences = fields;
					//always in the format of `entityname.[field]` where field can have dots too;
					var fieldTokens = fullPath.Split('.').ToArray();
					if (fieldTokens.Length <= 2)
					{
						parentPath = fullPath.StartsWith(name + ".") && fieldTokens.Length > 1 ? fieldTokens[0] : name;
						if (field.Type is FieldType.Object or FieldType.Nested)
						{
							InlineObjects[fullPath] = InlineObjects.TryGetValue(fullPath, out var o)
								? o
								: new InlineObject(fullPath, field);
							currentPropertyReferences[fullPath] =
								currentPropertyReferences.TryGetValue(fullPath, out var p)
									? p
									: new InlineObjectPropertyReference(parentPath, fullPath, InlineObjects[fullPath]);
						}
						else
							currentPropertyReferences[fullPath] = new ValueTypePropertyReference(parentPath, fullPath, field);
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
						if (fieldSet.Nestings != null && fieldSet.Nestings.Any(nesting => fullPath.StartsWith($"{nesting}.")))
						{
							continue;
						}

						var foundInlineObjectPath = false;
						foreach (var path in inlineObjectPaths)
						{
							if (!fields.ContainsKey(path))
							{
								continue;
							}

							InlineObjects[path] = InlineObjects.TryGetValue(path, out var o) ? o : new InlineObject(path, field);

							currentPropertyReferences[path] =
								currentPropertyReferences.TryGetValue(path, out var p)
									? p
									: new InlineObjectPropertyReference(parentPath, path, InlineObjects[path]);
							currentPropertyReferences = InlineObjects[path].Properties;
							parentPath = path;
							foundInlineObjectPath = true;
						}
						if (!foundInlineObjectPath)
						{
							parentPath = name;
						}
						currentPropertyReferences[fullPath] = new ValueTypePropertyReference(parentPath, fullPath, field);
					}
				}
			}
		}
	}
}
