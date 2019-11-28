// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;

namespace Generator.Schema
{
	public class EcsSpecification
	{
		public IEnumerable<Tuple<string, Field>> BaseFieldsOrdered
		{
			get
			{
				var baseClass = YamlSchemas.Single(s => s.Name == "base");
				var list = new List<Tuple<string, Field>>();
				list.Add(Tuple.Create("WriteTimestamp", baseClass.Fields.Single(f => f.Key == "@timestamp").Value));

				// HACK in the log.level
				list.Add(Tuple.Create("WriteLogLevel", new Field { Name = "log.level", Schema = baseClass }));
				list.Add(Tuple.Create("WriteMessage", baseClass.Fields.Single(f => f.Key == "message").Value));

				// HACK in _metadata
				list.Add(Tuple.Create("WriteProp", new Field { Name = "_metadata", Schema = baseClass }));
				list.AddRange(baseClass.Fields.Values.Where(f => f.Name != "@timestamp" && f.Name != "message")
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
				var list = new List<YamlSchema>();
				list.Add(YamlSchemas.Single(s => s.Name == "base"));
				list.AddRange(YamlSchemas.Where(s => s.Name != "base").OrderBy(s => s.Name));
				return list;
			}
		}
	}
}
