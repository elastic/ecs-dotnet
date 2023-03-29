using System;
using System.Linq;

namespace Elastic.CommonSchema.Generator.Projection
{
	public class IndexTemplate
	{
		public string Name { get; }
		public string Template { get; }
		public int Priority { get; }

		public IndexTemplate(string name, string template, string schemaVersion)
		{
			var v = schemaVersion.Split('.')
				.Select(s => uint.Parse(s))
				.ToArray();

			uint versionInteger = 0;
            versionInteger |= v[0] << 16;
            versionInteger |= v[1] << 8;
            versionInteger |= v[2];

            Priority = (int)versionInteger;

			Name = name.PascalCase();
			Template =
				//Regex.Replace(template, @"\r\n?|\n", "")
				template
					// ensure our template beats out builtin templates or elastic agent integrations
					// force datastreams for new index templates

					.Replace("\"priority\": 1,", $"\"priority\": {Priority},\r\n  \"data_stream\": {{}},")
					.Replace("Sample composable template that includes all ECS fields",
						$"Template installed by ECS.NET {schemaVersion} (https://github.com/elastic/ecs-dotnet)")
					.Replace("\"", "\"\"")
					.Replace("_vulnerability\"\"", "_vulnerability\"\"\" + userComponents + @\"")
					.Replace("try-ecs-*", "\" + indexPattern + @\"");
		}
	}
}
