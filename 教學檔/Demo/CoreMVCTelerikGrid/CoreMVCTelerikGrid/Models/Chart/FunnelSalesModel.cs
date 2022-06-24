using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Models.Chart
{
    public class FunnelSalesModel
    {
        public FunnelSalesModel(string category, int value)
        {
            Category = category;
            Value = value;
        }
        public string Category { get; set; }

        public int Value { get; set; }
    }
}
