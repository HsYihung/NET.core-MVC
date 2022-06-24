using pcg2019.Resource;
using System.ComponentModel.DataAnnotations;

namespace pcg2019.Models
{
    internal class ProductsMetadata
    {
        [Required(ErrorMessageResourceType =typeof(WebResource),ErrorMessageResourceName ="ProductNameEmpty")]
        [Display(Name = "ProductName", ResourceType = typeof(WebResource))]
        [StringLength(40, ErrorMessage ="{0}最多輸入{1}個字元")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "{0}未填寫")]
        [Display(Name = "商品單價")]
        [DisplayFormat(DataFormatString = "{0:C0}")]        
        public decimal? UnitPrice { get; set; }

        [Display(Name = "訂購單位")]
        [Range(1,100,ErrorMessage ="{0} 最少{1}最多{2}")]
        public short? UnitsOnOrder { get; set; }
    }
}