// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elastic.Extensions.Logging.Options;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;

namespace Elastic.Extensions.Logging;

internal class ElasticsearchLoggerOptionsSetup(ILoggerProviderConfiguration<ElasticsearchLoggerProvider> providerConfiguration)
	: ConfigureFromConfigurationOptions<ElasticsearchLoggerOptions>(providerConfiguration.Configuration);
