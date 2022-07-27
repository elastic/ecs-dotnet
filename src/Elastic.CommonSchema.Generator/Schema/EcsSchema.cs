using System.Collections.Generic;
using System.Linq;
using Elastic.CommonSchema.Generator.Schema.DTO;

namespace Elastic.CommonSchema.Generator.Schema
{
	public class EcsSchema
	{
		public IReadOnlyCollection<string> Warnings { get; }
		public IReadOnlyDictionary<string, string> Templates { get; }
		public string VersionTag { get; }
		public IReadOnlyCollection<FieldSet> Entities { get; }

		public EcsSchema(IReadOnlyCollection<FieldSet> entities, IReadOnlyCollection<string> warnings, Dictionary<string, string> templates,
			string versionTag
		)
		{
			Entities = entities;
			Warnings = warnings;
			Templates = templates;
			VersionTag = versionTag;
		}
	}
}
