using System.Runtime.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	public class BenchmarkLanguage
	{
		[DataMember(Name = "version")]
		public string Version { get; set; }

		[DataMember(Name = "dotnet_sdk_version")]
		public string DotNetSdkVersion { get; set; }

		[DataMember(Name = "has_ryu_jit")]
		public bool HasRyuJit { get; set; }

		[DataMember(Name = "jit_modules")]
		public string JitModules { get; set; }

		[DataMember(Name = "build_configuration")]
		public string BuildConfiguration { get; set; }

		[DataMember(Name = "benchmarkdotnet_version")]
		public string BenchmarkDotNetVersion { get; set; }

		[DataMember(Name = "benchmarkdotnet_version")]
		public string BenchmarkDotNetCaption { get; set; }

		[DataMember(Name = "jit_info")]
		public string JitInfo { get; set; }
	}
}
