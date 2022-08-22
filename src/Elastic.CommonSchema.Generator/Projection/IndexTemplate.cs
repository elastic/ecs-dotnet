namespace Elastic.CommonSchema.Generator.Projection
{
	public class IndexTemplate
	{
		public string Name { get; }
		public string Template { get; }

		public IndexTemplate(string name, string template)
		{
			Name = name.PascalCase();
			Template =
				//Regex.Replace(template, @"\r\n?|\n", "")
				template
					.Replace("\"", "\"\"")
					.Replace("try-ecs-*", "\" + indexPattern + @\"");
		}
	}
}
