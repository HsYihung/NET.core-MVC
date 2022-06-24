using CoreMVCWebSite.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Caching.Memory;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IMemoryCache _cache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _cache = memoryCache;
        }

        public IActionResult Index()
        {
            //Read Cookie
            string CookieValue = HttpContext.Request.Cookies["CookieKey"];

            //Read Session
            if (HttpContext.Session.Keys.Contains("SessionKey"))
            {
                string SessionValue = HttpContext.Session.GetString("SessionKey");
            }

            //Read Cache]
            object CacheValue;
            if (_cache.TryGetValue("CacheKey", out CacheValue))
            {
                string CacheData = Convert.ToString(CacheValue);
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Input()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Contact()
        {
            //Write Cookie
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddDays(1);
            HttpContext.Response.Cookies.Append("CookieKey", "CookieValue", option);

            //Write Session
            HttpContext.Session.SetString("SessionKey", "SessionValue");

            //Set Cache
            MemoryCacheEntryOptions CacheEntryOptions = new MemoryCacheEntryOptions();
            CacheEntryOptions.SetSlidingExpiration(TimeSpan.FromSeconds(60));

            // Save data in cache.
            _cache.Set("CacheKey", "CacheValue", CacheEntryOptions);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Contact(string Name, string Email) 
        public RedirectToActionResult Contact(string Name, string Email)
        {
            return RedirectToAction(nameof(Index));
            //return View("ContactForm");
        }
    }
}
