using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using CSharpRomp.Models;
using System;
using System.Linq;

namespace CSharpRomp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            // Startup.cs finally :)
            var startup = new Startup();
            startup.ConfigureServices(services);
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            //configure console logging
             serviceProvider.GetService<ILoggerFactory>();
             var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger<Program>();
             logger.LogDebug("Logger is working!");
            // Get Service and call method
            var service = serviceProvider.GetService<ILocalizedServices>();
            
            service.MyServiceMethod();
            var configuration = serviceProvider.GetService<IConfigurationRoot>();
            var context= serviceProvider.GetService<WideWorldImportersContext>();
             IQueryable<Countries> myCities = context.Countries;
            Console.WriteLine(configuration.GetConnectionString("daxmaxdb"));

            Console.ReadLine();
        }
    }
}