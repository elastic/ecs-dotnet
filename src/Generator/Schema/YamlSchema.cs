// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using RazorLight;

namespace Generator.Schema
{
	[JsonObject(MemberSerialization.OptIn)]
	public class YamlSchema
	{
		/// <summary>
		///  Reference to the YAML specification.
		/// </summary>
		public YamlSpecification Specification { get; set; }

		/// <summary>
		/// vDescription of the field set
		/// </summary>
		[JsonProperty("description", Required = Required.Always)]
		public string Description { get; set; }

		/// <summary>
		///  The fields within the schema
		/// </summary>
		[JsonProperty("fields", Required = Required.Always)]
		public Dictionary<string, Field> Fields { get; set; }

		/// <summary>
		///  Footnote of this schema.
		/// </summary>
		[JsonProperty("footnote")]
		public string Footnote { get; set; }

		/// <summary>
		///     TBD. Just set it to 2, for now ;-)
		/// </summary>
		[JsonProperty("group", Required = Required.Always)]
		public int Group { get; set; } = 2;

		/// <summary>
		///     Name of the field set (required)
		/// </summary>
		[JsonProperty("name", Required = Required.Always)]
		public string Name { get; set; }

		[JsonProperty("nestings")]
		public string[] Nestings { get; set; }

		[JsonProperty("prefix")]
		public string Prefix { get; set; }

		/// <summary>
		///     Optional
		/// </summary>
		[JsonProperty("reusable")]
		public YamlSchemaReusable Reusable { get; set; }

		/// <summary>
		///     Optional
		/// </summary>
		[JsonProperty("reused_here")]
		public List<YamlSchemaReusedHere> ReusedHere { get; set; }

		/// <summary>
		///     Whether or not the fields of this field set should be nested under the field set name. (optional)
		/// </summary>
		[JsonProperty("root")]
		public bool? Root { get; set; }

		/// <summary>
		///     Shorter definition, for display in tight spaces
		/// </summary>
		[JsonProperty("short")]
		public string Short { get; set; }

		/// <summary>
		///     Rendered name of the field set (e.g. for documentation) Must be correctly capitalized (required)
		/// </summary>
		[JsonProperty("title", Required = Required.Always)]
		public string Title { get; set; }

		/// <summary>
		///     At this level, should always be group
		/// </summary>
		[JsonProperty("type")]
		public string Type { get; set; }

		public IEnumerable<Field> GetFilteredFields() =>
			Fields.Where(f => Nestings == null || !Nestings.Any(n => f.Key.StartsWith(n)))
				  .Select(f => f.Value)
				  .OrderBy(f => f.Order ?? 0);

		public List<NestedFields> GetFieldsNested()
		{
			var nestedFields = new List<NestedFields>();
			foreach (var nestedField in Fields
				.Select(f => f.Value)
				.OrderBy(f => f.Order ?? 0)
				.Where(f => f.JsonFieldName().Contains(".")))
			{
				var reusedHere = ReusedHere?.SingleOrDefault(n => nestedField.FlatName.StartsWith(n.Full));
				// check if this is a reused_here field
				if (reusedHere != null && reusedHere.Full.Split('.').Length == 2)
				{
					var schema = Specification.YamlSchemas.Single(s => s.Name == reusedHere.SchemaName);
					var expected = schema.Reusable.Expected.Single(e => e.Full == reusedHere.Full);

					var current = nestedFields.SingleOrDefault(n => n.Name == expected.As);
					if (current is null)
						nestedFields.Add(new NestedFields(this) { Name = expected.As, Description = reusedHere.Short });
				}
				else
				{
					var nameParts = nestedField.JsonFieldName().Split('.');
					var current = nestedFields.SingleOrDefault(n => n.Name == nameParts[0]);

					if (current != null)
						Add(current, nameParts.Skip(1).ToArray(), nestedField);
					else
					{
						var newRoot = new NestedFields(this) { Name = nameParts[0] };
						nestedFields.Add(newRoot);

						Add(newRoot, nameParts.Skip(1).ToArray(), nestedField);
					}
				}
			}

			return nestedFields;
		}

		private void Add(NestedFields root, string[] nameParts, Field field)
		{
			// primitive property
			if (nameParts.Length == 1)
			{
				root.Fields.Add(field);
				return;
			}

			// Typed property. look into reused_here
			if (ReusedHere != null)
			{
				var reusedHere = ReusedHere.SingleOrDefault(r => field.FlatName.StartsWith(r.Full));

				if (reusedHere != null)
				{
					var schema = Specification.YamlSchemas.Single(s => s.Name == reusedHere.SchemaName);
					var expected = schema.Reusable.Expected.Single(e => e.Full == reusedHere.Full);

					// skip any fields that would be children of a reused_here field and add only the reused_here field
					if (root.Fields.All(f => f.Name != expected.As))
					{
						root.Fields.Add(new Field
						{
							Name = expected.As,
							Description = reusedHere.Short,
							ClrType = FileGenerator.PascalCase(reusedHere.SchemaName)
						});
					}
				}

				return;
			}

			var existingRoot = root.Children.SingleOrDefault(c => c.Name == nameParts[0]);
			if (existingRoot != null)
				Add(existingRoot, nameParts.Skip(1).ToArray(), field);
			else
			{
				var newRoot = new NestedFields(this) { Name = nameParts[0] };
				root.Children.Add(newRoot);

				Add(newRoot, nameParts.Skip(1).ToArray(), field);
			}
		}

		public IEnumerable<Field> GetFieldsFlat()
		{
			var filtered = GetFilteredFields().Where(f => !f.JsonFieldName().Contains("."));

			// The following are handled as child objects
			filtered = filtered.Where(f => f.FlatName != "dns.answers");
			filtered = filtered.Where(f => f.FlatName != "log.syslog");
			filtered = filtered.Where(f => f.FlatName != "network.inner");
			filtered = filtered.Where(f => f.FlatName != "observer.egress");
			filtered = filtered.Where(f => f.FlatName != "observer.ingress");

			return filtered;
		}
	}
}
