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
		private YamlSchema _baseRoot;

		public YamlSchema BaseYamlSchema()
		{
			if (_baseRoot != null)
				return _baseRoot;

			var otherRoots = YamlSchemas.Where(s => string.IsNullOrWhiteSpace(s.Prefix) && s.Name != "base").ToArray();
			var baseRoot = YamlSchemas.Single(s => s.Name == "base");

			foreach (var otherRoot in otherRoots)
			{
				foreach (var otherRootField in otherRoot.Fields)
				{
					if (!baseRoot.Fields.ContainsKey(otherRootField.Key))
						baseRoot.Fields.Add(otherRootField.Key, otherRootField.Value);
				}
			}

			_baseRoot = baseRoot;
			return _baseRoot;
		}

		public IEnumerable<YamlSchema> NonBaseYamlSchemas() => YamlSchemas.Where(s => !string.IsNullOrWhiteSpace(s.Prefix)).OrderBy(s => s.Name);

		public IEnumerable<Tuple<string, Field>> BaseFieldsOrdered
		{
			get
			{
				var baseRootObject = BaseYamlSchema();
				var list = new List<Tuple<string, Field>>();
				list.Add(Tuple.Create("WriteTimestamp", baseRootObject.Fields.Single(f => f.Key == "@timestamp").Value));

				// HACK in the log.level
				list.Add(Tuple.Create("WriteLogLevel", new Field { Name = "log.level", Schema = baseRootObject, FlatName = "log.level" }));
				list.Add(Tuple.Create("WriteMessage", baseRootObject.Fields.Single(f => f.Key == "message").Value));

				// HACK in _metadata
				list.Add(Tuple.Create("WriteProp", new Field { Name = "_metadata", Schema = baseRootObject, FlatName = "_metadata" }));
				list.AddRange(baseRootObject.GetFieldsFlat().Where(f => f.Name != "@timestamp" && f.Name != "message")
					.Select(f => Tuple.Create("WriteProp", f)));
				return list;
			}
		}

		public IDictionary<int, string> Templates { get; set; }

		public IList<YamlSchema> YamlSchemas { get; set; }

		public IEnumerable<YamlSchema> YamlSchemasOrdered
		{
			get
			{
				var list = new List<YamlSchema> { BaseYamlSchema() };
				list.AddRange(NonBaseYamlSchemas());
				return list;
			}
		}
	}
}
