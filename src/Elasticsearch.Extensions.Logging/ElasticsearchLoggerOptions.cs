using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Elastic.Ingest;

namespace Elasticsearch.Extensions.Logging
{
	public class ElasticsearchLoggerOptions : ElasticsearchChannelOptions<LogEvent>
	{
		public ElasticsearchLoggerOptions()
		{
			WriteEvent = async (stream, ctx, l) => await l.SerializeAsync(stream, ctx).ConfigureAwait(false);
			TimestampLookup = l => l.Timestamp;
		}

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
		/// Gets or sets flag indicating if the logger is enabled. Default is <c>true</c>.
		/// </summary>
		public bool IsEnabled { get; set; } = true;

		/// <summary>
		/// Gets or sets the separate to use for <c>IList</c> semantic values.
		/// </summary>
		public string ListSeparator { get; set; } = ", ";

		/// <summary>
		/// Gets or sets additional tags to pass in the message, for example you can tag with the environment name ('Development',
		/// 'Production', etc).
		/// </summary>
		public string[] Tags { get; set; } = new string[0];
	}
}
