// AspNetCoreOData(https://github.com/OData/AspNetCoreOData)

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using CoreODataApi.Models;

namespace CoreODataApi.Controllers
{
    [EnableQuery()]
    [EnableCors("AllowOrigin")]
    public class CustomersController : ODataController
    {
        private readonly NorthwindContext _context;

        public CustomersController(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetCustomers()
        {
            return Ok(_context.Customers);
        }

        [ODataRoute("Customers({CustomerId})")]
        public async Task<IActionResult> GetCustomers(string CustomerId)
        {
            return Ok(await _context.Customers.FindAsync(CustomerId));
        }
    }
}
