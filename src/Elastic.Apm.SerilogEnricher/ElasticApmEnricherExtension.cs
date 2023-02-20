// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using Serilog;
using Serilog.Configuration;

namespace Elastic.Apm.SerilogEnricher
{
	/// <summary> Provides configuration methods to <see cref="LoggerEnrichmentConfiguration"/> </summary>
	public static class ElasticApmEnricherExtension
	{
		/// <summary>
		/// Enrich log events with a trace and transaction id properties containing the
		/// current ids that the Elastic APM .NET Agent generated.
		/// </summary>
		/// <param name="enrichmentConfiguration">Logger enrichment configuration.</param>
		/// <returns>Configuration object allowing method chaining.</returns>
		/// <exception cref="ArgumentNullException">If <paramref name="enrichmentConfiguration" /> is null.</exception>
		public static LoggerConfiguration WithElasticApmCorrelationInfo(this LoggerEnrichmentConfiguration enrichmentConfiguration)
		{
			if (enrichmentConfiguration == null)
				throw new ArgumentNullException(nameof(enrichmentConfiguration));

			return enrichmentConfiguration.With<ElasticApmEnricher>();
		}
	}
}
