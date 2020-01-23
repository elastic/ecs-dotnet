// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	public class BenchmarkSimplifiedWorkloadCounts
	{
		[DataMember(Name = "warmup")]
		public long Warmup { get; set; }

		[DataMember(Name = "measured")]
		public long Measured { get; set; }
	}
}
