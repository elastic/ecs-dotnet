// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

#if NETSTANDARD
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Features;
using UAParser;

namespace Elastic.CommonSchema.Serilog.Adapters
{
	/// <inheritdoc cref="IHttpAdapter"/>
	public class HttpAdapter : IHttpAdapter
	{
		private static readonly Parser UAParser = Parser.GetDefault();

		private readonly IHttpContextAccessor _httpContextAccessor;

		/// <inheritdoc cref="IHttpAdapter"/>
		public HttpAdapter(IHttpContextAccessor httpContextAccessor) =>
			_httpContextAccessor = httpContextAccessor;

		/// <inheritdoc cref="IHttpAdapter.HasContext"/>
		public bool HasContext => _httpContextAccessor?.HttpContext != null;

		/// <inheritdoc cref="IHttpAdapter.UserAgent"/>
		public UserAgent UserAgent
		{
			get
			{
				if (!HasContext)
					return null;

				var userAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"];

				if (string.IsNullOrEmpty(userAgent)) return null;

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

		/// <inheritdoc cref="IHttpAdapter.Http"/>
		public Http Http
		{
			get
			{
				if (!HasContext)
					return null;

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

		// ReSharper disable once UnusedParameter.Local
		private void SetResponseBody(Http http)
		{
			// if (!HasContext) return;

			// TODO!
			// http.ResponseBodyBytes = 0, //response?.OutputStream.Length ?? 0,
			// http.ResponseBodyContent  = _httpContextAccessor.HttpContext.Response.Body
		}

		private void SetRequestBody(Http http)
		{
			if (!HasContext) return;

			if (!_httpContextAccessor.HttpContext.Request.ContentLength.HasValue)
				return;

			http.RequestBodyBytes = _httpContextAccessor.HttpContext.Request.ContentLength;
			//TODO!
			// http.RequestBodyContent = _httpContextAccessor.HttpContext.Request.Body
		}

		/// <inheritdoc cref="IHttpAdapter.Url"/>
		public Url Url
		{
			get
			{
				if (!HasContext) return null;

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

		/// <inheritdoc cref="IHttpAdapter.Server"/>
		public Server Server
		{
			get
			{
				if (!HasContext)
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

		/// <inheritdoc cref="IHttpAdapter.Client"/>
		public Client Client
		{
			get
			{
				if (!HasContext)
					return null;

				var ip4 = _httpContextAccessor.HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.MapToIPv4();

				return new Client
				{
					Address = ip4?.ToString(),
					Ip = ip4?.ToString(),
					Bytes = _httpContextAccessor.HttpContext.Request.ContentLength,
					User = User
				};
			}
		}

		/// <inheritdoc cref="IHttpAdapter.User"/>
		public User User
		{
			get
			{
				if (!HasContext)
					return null;

				var idClaims = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.NameIdentifier);
				var nameClaims = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.Name);
				var hashClaims = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.Hash);
				var emailClaims = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.Email);
				var groupClaims = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.GroupSid);

				var groupId = groupClaims?.FirstOrDefault()?.Value;
				var idClaim = idClaims?.FirstOrDefault()?.Value;
				var nameClaim = nameClaims?.FirstOrDefault()?.Value;
				var emailClaim = emailClaims?.FirstOrDefault()?.Value;
				var hashClaim = hashClaims?.FirstOrDefault()?.Value;

				if (groupId == null && nameClaim == null && emailClaim == null && hashClaim == null && idClaim == null)
					return null;

				return new User
				{
					Id = idClaim,
					Name = nameClaim,
					Email = emailClaim,
					Hash = hashClaim,
					Group = groupId != null ? new Group { Id = groupId } : null
				};
			}
		}
	}
}
#endif
