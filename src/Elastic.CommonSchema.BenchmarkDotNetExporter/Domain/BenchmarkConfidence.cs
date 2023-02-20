// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Perfolizer.Mathematics.Common;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	/// <summary></summary>
	public class BenchmarkConfidence
	{
		/// <summary></summary>
		public BenchmarkConfidence() {}
		/// <summary></summary>
		public BenchmarkConfidence(ConfidenceInterval interval)
		{
			Level = interval.Level;
			Lower = interval.Lower;
			Margin = interval.Margin;
			Mean = interval.Mean;
			N = interval.N;
			StandardError = interval.StandardError;
		}

		/// <summary></summary>
		[JsonPropertyName("level"), DataMember(Name = "level")]
		public ConfidenceLevel Level { get; set; }

		/// <summary></summary>
		[JsonPropertyName("lower"), DataMember(Name = "lower")]
		public double Lower { get; set; }

		/// <summary></summary>
		[JsonPropertyName("margin"), DataMember(Name = "margin")]
		public double Margin { get; set; }

		/// <summary></summary>
		[JsonPropertyName("mean"), DataMember(Name = "mean")]
		public double Mean { get; set; }

		/// <summary></summary>
		[JsonPropertyName("n"), DataMember(Name = "n")]
		public int N { get; set; }

		/// <summary></summary>
		[JsonPropertyName("standard_error"), DataMember(Name = "standard_error")]
		public double StandardError { get; set; }
	}
}
