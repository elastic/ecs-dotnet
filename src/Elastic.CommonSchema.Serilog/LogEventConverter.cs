using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Threading;
using System.Web;
using Serilog.Core;
using Serilog.Events;

namespace Elastic.CommonSchema.Serilog
{
    /// <summary>
    /// Elastic Common Schema converter for LogEvent
    /// </summary>
    public class LogEventConverter
    {
        public static Base ConvertToEcs(LogEvent logEvent, ECSJsonFormatterDescriptor descriptor)
        {
            var request = HttpContext.Current?.Request;
            var response = HttpContext.Current?.Response;
            var exceptions = logEvent.Exception != null ? new[] {logEvent.Exception} : HttpContext.Current?.AllErrors;
            var currentUser = HttpContext.Current?.User;
            var currentThread = Thread.CurrentThread;

            var ecsEvent = new Base
            {
                Timestamp = logEvent.Timestamp,
                Ecs = new Ecs { Version = Base.Version },
                Log = GetLog(logEvent, exceptions),
                Agent = GetAgent(logEvent),
                Client = GetClient(request, currentUser),
                Event = GetEvent(logEvent),
                Error = GetError(exceptions),
                Http = GetHttp(request, response),
                Process = GetProcess(currentThread),
                Server = GetServer(logEvent, request),
                Url = GetUrl(request),
                User = GetUser(currentUser),
                UserAgent = GetUserAgent(request),
                Metadata = GetMetadata(logEvent)
            };

            return ecsEvent;
        }

        private static IDictionary<string, object> GetMetadata(LogEvent logEvent)
        {
            var dict = new Dictionary<string, object>();

            if (logEvent.Properties.TryGetValue("ActionPayload", out var actionPayload))
            {
                var logEventPropertyValues = (actionPayload as SequenceValue)?.Elements;

                if (logEventPropertyValues != null)
                {
                    foreach (var item in logEventPropertyValues?.Select(x => x.ToString()
                                          .Replace("\"", string.Empty)
                                          .Replace("\"", string.Empty)
                                          .Replace("[", string.Empty)
                                          .Replace("]", string.Empty)
                                          .Split(','))
                                      .Select(value => new {Key = value[0].Trim(), Value = value[1].Trim()}))
                    {
                        dict.Add(item.Key, item.Value);
                    }
                }
            }

            foreach (var logEventPropertyValue in logEvent.Properties)
            {
                if (logEventPropertyValue.Value is SequenceValue values)
                {
                    dict.Add(logEventPropertyValue.Key, values.Elements.Select(e => e.ToString()).ToArray());
                    continue;
                }
                
                dict.Add(logEventPropertyValue.Key, logEventPropertyValue.Value.ToString());
            }

            return dict;
        }

        private static UserAgent GetUserAgent(System.Web.HttpRequest request)
        {
            if (request == null)
                return null;
            
            return new UserAgent
            {
                Device = request.Browser != null
                            ? new UserAgentDevice
                            {
                                Name = request.Browser?.MobileDeviceModel
                            }
                            : null,
                Name = request.UserAgent,
                Original = request.UserAgent,
                Version = request.Browser?.Version
            };
        }

        private static User GetUser(IPrincipal currentUser)
        {
            if (currentUser?.Identity == null || string.IsNullOrEmpty(currentUser.Identity.Name))
                return null;

            return new User
            {
                Id = new[] { currentUser.Identity.Name },
                Name = currentUser.Identity.Name
            };
        }

        private static Url GetUrl(System.Web.HttpRequest request)
        {
            if (request == null)
                return null;
            
            return new Url
            {
                Original = request.RawUrl,
                Full = request.Url.ToString(),
                Path = request.Path,
                Scheme = request.Url.Scheme,
                Query = request.Url.Query,
                Domain = request.Url.Authority,
                Username = request.LogonUserIdentity?.Name,
                Port = request.Url.Port
            };
        }

        private static Server GetServer(LogEvent e, System.Web.HttpRequest request)
        {
            if (request == null)
                return null;

            var hasHost = e.Properties.TryGetValue("Host", out var host);
            
            return new Server
            {
                Domain = request.Url.Authority,
                User = e.Properties.TryGetValue("EnvironmentUserName", out var environmentUserName)
                    ? new User
                    {
                        Name = environmentUserName.ToString()
                    }
                    : null,
                Address = hasHost ? host.ToString() : null,
                Ip = hasHost ? host.ToString() : null
            };
        }

        private static Process GetProcess(Thread currentThread)
        {
            if (currentThread == null)
                return null;
            
            return new Process
            {
                Title = currentThread.Name,
                Name = currentThread.Name,
                Executable = currentThread.ExecutionContext.GetType().ToString(),
                Thread = new ProcessThread
                {
                    Id = currentThread.ManagedThreadId
                }
            };
        }

