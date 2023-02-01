// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using BenchmarkDotNet.Mathematics;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	public class BenchmarkData
	{
		[JsonConstructor]
		public BenchmarkData() {}
		public BenchmarkData(Statistics statistics)
		{
			N = statistics.N;
			Min = statistics.Min;
			LowerFence = statistics.LowerFence;
			Q1 = statistics.Q1;
			Median = statistics.Median;
			Mean = statistics.Mean;
			Q3 = statistics.Q3;
			UpperFence = statistics.UpperFence;
			Max = statistics.Max;
			InterquartileRange = statistics.InterquartileRange;
			LowerOutliers = statistics.LowerOutliers;
			UpperOutliers = statistics.UpperOutliers;
			AllOutliers = statistics.AllOutliers;
			StandardError = statistics.StandardError;
			Variance = statistics.Variance;
			StandardDeviation = statistics.StandardDeviation;
			Skewness = statistics.Skewness;
			Kurtosis = statistics.Kurtosis;
			ConfidenceInterval = new BenchmarkConfidence(statistics.ConfidenceInterval);
			Percentiles = statistics.Percentiles;
		}

		[JsonPropertyName("all_outliers"), DataMember(Name = "all_outliers"), JsonInclude]
		public double[] AllOutliers { get; internal set; }

		[JsonPropertyName("confidence_interval"), DataMember(Name = "confidence_interval"), JsonInclude]
		public BenchmarkConfidence ConfidenceInterval { get; internal set; }

		[JsonPropertyName("interquartile_range"), DataMember(Name = "interquartile_range"), JsonInclude]
		public double InterquartileRange { get; internal set; }

		[JsonPropertyName("kurtosis"), DataMember(Name = "kurtosis"), JsonInclude]
		public double Kurtosis { get; internal set; }

		[JsonPropertyName("lower_fence"), DataMember(Name = "lower_fence"), JsonInclude]
		public double LowerFence { get; internal set; }

		[JsonPropertyName("lower_outliers"), DataMember(Name = "lower_outliers"), JsonInclude]
		public double[] LowerOutliers { get; internal set; }

		[JsonPropertyName("max"), DataMember(Name = "max"), JsonInclude]
		public double Max { get; internal set; }

		[JsonPropertyName("mean"), DataMember(Name = "mean"), JsonInclude]
		public double Mean { get; internal set; }

		[JsonPropertyName("median"), DataMember(Name = "median"), JsonInclude]
		public double Median { get; internal set; }

		[JsonPropertyName("memory"), DataMember(Name = "memory"), JsonInclude]
		public BenchmarkGcStats Memory { get; internal set; }

		[JsonPropertyName("min"), DataMember(Name = "min"), JsonInclude]
		public double Min { get; internal set; }

		[JsonPropertyName("n"), DataMember(Name = "n"), JsonInclude]
		public int N { get; internal set; }

		[JsonPropertyName("percentiles"), DataMember(Name = "percentiles"), JsonInclude]
		public PercentileValues Percentiles { get; internal set; }

		[JsonPropertyName("q1"), DataMember(Name = "q1"), JsonInclude]
		public double Q1 { get; internal set; }

		[JsonPropertyName("q3"), DataMember(Name = "q3"), JsonInclude]
		public double Q3 { get; internal set; }

		[JsonPropertyName("skewness"), DataMember(Name = "skewness"), JsonInclude]
		public double Skewness { get; internal set; }

		[JsonPropertyName("standard_deviation"), DataMember(Name = "standard_deviation"), JsonInclude]
		public double StandardDeviation { get; internal set; }

		[JsonPropertyName("standard_error"), DataMember(Name = "standard_error"), JsonInclude]
		public double StandardError { get; internal set; }

		[JsonPropertyName("upper_fence"), DataMember(Name = "upper_fence"), JsonInclude]
		public double UpperFence { get; internal set; }

		[JsonPropertyName("upper_outliers"), DataMember(Name = "upper_outliers"), JsonInclude]
		public double[] UpperOutliers { get; internal set; }

		[JsonPropertyName("variance"), DataMember(Name = "variance"), JsonInclude]
		public double Variance { get; internal set; }
	}
}
