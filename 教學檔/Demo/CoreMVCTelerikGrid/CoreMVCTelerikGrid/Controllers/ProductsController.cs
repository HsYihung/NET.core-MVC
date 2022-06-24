using CoreMVCTelerikGrid.Models;
using CoreMVCTelerikGrid.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCTelerikGrid.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            return View(GetProducts());
        }

        NorthwindContext _context = new NorthwindContext();
        private IEnumerable<ProductViewModel> GetProducts()
        {
            var query = from p in _context.Products
                        select new ProductViewModel
                        {
                            ProductId = p.ProductId,
                            ProductName = p.ProductName,
                            CategoryId = p.CategoryId,
                            UnitPrice = p.UnitPrice,
                            Discontinued = p.Discontinued
                        };
            return query;
        }
    }
}
