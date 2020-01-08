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
