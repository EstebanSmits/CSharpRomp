
using Microsoft.Extensions.Caching.Distributed;
using System.Diagnostics;

using Microsoft.AspNetCore.Mvc;
using System;

namespace CSharpRomp.Web.Controllers
{
    
    public class HomeController : Controller
    {
        private IDistributedCache _cache;
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult TestPage(IDistributedCache cache)
        {
            _cache = cache;

            string value = _cache.GetString("CacheTime");

            if (value == null)
            {
                value = DateTime.Now.ToString();
                var options = new DistributedCacheEntryOptions();
                options.SetSlidingExpiration(TimeSpan.FromMinutes(1));
                _cache.SetString("CacheTime", value, options);
            }
            ViewData["CacheTime"] = value;
            ViewData["CurrentTime"] = DateTime.Now.ToString();
            return View();
        }


        public IActionResult Error()
        {
            ViewData["RequestId"] = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
            return View();
        }
    }
}
