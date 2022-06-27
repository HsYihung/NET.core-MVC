using CustomerOrder2019.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerOrder2019.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            NorthwindContext dc = new NorthwindContext();
            ViewBag.CustomerID = new SelectList(dc.Customers,"CustomerId","CompanyName" );
            return View();
        }

        public async Task<IActionResult> Orders(string id)
        {
            NorthwindContext dc = new NorthwindContext();
            Customers c = await dc.Customers.FindAsync(id);
            return PartialView("_OrdersPartal", c.Orders);
        }
    }
}
