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

        public HomeController(ILogger<HomeController> logger,IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        string sessionKey = "SessionKey";
        string cacheKey = "Cackey";
        string cookieKey = "cookieKey";
        public IActionResult Index()
        {

            //ViewBag.Name = "Name";
            //ViewBag.Email = "Eamil";
            //ViewBag.C126 = "C126";
            HttpContext.Session.SetString(sessionKey, "SeetionValue");
            HttpContext.Session.SetInt32("SessionValue", 744);

            MemoryCacheEntryOptions CaceOptions = new MemoryCacheEntryOptions();
            CaceOptions.SetSlidingExpiration(TimeSpan.FromSeconds(60));
            _cache.Set(cacheKey, "cacheValue");

            CookieOptions co = new CookieOptions();
            co.Expires = DateTime.Now.AddYears(1);
            co.HttpOnly = true;
            co.Secure = true;
            HttpContext.Response.Cookies.Append(cookieKey, "CookieValue", co);

            return View();
        }

        public IActionResult Privacy()
        {
            ViewBag.JavaScript = $"alert('Name:{@TempData["Name"]} Email:{@TempData["Email"]}')";
            if(HttpContext.Session.Keys.Contains(sessionKey))
                {
                   string SessionValue = HttpContext.Session.GetString(sessionKey);
                }

            object CacheData;
            if(_cache.TryGetValue(cacheKey,out CacheData))
            {
                string CacheValue = Convert.ToString(CacheData);
            }

            string CoockieVaule = Request.Cookies[cookieKey];

            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public RedirectToActionResult Contact([Bind("Name,Email")]ContactModel cm)
        {
            //Bind 白名單驗證法
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
