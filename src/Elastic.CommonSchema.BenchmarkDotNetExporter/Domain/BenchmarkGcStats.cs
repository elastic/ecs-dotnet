// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Running;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	/// <summary></summary>
	public class BenchmarkGcStats
	{
		/// <summary></summary>
		public BenchmarkGcStats() {}
		/// <summary></summary>
		public BenchmarkGcStats(GcStats statistics, BenchmarkCase benchmarkCase)
		{
			Gen0Collections = statistics.Gen0Collections;
			Gen1Collections = statistics.Gen1Collections;
			Gen2Collections = statistics.Gen2Collections;
			TotalOperations = statistics.TotalOperations;
			BytesAllocatedPerOperation = statistics.GetBytesAllocatedPerOperation(benchmarkCase);
		}

		/// <summary></summary>
		[JsonPropertyName("bytes_allocated_per_operation"), DataMember(Name = "bytes_allocated_per_operation")]
		public long BytesAllocatedPerOperation { get; set; }

		/// <summary></summary>
		[JsonPropertyName("total_operations"), DataMember(Name = "total_operations")]
		public long TotalOperations { get; set; }

		/// <summary></summary>
		[JsonPropertyName("gen2_collections"), DataMember(Name = "gen2_collections")]
		public int Gen2Collections { get; set; }

		/// <summary></summary>
		[JsonPropertyName("gen1_collections"), DataMember(Name = "gen1_collections")]
		public int Gen1Collections { get; set; }

		/// <summary></summary>
		[JsonPropertyName("gen0_collections"), DataMember(Name = "gen0_collections")]
		public int Gen0Collections { get; set; }
	}
}
