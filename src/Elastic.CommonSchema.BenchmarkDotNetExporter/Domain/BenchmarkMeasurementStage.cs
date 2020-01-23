// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	public class BenchmarkMeasurementStage
	{
		[DataMember(Name = "iteration_mode")]
		public string IterationMode { get; set; }

		[DataMember(Name = "iteration_stage")]
		public string IterationStage { get; set; }

		[DataMember(Name = "operations")]
		public long Operations { get; set; }
	}
}
