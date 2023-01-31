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
					// ensure our template beats out builtin templates or elastic agent integrations
					// force datastreams for new index templates

					.Replace("\"priority\": 1,", "\"priority\": 201,\r\n  \"data_stream\": {},")
					.Replace("Sample composable template that includes all ECS fields",
						"Template installed by .NET ECS libraries (https://github.com/elastic/ecs-dotnet)")
					.Replace("\"", "\"\"")
					.Replace("\"\"ecs_8.4.0_vulnerability\"\"", "\"\"ecs_8.4.0_vulnerability\"\"\" + userComponents + @\"")
					.Replace("try-ecs-*", "\" + indexPattern + @\"");
		}
	}
}
