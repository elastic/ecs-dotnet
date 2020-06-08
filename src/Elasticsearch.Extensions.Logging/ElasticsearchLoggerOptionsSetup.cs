// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;

namespace Elasticsearch.Extensions.Logging
{
	internal class ElasticsearchLoggerOptionsSetup : ConfigureFromConfigurationOptions<ElasticsearchLoggerOptions>
	{
		public ElasticsearchLoggerOptionsSetup(
			ILoggerProviderConfiguration<ElasticsearchLoggerProvider> providerConfiguration
		)
			: base(providerConfiguration.Configuration) { }
	}
}
