using System.Runtime.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	public class BenchmarkJobConfig
	{
		[DataMember(Name = "platfom")]
		public string Platform { get; set; }

		[DataMember(Name = "runtime")]
		public string RunTime { get; set; }

		[DataMember(Name = "jit")]
		public string Jit { get; set; }

		[DataMember(Name = "gc")]
		public BenchmarkGcInfo Gc { get; set; }

		[DataMember(Name = "id")]
		public string Id { get; set; }

		[DataMember(Name = "launch")]
		public BenchmarkLaunchInformation Launch { get; set; }
	}
}
