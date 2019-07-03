using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsQuery.ExtensionMethods;
using DiffMatchPatch;
using Generator.Schema;
using Microsoft.CodeAnalysis.Emit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RazorLight;
using RazorLight.Extensions;
using ShellProgressBar;
using YamlDotNet.Serialization;

namespace Generator
{
    public class FileGenerator
    {
//        private static readonly RazorLightEngine Razor = new RazorLightEngineBuilder()
//                                                                .UseMemoryCachingProvider()
//                                                                .Build();
        private static List<string> Warnings { get; set; }

        public static void Generate(string downloadBranch, params string[] folders)
        {
            Warnings = new List<string>();
            var spec = CreateSpecModel(downloadBranch, folders);
            var actions = new Dictionary<Action<object>, string>
            {
                { GenerateClientInterface, "Client interface" }
            };

            using (var pbar = new ProgressBar(actions.Count, "Generating code",
                new ProgressBarOptions {BackgroundColor = ConsoleColor.DarkGray}))
            {
                foreach (var kv in actions)
                {
                    pbar.Message = "Generating " + kv.Value;
                    kv.Key(spec);
                    pbar.Tick("Generated " + kv.Value);
                }
            }

            if (Warnings.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("No validation errors in YAML");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Validation errors in YAML");
            foreach (var warning in Warnings.Distinct().OrderBy(w => w))
                Console.WriteLine(warning);
            Console.ResetColor();
        }

        private static IList<YamlSchema> CreateSpecModel(string downloadBranch, string[] folders)
        {
            var directories = Directory
                .GetDirectories(CodeConfiguration.SpecificationFolder, "*", SearchOption.AllDirectories)
                .Where(f => folders == null || folders.Length == 0 || folders.Contains(new DirectoryInfo(f).Name))
                .ToList();

            var specItems = new List<YamlSchema>();
            using (var progressBar = new ProgressBar(directories.Count, $"Listing {directories.Count} directories",
                new ProgressBarOptions {BackgroundColor = ConsoleColor.DarkGray}))
            {
                var folderFiles = directories.Select(dir =>
                    Directory.GetFiles(dir)
                        .Where(f => f.EndsWith(".yml"))
                        .ToList()
                );

                foreach (var files in folderFiles)
                {
                    using (var fileProgress = progressBar.Spawn(files.Count, $"Listing {files.Count} files",
                        new ProgressBarOptions {ProgressCharacter = '─', BackgroundColor = ConsoleColor.DarkGray}))
                    {
                        foreach (var file in files)
                        {
                            var specifications = CreateSpecification(file);
                            specItems.AddRange(specifications);
                            fileProgress.Tick();
                        }
                    }

                    progressBar.Tick();
                }
            }

            return specItems;
        }

        public static string PascalCase(string s)
        {
            var textInfo = new CultureInfo("en-US").TextInfo;
            return textInfo.ToTitleCase(s.ToLowerInvariant()).Replace("_", string.Empty).Replace(".", string.Empty);
        }

        private static IEnumerable<YamlSchema> CreateSpecification(string file)
        {
            var deserializer = new Deserializer();
            var contents = File.ReadAllText(file);
            var yamlObject = deserializer.Deserialize(new StringReader(contents));
            var asJson = yamlObject.ToJSON();

            var jsonSerializer = JsonSerializer.Create();
            var spec = jsonSerializer.Deserialize<List<YamlSchema>>(new JsonTextReader(new StringReader(asJson)));

            var serialised = JsonConvert.SerializeObject(spec,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    Converters =
                    {
                        new FormatAsTextConverter<int>(),
                        new FormatAsTextConverter<int?>(),
                        new FormatAsTextConverter<bool?>()
                    }
                });

            var differ = new JsonDiffPatchDotNet.JsonDiffPatch();    
            var diffs = differ.Diff(asJson, serialised);
            if (diffs!=null)
            {
                foreach (var diff in diffs)
                    Warnings.Add($"{file}:{diff}");
            }

            return spec;
        }

        private sealed class FormatAsTextConverter<T> : JsonConverter
        {
            public override bool CanRead => false;
            public override bool CanWrite => true;
            public override bool CanConvert(Type type) => type == typeof(T);

            public override void WriteJson(
                JsonWriter writer, object value, JsonSerializer serializer)
            {
                var cast = (T) value;
                writer.WriteValue(cast.ToString().ToLower());
            }

            public override object ReadJson(
                JsonReader reader, Type type, object existingValue, JsonSerializer serializer)
            {
                throw new NotSupportedException();
            }
        }
        
        private static string DoRazor(string name, string template, object model)
        {
            return "";
        }
        //Razor.CompileRenderAsync(name, template, model).GetAwaiter().GetResult();

        private static void GenerateClientInterface(object model)
        {
//            var targetFile = CodeConfiguration.EsNetFolder + @"IElasticLowLevelClient.Generated.cs";
//            var source = DoRazor(nameof(GenerateClientInterface),
//                File.ReadAllText(CodeConfiguration.ViewFolder + @"IElasticLowLevelClient.Generated.cshtml"), model);
//            File.WriteAllText(targetFile, source);
        }
    }
}