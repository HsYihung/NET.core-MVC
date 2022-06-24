namespace Kendo.Mvc.Examples.Models.Form
{
    using System.ComponentModel.DataAnnotations;

    public class FormOrderViewModel
    {
        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName
        {
            get; set;
        }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName
        {
            get;
            set;
        }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email
        {
            get;
            set;
        }

        [Required]
        [Display(Name = "Ship Country")]
        public string ShipCountry { get; set; }

        [Required]
        public string City
        {
            get;
            set;
        }

        [Required]
        public string Address
        {
            get;
            set;
        }

        [Required]
        public bool Agree
        {
            get;
            set;
        }
    }
}
