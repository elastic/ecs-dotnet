// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Diagnostics.CodeAnalysis;
using Elastic.Extensions.Logging.Options;
using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;

namespace Elastic.Extensions.Logging;

[UnconditionalSuppressMessage("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode", Justification = "We always provide a static JsonTypeInfoResolver")]
[UnconditionalSuppressMessage("AotAnalysis", "IL3050:RequiresDynamicCode", Justification = "We always provide a static JsonTypeInfoResolver")]
internal class ElasticsearchLoggerOptionsSetup(ILoggerProviderConfiguration<ElasticsearchLoggerProvider> providerConfiguration)
	: ConfigureFromConfigurationOptions<ElasticsearchLoggerOptions>(providerConfiguration.Configuration);
