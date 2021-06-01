// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;

namespace Generator.Schema
{
	public class YamlSpecification
	{
		public const string TimestampFieldName = "@timestamp";
		public const string MessageFieldName = "message";
		public const string LogLevelFieldName = "log.level";

		// The "root" schema for ECS
		private YamlSchema _baseSchema;

		public string FullVersion => DownloadBranch + ".0";

		public string DownloadBranch { get; set; }

		public YamlSchema BaseYamlSchema()
		{
			if (_baseSchema != null)
				return _baseSchema;

			const string baseSchemaName = "base";
			var baseSchema = YamlSchemas.Single(s => s.Name == baseSchemaName);

			// Currently the tracing schema exists outside of the base schema, and needs to be "re-attached"
			var otherBaseSchemas = YamlSchemas.Where(s => string.IsNullOrWhiteSpace(s.Prefix) && s.Name != baseSchemaName).ToArray();
			foreach (var otherBaseSchema in otherBaseSchemas)
			{
				foreach (var (key, value) in otherBaseSchema.Fields)
				{
					if (!baseSchema.Fields.ContainsKey(key))
						baseSchema.Fields.Add(key, value);
				}
			}

			_baseSchema = baseSchema;
			return _baseSchema;
		}

		public IEnumerable<YamlSchema> NonBaseNonReusableYamlSchemas() => NonBaseYamlSchemas()
			.Where(s => s.Reusable?.TopLevel ?? true).OrderBy(s => s.Name);

		public IEnumerable<YamlSchema> NonBaseYamlSchemas() => YamlSchemas
			.Where(s => !string.IsNullOrWhiteSpace(s.Prefix)).OrderBy(s => s.Name);

		public IEnumerable<Tuple<string, Field>> BaseFieldsOrdered
		{
			get
			{
				var baseRootObject = BaseYamlSchema();
				var list = new List<Tuple<string, Field>>
				{
					Tuple.Create("WriteTimestamp", baseRootObject.Fields.Single(f => f.Key == TimestampFieldName).Value),
					// HACK in the log.level
					Tuple.Create("WriteLogLevel", new Field { Name = LogLevelFieldName, Schema = baseRootObject, FlatName = LogLevelFieldName }),
					Tuple.Create("WriteMessage", baseRootObject.Fields.Single(f => f.Key == MessageFieldName).Value),
					Tuple.Create("WriteProp", new Field { Name = "metadata", Schema = baseRootObject, FlatName = "metadata" })
				};

				list.AddRange(baseRootObject.GetFieldsFlat()
					                                     .Where(f => f.Name != TimestampFieldName && f.Name != MessageFieldName)
														 .Select(f => Tuple.Create("WriteProp", f)));
				return list;
			}
		}

		public IDictionary<int, string> Templates { get; set; }

		public IList<YamlSchema> YamlSchemas { get; set; }
	}
}
