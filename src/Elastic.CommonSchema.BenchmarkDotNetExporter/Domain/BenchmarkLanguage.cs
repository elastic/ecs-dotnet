// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	/// <summary></summary>
	public class BenchmarkLanguage
	{
		/// <summary></summary>
		[JsonPropertyName("version"), DataMember(Name = "version")]
		public string Version { get; set; }

		/// <summary></summary>
		[JsonPropertyName("dotnet_sdk_version"), DataMember(Name = "dotnet_sdk_version")]
		public string DotNetSdkVersion { get; set; }

		/// <summary></summary>
		[JsonPropertyName("has_ryu_jit"), DataMember(Name = "has_ryu_jit")]
		public bool HasRyuJit { get; set; }

		/// <summary></summary>
		[JsonPropertyName("jit_modules"), DataMember(Name = "jit_modules")]
		public string JitModules { get; set; }

		/// <summary></summary>
		[JsonPropertyName("build_configuration"), DataMember(Name = "build_configuration")]
		public string BuildConfiguration { get; set; }

		/// <summary></summary>
		[JsonPropertyName("benchmarkdotnet_version"), DataMember(Name = "benchmarkdotnet_version")]
		public string BenchmarkDotNetVersion { get; set; }

		/// <summary></summary>
		[JsonPropertyName("benchmarkdotnet_caption"), DataMember(Name = "benchmarkdotnet_caption")]
		public string BenchmarkDotNetCaption { get; set; }

		/// <summary></summary>
		[JsonPropertyName("jit_info"), DataMember(Name = "jit_info")]
		public string JitInfo { get; set; }
	}
}
