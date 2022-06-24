using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Models.Chart
{
    public class ProductCategoriesModel
    {
        public ProductCategoriesModel(string year, int vacantLand, int residentialProperties, int commercialProperties, int total)
        {
            Year = year;
            VacantLand = vacantLand;
            ResidentialProperties = residentialProperties;
            CommercialProperties = commercialProperties;
            Total = total;
        }

        public string Year { get; set; }
        public int VacantLand { get; set; }
        public int ResidentialProperties { get; set; }
        public int CommercialProperties { get; set; }
        public int Total { get; set; }
    }
}
