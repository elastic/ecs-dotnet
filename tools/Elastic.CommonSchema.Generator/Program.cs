using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Elastic.CommonSchema.Generator.Projection;
using Elastic.CommonSchema.Generator.Schema;

namespace Elastic.CommonSchema.Generator;

public static class Program
{
	private const string DefaultDownloadBranch = "v9.3.0";

	// Usage:
	//   dotnet run                          — interactive mode (prompts for download/tag)
	//   dotnet run -- --no-download         — skip download, use cached spec, default tag
	//   dotnet run -- --download            — download spec, default tag
	//   dotnet run -- --download --tag v9.3.0 — download spec with specific tag
	//   dotnet run -- --no-download --tag v9.3.0 — skip download, specific tag
	//   dotnet run -- --token <gh-token>    — pass GitHub token for download
	// ReSharper disable once UnusedParameter.Local
	private static async Task Main(string[] args)
	{
		Console.WriteLine($"Running from: {Directory.GetCurrentDirectory()}");
		Console.WriteLine($"Resolved codebase root to: {CodeConfiguration.Root}");
		Console.WriteLine();

		var token = string.Empty;
		var redownloadCoreSpecification = (bool?)null;
		var downloadBranch = DefaultDownloadBranch;

		// Parse CLI args
		for (var i = 0; i < args.Length; i++)
		{
			switch (args[i])
			{
				case "--no-download":
					redownloadCoreSpecification = false;
					break;
				case "--download":
					redownloadCoreSpecification = true;
					break;
				case "--tag" when i + 1 < args.Length:
					downloadBranch = args[++i];
					break;
				case "--token" when i + 1 < args.Length:
					token = args[++i];
					break;
				default:
					// Legacy: first positional arg is token
					if (!args[i].StartsWith("--") && string.IsNullOrEmpty(token))
						token = args[i];
					break;
			}
		}

		// Interactive prompts only if not specified via CLI
		if (redownloadCoreSpecification == null)
		{
			var answer = "invalid";
			while (answer != "y" && answer != "n" && answer != "")
			{
				Console.Write("Download online specifications? [Y/N] (default N): ");
				answer = Console.ReadLine()?.Trim().ToLowerInvariant();
				redownloadCoreSpecification = answer == "y";
			}

			Console.Write($"Tag to use (default {downloadBranch}): ");
			var readBranch = Console.ReadLine()?.Trim();
			if (!string.IsNullOrEmpty(readBranch)) downloadBranch = readBranch;
		}

		if (string.IsNullOrEmpty(downloadBranch))
			downloadBranch = DefaultDownloadBranch;

		if (redownloadCoreSpecification == true)
			await SpecificationDownloader.DownloadAsync(downloadBranch, token);

		var ecsSchema = new EcsSchemaParser(downloadBranch).Parse();
		WarnAboutSchemaValidations(ecsSchema);

		var projection = new TypeProjector(ecsSchema).CreateProjection();
		WarnAboutProjectionValidations(projection);

		FileGenerator.Generate(projection);
	}

	private static void WarnAboutSchemaValidations(EcsSchema ecsSchema)
	{
		if (ecsSchema.Warnings.Count > 0)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Validation errors in YAML");
			foreach (var warning in ecsSchema.Warnings.Distinct().OrderBy(w => w))
				Console.WriteLine(warning);
			Console.ResetColor();
			return;
		}
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("No validation errors in YAML");
		Console.ResetColor();
	}

	private static void WarnAboutProjectionValidations(CommonSchemaTypesProjection projection)
	{
		if (projection.Warnings.Count > 0)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Validation errors in Canonical Model");
			foreach (var warning in projection.Warnings.Distinct().OrderBy(w => w))
				Console.WriteLine(warning);
			Console.ResetColor();
			return;
		}
		Console.ForegroundColor = ConsoleColor.Green;
		Console.WriteLine("No validation errors in the Canonical Model");
		Console.ResetColor();
	}
}
