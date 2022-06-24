using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UseASPNETCoreIdentity.Data
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(3)]
        [Display(Name = "國別碼")]
        public string CountryCode { get; set; }
    }
}
