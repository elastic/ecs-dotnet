// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

#if !NETSTANDARD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Elastic.CommonSchema.Serilog.Adapters
{
	public class HttpAdapter : IHttpAdapter
	{
		private readonly HttpContext _httpContext;

		public HttpAdapter(HttpContext httpContext) => _httpContext = httpContext;

		public Client Client => null;

		public bool HasContext => _httpContext != null;

		public IEnumerable<Exception> Exceptions => Enumerable.Empty<Exception>();

		public Http Http => !HasContext ? null : new Http
		{
			RequestMethod = _httpContext.Request.HttpMethod,
			RequestBytes = _httpContext.Request.TotalBytes,
			RequestBodyBytes = _httpContext.Request.TotalBytes,
			RequestBodyContent  = _httpContext.Request.InputStream.ToString(),
			RequestReferrer = _httpContext.Request.UrlReferrer?.ToString(),

			// Bytes = 0, // response?.OutputStream.Length ?? 0,
			ResponseStatusCode = _httpContext.Response.StatusCode,
			ResponseBodyContent = _httpContext.Response.OutputStream.ToString()
		};

		public Server Server => !HasContext ? null : new Server
		{
			Domain = _httpContext.Request.Url.Authority
		};

		public Url Url => !HasContext ? null : new Url
		{
			Original = _httpContext.Request.RawUrl,
			Full = _httpContext.Request.Url.ToString(),
			Path = _httpContext.Request.Path,
			Scheme = _httpContext.Request.Url.Scheme,
			Query = _httpContext.Request.Url.Query,
			Domain = _httpContext.Request.Url.Authority,
			Username = _httpContext.Request.LogonUserIdentity?.Name,
			Port = _httpContext.Request.Url.Port
		};

		public User User => null;

		public UserAgent UserAgent => !HasContext ? null : new UserAgent
		{
			DeviceName = _httpContext.Request.Browser?.MobileDeviceModel,
			Name = _httpContext.Request.Browser?.Browser,
			Original = _httpContext.Request.UserAgent,
			Version = _httpContext.Request.Browser?.Version
		};
	}
}
#endif