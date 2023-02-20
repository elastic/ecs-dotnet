// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Elastic.CommonSchema.Serialization;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter.Domain
{
	/// <summary>
	/// Represents a benchmark case with information of the overall benchmark run.
	/// </summary>
	[JsonConverter(typeof(EcsDocumentJsonConverterFactory))]
	public class BenchmarkDocument : EcsDocument
	{
		/// <summary></summary>
		[JsonPropertyName("benchmark"), DataMember(Name = "benchmark")]
		public BenchmarkData Benchmark { get; set; }

		/// <inheritdoc cref="EcsDocument.TryRead"/>
		protected override bool TryRead(string propertyName, out Type type)
		{
			type = propertyName switch
			{
				"benchmark" => typeof(BenchmarkData),
				_ => null
			};
			return type != null;
		}

		/// <inheritdoc cref="EcsDocument.ReceiveProperty"/>
		protected override bool ReceiveProperty(string propertyName, object value) =>
			propertyName switch
			{
				"benchmark" => null != (Benchmark = value as BenchmarkData),
				_ => false
			};

		/// <inheritdoc cref="EcsDocument.WriteAdditionalProperties"/>
		protected override void WriteAdditionalProperties(Action<string, object> write) => write("benchmark", Benchmark);
	}
}
