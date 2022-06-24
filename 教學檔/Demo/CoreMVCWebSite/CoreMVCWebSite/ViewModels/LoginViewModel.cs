using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCWebSite.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    namespace FormsTagHelper.ViewModels
    {
        public class LoginViewModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email Address")]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
