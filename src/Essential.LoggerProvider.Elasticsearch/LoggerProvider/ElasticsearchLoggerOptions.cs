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

        public bool IncludeHost { get; set; } = true;

        public bool IncludeProcess { get; set; } = true;

        public bool IncludeUser { get; set; } = true;

        public string Index { get; set; } = "dotnet-{0:yyyy.MM.dd}";
        
        /// <summary>
        /// Gets or sets value indicating if logger accepts and queues writes.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        public Uri[] NodeUris { get; set; } = new Uri[0];

        public ConnectionPoolType ConnectionPoolType { get; set; }

        public string[] Tags { get; set; } = new string[0];
    }
}
