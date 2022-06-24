namespace Kendo.Mvc.Examples.Models.Form
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class UserViewModel
    {
        public int UserID
        {
            get;
            set;
        }

        [Required]
        public string UserName
        {
            get;
            set;
        }

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
        public string Password
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

        public DateTime? DateOfBirth { get; set; }

        public DateTime? HireDate { get; set; }

        public DateTime? RetireDate { get; set; }

        public string Company { get; set; }
    }
}
