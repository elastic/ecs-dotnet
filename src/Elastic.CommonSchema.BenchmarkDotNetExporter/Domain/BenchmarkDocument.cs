using System;
using System.Runtime.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	/// <summary> Represents a benchmark case with information of the overall benchmark run as well. </summary>
	public class BenchmarkDocument : Base
	{
		[DataMember(Name = "benchmark")]
		public BenchmarkData Benchmark { get; set; }

		protected override bool TryRead(string propertyName, out Type type)
		{
			type = propertyName switch
			{
				"benchmark" => typeof(BenchmarkData),
				_ => null
			};
			return type != null;
		}

		protected override bool ReceiveProperty(string propertyName, object value) =>
			propertyName switch
			{
				"benchmark" => null != (Benchmark = value as BenchmarkData),
				_ => false
			};

		protected override void WriteAdditionalProperties(Action<string, object> write) => write("benchmark", Benchmark);
	}
}
