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
