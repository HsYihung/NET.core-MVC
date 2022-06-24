using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Models.Chart
{
    public class ChartOverviewDataRepository
    {
        public static IEnumerable<ProductCategoriesModel> ProductCategoriesData()
        {
            return new ProductCategoriesModel[] {
                new ProductCategoriesModel("2010", 2085200, 3080700, 1485700, 6651600),
                new ProductCategoriesModel("2011", 2091800, 3386400, 1525800, 7004000),
                new ProductCategoriesModel("2012", 3002100, 2627000, 1095500, 6724600),
                new ProductCategoriesModel("2013", 3008000, 4389700, 1907500, 9305200),
                new ProductCategoriesModel("2014", 3015000, 3443900, 1570000, 8028900),
                new ProductCategoriesModel("2015", 3035000, 2302500, 2117600, 7455100),
                new ProductCategoriesModel("2016", 3042000, 2983100, 2329700, 8354800),
                new ProductCategoriesModel("2017", 3044400, 3052200, 2756800, 8853400),
                new ProductCategoriesModel("2018", 3057800, 2611200, 3220300, 8889300),
                new ProductCategoriesModel("2019", 3087800, 2211200, 3020300, 8319300)
            };
        }

        public static IEnumerable<FunnelSalesModel> FunnelSalesData()
        {
            return new FunnelSalesModel[] {
                new FunnelSalesModel("Impressions", 35319300),
                new FunnelSalesModel("Listed Properties", 15319300),
                new FunnelSalesModel("Properties Shown", 12319300),
                new FunnelSalesModel("Total Sales", 8319300)
            };
        }

        public static IEnumerable<RegionSalesModel> RegionSalesData()
        {
            return new RegionSalesModel[] {
                new RegionSalesModel("Africa", 17.6),
                new RegionSalesModel("Middle East", 9.2),
                new RegionSalesModel("North America", 4.6),
                new RegionSalesModel("Asia", 30.8),
                new RegionSalesModel("Europe", 21.1),
                new RegionSalesModel("Latin America", 16.3)
            };
        }

        public static IList<SalesPerformersModel> SalesPerformers()
        {
            return new SalesPerformersModel[] {
                new SalesPerformersModel("John Smith", 1594000),
                new SalesPerformersModel("Annie Johnson", 1860500),
                new SalesPerformersModel("Christine Quinn", 1035000),
                new SalesPerformersModel("Sophia Williams", 980000),
                new SalesPerformersModel("Jacob Martinez", 1780000)
            };
        }
    }
}
