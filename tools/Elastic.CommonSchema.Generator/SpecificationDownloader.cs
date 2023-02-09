// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using CsQuery;
using ShellProgressBar;

namespace Elastic.CommonSchema.Generator
{
	public class SpecificationDownloader
	{
		private const string Core = "Core";
		private const string Legacy = "legacy";
		private const string Composable = "composable";
		private const string Components = "component";

		private static readonly ProgressBarOptions MainProgressBarOptions = new() { BackgroundColor = ConsoleColor.DarkGray };

		private static readonly Dictionary<string, string> OnlineSpecifications = new()
		{
			{ Core, "https://github.com/elastic/ecs/tree/{version}/generated/ecs" },
			{ Legacy, "https://github.com/elastic/ecs/tree/{version}/generated/elasticsearch/legacy" },
			{ Composable, "https://github.com/elastic/ecs/tree/{version}/generated/elasticsearch/composable" },
			{ Path.Combine(Composable, Components), "https://github.com/elastic/ecs/tree/{version}/generated/elasticsearch/composable/component" }
		};

		private static readonly ProgressBarOptions SubProgressBarOptions = new()
		{
			ForegroundColor = ConsoleColor.Cyan,
			ForegroundColorDone = ConsoleColor.DarkGreen,
			ProgressCharacter = '─',
			BackgroundColor = ConsoleColor.DarkGray
		};

		public static void Download(string branch)
		{
			var specifications =
				(from kv in OnlineSpecifications
					let url = kv.Value.Replace("{version}", branch)
					select new Specification { FolderOnDisk = Path.Combine(branch, kv.Key), Branch = branch, GithubListingUrl = url })
				.ToList();

			using var progress = new ProgressBar(specifications.Count, "Downloading specifications", MainProgressBarOptions);
			foreach (var spec in specifications)
			{
				progress.Message = $"Downloading to {spec.FolderOnDisk} for branch {branch}";
				DownloadDefinitions(spec, progress, ".yml");
				DownloadDefinitions(spec, progress, ".json");
				progress.Tick($"Downloaded to {spec.FolderOnDisk} for branch {branch}");
			}
		}


		private static void DownloadDefinitions(Specification spec, IProgressBar progress, string filenameMatch)
		{
			//TODO move to HttpClient
#pragma warning disable SYSLIB0014
#pragma warning disable CS0618
			var client = new WebClient();
#pragma warning restore CS0618
#pragma warning restore SYSLIB0014
			var html = client.DownloadString(spec.GithubListingUrl);
			if (!Directory.Exists(CodeConfiguration.SpecificationFolder))
				Directory.CreateDirectory(CodeConfiguration.SpecificationFolder);

			var dom = CQ.Create(html);

			WriteToFolder(spec.FolderOnDisk, "root.html", html);

			var endpoints = dom[".js-navigation-open"]
				.Select(s => s.InnerText)
				.Where(s => !string.IsNullOrEmpty(s) && s.EndsWith(filenameMatch))
				.ToList();

			using var subBar = progress.Spawn(endpoints.Count, "fetching individual files", SubProgressBarOptions);
			endpoints.ForEach(s => {
				var rawFile = spec.GithubDownloadUrl(s);
				var fileName = rawFile.Split('/').Last();
				var contents = client.DownloadString(rawFile);
				WriteToFolder(spec.FolderOnDisk, fileName, contents);
				subBar.Tick($"Downloading {fileName}");
			});
		}

		private static void WriteToFolder(string folder, string filename, string contents)
		{
			var f = Path.Combine(CodeConfiguration.SpecificationFolder, folder);
			if (!Directory.Exists(f)) Directory.CreateDirectory(f);
			var path = Path.Combine(f, filename);
			File.WriteAllText(path, contents);
		}

		private class Specification
		{
			// ReSharper disable once UnusedAutoPropertyAccessor.Local
			public string Branch { get; set; }
			public string FolderOnDisk { get; set; }
			public string GithubListingUrl { get; set; }

			public string GithubDownloadUrl(string file) =>
				$"{GithubListingUrl.Replace("github.com", "raw.githubusercontent.com").Replace("tree/", "")}/{file}";
		}
	}
}
