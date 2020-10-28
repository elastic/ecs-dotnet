// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using Elastic.Transport;

namespace Elastic.Ingest
{
	public class ShipTo
	{
		public IEnumerable<Uri>? NodeUris { get; }
		public ConnectionPoolType? ConnectionPool{ get; }
		public string? CloudId { get; }

		public string? ApiKey { get; }

		public string? Username { get; }
		public string? Password { get; }

		public ITransport<ITransportConfigurationValues>? Transport { get; set; }

		public ShipTo() => ConnectionPool = ConnectionPoolType.SingleNode;

		public ShipTo(ITransport<ITransportConfigurationValues> client) => Transport = client;

		public ShipTo(IEnumerable<Uri> nodeUris, ConnectionPoolType connectionPoolType)
		{
			NodeUris = nodeUris;
			ConnectionPool = connectionPoolType;
		}

		public ShipTo(string cloudId, string apiKey)
		{
			if (string.IsNullOrEmpty(cloudId))
				throw new ArgumentException("cloudId may not be null.", nameof(cloudId));

			if (string.IsNullOrEmpty(apiKey))
				throw new ArgumentException("apiKey may not be null.", nameof(apiKey));

			CloudId = cloudId;
			ApiKey = apiKey;
			ConnectionPool = ConnectionPoolType.Cloud;
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

			ConnectionPool = ConnectionPoolType.Cloud;
		}

		internal IConnectionPool? CreateConnectionPool()
		{
			switch (ConnectionPool)
			{
				// TODO: Add option to randomize pool
				case ConnectionPoolType.Unknown:
				case ConnectionPoolType.Sniffing:
					return new SniffingConnectionPool(NodeUris);
				case ConnectionPoolType.Static:
					return new StaticConnectionPool(NodeUris);
				case ConnectionPoolType.Sticky:
					return new StickyConnectionPool(NodeUris);
				// case ConnectionPoolType.StickySniffing:
				case ConnectionPoolType.Cloud:
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
	}

}
