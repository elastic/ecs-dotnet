// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	public class BenchmarkLaunchInformation
	{
		[DataMember(Name = "run_strategy")]
		public string RunStrategy { get; set; }

		[DataMember(Name = "launch_count")]
		public int LaunchCount { get; set; }

		[DataMember(Name = "warm_count")]
		public int WarmCount { get; set; }

		[DataMember(Name = "unroll_factor")]
		public int UnrollFactor { get; set; }

		[DataMember(Name = "iteration_count")]
		public int IterationCount { get; set; }

		[DataMember(Name = "invocation_count")]
		public int InvocationCount { get; set; }

		[DataMember(Name = "max_iteration_count")]
		public int MaxIterationCount { get; set; }

		[DataMember(Name = "min_iteration_count")]
		public int MinIterationCount { get; set; }

		[DataMember(Name = "max_warmup_iteration_count")]
		public int MaxWarmupIterationCount { get; set; }

		[DataMember(Name = "min_warmup_iteration_count")]
		public int MinWarmupIterationCount { get; set; }

		[DataMember(Name = "iteration_time_in_ms")]
		public double IterationTimeInMilliseconds { get; set; }
	}
}
