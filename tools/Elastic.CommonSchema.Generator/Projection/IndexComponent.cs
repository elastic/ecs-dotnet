namespace Elastic.CommonSchema.Generator.Projection
{
	public class IndexComponent
	{
		public string Name { get; }
		public string EcsName { get; }
		public string Component { get; }

		public IndexComponent(string name, string component, string schemaVersion)
		{
			Name = name.PascalCase();
			EcsName = $"ecs_{schemaVersion}_{name}";
			Component = component
				.Replace("\"", "\"\"");
		}
	}
}
