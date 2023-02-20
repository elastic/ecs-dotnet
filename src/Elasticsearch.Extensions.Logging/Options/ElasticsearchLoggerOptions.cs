using Elastic.CommonSchema;
using Elastic.Ingest.Elasticsearch;
using Elastic.Transport;

namespace Elasticsearch.Extensions.Logging.Options
{
	/// <summary>
	/// Provide options to <see cref="ElasticsearchLogger"/> to control how data gets written to Elasticsearch
	/// </summary>
	public class ElasticsearchLoggerOptions : IEcsDocumentCreationOptions
	{
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
		/// The data stream to log into, defaults to <c>logs-generic-default</c> if neither <see cref="DataStream"/> or <see cref="Index"/> is set.
		/// </summary>
		public DataStreamNameOptions? DataStream { get; set; }

		/// <summary>
		/// Indicates how to bootstrap the target <see cref="DataStream"/> or <see cref="Index"/> automatically.
		/// The default is to do no bootstrapping, assuming the target <see cref="DataStream"/> or <see cref="Index"/> is already properly setup.
		/// </summary>
		public BootstrapMethod BootstrapMethod { get; set; } = BootstrapMethod.None;

		/// <summary>
		/// The index to log into, if this is not set the logger integration will assume it will write into datastreams <see cref="DataStream"/>.
		/// <para>
		/// If both <see cref="Index"/> and <see cref="DataStream"/> are set <see cref="DataStream"/> takes precedence.
		/// </para>
		/// <para>
		/// If neither <see cref="Index"/> and <see cref="DataStream"/> are set a default for <see cref="DataStream"/> will be assumed namely
		/// <c>logs-dotnet-default</c>.
		/// </para>
		/// </summary>
		public IndexNameOptions? Index { get; set; }

		/// <summary>
		/// Gets or sets flag indicating if the logger is enabled. Default is <c>true</c>.
		/// </summary>
		public bool IsEnabled { get; set; } = true;

		/// <summary>
		/// Gets or sets the separate to use for <c>IList</c> semantic values.
		/// </summary>
		public string ListSeparator { get; set; } = ", ";

		/// <summary>
		/// Gets or sets the type of connection and details to use, e.g. pool URIs, cloud API key, etc.
		/// </summary>
		public ShipToOptions ShipTo { get; set; } = new ShipToOptions();

		/// <summary>
		/// Gets or sets additional tags to pass in the message, for example you can tag with the environment name ('Development',
		/// 'Production', etc).
		/// </summary>
		public string[]? Tags { get; set; }

		/// <summary>
		/// Allows the direct setting of a <see cref="HttpTransport{TConfiguration}"/> to be used to communicate with Elasticsearch.
		/// <para>If set takes precedence over <see cref="ShipTo"/> </para>
		/// </summary>
		public HttpTransport? Transport { get; set; }
	}
}
