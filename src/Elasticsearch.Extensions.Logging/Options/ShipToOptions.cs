// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;

namespace Elasticsearch.Extensions.Logging.Options
{
	/// <summary>
	/// Configures where to write Elasticsearch logs to
	/// </summary>
	public class ShipToOptions
	{
		/// <summary>
		/// Gets or sets the API Key, where connection pool type is Cloud, and authenticating via API Key.
		/// </summary>
		public string ApiKey { get; set; } = "";

		/// <summary>
		/// Gets or sets the cloud ID, where connection pool type is Cloud.
		/// </summary>
		public string CloudId { get; set; } = "";

		/// <summary>
		/// Gets or sets the connection pool type. Default for multiple nodes is <c>Sniffing</c>; other supported values are
		/// <c>Static</c>, <c>Sticky</c>, or force to <c>SingleNode</c>.
		/// </summary>
		public NodePoolType NodePoolType { get; set; }

		/// <summary>
		/// Gets or sets the URIs of the Elasticsearch nodes in the connection pool. If not specified the default single node
		/// "http://localhost:9200" is used.
		/// </summary>
		public Uri[]? NodeUris { get; set; }

		/// <summary>
		/// Gets or sets the password, where connection pool type is Cloud, and authenticating via username/password.
		/// </summary>
		public string Password { get; set; } = "";

		/// <summary>
		/// Gets or sets the username, where connection pool type is Cloud, and authenticating via username/password.
		/// </summary>
		public string Username { get; set; } = "";
	}
}
