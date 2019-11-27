using System;
using System.Collections.Generic;

namespace Elastic.CommonSchema.Serilog
{
    public interface IHttpAdapter
    {
        UserAgent UserAgent { get; }
        Http Http { get; }
        Url Url { get; }
        Server Server { get; }
        Client Client { get; }
        User User { get; }
        IEnumerable<Exception> Exceptions { get; }
    }
}