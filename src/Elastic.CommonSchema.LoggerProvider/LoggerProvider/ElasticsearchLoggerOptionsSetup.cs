using Microsoft.Extensions.Logging.Configuration;
using Microsoft.Extensions.Options;

namespace Essential.LoggerProvider
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
