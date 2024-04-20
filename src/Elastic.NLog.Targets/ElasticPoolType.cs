using Elastic.Transport;

namespace NLog.Targets
{
	/// <summary>
	/// The type of connection pool for Elasticsearch
	/// </summary>
	public enum ElasticPoolType
	{
		/// <summary> Not configured </summary>
		Unknown = 0,
		/// <inheritdoc cref="SingleNodePool"/>
		SingleNode,
		/// <inheritdoc cref="SniffingNodePool"/>
		Sniffing,
		/// <inheritdoc cref="StaticNodePool"/>
		Static,
		/// <inheritdoc cref="StickyNodePool"/>
		Sticky,
		/// <inheritdoc cref="StickySniffingNodePool"/>
		StickySniffing,
		/// <inheritdoc cref="CloudNodePool"/>
		Cloud
	}
}
