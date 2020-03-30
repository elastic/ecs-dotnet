// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

#if NETSTANDARD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using UAParser;

namespace Elastic.CommonSchema.Serilog
{
	public class HttpAdapter : IHttpAdapter
	{
		private static readonly Parser UAParser = Parser.GetDefault();

		private readonly IHttpContextAccessor _httpContextAccessor;

		public HttpAdapter(IHttpContextAccessor httpContextAccessor) =>
			_httpContextAccessor = httpContextAccessor;

		public UserAgent UserAgent
		{
			get
			{
				if (_httpContextAccessor.HttpContext == null)
					return null;

				var userAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"];

				if (string.IsNullOrEmpty(userAgent))
				{
					return null;
				}

				var clientInfo = UAParser.Parse(userAgent);

				return new UserAgent
				{
					Name = userAgent,
					Original = userAgent,
					Device = new UserAgentDevice
					{
						Name = clientInfo.Device.ToString()
					},
					Os = new Os
					{
						Family = clientInfo.OS.Family,
						Full = clientInfo.OS.ToString(),
						Version = VersionString.Format(clientInfo.OS.Major, clientInfo.OS.Minor, clientInfo.OS.Patch, clientInfo.OS.PatchMinor),
					},
					Version = VersionString.Format(clientInfo.UA.Major, clientInfo.UA.Minor, clientInfo.UA.Patch)
				};
			}
		}

		public Http Http => _httpContextAccessor.HttpContext == null ? null : new Http
		{
			Request = new HttpRequest
			{
				Method = _httpContextAccessor.HttpContext.Request.Method,
				Bytes = _httpContextAccessor.HttpContext.Request.ContentLength,
				Body = GetRequestBody(),
				Referrer = _httpContextAccessor.HttpContext.Request.Headers["Referer"]
			},
			Response = new HttpResponse
			{
				Bytes = _httpContextAccessor.HttpContext.Response.ContentLength,
				StatusCode = _httpContextAccessor.HttpContext.Response.StatusCode,
				Body = GetResponseBody()
			}
		};

		private ResponseBody GetResponseBody() => null;
		// TODO!
		// return new ResponseBody
		// {
		//    Bytes = 0, //response?.OutputStream.Length ?? 0,
		//    Content = _httpContextAccessor.HttpContext.Response.Body
		// };

		private RequestBody GetRequestBody()
		{
			if (!_httpContextAccessor.HttpContext.Request.ContentLength.HasValue)
				return null;

			return new RequestBody
			{
				Bytes = _httpContextAccessor.HttpContext.Request.ContentLength,
				// Content = _httpContextAccessor.HttpContext.Request.Body
			};
		}

		public Url Url
		{
			get
			{
				if (_httpContextAccessor.HttpContext == null)
					return null;

				var uri = ConvertToUri(_httpContextAccessor.HttpContext.Request);

				return new Url
				{
					Path = _httpContextAccessor.HttpContext.Request.Path,
					Original = _httpContextAccessor.HttpContext.Request.Path,
					Full = uri.ToString(),
					Scheme = uri.Scheme,
					Query = string.IsNullOrEmpty(uri.Query) ? null : uri.Query,
					Domain = uri.Authority,
					Port = uri.Port
				};
			}
		}

		public Server Server
		{
			get
			{
				if (_httpContextAccessor.HttpContext == null)
					return null;

				var ip4 = _httpContextAccessor.HttpContext.Connection.LocalIpAddress.MapToIPv4();

				var uri = ConvertToUri(_httpContextAccessor.HttpContext.Request);

				return new Server
				{
					Address = ip4.ToString(),
					Ip = ip4.ToString(),
					Domain = uri.Authority
				};
			}
		}

		private static Uri ConvertToUri(Microsoft.AspNetCore.Http.HttpRequest request) =>
			new Uri($"{request.Scheme}://{request.Host}{request.Path}");

		public Client Client
		{
			get
			{
				if (_httpContextAccessor.HttpContext == null)
					return null;

				var ip4 = _httpContextAccessor.HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.MapToIPv4();

				return new Client
				{
					Address = ip4.ToString(),
					Ip = ip4.ToString(),
					Bytes = _httpContextAccessor.HttpContext.Request.ContentLength,
					User = User
				};
			}
		}

		public User User
		{
			get
			{
				if (_httpContextAccessor.HttpContext == null)
					return null;

				var idClaim = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.NameIdentifier);
				var nameClaim = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.Name);
				var hashClaim = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.Hash);
				var emailClaim = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.Email);
				var groupClaim = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.GroupSid);
				var groupId = groupClaim != null && groupClaim.Any() ? groupClaim.First().Value : null;

				var hasIdClaim = idClaim != null && idClaim.Any();
				var hasNameClaim = nameClaim != null && nameClaim.Any();
				var hasEmailClaim = emailClaim != null && emailClaim.Any();
				var hasHashClaim = hashClaim != null && hashClaim.Any();
				var hasGroupId = groupId != null;

				if (!hasIdClaim && !hasNameClaim && !hasEmailClaim && !hasHashClaim && !hasGroupId)
					return null;

				return new User
				{
					Id = hasIdClaim ? idClaim.First().Value : null,
					Name = hasNameClaim ? nameClaim.First().Value : null,
					Email = hasEmailClaim ? emailClaim.First().Value : null,
					Hash = hasHashClaim ? hashClaim.First().Value : null,
					Group = hasGroupId
								? new Group
								{
									Id = groupId
								}
								: null
				};
			}
		}

		public IEnumerable<Exception> Exceptions => Enumerable.Empty<Exception>();
	}
}
#endif
