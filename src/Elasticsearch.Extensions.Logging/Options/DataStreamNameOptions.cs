namespace Elasticsearch.Extensions.Logging.Options
{
	public class DataStreamNameOptions
	{
		/// <summary> Generic type describing the data</summary>
		public string Type { get; set; } = "logs";

		/// <summary> Describes the data ingested and its structure</summary>
		public string DataSet { get; set; } = "dotnet";

		/// <summary> User-configurable arbitrary grouping</summary>
		public string Namespace { get; set; } = "default";
	}
}
