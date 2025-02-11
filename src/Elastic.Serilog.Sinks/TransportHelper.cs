using System;
using System.Collections.Generic;
using System.Linq;
using Elastic.Transport;
using Elastic.Transport.Products;
using Elastic.Transport.Products.Elasticsearch;

namespace Elastic.Serilog.Sinks
{
	internal static class TransportHelper
	{
		private static readonly ProductRegistration DefaultProduct = ElasticsearchProductRegistration.Default;

		public static TransportConfiguration Default() =>
			new TransportConfiguration(new Uri("http://localhost:9200"), DefaultProduct);

		public static TransportConfigurationDescriptor Static(IEnumerable<string> nodes) => Static(nodes.Select(n => new Uri(n)));

		public static TransportConfigurationDescriptor Static(IEnumerable<Uri> nodes)
		{
			var pool = new StaticNodePool(nodes.Select(e => new Node(e)));
			return new TransportConfigurationDescriptor(pool, productRegistration: DefaultProduct);
		}

		public static TransportConfigurationDescriptor Sniffing(IEnumerable<string> nodes) => Sniffing(nodes.Select(n => new Uri(n)));

		public static TransportConfigurationDescriptor Sniffing(IEnumerable<Uri> nodes)
		{
			var pool = new SniffingNodePool(nodes.Select(e => new Node(e)));
			return new TransportConfigurationDescriptor(pool, productRegistration: DefaultProduct);
		}

		public static TransportConfigurationDescriptor Cloud(string cloudId, string apiKey)
		{
			var header = new ApiKey(apiKey);
			var pool = new CloudNodePool(cloudId, header);
			return new TransportConfigurationDescriptor(pool, productRegistration: DefaultProduct);
		}

		public static TransportConfigurationDescriptor Cloud(string cloudId, string username, string password)
		{
			var header = new BasicAuthentication(username, password);
			var pool = new CloudNodePool(cloudId, header);
			return new TransportConfigurationDescriptor(pool, productRegistration: DefaultProduct);
		}
	}
}
