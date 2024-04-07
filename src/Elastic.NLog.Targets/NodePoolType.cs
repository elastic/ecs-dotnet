using Elastic.Transport;

namespace NLog.Targets
{
	/// <summary>
	/// The type of connection pool to use
	/// </summary>
	public enum NodePoolType
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
