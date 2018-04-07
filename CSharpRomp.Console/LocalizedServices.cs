
using System;
using Microsoft.Extensions.Configuration;
using CSharpRomp.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
namespace CSharpRomp
{

    public class LocallizedServices : ILocalizedServices

    {
        private readonly string _baseUrl;
        private readonly string _token;
        private readonly ILogger<LocallizedServices> _logger;

        public LocallizedServices(ILoggerFactory loggerFactory, IConfigurationRoot config)
        {
            var baseUrl = config["Logging:BaseUrl"];
            var token = config["Logging:Token"];

            _baseUrl = baseUrl;
            _token = token;
            _logger = loggerFactory.CreateLogger<LocallizedServices>();
        }

        public async Task MyServiceMethod()
        {
           _logger.LogDebug(_baseUrl);
            _logger.LogDebug(_token);
        }
    }

    public interface ILocalizedServices
    {
        Task MyServiceMethod();
    }
}