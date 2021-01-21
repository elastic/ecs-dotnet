// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Elastic.CommonSchema;

namespace Elasticsearch.Extensions.Logging
{
	public class LogEvent : Base
	{
		// Custom field; use capitalisation as per ECS

		/// <summary>
		/// Original template used to generate the message, with token placeholders for inserted label values.
		/// </summary>
		public string? MessageTemplate { get; set; }

		/// <summary>
		/// List of the converted string values of .NET logging scope stack context
		/// </summary>
		public IList<string>? Scopes { get; set; }

		/// <summary>
		/// Holds the ID of the current span.
		/// </summary>
		/// <remarks>
		/// Custom field Span.id to hold the span for ECS 1.5; can be replaced in ECS 1.6 with span.id
		/// </remarks>
		public Span? Span { get; set; }

		protected override void WriteAdditionalProperties(Action<string, object> write)
		{
			if (MessageTemplate != null) write(nameof(MessageTemplate), MessageTemplate);
			if (Scopes != null) write(nameof(Scopes), Scopes);
			if (Span != null) write(nameof(Span), Span);
		}
	}

	public class Span
	{
		/// <summary>
		/// Unique identifier of the span.<para/>
		/// </summary>
		/// <example>e7bc32771d164a92</example><example>a0177b7435d7d545</example>
		[DataMember(Name = "id")]
		public string Id { get; set; } = string.Empty;
	}
}
