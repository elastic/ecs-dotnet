// Licensed to Elasticsearch B.V under one or more agreements.
// Elasticsearch B.V licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information

using Serilog;

namespace Elastic.CommonSchema.Serilog.Test
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            global::Serilog.Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(new EcsTextFormatter())
                .CreateLogger();

            global::Serilog.Log.Information("Hello, world {0} {1}!", new [] { "param1", "param2" });
        }
    }
}
