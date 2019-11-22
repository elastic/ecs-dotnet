using System;
using Serilog;

namespace Elastic.CommonSchema.Serilog.Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(new ECSJsonFormatter())
                .CreateLogger();
            
            Log.Information("Hello, world {0} {1}!", new [] { "param1", "param2" });

        }
    }
}