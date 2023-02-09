using System;
using System.Linq;
using Elastic.CommonSchema.Generator.Projection;
using Elastic.CommonSchema.Generator.Schema;

namespace Elastic.CommonSchema.Generator
{
	public static class Program
	{
		private const string DefaultDownloadBranch = "v8.4.0";

		// ReSharper disable once UnusedParameter.Local
		private static void Main(string[] args)
		{
			var redownloadCoreSpecification = true;
			var downloadBranch = DefaultDownloadBranch;

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

			if (string.IsNullOrEmpty(downloadBranch))
				downloadBranch = DefaultDownloadBranch;

			if (redownloadCoreSpecification)
				SpecificationDownloader.Download(downloadBranch);


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
}
