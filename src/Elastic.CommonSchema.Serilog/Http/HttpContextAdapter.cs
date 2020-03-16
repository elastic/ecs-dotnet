// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

#if !NETSTANDARD
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;

namespace Elastic.CommonSchema.Serilog
{
	public class HttpAdapter : IHttpAdapter
	{
		private readonly HttpContext _httpContext;

		public HttpAdapter(HttpContext httpContext) => _httpContext = httpContext;

		public Client Client => null;

		public IEnumerable<Exception> Exceptions => Enumerable.Empty<Exception>();

		public Http Http => _httpContext == null ? null : new Http
		{
			Request = new HttpRequest
			{
				Method = _httpContext.Request.HttpMethod,
				Bytes = _httpContext.Request.TotalBytes,
				Body = new RequestBody
				{
					Bytes = _httpContext.Request.TotalBytes,
					Content = _httpContext.Request.InputStream.ToString()
				},
				Referrer = _httpContext.Request.UrlReferrer?.ToString()
			},
			Response = new HttpResponse
			{
				// Bytes = 0, // response?.OutputStream.Length ?? 0,
				StatusCode = _httpContext.Response.StatusCode,
				Body = new ResponseBody
				{
					// Bytes = 0, //response?.OutputStream.Length ?? 0,
					Content = _httpContext.Response.OutputStream.ToString()
				}
			}
		};

		public Server Server => _httpContext == null ? null : new Server
		{
			Domain = _httpContext.Request.Url.Authority
		};

		public Url Url => _httpContext == null ? null : new Url
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

		public UserAgent UserAgent => _httpContext == null ? null : new UserAgent
		{
			Device = _httpContext.Request.Browser != null
				? new UserAgentDevice { Name = _httpContext.Request.Browser?.MobileDeviceModel }
				: null,
			Name = _httpContext.Request.UserAgent,
			Original = _httpContext.Request.UserAgent,
			Version = _httpContext.Request.Browser?.Version
		};
	}
}
#endif
