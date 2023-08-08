// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Octokit;
using ShellProgressBar;
using static System.Text.Encoding;

namespace Elastic.CommonSchema.Generator
{
	public static class SpecificationDownloader
	{
		private const string Core = "Core";
		private const string Legacy = "legacy";
		private const string Composable = "composable";
		private const string Components = "component";

		private static readonly ProgressBarOptions MainProgressBarOptions = new()
		{
			BackgroundColor = ConsoleColor.DarkGray, ForegroundColorError = ConsoleColor.Red
		};

		private static readonly Dictionary<string, string> OnlineSpecifications = new()
		{
			{ Core, "generated/ecs" },
			{ Legacy, "generated/elasticsearch/legacy" },
			{ Composable, "generated/elasticsearch/composable" },
			{ Path.Combine(Composable, Components), "generated/elasticsearch/composable/component" }
		};

		private static readonly ProgressBarOptions SubProgressBarOptions = new()
		{
			ForegroundColor = ConsoleColor.Cyan,
			ForegroundColorDone = ConsoleColor.DarkGreen,
			ProgressCharacter = '─',
			BackgroundColor = ConsoleColor.DarkGray
		};

		public static async Task DownloadAsync(string branch, string token)
		{
			var client = new GitHubClient(new ProductHeaderValue("ecs-generator"));
			if (!string.IsNullOrEmpty(token))
				client.Credentials = new Credentials(token);
			using var queryProgress = new ProgressBar(OnlineSpecifications.Count, "Listing remote files", MainProgressBarOptions);

			await WaitRateLimit(client, queryProgress);
			var repo = await client.Repository.Get("elastic", "ecs");
			var specifications = new List<Specification>();
			foreach (var (folder, remotePath) in OnlineSpecifications)
			{
				await WaitRateLimit(client, queryProgress);
				var contents = await client.Repository.Content.GetAllContentsByRef(repo.Id, remotePath, branch);
				var spec = new Specification
				{
					FolderOnDisk = Path.Combine(branch, folder),
					Branch = branch,
					RemoteFiles = contents.Select(c => new RemoteFile(c.Name, c.Path)).ToArray()
				};
				specifications.Add(spec);
			}

			using var progress = new ProgressBar(specifications.Count, "Downloading specifications", MainProgressBarOptions);
			foreach (var spec in specifications)
			{
				progress.Message = $"Downloading to {spec.FolderOnDisk} for branch {branch}";
				await DownloadDefinitionsAsync(spec, client, progress, ".yml", ".json");
				progress.Tick($"Downloaded to {spec.FolderOnDisk} for branch {branch}");
			}
		}


		private static async Task WaitRateLimit(GitHubClient client, ProgressBar progressBar)
		{
			var apiInfo = client.GetLastApiInfo();
			var rateLimit = apiInfo?.RateLimit ?? (await client.RateLimit.GetRateLimits()).Rate;
			if (rateLimit.Remaining > 0) return;
			var options = new ProgressBarOptions
			{
				ForegroundColor = ConsoleColor.Yellow,
				ForegroundColorDone = ConsoleColor.DarkGreen,
				BackgroundColor = ConsoleColor.DarkGray,
				BackgroundCharacter = '\u2593'
			};
			var waitTime = rateLimit.Reset - DateTimeOffset.UtcNow;
			using var indeterminate = progressBar.SpawnIndeterminate($"Github rate limit hit, waiting: {waitTime}", options);
			await Task.Delay(waitTime);
			indeterminate.Finished();
		}


		private static async Task DownloadDefinitionsAsync(Specification spec, GitHubClient client, ProgressBar progress,
			params string[] filenameMatch
		)
		{
			if (!Directory.Exists(CodeConfiguration.SpecificationFolder))
				Directory.CreateDirectory(CodeConfiguration.SpecificationFolder);

			var endpoints = spec.RemoteFiles.Where(r => filenameMatch.Any(m => r.FileName.EndsWith(m))).ToArray();

			if (endpoints.Length == 0)
			{
				progress.WriteErrorLine($"No remote files found to download to: {spec.FolderOnDisk}");
				return;
			}
			using var subBar = progress.Spawn(endpoints.Length, "fetching individual files", SubProgressBarOptions);
			foreach (var endpoint in endpoints)
			{
				await WaitRateLimit(client, progress);
				var bytes = await client.Repository.Content.GetRawContentByRef("elastic", "ecs", endpoint.Path, spec.Branch);
				WriteToFolder(spec.FolderOnDisk, endpoint.FileName, UTF8.GetString(bytes));
				subBar.Tick($"Downloading {endpoint.FileName}");
			}
		}

		private static void WriteToFolder(string folder, string filename, string contents)
		{
			var f = Path.Combine(CodeConfiguration.SpecificationFolder, folder);
			if (!Directory.Exists(f)) Directory.CreateDirectory(f);
			var path = Path.Combine(f, filename);
			File.WriteAllText(path, contents);
		}

		private readonly struct RemoteFile
		{
			public readonly string FileName;
			public readonly string Path;

			public RemoteFile(string fileName, string path)
			{
				FileName = fileName;
				Path = path;
			}
		}

		private class Specification
		{
			// ReSharper disable once UnusedAutoPropertyAccessor.Local
			public string Branch { get; set; }
			public string FolderOnDisk { get; set; }
			public RemoteFile[] RemoteFiles { get; set; }
		}
	}
}
