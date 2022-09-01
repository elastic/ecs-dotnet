// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	public class BenchmarkGcInfo
	{
		[JsonPropertyName("force"), DataMember(Name = "force")]
		public bool Force { get; set; }

		[JsonPropertyName("server"), DataMember(Name = "server")]
		public bool Server { get; set; }

		[JsonPropertyName("concurrent"), DataMember(Name = "concurrent")]
		public bool Concurrent { get; set; }

		[JsonPropertyName("retain_vm"), DataMember(Name = "retain_vm")]
		public bool RetainVm { get; set; }

		[JsonPropertyName("cpu_groups"), DataMember(Name = "cpu_groups")]
		public bool CpuGroups { get; set; }

		[JsonPropertyName("heap_count"), DataMember(Name = "heap_count")]
		public int HeapCount { get; set; }

		[JsonPropertyName("no_affinitize"), DataMember(Name = "no_affinitize")]
		public bool NoAffinitize { get; set; }

		[JsonPropertyName("heap_affinitize"), DataMember(Name = "heap_affinitize")]
		public int HeapAffinitizeMask { get; set; }

		[JsonPropertyName("allow_very_large_objects"), DataMember(Name = "allow_very_large_objects")]
		public bool AllowVeryLargeObjects { get; set; }
	}
}
