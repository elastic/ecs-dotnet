// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

#if NETSTANDARD
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
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
					Name = clientInfo.UA.Family,
					Original = userAgent,
					DeviceName = clientInfo.Device.ToString(),
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

		public Http Http
		{
			get
			{
				if (_httpContextAccessor.HttpContext == null)
					return null;
				else
				{
					var http = new Http
					{
						RequestMethod = _httpContextAccessor.HttpContext.Request.Method,
						RequestBytes = _httpContextAccessor.HttpContext.Request.ContentLength,
						RequestReferrer = _httpContextAccessor.HttpContext.Request.Headers["Referer"],
						ResponseStatusCode = _httpContextAccessor.HttpContext.Response.StatusCode,
					};
					SetResponseBody(http);
					SetRequestBody(http);
					return http;
				}
			}
		}

		private void SetResponseBody(Http http)
		{
		// TODO!
		// http.ResponseBodyBytes = 0, //response?.OutputStream.Length ?? 0,
		// http.ResponseBodyContent  = _httpContextAccessor.HttpContext.Response.Body
		}

		private void SetRequestBody(Http http)
		{
			if (!_httpContextAccessor.HttpContext.Request.ContentLength.HasValue)
				return;

			http.RequestBodyBytes = _httpContextAccessor.HttpContext.Request.ContentLength;
			//TODO!
			// http.RequestBodyContent = _httpContextAccessor.HttpContext.Request.Body
		}

		public Url Url
		{
			get
			{
				if (_httpContextAccessor.HttpContext == null)
					return null;

				var request = _httpContextAccessor.HttpContext.Request;

				return new Url
				{
					Path = request.Path,
					Original = request.GetDisplayUrl(),
					Full = request.GetDisplayUrl(),
					Scheme = request.Scheme,
					Query = request.QueryString.HasValue ? request.QueryString.Value.TrimStart('?') : null,
					Domain = request.Host.HasValue ? request.Host.Host : null,
					Port = request.Host.HasValue ? request.Host.Port : null
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

				var request = _httpContextAccessor.HttpContext.Request;

				return new Server
				{
					Address = ip4.ToString(),
					Ip = ip4.ToString(),
					Domain = request.Host.HasValue ? request.Host.Host : null
				};
			}
		}

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
