namespace Elastic.CommonSchema.Generator.Projection
{
	public class IndexComponent
	{
		public string Name { get; }
		public string Component { get; }

		public IndexComponent(string name, string component)
		{
			Name = name.PascalCase();
			Component = component
				.Replace("\"", "\"\"");
		}
	}
}
