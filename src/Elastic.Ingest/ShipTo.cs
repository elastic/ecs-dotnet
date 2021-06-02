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
		public ShipTo() => ConnectionPool = ConnectionPoolType.SingleNode;

		public ShipTo(ITransport<ITransportConfiguration> client) => Transport = client;

		public ShipTo(IEnumerable<Uri> nodeUris, ConnectionPoolType connectionPoolType)
		{
			NodeUris = nodeUris;
			ConnectionPool = connectionPoolType;
		}

		public ShipTo(string cloudId, string apiKey)
		{
			if (string.IsNullOrEmpty(cloudId))
				throw new ArgumentException("cloudId may not be null or empty.", nameof(cloudId));

			if (string.IsNullOrEmpty(apiKey))
				throw new ArgumentException("apiKey may not be null or empty.", nameof(apiKey));

			CloudId = cloudId;
			ApiKey = apiKey;
			ConnectionPool = ConnectionPoolType.Cloud;
		}

		public ShipTo(string cloudId, string username, string password)
		{
			if (string.IsNullOrEmpty(cloudId))
				throw new ArgumentException("cloudId may not be null or empty.", nameof(cloudId));

			if (string.IsNullOrEmpty(username))
				throw new ArgumentException("username may not be null or empty.", nameof(username));

			if (string.IsNullOrEmpty(password))
				throw new ArgumentException("password may not be null or empty.", nameof(password));

			CloudId = cloudId;
			Username = username;
			Password = password;

			ConnectionPool = ConnectionPoolType.Cloud;
		}

		public string? ApiKey { get; }
		public string? CloudId { get; }
		public ConnectionPoolType? ConnectionPool { get; }
		public IEnumerable<Uri>? NodeUris { get; }
		public string? Password { get; }
		public ITransport<ITransportConfiguration>? Transport { get; set; }
		public string? Username { get; }

		internal IConnectionPool CreateConnectionPool()
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
						var apiKeyCredentials = new ApiKey(ApiKey);
						return new CloudConnectionPool(CloudId, apiKeyCredentials);
					}

					var basicAuthCredentials = new BasicAuthentication(Username, Password);
					return new CloudConnectionPool(CloudId, basicAuthCredentials);
				default:
					throw new ArgumentException($"Unrecognised connection pool type '{ConnectionPool}' specified in the configuration.", nameof(ConnectionPool));
			}
		}
	}
}
