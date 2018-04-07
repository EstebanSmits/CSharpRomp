using System;
using Microsoft.Extensions.Configuration;
using CSharpRomp.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CSharpRomp
{
    class Startup
    {
        IConfigurationRoot Configuration { get; }
        IConfigurationBuilder builder { get; }
        public Startup()
        {
            builder = new ConfigurationBuilder()
           .SetBasePath(Environment.CurrentDirectory)
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();

        }
        public void ConfigureServices(IServiceCollection services)
        {
       //     services.AddMvc
            var connection = Configuration.GetConnectionString("daxmaxdb");
            services.AddDbContext<WideWorldImportersContext>(options => options.UseSqlServer(connection));
            

            services.AddLogging();
            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.AddSingleton<ILocalizedServices,LocallizedServices>();
        }
    }
}
