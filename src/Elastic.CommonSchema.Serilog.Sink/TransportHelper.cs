using System;
using System.Collections.Generic;
using System.Linq;
using Elastic.Transport;
using Elastic.Transport.Products;
using Elastic.Transport.Products.Elasticsearch;

namespace Elastic.CommonSchema.Serilog.Sink
{
	internal static class TransportHelper
	{
		private static IProductRegistration DefaultProduct = new ElasticsearchProductRegistration();
		public static ITransport Default() =>
			new Transport.Transport(new TransportConfiguration(new Uri("http://localhost:9200"), DefaultProduct));

		public static ITransport Static(IEnumerable<string> nodes)
		{
			var pool = new StaticNodePool(nodes.Select(e => new Node(new Uri(e))));
			return new Transport.Transport(new TransportConfiguration(pool, productRegistration: DefaultProduct));
		}
		public static ITransport Sniffing(IEnumerable<string> nodes)
		{
			var pool = new SniffingNodePool(nodes.Select(e => new Node(new Uri(e))));
			return new Transport.Transport(new TransportConfiguration(pool, productRegistration: DefaultProduct));
		}

		public static ITransport Cloud(string endpoint, string apiKey)
		{
			var header = new ApiKey(apiKey);
			var pool = new CloudNodePool(endpoint, header);
			return new Transport.Transport(new TransportConfiguration(pool, productRegistration: DefaultProduct));
		}

		public static ITransport Cloud(string endpoint, string username, string password)
		{
			var header = new BasicAuthentication(username, password);
			var pool = new CloudNodePool(endpoint, header);
			return new Transport.Transport(new TransportConfiguration(pool, productRegistration: DefaultProduct));
		}

	}
}
