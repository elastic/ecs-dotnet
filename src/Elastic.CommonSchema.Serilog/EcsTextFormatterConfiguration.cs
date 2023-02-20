// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using System;
using System.Collections.Generic;
using Elastic.CommonSchema.Serilog.Adapters;
using Serilog.Events;

namespace Elastic.CommonSchema.Serilog
{
	/// <summary> Provides configuration options for <see cref="EcsTextFormatter"/> </summary>
	public interface IEcsTextFormatterConfiguration : IEcsDocumentCreationOptions
	{
		/// <summary>
		/// Expert option, its recommended to use <see cref="EnricherExtensions.WithEcsHttpContext"/> to ensure HttpContext gets mapped
		/// to the appropriate ECS fields.
		/// <para> Example: </para>
		/// <code>
		/// .UseSerilog((ctx, config) =>
		/// {
		///		var httpAccessor = ctx.Configuration.Get&lt;HttpContextAccessor&gt;();
		///
		///		config
		///			.ReadFrom.Configuration(ctx.Configuration)
		///			.Enrich.WithEcsHttpContext(httpAccessor);
		/// </code>
		/// </summary>
		IHttpAdapter MapHttpAdapter { get; set; }

		/// <summary>
		/// Stop certain keys to be persisted as <see cref="EcsDocument.Metadata"/> or <see cref="BaseFieldSet.Labels"/>
		/// </summary>
		ISet<string> LogEventPropertiesToFilter { get;set; }
	}

	/// <summary> Provides configuration options for <see cref="EcsTextFormatter{TEcsDocument}"/> </summary>
	public interface IEcsTextFormatterConfiguration<TEcsDocument> : IEcsTextFormatterConfiguration
		where TEcsDocument : EcsDocument, new()
	{
		/// <summary>
		/// Allows you to enrich <typeparamref name="TEcsDocument"/> using <see cref="LogEvent"/> before its being formatted
		/// </summary>
		Func<TEcsDocument, LogEvent, TEcsDocument> MapCustom { get; set; }
	}

	/// <inheritdoc cref="IEcsTextFormatterConfiguration{TEcsDocument}"/>
	public class EcsTextFormatterConfiguration<TEcsDocument> : IEcsTextFormatterConfiguration<TEcsDocument>
		where TEcsDocument : EcsDocument, new()
	{
		/// <inheritdoc cref="IEcsDocumentCreationOptions.IncludeHost"/>
		public bool IncludeHost { get; set; } = true;

		/// <inheritdoc cref="IEcsDocumentCreationOptions.IncludeProcess"/>
		public bool IncludeProcess { get; set; } = true;

		/// <inheritdoc cref="IEcsDocumentCreationOptions.IncludeUser"/>
		public bool IncludeUser { get; set; } = true;

		/// <inheritdoc cref="IEcsTextFormatterConfiguration.MapHttpAdapter"/>
		public IHttpAdapter MapHttpAdapter { get; set; }
		/// <inheritdoc cref="IEcsTextFormatterConfiguration.LogEventPropertiesToFilter"/>
		public ISet<string> LogEventPropertiesToFilter { get; set; }
		/// <inheritdoc cref="IEcsTextFormatterConfiguration{TEcsDocument}.MapCustom"/>
		public Func<TEcsDocument, LogEvent, TEcsDocument> MapCustom { get; set; }
	}

	// ReSharper disable once ClassNeverInstantiated.Global
	/// <inheritdoc cref="IEcsTextFormatterConfiguration{TEcsDocument}"/>
	public class EcsTextFormatterConfiguration : EcsTextFormatterConfiguration<EcsDocument>
	{

	}
}
