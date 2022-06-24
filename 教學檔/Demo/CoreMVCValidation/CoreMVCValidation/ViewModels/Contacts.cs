using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreMVCValidation.ViewModels
{
    public class Contacts
    {
        [Display(Name="姓名")]
        public string Name { get; set; }

        [Display(Name="電子郵件")]
        public string Email { get; set; }
    }
}
