using ASP.NETCoreMVCChart.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NETCoreMVCChart.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCustomersCount()
        {
            NorthwindContext _context = new NorthwindContext();
            var query = _context.Customers.GroupBy(c => c.Country).Select(g => new CustomerCount
            {
                Country = g.Key,
                Count = g.Count()
            });
            return Json(query);
        }
    }
}
