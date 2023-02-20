// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	/// <summary></summary>
	public class BenchmarkMeasurementStage
	{
		/// <summary></summary>
		[JsonPropertyName("iteration_mode"), DataMember(Name = "iteration_mode")]
		public string IterationMode { get; set; }

		/// <summary></summary>
		[JsonPropertyName("iteration_stage"), DataMember(Name = "iteration_stage")]
		public string IterationStage { get; set; }

		/// <summary></summary>
		[JsonPropertyName("operations"), DataMember(Name = "operations")]
		public long Operations { get; set; }
	}
}
