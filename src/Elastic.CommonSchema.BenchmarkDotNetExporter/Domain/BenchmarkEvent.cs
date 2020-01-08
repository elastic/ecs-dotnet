using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	public class BenchmarkEvent : Event
	{
		[DataMember(Name = "description")]
		public string Description { get; set; }

		[DataMember(Name = "parameters")]
		public string Parameters { get; set; }

		[DataMember(Name = "method")]
		public string Method { get; set; }

		[DataMember(Name = "measurement_stages")]
		public IEnumerable<BenchmarkMeasurementStage> MeasurementStages { get; set; }

		[DataMember(Name = "repetitions")]
		public BenchmarkSimplifiedWorkloadCounts Repetitions { get; set; }

		[DataMember(Name = "job_config")]
		public BenchmarkJobConfig JobConfig { get; set; }
	}
}
