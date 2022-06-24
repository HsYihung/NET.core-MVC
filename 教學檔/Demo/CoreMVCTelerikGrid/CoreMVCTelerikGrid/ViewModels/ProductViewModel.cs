using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCTelerikGrid.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        [Editable(false)]
        [Display(Name = "產品編號")]
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "產品名稱")]
        public string ProductName { get; set; }

        [Display(Name = "種類編號")]
        public int? CategoryId { get; set; }

        [Display(Name = "產品單價")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public decimal? UnitPrice { get; set; }

        [Display(Name = "連續")]
        public bool Discontinued { get; set; }
    }

}
