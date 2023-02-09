using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

/* 1. Add using */
using Elasticsearch.Extensions.Logging;

namespace ConsoleExample
{
    public class Program
    {
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseConsoleLifetime()
                .ConfigureAppConfiguration((_, configurationBuilder) =>
                {
                    configurationBuilder.SetBasePath(AppDomain.CurrentDomain.BaseDirectory);
                })
                .ConfigureLogging((_, loggingBuilder) =>
                {
                    /* 2. Add logger provider */
                    loggingBuilder.AddElasticsearch();

                    // The default configuration section is "Elasticsearch"; if you want
                    // a different section, you can manually configure:
                    // loggingBuilder.AddElasticsearch(options =>
                    //     hostContext.Configuration.Bind("Logging:CustomElasticsearch", options));
                })
                .ConfigureServices((_, services) =>
                {
                    services.AddHostedService<Worker>();
                });

        public static async Task Main(string[] args)
        {
            Activity.DefaultIdFormat = ActivityIdFormat.W3C;
            await CreateHostBuilder(args).Build().RunAsync();
        }
    }
}
