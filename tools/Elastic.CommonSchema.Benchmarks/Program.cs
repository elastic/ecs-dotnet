using System;
using AutoBogus;
using BenchmarkDotNet.Running;

namespace Elastic.CommonSchema.Benchmarks
{
	internal class Program
	{
		public static void Main(string[] args)
		{
			var x = new AutoFaker<EcsDocument>()
				.RuleFor(d => d.Metadata, d => new MetadataDictionary { { "x", "y" } })
				.UseSeed(1337)
				.Generate();
			BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
		}
	}
}
