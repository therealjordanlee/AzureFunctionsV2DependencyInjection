using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: FunctionsStartup(typeof(DemoFunction.Startup))]

namespace DemoFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            // Configurations
            // https://blog.jongallant.com/2018/01/azure-function-config/
            // https://www.koskila.net/how-to-access-azure-function-apps-settings-from-c/
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?view=aspnetcore-2.2

            //var config = new ConfigurationBuilder()
            //    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            //    .AddEnvironmentVariables()
            //    .Build();

            var helloMessage = Environment.GetEnvironmentVariable("HelloMessage");

            Console.WriteLine("in startup");

            //builder.Services
            //    .Configure
        }
    }
}
