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
			Level = interval.ConfidenceLevel.Value;
			Lower = interval.Lower;
			Margin = interval.Margin;
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

	}
}
