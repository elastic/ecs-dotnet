// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	/// <summary></summary>
	public class BenchmarkJobConfig
	{
		/// <summary></summary>
		[JsonPropertyName("platform"), DataMember(Name = "platform")]
		public string Platform { get; set; }

		/// <summary></summary>
		[JsonPropertyName("runtime"), DataMember(Name = "runtime")]
		public string RunTime { get; set; }

		/// <summary></summary>
		[JsonPropertyName("jit"), DataMember(Name = "jit")]
		public string Jit { get; set; }

		/// <summary></summary>
		[JsonPropertyName("gc"), DataMember(Name = "gc")]
		public BenchmarkGcInfo Gc { get; set; }

		/// <summary></summary>
		[JsonPropertyName("id"), DataMember(Name = "id")]
		public string Id { get; set; }

		/// <summary></summary>
		[JsonPropertyName("launch"), DataMember(Name = "launch")]
		public BenchmarkLaunchInformation Launch { get; set; }
	}
}
