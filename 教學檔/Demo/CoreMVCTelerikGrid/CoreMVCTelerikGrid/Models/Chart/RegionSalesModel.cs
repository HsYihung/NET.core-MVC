using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Models.Chart
{
    public class RegionSalesModel
    {
        public RegionSalesModel(string region, double sales)
        {
            Region = region;
            Sales = sales;
        }

        public string Region { get; set; }
        public double Sales { get; set; }
    }
}
