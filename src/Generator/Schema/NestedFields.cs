using System.Collections.Generic;
using System.Linq;

namespace Generator.Schema
{
	public class NestedFields
	{
		private readonly YamlSchema _schema;

		public NestedFields(YamlSchema schema) => _schema = schema;

		public List<NestedFields> Children = new List<NestedFields>();

		public string ClassName { get; set; }

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
					return _schema.Fields.Single(f => f.Value.FlatName == "dns.answers").Value.DescriptionSanitized;

				if (_schema.Name == "log" && ClassName == "Syslog")
					return _schema.Fields.Single(f => f.Value.FlatName == "log.syslog").Value.DescriptionSanitized;

				return $"{FileGenerator.PascalCase(ClassName)} property.";
			}
		}

		public List<Field> Fields { get; set; } = new List<Field>();
	}
}
