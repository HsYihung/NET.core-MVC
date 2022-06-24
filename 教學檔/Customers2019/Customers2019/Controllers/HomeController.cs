using Customers2019.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Customers2019.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache _cache;

        public HomeController(ILogger<HomeController> logger, IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        string SessionKey = "SessionKey";
        string CacheKey = "CacheKey";
        string CookieKey = "CookieKey";

        public IActionResult Index()
        {
            HttpContext.Session.SetString(SessionKey, "SessionValue");
            MemoryCacheEntryOptions CacheOptions = new MemoryCacheEntryOptions();
            CacheOptions.SetSlidingExpiration(TimeSpan.FromSeconds(60));
            _cache.Set(CacheKey, "CacheValue", CacheOptions);

            CookieOptions co = new CookieOptions();
            co.Expires = DateTime.Now.AddYears(1);
            co.HttpOnly = true;
            co.Secure = true;

            Response.Cookies.Append(CookieKey, "CookieValue", co);
            return View();
        }

        public IActionResult Privacy()
        {
            if(HttpContext.Session.Keys.Contains(SessionKey))
            {
                string SessionValue=HttpContext.Session.GetString(SessionKey);
            }

            object CacheData;
            if (_cache.TryGetValue(CacheKey, out CacheData))
            {
                string CacheValue = Convert.ToString(CacheData);
            }

            string CookieValue=Request.Cookies[CookieKey];
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult Contact([Bind("Name,Email")] ContactModel cm)
        {
            if (ModelState.IsValid)
            {
                TempData["Name"] = cm.Name;
                TempData["Email"] = cm.Email;
            }
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
