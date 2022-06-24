using System;
using System.ComponentModel.DataAnnotations;

namespace CoreMVCValidation.Models
{
    public class OrderMetadata
    {
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? OrderDate { get; set; }
    }
}