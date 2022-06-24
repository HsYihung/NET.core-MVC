using System.ComponentModel.DataAnnotations;

namespace Customers2019.Models
{
    public class ContactModel
    {
        [Required(ErrorMessage ="Name不可空白")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email不可空白")]
        [EmailAddress(ErrorMessage = "Email格式錯誤")]
        public string Email { get; set; }
    }
}