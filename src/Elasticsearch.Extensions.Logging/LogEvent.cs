// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using Elastic.CommonSchema;
using Elastic.CommonSchema.Serialization;

namespace Elasticsearch.Extensions.Logging
{
	/// <summary>
	/// A subclass of <see cref="EcsDocument"/> that adds additional properties related to Extensions logging.
	/// <para>For instance it adds scope information to each logged event</para>
	/// </summary>
	[JsonConverter(typeof(EcsDocumentJsonConverterFactory))]
	public class LogEvent : EcsDocument
	{
		// Custom fields; use capitalisation as per ECS
		private const string MessageTemplatePropertyName = nameof(MessageTemplate);
		private const string ScopesPropertyName = nameof(Scopes);

		/// <summary>
		/// Custom field with the original template used to generate the message, with token placeholders
		/// for inserted label values, e.g. "Unexpected error processing customer {CustomerId}."
		/// </summary>
		[JsonPropertyName(MessageTemplatePropertyName), DataMember(Name=MessageTemplatePropertyName)]
		public string? MessageTemplate { get; set; }

		/// <summary>
		/// Custom field with an array of string formatted scope values, in the order added.
		/// </summary>
		[JsonPropertyName(ScopesPropertyName), DataMember(Name=ScopesPropertyName)]
		public IList<string>? Scopes { get; set; }

		/// <summary>
		/// If <see cref="TryRead" /> returns <c>true</c> this will be called with the deserialized <paramref name="value" />
		/// </summary>
		/// <param name="propertyName">The additional property <see cref="EcsDocumentJsonConverter" /> encountered</param>
		/// <param name="value">
		/// The deserialized boxed value you will have to manually unbox to the type that
		/// <see cref="TryRead" /> set
		/// </param>
		/// <returns></returns>
		protected override bool ReceiveProperty(string propertyName, object value) =>
			propertyName switch
			{
				MessageTemplatePropertyName => null != (MessageTemplate = value as string),
				ScopesPropertyName => null != (Scopes = value as IList<string>),
				_ => false
			};

		/// <summary>
		/// If implemented in a subclass, this allows you to hook into <see cref="EcsDocumentJsonConverter" />
		/// and make it aware of properties on a subclass of <see cref="EcsDocument" />.
		/// If <paramref name="propertyName" /> is known, set <paramref name="type" /> to the correct type and return true.
		/// </summary>
		/// <param name="propertyName">The additional property that <see cref="EcsDocumentJsonConverter" /> encountered</param>
		/// <param name="type">Set this to the type you wish to deserialize to</param>
		/// <returns>Return true if <paramref name="propertyName" /> is handled</returns>
		protected override bool TryRead(string propertyName, out Type? type)
		{
			type = propertyName switch
			{
				MessageTemplatePropertyName => typeof(string),
				ScopesPropertyName => typeof(IList<string>),
				_ => null
			};
			return type != null;
		}

		/// <summary>
		/// Write any additional properties in your subclass during <see cref="EcsDocumentJsonConverter" /> serialization.
		/// </summary>
		/// <param name="write">An action taking a <c>property name</c> and <c>boxed value</c> to write to the output</param>
		protected override void WriteAdditionalProperties(Action<string, object> write)
		{
			if (MessageTemplate != null) write(MessageTemplatePropertyName, MessageTemplate);
			if (Scopes != null) write(ScopesPropertyName, Scopes);
		}
	}
}
