// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;
using BenchmarkDotNet.Engines;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	public class BenchmarkGcStats
	{
		public BenchmarkGcStats(GcStats statistics)
		{
			Gen0Collections = statistics.Gen0Collections;
			Gen1Collections = statistics.Gen1Collections;
			Gen2Collections = statistics.Gen2Collections;
			TotalOperations = statistics.TotalOperations;
			BytesAllocatedPerOperation = statistics.BytesAllocatedPerOperation;
		}

		[DataMember(Name = "bytes_allocated_per_operation")]
		public long BytesAllocatedPerOperation { get; set; }

		[DataMember(Name = "total_operations")]
		public long TotalOperations { get; set; }

		[DataMember(Name = "gen2_collections")]
		public int Gen2Collections { get; set; }

		[DataMember(Name = "gen1_collections")]
		public int Gen1Collections { get; set; }

		[DataMember(Name = "gen0_collections")]
		public int Gen0Collections { get; set; }
	}
}
