using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Elastic.CommonSchema.Generator.Schema;
using Elastic.CommonSchema.Generator.Schema.DTO;

namespace Elastic.CommonSchema.Generator.Domain
{
	public class CsharpProjectionParser
	{
		private class Nesting
		{
			public string FullPath { get; set; }
			public List<Nesting> Nestings { get; set; } = new List<Nesting>();
		}

		public static CsharpProjection Parse(EcsSchema schema)
		{
			var rootEntities = schema.Entities.ToDictionary(k => k.Name, v => (v, new CsharpEntityClass(v.Name)));
			foreach (var (name, (ecsEntity, entityClass)) in rootEntities)
			{
				var directFields =
					from kv in ecsEntity.Fields
					let parsed = (isRoot: CsharpEntityProperty.TryCreate(name, kv.Value, out var prop), prop)
					where parsed.isRoot
					select parsed.prop;

				entityClass.Fields = directFields.ToList();
			}
			foreach (var (name, (ecsEntity, entityClass)) in rootEntities)
			{
				if (ecsEntity.ReusedHere == null) continue;

				//process.x.y
				//process.x
				//process.z
				var nestings = ecsEntity.Nestings ?? Array.Empty<string>();
				var nested = NestNesting(2, nestings, null);
				foreach (var nesting in nested)
				{
					var reuseReference = ecsEntity.ReusedHere.First(e => e.Full == nesting.FullPath);
					var entity = rootEntities[reuseReference.SchemaName];
					RecurseNestedTypes(nesting, entity, rootEntities, 1);

				}

			}



			var projection = new CsharpProjection { Entities = rootEntities.Values.Select(t => t.Item2).ToList() };
			return projection;
		}

		private static void RecurseNestedTypes(Nesting nesting, (EntityFieldSet v, CsharpEntityClass) entity,
			Dictionary<string, (EntityFieldSet v, CsharpEntityClass)> rootEntities, int depth = 1
		)
		{
			if (nesting.Nestings.Count == 0)
			{
				var fieldRef = CsharpEntityReferenceProperty.Create(nesting.FullPath, entity.Item2);
				entity.Item2.FieldsReferencingEntities.Add(fieldRef);
			}
			else
			{
				if (entity.v.ReusedHere == null) return;

				foreach (var nested in nesting.Nestings)
				{
					var reuseReference = entity.v.ReusedHere.First(e => e.Full == nesting.FullPath);
					var referenceRootEntity = rootEntities[reuseReference.SchemaName];

					var nestedEntity = new CsharpNestedEntityClass(nesting.FullPath, referenceRootEntity.Item2);

					var fieldRef = CsharpNestedEntityReferenceProperty.Create(nested.FullPath, nestedEntity);
					entity.Item2.FieldsReferencingNestedEntities.Add(fieldRef);
					RecurseNestedTypes(nested, entity, rootEntities);
				}
			}
		}

		private static List<Nesting> NestNesting(int i, string[] nestings, string path)
		{
			var nested = from n in nestings
				let tokens = n.Split('.')
				where tokens.Length == i && (path == null || n.StartsWith(path + "."))
				select new Nesting { FullPath = n, Nestings = NestNesting(i+1, nestings, n) };
			return nested.ToList();
		}
	}

	public class CsharpProjection
	{
		public IReadOnlyCollection<CsharpEntityClass> Entities { get; set; }
	}


	public class CsharpEntityClass
	{
		public CsharpEntityClass(string name) => Name = name;

		public string Name { get; }

		public IReadOnlyCollection<CsharpEntityProperty> Fields { get; set; } = Array.Empty<CsharpEntityProperty>();

		public List<CsharpEntityReferenceProperty> FieldsReferencingEntities { get; } = new ();
		public List<CsharpNestedEntityReferenceProperty> FieldsReferencingNestedEntities { get; } = new ();
	}

	/// <summary>
	/// A more specialized class that extends <see cref="CsharpEntityClass"/> with more reference to itself or other entities
	/// </summary>
	public class CsharpNestedEntityClass
	{
		public CsharpNestedEntityClass(string fullPath, CsharpEntityClass entityReference)
		{
			Name = fullPath.GetLastProperty();
			FullPath = fullPath;
			CsharpEntityTypeName = entityReference.Name;
		}

		public string Name { get; }
		public string FullPath { get; }
		/// <summary>The entity we are extending</summary>
		public string CsharpEntityTypeName { get; internal set; }

		public List<CsharpEntityReferenceProperty> FieldsReferencingEntities { get; } = new ();
	}
}