        private static Http GetHttp(System.Web.HttpRequest request, System.Web.HttpResponse response)
        {
            if (request == null && response == null)
                return null;
            
            return new Http
            {
                Request = request != null 
                    ? new HttpRequest
                    {
                        Method = request.HttpMethod,
                        Bytes = request.TotalBytes,
                        Body = new RequestBody
                        {
                            Bytes = request.TotalBytes,
                            Content = request.InputStream.ToString()
                        },
                        Referrer = request.UrlReferrer?.ToString()
                    }
                    : null,
                Response = response != null
                    ? new HttpResponse
                    {
                        // Bytes = 0, // response?.OutputStream.Length ?? 0,
                        StatusCode = response.StatusCode,
                        Body = new ResponseBody
                        {
                            // Bytes = 0, //response?.OutputStream.Length ?? 0,
                            Content = response.OutputStream.ToString()
                        }
                    }
                    : null
            };
        }

        private static Log GetLog(LogEvent e, Exception[] exceptions)
        {
            return new Log
            {
                Level = e.Level.ToString("F"),
                Logger = "Elastic.CommonSchema.Serilog"
                // TODO - walk stack trace for other information
            };
        }

        private static Error GetError(Exception[] exceptions)
        {
            return exceptions != null && exceptions.Length > 0
                ? new Error
                {
                    Message = exceptions[0].Message,
                    StackTrace = CatchErrors(exceptions),
                    Code = exceptions[0].GetType().ToString()
                }
                : null;
        }

        private static Event GetEvent(LogEvent e)
        {
            return new Event
            {
                Created = e.Timestamp,
                Timezone = TimeZone.CurrentTimeZone.StandardName,
                Category = e.Properties.ContainsKey("ActionCategory")
                    ? e.Properties["ActionCategory"].ToString()
                    : null,
                Action = e.Properties.ContainsKey("ActionName")
                    ? e.Properties["ActionName"].ToString().Replace("\"", "")
                    : null,
                Id = e.Properties.ContainsKey("ActionId")
                    ? e.Properties["ActionId"].ToString().Replace("\"", "")
                    : null,
                Kind = e.Properties.ContainsKey("ActionKind")
                    ? e.Properties["ActionKind"].ToString().Replace("\"", "")
                    : null,
                Severity = e.Properties.ContainsKey("ActionSeverity")
                    ? long.Parse(e.Properties["ActionSeverity"].ToString())
                    : 0
            };
        }

        private static Client GetClient(System.Web.HttpRequest request, IPrincipal currentUser)
        {
            if (request == null && currentUser == null)
                return null;
            
            return new Client
            {
                Address = request?.UserHostAddress,
                Ip = request?.UserHostAddress,
                Bytes = request?.TotalBytes,
                User = string.IsNullOrEmpty(currentUser?.Identity?.Name)
                    ? null
                    : new User
                    {
                        Name = currentUser.Identity?.Name
                    }
            };
        }

        private static Agent GetAgent(LogEvent e)
        {
            return e.Properties.ContainsKey("ApplicationId")
                   || e.Properties.ContainsKey("ApplicationName")
                   || e.Properties.ContainsKey("ApplicationType")
                   || e.Properties.ContainsKey("ApplicationVersion")
                ? new Agent
                {
                    Id = e.Properties.ContainsKey("ApplicationId")
                        ? e.Properties["ApplicationId"].ToString()
                        : null,
                    Name = e.Properties.ContainsKey("ApplicationName")
                        ? e.Properties["ApplicationName"].ToString()
                        : null,
                    Type = e.Properties.ContainsKey("ApplicationType")
                        ? e.Properties["ApplicationType"].ToString()
                        : null,
                    Version = e.Properties.ContainsKey("ApplicationVersion")
                        ? e.Properties["ApplicationVersion"].ToString()
                        : null
                }
                : null;
        }

        private static string CatchErrors(IReadOnlyCollection<Exception> errors)
        {
            if (errors == null || errors.Count <= 0)
                return string.Empty;

            var i = 1;
            var fullText = new StringWriter();
            foreach (var error in errors)
            {
                var frame = new StackTrace(error, true).GetFrame(0);

                fullText.WriteLine($"Exception {i++:D2} ===================================");
                fullText.WriteLine($"Type: {error.GetType()}");
                fullText.WriteLine($"Source: {error.TargetSite?.DeclaringType?.AssemblyQualifiedName}");
                fullText.WriteLine($"Message: {error.Message}");
                fullText.WriteLine($"Trace: {error.StackTrace}");
                fullText.WriteLine($"Location: {frame.GetFileName()}");
                fullText.WriteLine(
                    $"Method: {frame.GetMethod()} ({frame.GetFileLineNumber()}, {frame.GetFileColumnNumber()})");

                var exception = error.InnerException;
                while (exception != null)
                {
                    frame = new StackTrace(exception, true).GetFrame(0);
                    fullText.WriteLine($"\tException {i:D2} inner --------------------------");
                    fullText.WriteLine($"\tType: {exception.GetType()}");
                    fullText.WriteLine($"\tSource: {exception.TargetSite?.DeclaringType?.AssemblyQualifiedName}");
                    fullText.WriteLine($"\tMessage: {exception.Message}");
                    fullText.WriteLine($"\tLocation: {frame.GetFileName()}");
                    fullText.WriteLine(
                        $"\tMethod: {frame.GetMethod()} ({frame.GetFileLineNumber()}, {frame.GetFileColumnNumber()})");

                    exception = exception.InnerException;
                }
            }

            return fullText.ToString();
        }
    }
}