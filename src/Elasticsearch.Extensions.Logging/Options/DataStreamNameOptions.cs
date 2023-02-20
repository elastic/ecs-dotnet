namespace Elasticsearch.Extensions.Logging.Options
{
	/// <summary>
	/// Provides options to control the datastream to write Elasticsearch logs too
	/// </summary>
	public class DataStreamNameOptions
	{
		/// <summary> Generic type describing the data. Defaults to 'logs', not recommended to change this</summary>
		public string Type { get; set; } = "logs";

		/// <summary> Describes the data ingested and its structure</summary>
		public string DataSet { get; set; } = "dotnet";

		/// <summary> User-configurable arbitrary grouping</summary>
		public string Namespace { get; set; } = "default";
	}
}
