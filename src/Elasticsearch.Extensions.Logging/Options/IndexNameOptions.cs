using System;

namespace Elasticsearch.Extensions.Logging.Options
{
	/// <summary>
	/// Provides options to configure the naming of the index name to write too.
	/// </summary>
	public class IndexNameOptions
	{
		/// <summary>
		/// Gets or sets the format string for the Elastic search index. The current <c>DateTimeOffset</c> is passed as parameter
		/// 0.
		/// </summary>
		public string Format { get; set; } = "dotnet-{0:yyyy.MM.dd}";

		/// <summary>
		/// Gets or sets the offset to use for the index <c>DateTimeOffset</c>. Default value is null, which uses the system local
		/// offset. Use "00:00" for UTC.
		/// </summary>
		public TimeSpan? IndexOffset { get; set; }
	}
}
