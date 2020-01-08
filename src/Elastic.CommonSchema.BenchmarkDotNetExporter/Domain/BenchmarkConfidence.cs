using System.Runtime.Serialization;
using BenchmarkDotNet.Mathematics;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	public class BenchmarkConfidence
	{
		public BenchmarkConfidence(ConfidenceInterval interval)
		{
			Level = interval.Level;
			Lower = interval.Lower;
			Margin = interval.Margin;
			Mean = interval.Mean;
			N = interval.N;
			StandardError = interval.StandardError;
		}

		[DataMember(Name = "level")]
		public ConfidenceLevel Level { get; set; }

		[DataMember(Name = "lower")]
		public double Lower { get; set; }

		[DataMember(Name = "margin")]
		public double Margin { get; set; }

		[DataMember(Name = "mean")]
		public double Mean { get; set; }

		[DataMember(Name = "n")]
		public int N { get; set; }

		[DataMember(Name = "standard_error")]
		public double StandardError { get; set; }
	}
}
