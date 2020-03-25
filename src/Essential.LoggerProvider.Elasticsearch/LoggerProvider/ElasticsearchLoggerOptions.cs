namespace Essential.LoggerProvider
{
    public class ElasticsearchLoggerOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether scopes should be included in the message.
        /// Defaults to <c>false</c>.
        /// </summary>
        public bool IncludeScopes { get; set; }

        /// <summary>
        /// Gets or sets value indicating if logger accepts and queues writes.
        /// </summary>
        public bool IsEnabled { get; set; } = true;        
    }
}
