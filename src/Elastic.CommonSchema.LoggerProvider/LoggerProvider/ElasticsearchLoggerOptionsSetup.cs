using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;

namespace Elastic.CommonSchema
{
    internal class ElasticsearchLoggerOptionsSetup : ConfigureFromConfigurationOptions<ElasticsearchLoggerOptions>
    {
        public ElasticsearchLoggerOptionsSetup(
            ILoggerProviderConfiguration<ElasticsearchLoggerProvider> providerConfiguration)
            : base(providerConfiguration.Configuration)
        {
        }
    }
}
