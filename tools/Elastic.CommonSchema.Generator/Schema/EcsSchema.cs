using System.Collections.Generic;
using Elastic.CommonSchema.Generator.Schema.DTO;

namespace Elastic.CommonSchema.Generator.Schema;

public class EcsSchema
{
	public IReadOnlyCollection<string> Warnings { get; }
	public IReadOnlyDictionary<string, string> Templates { get; }
	public IReadOnlyDictionary<string, string> Components { get; }
	public string GitRef { get; }
	public string Version { get; }
	public IReadOnlyCollection<FieldSet> Entities { get; }

	public EcsSchema(IReadOnlyCollection<FieldSet> entities,
		IReadOnlyCollection<string> warnings,
		Dictionary<string, string> templates,
		Dictionary<string, string> components,
		string gitRef,
		string version
	)
	{
		Entities = entities;
		Warnings = warnings;
		Templates = templates;
		Components = components;
		GitRef = gitRef;
		Version = version;
	}
}
