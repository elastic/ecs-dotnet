// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elastic.Transport;

namespace Elasticsearch.Extensions.Logging.Options
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
