// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Collections.Generic;
using System.Linq;

namespace Generator.Schema
{
	public class NestedFields
	{
		private readonly YamlSchema _schema;

		public NestedFields(YamlSchema schema) => _schema = schema;

		public List<NestedFields> Children = new List<NestedFields>();

		public string Name { get; set; }

		public string ClassName => FileGenerator.PascalCase(Name);

		public string ClassNameType
		{
			get
			{
				if (_schema.Name == "dns" && ClassName == "Answers")
					return FileGenerator.PascalCase(ClassName) + "[]";

				if (_schema.Name == "log" && ClassName == "Syslog")
					return FileGenerator.PascalCase(ClassName) + "[]";

				return FileGenerator.PascalCase(ClassName);
			}
		}

		public string Description
		{
			get
			{
				if (_schema.Name == "dns" && ClassName == "Answers")
					return _schema.Fields.Single(f => f.Value.FlatName == "dns.answers").Value.DescriptionSanitized();

				if (_schema.Name == "log" && ClassName == "Syslog")
					return _schema.Fields.Single(f => f.Value.FlatName == "log.syslog").Value.DescriptionSanitized();

				if (_schema.Name == "network" && ClassName == "Inner")
					return _schema.Fields.Single(f => f.Value.FlatName == "network.inner").Value.DescriptionSanitized();

				if (_schema.Name == "observer" && ClassName == "Ingress")
					return _schema.Fields.Single(f => f.Value.FlatName == "observer.ingress").Value.DescriptionSanitized();

				if (_schema.Name == "observer" && ClassName == "Egress")
					return _schema.Fields.Single(f => f.Value.FlatName == "observer.egress").Value.DescriptionSanitized();

				if (ClassName == "Trace" || ClassName == "Transaction")
				{
					var tracingSchema = _schema.Specification.YamlSchemas.Single(f => f.Name == "tracing");
					return $"{tracingSchema.DescriptionSanitized()}<para/>{FileGenerator.PascalCase(Name)} property.";
				}

				return $"{FileGenerator.PascalCase(ClassName)} property.";
			}
		}

		public List<Field> Fields { get; set; } = new List<Field>();
	}
}
