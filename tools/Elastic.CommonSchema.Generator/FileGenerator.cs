// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.IO;
using Elastic.CommonSchema.Generator.Projection;
using RazorLight;
using RazorLight.Razor;
using ShellProgressBar;

namespace Elastic.CommonSchema.Generator
{
	public class FileGenerator
	{
		private static readonly RazorLightEngine Razor = new RazorLightEngineBuilder()
			.UseProject(new FileSystemRazorProject(Path.GetFullPath(CodeConfiguration.ElasticCommonSchemaGeneratedFolder)))
			.UseMemoryCachingProvider()
			.Build();

		public static void Generate(CommonSchemaTypesProjection commonSchemaTypesProjection)
		{
			var actions = new Dictionary<Action<CommonSchemaTypesProjection>, string>
			{
				{ m => Generate(m, "EcsDocument"), "Base ECS Document" },

				{ m => Generate(m, "EcsDocumentJsonConverter", "Serialization"), "Base ECS Document Json Converter" },
				{ m => Generate(m, "PropertiesReaderJsonConverterBase", "Serialization"), "Generate converters for entities with optional serialization behaviour" },
				{ m => Generate(m, "EcsJsonContext", "Serialization"), "Ecs System Text Json Source Generators" },

				{ m => Generate(m, "LogTemplateProperties"), "Strongly types ECS fields supported in log templates" },
				{ m => Generate(m, "PropDispatch"), "ECS key value setter generation" },
				{ m => Generate(m, "FieldSets"), "Field Sets" },
				{ m => Generate(m, "Entities"), "Entities" },
				{ m => Generate(m, "Entities.ShouldSerialize"), "Generate ShouldSerialize special handling for Log and ECS" },
				{ m => Generate(m, "InlineObjects"), "Inline Objects" },
				{ m => Generate(m, "IndexTemplates"), "Elasticsearch index templates" },
				{ m => Generate(m, "IndexComponents"), "Elasticsearch index components" },
			};

			using (var progressBar = new ProgressBar(actions.Count, "Generating code",
					   new ProgressBarOptions { BackgroundColor = ConsoleColor.DarkGray }))
			{
				foreach (var kv in actions)
				{
					progressBar.Message = "Generating " + kv.Value;
					kv.Key(commonSchemaTypesProjection);
					progressBar.Tick("Generated " + kv.Value);
				}
			}

		}


		private static string DoRazor(string name, string template, CommonSchemaTypesProjection model) =>
			Razor.CompileRenderStringAsync(name, template, model).GetAwaiter().GetResult();

		private static void Generate(CommonSchemaTypesProjection model, string what, string subFolder = "")
		{
			var targetDir = Path.GetFullPath(CodeConfiguration.ElasticCommonSchemaGeneratedFolder);
			var outputFile = Path.Combine(targetDir, subFolder, $"{what}.Generated.cs");
			var path = Path.Combine(CodeConfiguration.ViewFolder, $"{what}.Generated.cshtml");
			var template = File.ReadAllText(path);
			var source = DoRazor(nameof(Generate) + what, template, model);
			File.WriteAllText(outputFile, source);
		}


	}
}
