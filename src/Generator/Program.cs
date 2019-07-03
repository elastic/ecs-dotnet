using System;
using System.IO;

namespace Generator
{
    public static class Program
    {
        private const string DownloadBranch = "1.0";

        private static void Main(string[] args)
        {
            var redownloadCoreSpecification = false;
            var downloadBranch = DownloadBranch;

            var answer = "invalid";
            while (answer != "y" && answer != "n" && answer != "")
            {
                Console.Write("Download online specifications? [Y/N] (default N): ");
                answer = Console.ReadLine()?.Trim().ToLowerInvariant();
                redownloadCoreSpecification = answer == "y";
            }

            if (redownloadCoreSpecification)
            {
                Console.Write($"Branch to download specification from (default {downloadBranch}): ");
                var readBranch = Console.ReadLine()?.Trim();
                if (!string.IsNullOrEmpty(readBranch)) downloadBranch = readBranch;
            }
            else
            {
                // read last downloaded branch from file.
                if (File.Exists(CodeConfiguration.LastDownloadedVersionFile))
                    downloadBranch = File.ReadAllText(CodeConfiguration.LastDownloadedVersionFile);
            }

            if (string.IsNullOrEmpty(downloadBranch))
                downloadBranch = DownloadBranch;

            if (redownloadCoreSpecification)
                SpecificationDownloader.Download(downloadBranch);

            FileGenerator.Generate(downloadBranch);
        }
    }
}