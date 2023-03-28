using System;
using System.Linq;

namespace Elastic.CommonSchema.Generator.Projection
{
	public class IndexTemplate
	{
		public string Name { get; }
		public string Template { get; }

		public IndexTemplate(string name, string template, string schemaVersion)
		{
			var versionPriority = string.Split('.', schemaVersion)
				.Reverse()
				.Select((s,i) => int.Parse(s) * Math.Pow(10, i + 1))
				.Sum();

			Name = name.PascalCase();
			Template =
				//Regex.Replace(template, @"\r\n?|\n", "")
				template
					// ensure our template beats out builtin templates or elastic agent integrations
					// force datastreams for new index templates

					.Replace("\"priority\": 1,", $"\"priority\": {versionPriority},\r\n  \"data_stream\": {{}},")
					.Replace("Sample composable template that includes all ECS fields",
						$"Template installed by ECS.NET {schemaVersion} (https://github.com/elastic/ecs-dotnet)")
					.Replace("\"", "\"\"")
					.Replace("_vulnerability\"\"", "_vulnerability\"\"\" + userComponents + @\"")
					.Replace("try-ecs-*", "\" + indexPattern + @\"");
		}
	}
}
