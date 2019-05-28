using DemoFunction.Configurations;
using DemoFunction.Repositories;
using DemoFunction.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using System;

[assembly: FunctionsStartup(typeof(DemoFunction.Startup))]

namespace DemoFunction
{
    public class Startup : FunctionsStartup
    {
        public Startup()
        {
            // Initialize serilog logger
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.Trace()
                .MinimumLevel.Debug()
                .CreateLogger();
        }

        public override void Configure(IFunctionsHostBuilder builder)
        {
            /* It looks like configuration builder is already done out of the box, so the code
            ** below is no longer required in order to read from local.settings.json, environment, etc
            */
            //var config = new ConfigurationBuilder()
            //    .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
            //    .AddEnvironmentVariables()
            //    .Build();

            // Depedency Injecting loggers in Azure Functions V2
            // https://github.com/Azure/azure-functions-host/issues/4425
            // https://stackoverflow.com/questions/55916750/serilog-in-azure-functions
            // https://blog.bitscry.com/2019/04/05/dependency-injection-in-azure-functions/
            // https://asp.net-hacker.rocks/2017/05/05/add-custom-logging-in-aspnetcore.html

            var messageConfiguration = new MessageConfiguration
            {
                HelloMessage = Environment.GetEnvironmentVariable("HelloMessage"),
                GoodbyeMessage = Environment.GetEnvironmentVariable("GoodbyeMessage")
            };

            builder.Services.AddScoped<IMessageRepository>(m => {
                 return new MessageRepository(messageConfiguration);
            });
            builder.Services.AddScoped<IMessageService, MessageService>();
            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSerilog();
            });
        }
    }
}
