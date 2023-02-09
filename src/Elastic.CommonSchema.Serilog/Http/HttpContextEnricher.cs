// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Serilog.Core;
using Serilog.Events;
#if NETSTANDARD
using Microsoft.AspNetCore.Http;
#else
using System.Web;
#endif

namespace Elastic.CommonSchema.Serilog;

public class HttpContextEnricher : ILogEventEnricher
{
#if NETSTANDARD
	private readonly IHttpContextAccessor _httpContextAccessor;

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
		var r = new HttpContextEnrichments();
		if (Adapter.HasContext)
		{
			r.Http = Adapter.Http;
			r.Server = Adapter.Server;
			r.Url = Adapter.Url;
			r.UserAgent = Adapter.UserAgent;
			r.Client = Adapter.Client;
			r.User = Adapter.User;
		}

		logEvent.AddPropertyIfAbsent(propertyFactory.CreateProperty(PropertyName, r));
	}

	public class HttpContextEnrichments
	{
		public Client Client { get; set; }
		public CommonSchema.Http Http { get; set; }
		public Server Server { get; set; }
		public Url Url { get; set; }
		public User User { get; set; }
		public UserAgent UserAgent { get; set; }
	}
}
