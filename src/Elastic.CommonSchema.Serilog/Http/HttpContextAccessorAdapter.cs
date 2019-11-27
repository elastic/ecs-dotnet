#if DOTNETCORE
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;

namespace Elastic.CommonSchema.Serilog
{
    public class HttpAdapter : IHttpAdapter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HttpAdapter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserAgent UserAgent
        {
            get
            {
                var userAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"];
                return new UserAgent
                {
                    Name = userAgent,
                    Original = userAgent
                };                
            }
        }
        
        public Http Http => new Http
        {
            Request = new HttpRequest
            {
                Method = _httpContextAccessor.HttpContext.Request.Method,
                Bytes = _httpContextAccessor.HttpContext.Request.ContentLength,
                Body = new RequestBody
                {
                    Bytes = _httpContextAccessor.HttpContext.Request.ContentLength,
//                  Content = _httpContextAccessor.HttpContext.Request.Body
                },
                Referrer = _httpContextAccessor.HttpContext.Request.Headers["Referer"]
            },
            Response = new HttpResponse
            {
                Bytes = _httpContextAccessor.HttpContext.Response.ContentLength,
                StatusCode = _httpContextAccessor.HttpContext.Response.StatusCode,
//              Body = new ResponseBody
//              {
//                  Bytes = 0, //response?.OutputStream.Length ?? 0,
//                  Content = _httpContextAccessor.HttpContext.Response.Body
//              }
            }
        };

        public Url Url
        {
            get
            {
                var uri = new Uri(_httpContextAccessor.HttpContext.Request.Path);
                
                return new Url
                {
                    Path = _httpContextAccessor.HttpContext.Request.Path,
                    Original = _httpContextAccessor.HttpContext.Request.Path,
                    Full = uri.ToString(),
                    Scheme = uri.Scheme,
                    Query = uri.Query,
                    Domain = uri.Authority,
                    Port =  uri.Port
                };
            }
        }
        
        public Server Server => new Server
        {
            Domain = new Uri(_httpContextAccessor.HttpContext.Request.Path).Authority
        };

        public Client Client
        {
            get
            {
                var address = _httpContextAccessor.HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress.ToString();
                return new Client
                {
                    Address = address,
                    Ip = address,
                    Bytes = _httpContextAccessor.HttpContext.Request.ContentLength,
                    User = User
                };
            }
        }
        
        public User User
        {
            get
            {
                var idClaim = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.NameIdentifier);
                var nameClaim = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.Name);
                var hashClaim = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.Hash);
                var emailClaim = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.Email);
                var groupClaim = _httpContextAccessor.HttpContext.User.FindAll(ClaimTypes.GroupSid);

                var groupId = groupClaim != null && groupClaim.Any() ? groupClaim.First().Value : null;
                
                return new User
                {
                    Id = idClaim != null && idClaim.Any() ? new[] { idClaim.First().Value } : null,
                    Name = nameClaim != null && nameClaim.Any() ? nameClaim.First().Value : null,
                    Email = emailClaim != null && emailClaim.Any() ? emailClaim.First().Value : null,
                    Hash = hashClaim != null && hashClaim.Any() ? hashClaim.First().Value : null,
                    Group = groupId != null
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