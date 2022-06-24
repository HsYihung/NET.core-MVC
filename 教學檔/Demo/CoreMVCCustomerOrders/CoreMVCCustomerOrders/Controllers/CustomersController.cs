using CustomerOrders.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerOrders.Controllers
{
    public class CustomersController : Controller
    {
        public IActionResult Index()
        {
            NorthwindContext dc = new NorthwindContext();
            ViewBag.CustomerId = new SelectList(dc.Customers, "CustomerId", "CompanyName");
            return View();
        }

        public async Task<IActionResult> Orders(string id)
        {
            NorthwindContext dc = new NorthwindContext();
            Customer c = await dc.Customers.FindAsync(id);
            return PartialView("_OrdersPartial", c.Orders);
        }
    }
}
