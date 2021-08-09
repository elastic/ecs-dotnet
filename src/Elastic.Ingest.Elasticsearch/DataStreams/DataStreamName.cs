namespace Elastic.Ingest.Elasticsearch
{
	public record DataStreamName
	{
		/// <summary> Generic type describing the data</summary>
		public string Type { get; init; }

		/// <summary> Describes the data ingested and its structure</summary>
		public string DataSet { get; init; }

		/// <summary> User-configurable arbitrary grouping</summary>
		public string Namespace { get; init; }

		public DataStreamName(string type, string dataSet = "generic", string @namespace = "default")
		{
			Type = type;
			DataSet = dataSet;
			Namespace = @namespace;
		}

		private string? _stringValue;
		public override string ToString()
		{
			if (_stringValue != null) return _stringValue;

			_stringValue = $"{Type}-{DataSet}-{Namespace}";
			return _stringValue;
		}
	}
}
