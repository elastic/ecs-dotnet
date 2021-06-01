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

		public readonly List<NestedFields> Children = new List<NestedFields>();
		private string _description;

		public string Name { get; set; }

		public string NamePCased => FileGenerator.PascalCase(Name);

		public string ClassNameType =>
			_schema.Name switch
			{
				"dns" when Name == "answers" && _schema.Fields.Single(f => f.Value.Name == "answers").Value.IsArray() => (NamePCased + "[]"),
				"process" when Name == "parent" => FileGenerator.PascalCase(_schema.Name),
				_ => NamePCased
			};

		public string Description
		{
			get
			{
				if (!string.IsNullOrEmpty(_description))
					return _description;

				if (_schema.Name == "dns" && Name == "answers")
					return _schema.Fields.Single(f => f.Value.FlatName == "dns.answers").Value.DescriptionSanitized();

				if (_schema.Name == "log" && Name == "syslog")
					return _schema.Fields.Single(f => f.Value.FlatName == "log.syslog").Value.DescriptionSanitized();

				if (_schema.Name == "network" && Name == "inner")
					return _schema.Fields.Single(f => f.Value.FlatName == "network.inner").Value.DescriptionSanitized();

				if (_schema.Name == "observer" && Name == "ingress")
					return _schema.Fields.Single(f => f.Value.FlatName == "observer.ingress").Value.DescriptionSanitized();

				if (_schema.Name == "observer" && Name == "egress")
					return _schema.Fields.Single(f => f.Value.FlatName == "observer.egress").Value.DescriptionSanitized();

				if (Name == "trace" || Name == "transaction")
				{
					var tracingSchema = _schema.Specification.YamlSchemas.Single(f => f.Name == "tracing");
					return $"{tracingSchema.DescriptionSanitized()}<para/>{NamePCased} property.";
				}

				return $"{NamePCased} property.";
			}
			set => _description = value;
		}

		public List<Field> Fields { get; set; } = new List<Field>();
	}
}
