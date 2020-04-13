using System;

namespace Essential.LoggerProvider
{
    public class ElasticsearchLoggerOptions
    {
        /// <summary>
        /// Gets or sets the connection pool type. Default for multiple nodes is <c>Sniffing</c>; other supported values are <c>Static</c>, <c>Sticky</c>, or force to <c>SingleNode</c>.
        /// </summary>
        public ConnectionPoolType ConnectionPoolType { get; set; }

        /// <summary>
        /// Gets or sets a flag indicating whether host details should be included in the message. Defaults to <c>true</c>.
        /// </summary>
        public bool IncludeHost { get; set; } = true;

        /// <summary>
        /// Gets or sets a flag indicating whether process details should be included in the message. Defaults to <c>true</c>.
        /// </summary>
        public bool IncludeProcess { get; set; } = true;

        /// <summary>
        /// Gets or sets a flag indicating whether scopes should be included in the message. Defaults to <c>true</c>.
        /// </summary>
        public bool IncludeScopes { get; set; } = true;

        /// <summary>
        /// Gets or sets a flag indicating whether user details should be included in the message. Defaults to <c>true</c>.
        /// </summary>
        public bool IncludeUser { get; set; } = true;

        /// <summary>
        /// Gets or sets the format string for the Elastic search index. The current <c>DateTimeOffset</c> is passed as parameter 0.
        /// </summary>
        public string Index { get; set; } = "dotnet-{0:yyyy.MM.dd}";

        /// <summary>
        /// Gets or sets the offset to use for the index <c>DateTimeOffset</c>. Default value is null, which uses the system local offset. Use "00:00" for UTC.
        /// </summary>
        public TimeSpan? IndexOffset { get; set; }

        /// <summary>
        /// Gets or sets flag indicating if the logger is enabled. Default is <c>true</c>.
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Gets or sets the separate to use for <c>IList</c> semantic values.
        /// </summary>
        public string ListSeparator { get; set; } = ", ";

        /// <summary>
        /// Gets or sets a flag indicating whether well known correlation keys (in scope and message) should be mapped to ECS fields. Defaults to <c>true</c>.
        /// </summary>
        public bool MapCorrelationValues { get; set; } = true;

        /// <summary>
        /// Gets or sets the URIs of the Elasticsearch nodes in the connection pool. If not specified the default single node "http://localhost:9200" is used.
        /// </summary>
        public Uri[] NodeUris { get; set; } = new Uri[0];

        /// <summary>
        /// Gets or sets additional tags to pass in the message, for example you can tag with the environment name ('Development', 'Production', etc).
        /// </summary>
        public string[] Tags { get; set; } = new string[0];
    }
}
