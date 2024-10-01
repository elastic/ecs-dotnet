// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Elastic.CommonSchema.Serilog.Adapters;
using Elastic.Serilog.Enrichers.Web.Adapters;
using Serilog.Core;
using Serilog.Events;
#if NET
using Microsoft.AspNetCore.Http;
#else
using System.Web;
#endif
using static Elastic.CommonSchema.Serilog.SpecialProperties;

namespace Elastic.Serilog.Enrichers.Web;

/// <summary>Include current HTTP context data on any ECS document created</summary>
public class HttpContextEnricher : ILogEventEnricher
{
#if NET
	private readonly IHttpContextAccessor _httpContextAccessor;

	/// <summary>Include current HTTP context data on any ECS document created</summary>
	public HttpContextEnricher(IHttpContextAccessor httpContextAccessor) =>
		_httpContextAccessor = httpContextAccessor;

	private IHttpAdapter Adapter => new HttpAdapter(_httpContextAccessor);
#else
	private IHttpAdapter Adapter => new HttpAdapter(HttpContext.Current);
#endif



	/// <summary> The property name added to enriched log events.</summary>
	public const string PropertyName = SpecialKeys.HttpContext;

	/// <summary> Enrich the log event.</summary>
	public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
	{
		if (!Adapter.HasContext)
			return;

		var r = new HttpContextEnrichments {
			Http = Adapter.Http,
			Server = Adapter.Server,
			Url = Adapter.Url,
			UserAgent = Adapter.UserAgent,
			Client = Adapter.Client,
			User = Adapter.User
		};

		logEvent.AddPropertyIfAbsent(new LogEventProperty(PropertyName, new ScalarValue(r)));
	}

}
