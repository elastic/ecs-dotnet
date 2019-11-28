using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CsQuery.ExtensionMethods;
using Generator.Schema;
using Newtonsoft.Json;
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

        private static List<string> Warnings { get; set; }

        public static void Generate(string downloadBranch, params string[] folders)
        {
            Warnings = new List<string>();
            var spec = GetEcsSpecification(downloadBranch, folders);
            var actions = new Dictionary<Action<EcsSpecification>, string>
            {
                {GenerateTypes, "Dotnet types"},
                {GenerateTypeMappings, "Dotnet type mapping"},
                {GenerateBaseJsonFormatter, "Base Json Formatter"},
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

        private static EcsSpecification GetEcsSpecification(string downloadBranch, string[] folders)
        {
            var specificationFolder = Path.Combine(CodeConfiguration.SpecificationFolder, downloadBranch);
            var directories = Directory
                .GetDirectories(specificationFolder, "*", SearchOption.AllDirectories)
                .Where(f => folders == null || folders.Length == 0 || folders.Contains(new DirectoryInfo(f).Name))
                .ToList();

            var yamlSchemas = new List<YamlSchema>();
            var templates = new Dictionary<int, string>();
            
            using (var progressBar = new ProgressBar(directories.Count, $"Listing {directories.Count} directories",
                new ProgressBarOptions {BackgroundColor = ConsoleColor.DarkGray}))
            {
                var yamlFiles = directories.Select(dir =>
                    Directory.GetFiles(dir).Where(f => f.EndsWith("_nested.yml")).ToList()
                );

                foreach (var files in yamlFiles)
                {
                    using (var fileProgress = progressBar.Spawn(files.Count, $"Listing {files.Count} files",
                        new ProgressBarOptions {ProgressCharacter = '─', BackgroundColor = ConsoleColor.DarkGray}))
                    {
                        foreach (var file in files)
                        {
                            var specifications = GetYamlSchemas(downloadBranch, file);
                            yamlSchemas.AddRange(specifications);
                            fileProgress.Tick();
                        }
                    }

                    progressBar.Tick();
                }
                
                var jsonFiles = directories.Select(dir =>
                    Directory.GetFiles(dir).Where(f => f.EndsWith(".json")).ToList()
                );

                foreach (var files in jsonFiles)
                {
                    using (var fileProgress = progressBar.Spawn(files.Count, $"Listing {files.Count} files",
                        new ProgressBarOptions {ProgressCharacter = '─', BackgroundColor = ConsoleColor.DarkGray}))
                    {
                        foreach (var file in files)
                        {
                            var groupCollection = Regex.Match(file, ".*Template(\\d).*").Groups;
                            var versionString = groupCollection[1].Value;
                            var version = int.Parse(versionString);
                            var contents = File.ReadAllText(file);
                            templates.Add(version, contents);
                        }
                    }

                    progressBar.Tick();
                }
            }

            var spec = new EcsSpecification
            {
                YamlSchemas = yamlSchemas,
                Templates = templates
            };

            return spec;
        }

        public static string PascalCase(string s)
        {
            var textInfo = new CultureInfo("en-US").TextInfo;
            return textInfo.ToTitleCase(s.ToLowerInvariant()).Replace("_", string.Empty).Replace(".", string.Empty);
        }

        private static IEnumerable<YamlSchema> GetYamlSchemas(string downloadBranch, string file)
        {
            var deserializer = new Deserializer();
            var contents = File.ReadAllText(file);
            var yamlObject = deserializer.Deserialize(new StringReader(contents));
            var asJson = yamlObject.ToJSON();

            var jsonSerializer = JsonSerializer.Create();
            var spec = jsonSerializer.Deserialize<Dictionary<string, YamlSchema>>(new JsonTextReader(new StringReader(asJson)));

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
            if (diffs != null)
                foreach (var diff in diffs)
                    Warnings.Add($"{file}:{diff}");

            return spec.Select(d => d.Value).Select(s =>
            {
                s.DownloadBranch = downloadBranch;
                foreach (var kvp in s.Fields)
                {
                    kvp.Value.Schema = s;
                }
                return s;
            });
        }

        private static string DoRazor(string name, string template, EcsSpecification model)
        {
            return Razor.CompileRenderStringAsync(name, template, model).GetAwaiter().GetResult();
        }

        private static void GenerateTypes(EcsSpecification model)
        {
            var targetDir = Path.GetFullPath(CodeConfiguration.ElasticCommonSchemaGeneratedFolder);
            var outputFile = Path.Combine(targetDir, @"Types.Generated.cs");
            var path = Path.Combine(CodeConfiguration.ViewFolder, @"Types.Generated.cshtml");
            var template = File.ReadAllText(path);
            var source = DoRazor(nameof(GenerateTypes), template, model);
            File.WriteAllText(outputFile, source);
        }

        private static void GenerateTypeMappings(EcsSpecification model)
        {
            var targetDir = Path.GetFullPath(CodeConfiguration.ElasticCommonSchemaNESTGeneratedFolder);
            var outputFile = Path.Combine(targetDir, @"TypeMappings.Generated.cs");
            var path = Path.Combine(CodeConfiguration.ViewFolder, @"TypeMappings.Generated.cshtml");
            var template = File.ReadAllText(path);
            var source = DoRazor(nameof(GenerateTypeMappings), template, model);
            File.WriteAllText(outputFile, source);
        }

        private static void GenerateBaseJsonFormatter(EcsSpecification model)
        {
            var targetDir = Path.GetFullPath(CodeConfiguration.ElasticCommonSchemaGeneratedFolder);
            var outputFile = Path.Combine(targetDir, "Serialization", @"BaseJsonFormatter.Generated.cs");
            var path = Path.Combine(CodeConfiguration.ViewFolder, @"BaseJsonFormatter.Generated.cshtml");
            var template = File.ReadAllText(path);
            var source = DoRazor(nameof(GenerateBaseJsonFormatter), template, model);
            File.WriteAllText(outputFile, source);
        }

        private sealed class FormatAsTextConverter<T> : JsonConverter
        {
            public override bool CanRead => false;
            public override bool CanWrite => true;

            public override bool CanConvert(Type type)
            {
                return type == typeof(T);
            }

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
    }
}