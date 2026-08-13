// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Elastic.CommonSchema;

public partial class EcsDocument
{
	/// <summary>
	/// Passthrough key-value store for OTel semantic convention attributes.
	/// In Elasticsearch, <c>attributes</c> is a passthrough field type where the prefix can be omitted during queries.
	/// In JSON source, data is nested under an <c>attributes</c> object.
	/// </summary>
	[JsonPropertyName("attributes"), DataMember(Name = "attributes")]
	public MetadataDictionary? Attributes { get; set; }

	/// <summary>
	/// Assigns an OTel attribute value. Always stores in <see cref="Attributes"/>.
	/// If the OTel name maps to an ECS field (via <see cref="OTelMappings.OTelToEcs"/>),
	/// also sets the corresponding ECS property via <see cref="AssignField"/>.
	/// </summary>
	/// <param name="otelName">The OTel semantic convention attribute name</param>
	/// <param name="value">The value to assign</param>
	public void AssignOTelField(string otelName, object value)
	{
		// Always store in Attributes
		Attributes ??= new MetadataDictionary();
		Attributes[otelName] = value;

		// If there's a mapping to an ECS field, also set it
		if (OTelMappings.OTelToEcs.TryGetValue(otelName, out var ecsPath))
			AssignField(ecsPath, value);
		else
			// For match relations, the OTel name IS the ECS name — try direct assignment
			AssignField(otelName, value);
	}
}
