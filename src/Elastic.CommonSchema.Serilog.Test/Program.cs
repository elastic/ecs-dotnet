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