// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

#if NETSTANDARD
using Microsoft.AspNetCore.Http;
#else
using System.Web;
#endif
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Serilog.Events;

namespace Elastic.CommonSchema.Serilog
{
	public interface IEcsTextFormatterConfiguration
	{
		bool MapCurrentThread { get; set; }
		bool MapExceptions { get; set; }
		IHttpAdapter MapHttpAdapter { get; set; }
		ISet<string> LogEventPropertiesToFilter { get;set; }
	}

	public interface IEcsTextFormatterConfiguration<TEcsDocument> : IEcsTextFormatterConfiguration
		where TEcsDocument : EcsDocument, new()
	{
		Func<TEcsDocument, LogEvent, TEcsDocument> MapCustom { get; set; }
	}

	public class EcsTextFormatterConfiguration<TEcsDocument> : IEcsTextFormatterConfiguration<TEcsDocument>
		where TEcsDocument : EcsDocument, new()
	{
		public bool MapCurrentThread { get; set; } = true;
		public bool MapExceptions { get; set; } = true;
		public IHttpAdapter MapHttpAdapter { get; set; }
		public ISet<string> LogEventPropertiesToFilter { get; set; }
		public Func<TEcsDocument, LogEvent, TEcsDocument> MapCustom { get; set; }
	}

	public class EcsTextFormatterConfiguration : EcsTextFormatterConfiguration<EcsDocument>
	{

	}
}
