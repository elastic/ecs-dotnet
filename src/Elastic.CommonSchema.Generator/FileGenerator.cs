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
				{ GenerateTypes, "Dotnet types" },
				{ GenerateTypeMappings, "Dotnet type mapping" },
				{ GenerateBaseJsonFormatter, "Base Json Formatter" },
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

		private static void GenerateTypes(CsharpProjection model)
		{
			var targetDir = Path.GetFullPath(CodeConfiguration.ElasticCommonSchemaGeneratedFolder);
			var outputFile = Path.Combine(targetDir, @"Types.Generated.cs");
			var path = Path.Combine(CodeConfiguration.ViewFolder, @"Types.Generated.cshtml");
			var template = File.ReadAllText(path);
			var source = DoRazor(nameof(GenerateTypes), template, model);
			File.WriteAllText(outputFile, source);
		}

		private static void GenerateTypeMappings(CsharpProjection model)
		{
			var targetDir = Path.GetFullPath(CodeConfiguration.ElasticCommonSchemaNESTGeneratedFolder);
			var outputFile = Path.Combine(targetDir, @"TypeMappings.Generated.cs");
			var path = Path.Combine(CodeConfiguration.ViewFolder, @"TypeMappings.Generated.cshtml");
			var template = File.ReadAllText(path);
			var source = DoRazor(nameof(GenerateTypeMappings), template, model);
			File.WriteAllText(outputFile, source);
		}

		private static void GenerateBaseJsonFormatter(CsharpProjection model)
		{
			var targetDir = Path.GetFullPath(CodeConfiguration.ElasticCommonSchemaGeneratedFolder);
			var outputFile = Path.Combine(targetDir, "Serialization", @"BaseJsonFormatter.Generated.cs");
			var path = Path.Combine(CodeConfiguration.ViewFolder, @"BaseJsonFormatter.Generated.cshtml");
			var template = File.ReadAllText(path);
			var source = DoRazor(nameof(GenerateBaseJsonFormatter), template, model);
			File.WriteAllText(outputFile, source);
		}

	}
}
