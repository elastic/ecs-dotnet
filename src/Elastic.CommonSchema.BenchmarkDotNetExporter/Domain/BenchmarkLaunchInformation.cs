// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	public class BenchmarkLaunchInformation
	{
		[JsonPropertyName("run_strategy"), DataMember(Name = "run_strategy")]
		public string RunStrategy { get; set; }

		[JsonPropertyName("launch_count"), DataMember(Name = "launch_count")]
		public int LaunchCount { get; set; }

		[JsonPropertyName("warm_count"), DataMember(Name = "warm_count")]
		public int WarmCount { get; set; }

		[JsonPropertyName("unroll_factor"), DataMember(Name = "unroll_factor")]
		public int UnrollFactor { get; set; }

		[JsonPropertyName("iteration_count"), DataMember(Name = "iteration_count")]
		public int IterationCount { get; set; }

		[JsonPropertyName("invocation_count"), DataMember(Name = "invocation_count")]
		public int InvocationCount { get; set; }

		[JsonPropertyName("max_iteration_count"), DataMember(Name = "max_iteration_count")]
		public int MaxIterationCount { get; set; }

		[JsonPropertyName("min_iteration_count"), DataMember(Name = "min_iteration_count")]
		public int MinIterationCount { get; set; }

		[JsonPropertyName("max_warmup_iteration_count"), DataMember(Name = "max_warmup_iteration_count")]
		public int MaxWarmupIterationCount { get; set; }

		[JsonPropertyName("min_warmup_iteration_count"), DataMember(Name = "min_warmup_iteration_count")]
		public int MinWarmupIterationCount { get; set; }

		[JsonPropertyName("iteration_time_in_ms"), DataMember(Name = "iteration_time_in_ms")]
		public double IterationTimeInMilliseconds { get; set; }
	}
}
