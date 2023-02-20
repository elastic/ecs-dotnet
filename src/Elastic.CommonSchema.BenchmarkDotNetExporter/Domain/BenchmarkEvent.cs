// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	/// <summary></summary>
	public class BenchmarkEvent : Event
	{
		/// <summary></summary>
		[JsonPropertyName("description"), DataMember(Name = "description")]
		public string Description { get; set; }

		/// <summary></summary>
		[JsonPropertyName("parameters"), DataMember(Name = "parameters")]
		public string Parameters { get; set; }

		/// <summary></summary>
		[JsonPropertyName("method"), DataMember(Name = "method")]
		public string Method { get; set; }

		/// <summary></summary>
		[JsonPropertyName("measurement_stages"), DataMember(Name = "measurement_stages")]
		public IEnumerable<BenchmarkMeasurementStage> MeasurementStages { get; set; }

		/// <summary></summary>
		[JsonPropertyName("repetitions"), DataMember(Name = "repetitions")]
		public BenchmarkSimplifiedWorkloadCounts Repetitions { get; set; }

		/// <summary></summary>
		[JsonPropertyName("job_config"), DataMember(Name = "job_config")]
		public BenchmarkJobConfig JobConfig { get; set; }
	}
}
