using System;
using Microsoft.Extensions.Configuration;
using CSharpRomp.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CSharpRomp
{
    class Program
    {
        static void Main(string[] args)
        {
         
            IServiceCollection services = new ServiceCollection();
            // Startup.cs finally :)
            var startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            //configure console logging
            serviceProvider
                .GetService<ILoggerFactory>()  ;

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();

            logger.LogDebug("Logger is working!");

            // Get Service and call method
            var service = serviceProvider.GetService<ILocallizedServices>();
             service.MyServiceMethod();
            var configuration= serviceProvider.GetService<IConfigurationRoot>();


            Console.WriteLine(configuration.GetConnectionString("daxmaxdb"));
            var _cities = new Cities();

            Console.ReadLine();
        }
    }
}
