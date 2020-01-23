// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	public class BenchmarkGcInfo
	{
		[DataMember(Name = "force")]
		public bool Force { get; set; }

		[DataMember(Name = "server")]
		public bool Server { get; set; }

		[DataMember(Name = "concurrent")]
		public bool Concurrent { get; set; }

		[DataMember(Name = "retain_vm")]
		public bool RetainVm { get; set; }

		[DataMember(Name = "cpu_groups")]
		public bool CpuGroups { get; set; }

		[DataMember(Name = "heap_count")]
		public int HeapCount { get; set; }

		[DataMember(Name = "no_affinitize")]
		public bool NoAffinitize { get; set; }

		[DataMember(Name = "heap_affinitize")]
		public int HeapAffinitizeMask { get; set; }

		[DataMember(Name = "allow_very_large_objects")]
		public bool AllowVeryLargeObjects { get; set; }
	}
}
