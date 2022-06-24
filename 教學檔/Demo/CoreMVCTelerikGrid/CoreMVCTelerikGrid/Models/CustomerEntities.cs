using CoreMVCTelerikGrid;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Models
{
    public class CustomerEntitiesDataContext : DbContext
    {
        public CustomerEntitiesDataContext() : base(new DbContextOptions<CustomerEntitiesDataContext>())
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //var dataDirectory = Path.Combine(Startup.WebRootPath, "App_Data");

            //options.UseSqlite(@"Data Source=" + dataDirectory + System.IO.Path.DirectorySeparatorChar + @"customers.db;");
            IConfigurationRoot Configuration =
            new ConfigurationBuilder()
              .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
              .AddJsonFile("appsettings.json")
              .Build();
                    optionsBuilder.UseSqlServer(
                        Configuration.GetConnectionString("Northwind"));
        }
        public virtual DbSet<Kendo.Mvc.Examples.Models.Grid.Customer> Customers { get; set; }
    }
}
