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
		private static ProductRegistration DefaultProduct = new ElasticsearchProductRegistration();
		public static HttpTransport Default() =>
			new DefaultHttpTransport(new TransportConfiguration(new Uri("http://localhost:9200"), DefaultProduct));

		public static HttpTransport Static(IEnumerable<string> nodes)
		{
			var pool = new StaticNodePool(nodes.Select(e => new Node(new Uri(e))));
			return new DefaultHttpTransport(new TransportConfiguration(pool, productRegistration: DefaultProduct));
		}
		public static HttpTransport Sniffing(IEnumerable<string> nodes)
		{
			var pool = new SniffingNodePool(nodes.Select(e => new Node(new Uri(e))));
			return new DefaultHttpTransport(new TransportConfiguration(pool, productRegistration: DefaultProduct));
		}

		public static HttpTransport Cloud(string endpoint, string apiKey)
		{
			var header = new ApiKey(apiKey);
			var pool = new CloudNodePool(endpoint, header);
			return new DefaultHttpTransport(new TransportConfiguration(pool, productRegistration: DefaultProduct));
		}

		public static HttpTransport Cloud(string endpoint, string username, string password)
		{
			var header = new BasicAuthentication(username, password);
			var pool = new CloudNodePool(endpoint, header);
			return new DefaultHttpTransport(new TransportConfiguration(pool, productRegistration: DefaultProduct));
		}

	}
}
