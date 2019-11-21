using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Web;
using Serilog.Core;
using Serilog.Events;

namespace Elastic.CommonSchema.Serilog
{
    /// <summary>
    /// Elastic Common Schema Enricher that reformats the log message to incorporate.
    /// https://github.com/serilog/serilog/wiki/Configuration-Basics#enrichers
    /// </summary>
    public class ECSEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent == null) throw new ArgumentNullException(nameof(logEvent));

            var ecsProperties = ConvertToEcs(logEvent, propertyFactory);

            // Remove existing properties
            foreach (var property in logEvent.Properties.Select(x => x.Key).ToList())
                logEvent.RemovePropertyIfPresent(property);

            // Add the ECS properties
            foreach (var property in ecsProperties.OrderBy(x => x.Key))
                logEvent.AddPropertyIfAbsent(property.Value);
        }

        private static Dictionary<string, LogEventProperty> ConvertToEcs(LogEvent e,
            ILogEventPropertyFactory propertyFactory)
        {
            var ecsModel = ConvertToEcs(e);
            var properties = MapToDictionary(ecsModel, null, propertyFactory);
            return properties;
        }

        private static Dictionary<string, LogEventProperty> MapToDictionary(object source, string name,
            ILogEventPropertyFactory propertyFactory)
        {
            var dictionary = new Dictionary<string, LogEventProperty>();
            MapToDictionaryInternal(dictionary, source, name, propertyFactory);
            return dictionary;
        }

        private static void MapToDictionaryInternal(
            IDictionary<string, LogEventProperty> dictionary, object source, string name,
            ILogEventPropertyFactory propertyFactory)
        {
            var properties = source.GetType().GetProperties();
            foreach (var p in properties)
            {
                var value = p.GetValue(source, null);
                if (value == null) continue;

                var key = string.IsNullOrEmpty(name) ? p.Name : $"{name}.{p.Name}";

                var valueType = value.GetType();

                if (valueType.IsPrimitive || valueType == typeof(string) ||
                    valueType == typeof(DateTime) || valueType == typeof(DateTimeOffset))
                {
                    dictionary[key] = propertyFactory.CreateProperty(key, value);
                }
                else if (value is IEnumerable enumerable)
                {
                    var index = 0;
                    foreach (var o in enumerable)
                    {
                        if (o is string || o is DateTime || o is DateTimeOffset)
                        {
                            dictionary[$"{key}[{index}]"] = propertyFactory.CreateProperty($"{key}[{index}]", o);
                            index++;
                            continue;
                        }

                        MapToDictionaryInternal(dictionary, o, key + "[" + index + "]", propertyFactory);
                        index++;
                    }
                }
                else
                {
                    MapToDictionaryInternal(dictionary, value, key, propertyFactory);
                }
            }
        }

        private static Base ConvertToEcs(LogEvent e)
        {
            var request = HttpContext.Current?.Request;
            var response = HttpContext.Current?.Response;
            var exceptions = e.Exception != null ? new[] {e.Exception} : HttpContext.Current?.AllErrors;
            var currentUser = HttpContext.Current?.User;
            var currentThread = Thread.CurrentThread;

            var ecsEvent = new Base
            {
                Ecs = new Ecs {Version = "1.2.0"},
                Timestamp = e.Timestamp,
                Log = GetLog(e, exceptions),
                Agent = GetAgent(e),
                Client = GetClient(request, currentUser),
                Event = GetEvent(e),
                Error = GetError(exceptions),
                Http = GetHttp(request, response),
                Process = GetProcess(currentThread),
                Server = GetServer(e, request),
                Url = GetUrl(request),
                User = GetUser(currentUser),
                UserAgent = GetUserAgent(request),
                Metadata = GetMetadata(e)
            };

            return ecsEvent;
        }

        private static IDictionary<string, object> GetMetadata(LogEvent logEvent)
        {
            return logEvent.Properties.ContainsKey("ActionPayload")
                ? (logEvent.Properties["ActionPayload"] as SequenceValue)?.Elements
                .Select(x => x.ToString()
                    .Replace("\"", string.Empty)
                    .Replace("\"", string.Empty)
                    .Replace("[", string.Empty)
                    .Replace("]", string.Empty)
                    .Split(','))
                .Select(value => new { Key = value[0].Trim(), Value = value[1].Trim() })
                .ToDictionary(e => e.Key, e => e.Value as object)
                : null;
        }

        private static UserAgent GetUserAgent(System.Web.HttpRequest request)
        {
            return new UserAgent
            {
                Device = new UserAgentDevice
                {
                    Name = request?.Browser?.MobileDeviceModel
                },
                Name = request?.UserAgent,
                Original = request?.UserAgent,
                Version = request?.Browser?.Version
            };
        }

        private static User GetUser(IPrincipal currentUser)
        {
            return string.IsNullOrEmpty(currentUser?.Identity?.Name)
                ? null
                : new User
                {
                    Id = new[] {currentUser?.Identity?.Name},
                    Name = currentUser?.Identity?.Name,
                    Email = currentUser?.Identity?.Name
                };
        }

        private static Url GetUrl(System.Web.HttpRequest request)
        {
            return new Url
            {
                Original = request?.RawUrl,
                Full = request?.Url.ToString(),
                Path = request?.Path,
                Scheme = request?.Url.Scheme,
                Query = request?.Url?.Query,
                Domain = request?.Url?.Authority,
                Username = request?.LogonUserIdentity?.Name,
                Port = request?.Url?.Port ?? 0
            };
        }

        private static Server GetServer(LogEvent e, System.Web.HttpRequest request)
        {
            return new Server
            {
                Domain = request?.Url?.Authority,
                User = e.Properties.TryGetValue("EnvironmentUserName", out var environmentUserName)
                    ? new User
                    {
                        Name = environmentUserName.ToString()
                    }
                    : null,
                Address = e.Properties.ContainsKey("Host")
                    ? e.Properties["Host"].ToString()
                    : null,
                Ip = e.Properties.ContainsKey("Host")
                    ? e.Properties["Host"].ToString()
                    : null
            };
        }

        private static Process GetProcess(Thread currentThread)
        {
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
            return new Http
            {
                Request = new HttpRequest
                {
                    Method = request?.HttpMethod,
                    Bytes = request?.TotalBytes ?? 0,
                    Body = new RequestBody
                    {
                        Bytes = request?.TotalBytes ?? 0,
                        Content = request?.InputStream.ToString()
                    },
                    Referrer = request?.UrlReferrer?.ToString()
                },
                Response = new HttpResponse
                {
                    // Bytes = 0, // response?.OutputStream.Length ?? 0,
                    StatusCode = response?.StatusCode ?? 0,
                    Body = new ResponseBody
                    {
                        // Bytes = 0, //response?.OutputStream.Length ?? 0,
                        Content = response?.OutputStream.ToString()
                    }
                }
            };
        }

        private static Log GetLog(LogEvent e, Exception[] exceptions)
        {
            return new Log
            {
                Level = e.Level.ToString("f"),
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
                Created = DateTime.UtcNow,
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
                    : 0,
                Timezone = TimeZone.CurrentTimeZone.StandardName
            };
        }

        private static Client GetClient(System.Web.HttpRequest request, IPrincipal currentUser)
        {
            return new Client
            {
                Address = request?.UserHostAddress,
                Ip = request?.UserHostAddress,
                Bytes = request?.TotalBytes ?? 0,
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