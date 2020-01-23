using System;
using System.Linq;
using Elasticsearch.Net;

namespace Elastic.CommonSchema.BenchmarkDotNetExporter
{
	/// <summary> Configure the Elasticsearch BenchmarkDotNet exporter</summary>
	public class ElasticsearchBenchmarkExporterOptions
	{
		/// <summary>
		/// Configure the exporter options, the <see cref="commaSeparatedListOfUrls"> parameter is required.
		/// <para>The other options can be specified in the property initializer</para>
		/// </summary>
		/// <param name="commaSeparatedListOfUrls">
		/// A list of comma separated Elasticsearch nodes of the cluster you want to report into.
		/// <para>You need to specify at least one node, if you enable sniffing the exporter will find the rest of the nodes</para>
		/// </param>
		/// <exception cref="ArgumentException">If none of the urls specified parse into a <see cref="Uri"/></exception>
		public ElasticsearchBenchmarkExporterOptions(string commaSeparatedListOfUrls) : this(Parse(commaSeparatedListOfUrls)) { }

		/// <summary>
		/// Configure the exporter options, the <see cref="nodes"> parameter is required.
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

		/// <summary> Instructs the exporter to use a sniffing connection pool, which will discover the rest of the cluster</summary>
		public bool UseSniffingConnectionPool { get; set; }

		/// <summary> (Optional) Report the sha of the commit we are benchmarking</summary>
		public string GitCommitSha { get; set; }
		/// <summary> (Optional) Report the message of the commit we are benchmarking</summary>
		public string GitCommitMessage { get; set; }
		/// <summary> (Optional) Report the branch of the commit we are benchmarking</summary>
		public string GitBranch { get; set; }
		/// <summary> (Optional) Report the repository, does not have to be a complete URI</summary>
		public string GitRepositoryIdentifier { get; set; }

		internal static readonly string DefaultMoniker = "benchmarks-dotnet";
		/// <summary>
		/// The prefix for the indices being created, indices will be suffixed with <code>-DATE</code>
		/// see <see cref="IndexStrategy"/> how to control the DATE rounding.
		/// </summary>
		public string IndexName { get; set; } = DefaultMoniker;
		public string TemplateName { get; set; } = DefaultMoniker;
		public string PipelineName { get; set; } = DefaultMoniker;
		public TimeSeriesStrategy IndexStrategy { get; set; } = TimeSeriesStrategy.Default;

		private static Uri[] Parse(string urls)
		{
			if (string.IsNullOrWhiteSpace(urls)) throw new ArgumentException("no urls provided, empty string or null", nameof(urls));
			var uris = urls.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries)
				.Select(u => u.Trim())
				.Select(u => Uri.TryCreate(u, UriKind.Absolute, out var url) ? url : null)
				.Where(u => u != null)
				.ToList();
			if (uris.Count == 0) throw new ArgumentException($"'{urls}' can not be parsed to a list of Uri", nameof(urls));
			return uris.ToArray();
		}

		private IConnectionPool CreateConnectionPool()
		{
			if (!string.IsNullOrWhiteSpace(CloudId))
			{
				if (!string.IsNullOrWhiteSpace(ApiKey))
					return new CloudConnectionPool(CloudId, new ApiKeyAuthenticationCredentials(ApiKey));
				else if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
					return new CloudConnectionPool(CloudId, new BasicAuthenticationCredentials(Username, Password));
				else throw new Exception("A cloud id was provided but neither apikey nor username/pass combination was set");
			}

			var uris = Nodes;
			if ((uris?.Length ?? 0) == 0)
				return new SingleNodeConnectionPool(new Uri("http://localhost:9200"));

			if (uris.Length == 1)
				return UseSniffingConnectionPool
					? new SniffingConnectionPool(uris)
					: (IConnectionPool)new SingleNodeConnectionPool(uris[0]);

			return UseSniffingConnectionPool
				? new SniffingConnectionPool(uris)
				: new StaticConnectionPool(uris);
		}


		internal ConnectionConfiguration CreateConnectionSettings()
		{
			var settings = new ConnectionConfiguration(CreateConnectionPool());
			// TODO can not pass base64 encoded version on connectionsettings
			// if (!string.IsNullOrWhiteSpace(ApiKey))
			// 	settings = settings.ApiKeyAuthentication(new ApiKeyAuthenticationCredentials(ApiKey));

			if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
				settings = settings.BasicAuthentication(Username, Password);

			return settings;
		}

		/// <summary>
		/// If <see cref="ElasticsearchBenchmarkExporterOptions.PipelineName"/> is set, which it by default. This controls
		/// how the pipeline rewrites the <see cref="ElasticsearchBenchmarkExporterOptions.IndexName"/> to a time series index.
		/// <para>NOTE: this only controls what happens when the pipeline gets created initially</para>
		/// </summary>
		public enum TimeSeriesStrategy
		{
			/// <summary> The default rounding is to create <see cref="Yearly"/> benchmark indices </summary>
			Default,
			Daily,
			Weekly,
			Monthly,
			Yearly,
		}
	}
}
