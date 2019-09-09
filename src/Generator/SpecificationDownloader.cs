using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using CsQuery;
using ShellProgressBar;

namespace Generator
{
    public class SpecificationDownloader
    {
        private const string Core = "Core";

        private static readonly ProgressBarOptions MainProgressBarOptions = new ProgressBarOptions
        {
            BackgroundColor = ConsoleColor.DarkGray
        };

        private static readonly Dictionary<string, string> OnlineSpecifications = new Dictionary<string, string>
        {
            { Core, "https://github.com/elastic/ecs/tree/{version}/schemas" }
        };

        private static readonly ProgressBarOptions SubProgressBarOptions = new ProgressBarOptions
        {
            ForegroundColor = ConsoleColor.Cyan,
            ForegroundColorDone = ConsoleColor.DarkGreen,
            ProgressCharacter = '─',
            BackgroundColor = ConsoleColor.DarkGray
        };

        private SpecificationDownloader(string branch)
        {
            var specifications =
                (from kv in OnlineSpecifications
                    let url = kv.Value.Replace("{version}", branch)
                    select new Specification {FolderOnDisk = Path.Combine(branch, kv.Key), Branch = branch, GithubListingUrl = url}).ToList();

            using (var progress =
                new ProgressBar(specifications.Count, "Downloading specifications", MainProgressBarOptions))
            {
                foreach (var spec in specifications)
                {
                    progress.Message = $"Downloading to {spec.FolderOnDisk} for branch {branch}";
                    DownloadDefinitions(spec, progress, ".yml");
                    progress.Tick($"Downloaded to {spec.FolderOnDisk} for branch {branch}");
                }
            }
        }

        public static void Download(string branch)
        {
            new SpecificationDownloader(branch);
        }

        private static void DownloadDefinitions(Specification spec, IProgressBar progress, string filenameMatch)
        {
            using (var client = new WebClient())
            {
                var html = client.DownloadString(spec.GithubListingUrl);
                FindFilesOnListing(spec, html, progress, filenameMatch);
            }
        }

        private static void FindFilesOnListing(Specification spec, string html, IProgressBar progress, string filenameMatch)
        {
            if (!Directory.Exists(CodeConfiguration.SpecificationFolder))
                Directory.CreateDirectory(CodeConfiguration.SpecificationFolder);

            var dom = CQ.Create(html);

            WriteToFolder(spec.FolderOnDisk, "root.html", html);

            var endpoints = dom[".js-navigation-open"]
                .Select(s => s.InnerText)
                .Where(s => !string.IsNullOrEmpty(s) && s.EndsWith(filenameMatch))
                .ToList();

            using (var subBar = progress.Spawn(endpoints.Count, "fetching individual files", SubProgressBarOptions))
            {
                endpoints.ForEach(s => WriteFile(spec, s, subBar));
            }
        }

        private static void WriteFile(Specification spec, string s, IProgressBar progress)
        {
            var rawFile = spec.GithubDownloadUrl(s);
            using (var client = new WebClient())
            {
                var fileName = rawFile.Split('/').Last();
                var contents = client.DownloadString(rawFile);
                WriteToFolder(spec.FolderOnDisk, fileName, contents);
                progress.Tick($"Downloading {fileName}");
            }
        }

        private static void WriteToFolder(string folder, string filename, string contents)
        {
            var f = Path.Combine(CodeConfiguration.SpecificationFolder, folder);
            if (!Directory.Exists(f)) Directory.CreateDirectory(f);
            File.WriteAllText(f + "\\" + filename, contents);
        }

        private class Specification
        {
            public string Branch { get; set; }
            public string FolderOnDisk { get; set; }
            public string GithubListingUrl { get; set; }

            public string GithubDownloadUrl(string file)
            {
                return $"{GithubListingUrl.Replace("github.com", "raw.githubusercontent.com").Replace("tree/", "")}/{file}";
            }
        }
    }
}