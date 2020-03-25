using System;

namespace Essential.LoggerProvider
{
    public class ElasticsearchLoggerOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether scopes should be included in the message.
        /// Defaults to <c>true</c>.
        /// </summary>
        public bool IncludeScopes { get; set; } = true;

        /// <summary>
        /// Gets or sets value indicating if logger accepts and queues writes.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        public Uri[] NodeUris { get; set; } = new Uri[0];

        public ConnectionPoolType ConnectionPoolType { get; set; }
    }
}
