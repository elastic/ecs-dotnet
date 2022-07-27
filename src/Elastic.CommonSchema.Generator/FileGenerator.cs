// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CsQuery.ExtensionMethods;
using Elastic.CommonSchema.Generator.Domain;
using Elastic.CommonSchema.Generator.Schema;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RazorLight;
using RazorLight.Razor;
using ShellProgressBar;
using YamlDotNet.Serialization;

namespace Generator
{
	public class FileGenerator
	{
		private static readonly RazorLightEngine Razor = new RazorLightEngineBuilder()
			.UseProject(new FileSystemRazorProject(Path.GetFullPath(CodeConfiguration.ElasticCommonSchemaGeneratedFolder)))
			.UseMemoryCachingProvider()
			.Build();

		public static void Generate(CsharpProjection csharpProjection)
		{
			var actions = new Dictionary<Action<CsharpProjection>, string>
			{
				{ m => Generate(m, "FieldSets"), "Field Sets" },
				{ m => Generate(m, "Entities"), "Entities" },
				{ m => Generate(m, "InlineObjects"), "Inline Objects" },
				{ m => Generate(m, "Base"), "Base ECS Document" },
				{ m => Generate(m, "BaseJsonConverter"), "Base ECS Document Json Converter" },
			};

			using (var progressBar = new ProgressBar(actions.Count, "Generating code",
				new ProgressBarOptions { BackgroundColor = ConsoleColor.DarkGray }))
			{
				foreach (var kv in actions)
				{
					progressBar.Message = "Generating " + kv.Value;
					kv.Key(csharpProjection);
					progressBar.Tick("Generated " + kv.Value);
				}
			}

		}


		private static string DoRazor(string name, string template, CsharpProjection model) =>
			Razor.CompileRenderStringAsync(name, template, model).GetAwaiter().GetResult();

		private static void Generate(CsharpProjection model, string what)
		{
			var targetDir = Path.GetFullPath(CodeConfiguration.ElasticCommonSchemaGeneratedFolder);
			var outputFile = Path.Combine(targetDir, $"{what}.Generated.cs");
			var path = Path.Combine(CodeConfiguration.ViewFolder, $"{what}.Generated.cshtml");
			var template = File.ReadAllText(path);
			var source = DoRazor(nameof(Generate) + what, template, model);
			File.WriteAllText(outputFile, source);
		}


	}
}
