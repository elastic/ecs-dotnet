// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	/// <summary></summary>
	public class BenchmarkGcInfo
	{
		/// <summary></summary>
		[JsonPropertyName("force"), DataMember(Name = "force")]
		public bool Force { get; set; }

		/// <summary></summary>
		[JsonPropertyName("server"), DataMember(Name = "server")]
		public bool Server { get; set; }

		/// <summary></summary>
		[JsonPropertyName("concurrent"), DataMember(Name = "concurrent")]
		public bool Concurrent { get; set; }

		/// <summary></summary>
		[JsonPropertyName("retain_vm"), DataMember(Name = "retain_vm")]
		public bool RetainVm { get; set; }

		/// <summary></summary>
		[JsonPropertyName("cpu_groups"), DataMember(Name = "cpu_groups")]
		public bool CpuGroups { get; set; }

		/// <summary></summary>
		[JsonPropertyName("heap_count"), DataMember(Name = "heap_count")]
		public int HeapCount { get; set; }

		/// <summary></summary>
		[JsonPropertyName("no_affinitize"), DataMember(Name = "no_affinitize")]
		public bool NoAffinitize { get; set; }

		/// <summary></summary>
		[JsonPropertyName("heap_affinitize"), DataMember(Name = "heap_affinitize")]
		public int HeapAffinitizeMask { get; set; }

		/// <summary></summary>
		[JsonPropertyName("allow_very_large_objects"), DataMember(Name = "allow_very_large_objects")]
		public bool AllowVeryLargeObjects { get; set; }
	}
}
