// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Linq;
using Elastic.CommonSchema.BenchmarkDotNetExporter.Domain;
using Elastic.Ingest.Elasticsearch;
using Elastic.Ingest.Elasticsearch.DataStreams;
using Elastic.Transport;
using Elastic.Transport.Products.Elasticsearch;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter
{
	/// <summary>
	/// Configure the Elasticsearch BenchmarkDotNet exporter.
	/// </summary>
	public class ElasticsearchBenchmarkExporterOptions
	{
		/// <summary>
		/// Configure the exporter options, the <paramref name="commaSeparatedListOfUrls" /> parameter is required.
		/// <para>The other options can be specified in the property initializer</para>
		/// </summary>
		/// <param name="commaSeparatedListOfUrls">
		/// A list of comma separated Elasticsearch nodes of the cluster you want to report into.
		/// <para>You need to specify at least one node, if you enable sniffing the exporter will find the rest of the nodes</para>
		/// </param>
		/// <exception cref="ArgumentException">If none of the urls specified parse into a <see cref="Uri"/></exception>
		public ElasticsearchBenchmarkExporterOptions(string commaSeparatedListOfUrls) : this(Parse(commaSeparatedListOfUrls)) { }

		/// <summary>
		/// Configure the exporter options, the <paramref name="nodes"/> parameter is required.
		/// <para>The other options can be specified in the property initializer</para>
		/// </summary>
		/// <param name="nodes">
		/// A list of Elasticsearch nodes of the cluster you want to report into.
		/// <para>You need to specify at least one node, if you enable sniffing the exporter will find the rest of the nodes</para>
		/// </param>
		public ElasticsearchBenchmarkExporterOptions(params Uri[] nodes)
		{
			Nodes = nodes ?? throw new ArgumentNullException(nameof(nodes));
			if (Nodes.Length == 0)
				throw new ArgumentException($"No nodes were passed to {nameof(ElasticsearchBenchmarkExporterOptions)}", nameof(nodes));
		}

		/// <summary> The nodes to write data too </summary>
		public Uri[] Nodes { get; }

		/// <summary>
		/// A cloud id token for usage with Elastic Cloud
		/// </summary>
		public string CloudId { get; set; }

		/// <summary> If Elasticsearch security is enabled (it should!) this sets the username to be used. </summary>
		public string Username { get; set; }

		/// <summary> If Elasticsearch security is enabled (it should!) this sets the password to be used. </summary>
		public string Password { get; set; }

		/// <summary> If Elasticsearch security is enabled (it should!) this sets the api key. </summary>
		public string ApiKey { get; set; }

		/// <summary> Instructs the exporter to use a sniffing node pool, which will discover the rest of the cluster</summary>
		public bool UseSniffingNodePool { get; set; }

		/// <summary> Whether to use debug mode on the Elasticsearch Client</summary>
		public bool EnableDebugMode { get; set; } =
#if DEBUG
		true;
#else
			false;
#endif

		/// <summary> (Optional) Report the sha of the commit we are benchmarking</summary>
		public string GitCommitSha { get; set; }

		/// <summary> (Optional) Report the message of the commit we are benchmarking</summary>
		public string GitCommitMessage { get; set; }

		/// <summary> (Optional) Report the branch of the commit we are benchmarking</summary>
		public string GitBranch { get; set; }

		/// <summary> (Optional) Report the repository, does not have to be a complete URI</summary>
		public string GitRepositoryIdentifier { get; set; }

		/// <summary> The datastream namespace to write to, by default writes to benchmarks-dotnet-default</summary>
		public string DataStreamNamespace { get; set; } = "default";

		/// <summary>
		/// Allows the target datastream to be bootstrapped. The default is no bootstrapping
		/// since we assume the configured user might not have management privileges
		/// </summary>
		public BootstrapMethod BootstrapMethod { get; set; } = BootstrapMethod.None;

		/// <summary> Allows the user to directly change <see cref="DataStreamChannelOptions{TEvent}"/> used to export the benchmarks </summary>
		public Action<DataStreamChannelOptions<BenchmarkDocument>> ChannelOptionsCallback { get; set; }

		private static Uri[] Parse(string urls)
		{
			if (string.IsNullOrWhiteSpace(urls)) throw new ArgumentException("no urls provided, empty string or null", nameof(urls));

			var uris = urls.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
				.Select(u => u.Trim())
				.Select(u => Uri.TryCreate(u, UriKind.Absolute, out var url) ? url : null)
				.Where(u => u != null)
				.ToList();
			if (uris.Count == 0) throw new ArgumentException($"'{urls}' can not be parsed to a list of Uri", nameof(urls));

			return uris.ToArray();
		}

		private NodePool CreateNodePool()
		{
			if (!string.IsNullOrWhiteSpace(CloudId))
			{
				if (!string.IsNullOrWhiteSpace(ApiKey))
					return new CloudNodePool(CloudId, new ApiKey(ApiKey));
				if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
					return new CloudNodePool(CloudId, new BasicAuthentication(Username, Password));

				throw new Exception("A cloud id was provided but neither apikey nor username/pass combination was set");
			}

			var uris = Nodes;
			if ((uris?.Length ?? 0) == 0)
				return new SingleNodePool(new Uri("http://localhost:9200"));

			if (uris.Length == 1)
			{
				return UseSniffingNodePool
					? new SniffingNodePool(uris)
					: new SingleNodePool(uris[0]);
			}

			return UseSniffingNodePool
				? new SniffingNodePool(uris)
				: new StaticNodePool(uris);
		}


		internal TransportConfiguration CreateTransportConfiguration()
		{
			var settings = new TransportConfiguration(CreateNodePool(), productRegistration: new ElasticsearchProductRegistration());
			if (EnableDebugMode)
				settings.EnableDebugMode();
			return settings;
		}
	}
}
