// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using Elasticsearch.Net;

namespace Elasticsearch.Extensions.Logging
{
	public class ShipTo
	{
		public IEnumerable<Uri> NodeUris { get; } = new Uri[0];
		public ConnectionPoolType? ConnectionPoolType { get; }
		public string CloudId { get; } = string.Empty;

		public string ApiKey { get; } = string.Empty;

		public string Username { get; } = string.Empty;
		public string Password { get; } = string.Empty;

		public ShipTo() => ConnectionPoolType = Logging.ConnectionPoolType.SingleNode;

		public ShipTo(IEnumerable<Uri> nodeUris, ConnectionPoolType connectionPoolType)
		{
			NodeUris = nodeUris;
			ConnectionPoolType = connectionPoolType;
		}

		public ShipTo(string cloudId, string apiKey)
		{
			if (string.IsNullOrEmpty(cloudId))
				throw new ArgumentException("cloudId may not be null.", nameof(cloudId));

			if (string.IsNullOrEmpty(apiKey))
				throw new ArgumentException("apiKey may not be null.", nameof(apiKey));

			CloudId = cloudId;
			ApiKey = apiKey;
			ConnectionPoolType = Logging.ConnectionPoolType.Cloud;
		}

		public ShipTo(string cloudId, string username, string password)
		{
			if (string.IsNullOrEmpty(cloudId))
				throw new ArgumentException("cloudId may not be null.", nameof(cloudId));

			if (string.IsNullOrEmpty(username))
				throw new ArgumentException("username may not be null.", nameof(username));

			if (string.IsNullOrEmpty(password))
				throw new ArgumentException("password may not be null.", nameof(password));

			CloudId = cloudId;
			Username = username;
			Password = password;

			ConnectionPoolType = Logging.ConnectionPoolType.Cloud;
		}

		internal IConnectionPool? CreateConnectionPool()
		{
			switch (ConnectionPoolType)
			{
				// TODO: Add option to randomize pool
				case Logging.ConnectionPoolType.Unknown:
				case Logging.ConnectionPoolType.Sniffing:
					return new SniffingConnectionPool(NodeUris);
				case Logging.ConnectionPoolType.Static:
					return new StaticConnectionPool(NodeUris);
				case Logging.ConnectionPoolType.Sticky:
					return new StickyConnectionPool(NodeUris);
				// case ConnectionPoolType.StickySniffing:
				case Logging.ConnectionPoolType.Cloud:
					if (!string.IsNullOrEmpty(ApiKey))
					{
						var apiKeyCredentials = new ApiKeyAuthenticationCredentials(ApiKey);
						return new CloudConnectionPool(CloudId, apiKeyCredentials);
					}

					var basicAuthCredentials = new BasicAuthenticationCredentials(Username, Password);
					return new CloudConnectionPool(CloudId, basicAuthCredentials);
				default:
					return null;
			}
		}

		public override int GetHashCode()
		{
			var hashCode = 352033288;

			hashCode = hashCode * -1521134295 + ConnectionPoolType.GetHashCode();
			hashCode = hashCode * -1521134295 + CloudId.GetHashCode();
			hashCode = hashCode * -1521134295 + Username.GetHashCode();
			hashCode = hashCode * -1521134295 + Password.GetHashCode();
			hashCode = hashCode * -1521134295 + NodeUris.GetHashCode();

			return hashCode;
		}
	}

}
