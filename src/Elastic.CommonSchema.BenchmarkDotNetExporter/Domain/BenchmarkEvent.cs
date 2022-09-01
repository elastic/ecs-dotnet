// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	public class BenchmarkEvent : Event
	{
		[JsonPropertyName("description"), DataMember(Name = "description")]
		public string Description { get; set; }

		[JsonPropertyName("parameters"), DataMember(Name = "parameters")]
		public string Parameters { get; set; }

		[JsonPropertyName("method"), DataMember(Name = "method")]
		public string Method { get; set; }

		[JsonPropertyName("measurement_stages"), DataMember(Name = "measurement_stages")]
		public IEnumerable<BenchmarkMeasurementStage> MeasurementStages { get; set; }

		[JsonPropertyName("repetitions"), DataMember(Name = "repetitions")]
		public BenchmarkSimplifiedWorkloadCounts Repetitions { get; set; }

		[JsonPropertyName("job_config"), DataMember(Name = "job_config")]
		public BenchmarkJobConfig JobConfig { get; set; }
	}
}
