using System.Collections.Generic;
using System.Linq;
using Elastic.CommonSchema.Generator.Schema.DTO;

namespace Elastic.CommonSchema.Generator.Schema
{
	public class EcsSchema
	{
		public IReadOnlyCollection<string> Warnings { get; }
		public IReadOnlyDictionary<string, string> Templates { get; }
		public IReadOnlyCollection<FieldSet> Entities { get; }
		public FieldSet Base => Entities.Single(e => e.Name == "base");

		public EcsSchema(IReadOnlyCollection<FieldSet> entities, IReadOnlyCollection<string> warnings, Dictionary<string, string> templates)
		{
			Entities = entities;
			Warnings = warnings;
			Templates = templates;
		}
	}
}
