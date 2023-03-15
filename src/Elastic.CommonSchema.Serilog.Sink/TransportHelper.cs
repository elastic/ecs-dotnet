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
		private static readonly ProductRegistration DefaultProduct = new ElasticsearchProductRegistration();

		public static TransportConfiguration Default() =>
			new TransportConfiguration(new Uri("http://localhost:9200"), DefaultProduct);

		public static TransportConfiguration Static(IEnumerable<string> nodes) => Static(nodes.Select(n => new Uri(n)));

		public static TransportConfiguration Static(IEnumerable<Uri> nodes)
		{
			var pool = new StaticNodePool(nodes.Select(e => new Node(e)));
			return new TransportConfiguration(pool, productRegistration: DefaultProduct);
		}

		public static TransportConfiguration Sniffing(IEnumerable<string> nodes) => Sniffing(nodes.Select(n => new Uri(n)));

		public static TransportConfiguration Sniffing(IEnumerable<Uri> nodes)
		{
			var pool = new SniffingNodePool(nodes.Select(e => new Node(e)));
			return new TransportConfiguration(pool, productRegistration: DefaultProduct);
		}

		public static TransportConfiguration Cloud(string cloudId, string apiKey)
		{
			var header = new ApiKey(apiKey);
			var pool = new CloudNodePool(cloudId, header);
			return new TransportConfiguration(pool, productRegistration: DefaultProduct);
		}

		public static TransportConfiguration Cloud(string cloudId, string username, string password)
		{
			var header = new BasicAuthentication(username, password);
			var pool = new CloudNodePool(cloudId, header);
			return new TransportConfiguration(pool, productRegistration: DefaultProduct);
		}
	}
}
