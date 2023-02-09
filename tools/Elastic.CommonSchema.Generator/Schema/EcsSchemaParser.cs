using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CsQuery.ExtensionMethods;
using Elastic.CommonSchema.Generator.Schema.DTO;
using Newtonsoft.Json;
using YamlDotNet.Serialization;

namespace Elastic.CommonSchema.Generator.Schema
{
	public class EcsSchemaParser
	{
		private readonly string _gitRef;

		public EcsSchemaParser(string gitRef)
		{
			_gitRef = gitRef;
			SpecificationFolder = Path.Combine(CodeConfiguration.SpecificationFolder, gitRef);
			EcsYamlFile = Path.Combine(SpecificationFolder, "Core", "ecs_nested.yml");
			if (!File.Exists(EcsYamlFile)) throw new Exception($"Failed to locate {EcsYamlFile}");
		}

		public string EcsYamlFile { get; }

		public string SpecificationFolder { get; }

		public EcsSchema Parse()
		{

			var contents = File.ReadAllText(EcsYamlFile);

			var deserializer = new Deserializer();
			var yamlObject = deserializer.Deserialize(new StringReader(contents));
			var asJson = yamlObject.ToJSON();
			var jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings
			{
				Converters = { new ExpectedConverter() }
			});

			var spec = jsonSerializer.Deserialize<Dictionary<string, FieldSet>>(new JsonTextReader(new StringReader(asJson)));

			var warnings = SerializeParsedAndCompareWithOriginal(spec, asJson);
			var templates = ReadTemplates();
			var components = ReadComponents();
			var ecsVersion = new Regex("^.*\"ecs_version\":\\s?\"(.*?)\".*$", RegexOptions.Singleline)
				.Replace(templates["composable"], "$1");
			return new EcsSchema(spec.Values.ToList(), warnings, templates, components, _gitRef, ecsVersion);
		}

		private Dictionary<string, string> ReadTemplates()
		{

			var templates = new Dictionary<string, string>();
			var templateFiles =
				from directoryPath in Directory.GetDirectories(SpecificationFolder, "*", SearchOption.AllDirectories)
				let dir = new DirectoryInfo(directoryPath)
				from jsonFile in dir.EnumerateFileSystemInfos("*.json")
				select (dir, jsonFile);

			foreach (var (dir, jsonFile) in templateFiles)
			{
				if (dir.Name == "component") continue;

				templates.Add(dir.Name, File.ReadAllText(jsonFile.FullName));
			}
			return templates;
		}
		private Dictionary<string, string> ReadComponents()
		{

			var templates = new Dictionary<string, string>();
			var templateFiles =
				from directoryPath in Directory.GetDirectories(SpecificationFolder, "*", SearchOption.AllDirectories)
				let dir = new DirectoryInfo(directoryPath)
				from jsonFile in dir.EnumerateFileSystemInfos("*.json")
				select (dir, jsonFile);

			foreach (var (dir, jsonFile) in templateFiles)
			{
				if (dir.Name != "component") continue;

				templates.Add(jsonFile.Name.Replace(".json", ""), File.ReadAllText(jsonFile.FullName));
			}
			return templates;
		}


		private List<string> SerializeParsedAndCompareWithOriginal(Dictionary<string, FieldSet> spec, string asJson)
		{
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
			var warnings = new List<string>();
			if (diffs != null)
				warnings.Add($"{EcsYamlFile}:{diffs}");
			return warnings;
		}


		private sealed class FormatAsTextConverter<T> : JsonConverter
		{
			public override bool CanRead => false;
			public override bool CanWrite => true;

			public override bool CanConvert(Type type) => type == typeof(T);

			public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
			{
				var cast = (T)value;
				writer.WriteValue(cast.ToString()!.ToLower());
			}

			public override object ReadJson(JsonReader reader, Type type, object existingValue, JsonSerializer serializer) =>
				throw new NotSupportedException();
		}
	}
}
