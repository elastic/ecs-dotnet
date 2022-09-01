using System;
using System.Linq;

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

		private static char[] BadCharacters = { '\\', '/', '*', '?', '"', '<', '>', '|', ' ', ',', '#' };
		private static string BadCharactersError = string.Join(", ", BadCharacters.Select(c => $"'{c}'").ToArray());

		public DataStreamName(string type, string dataSet = "generic", string @namespace = "default")
		{
			if (string.IsNullOrEmpty(type)) throw new ArgumentException($"{nameof(type)} can not be null or empty", nameof(type));
			if (string.IsNullOrEmpty(dataSet)) throw new ArgumentException($"{nameof(dataSet)} can not be null or empty", nameof(dataSet));
			if (string.IsNullOrEmpty(@namespace)) throw new ArgumentException($"{nameof(@namespace)} can not be null or empty", nameof(@namespace));
			if (type.IndexOfAny(BadCharacters) > 0)
				throw new ArgumentException($"{nameof(type)} can not contain any of {BadCharactersError}", nameof(type));
			if (dataSet.IndexOfAny(BadCharacters) > 0)
				throw new ArgumentException($"{nameof(dataSet)} can not contain any of {BadCharactersError}", nameof(type));
			if (@namespace.IndexOfAny(BadCharacters) > 0)
				throw new ArgumentException($"{nameof(@namespace)} can not contain any of {BadCharactersError}", nameof(type));

			Type = type.ToLowerInvariant();
			DataSet = dataSet.ToLowerInvariant();
			Namespace = @namespace.ToLowerInvariant();
		}

		public string GetTemplatePrefix() => $"{Type}.{DataSet}.*";

		private string? _stringValue;
		public override string ToString()
		{
			if (_stringValue != null) return _stringValue;

			_stringValue = $"{Type}-{DataSet}-{Namespace}";
			return _stringValue;
		}
	}
}
