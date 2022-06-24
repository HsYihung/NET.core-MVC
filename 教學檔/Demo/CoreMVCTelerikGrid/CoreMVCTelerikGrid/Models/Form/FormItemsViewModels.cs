namespace Kendo.Mvc.Examples.Models.Form
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FormItemsViewModels
    {
        [Required]
        public string TextBox { get; set; }

        [Required]
        public int? NumericTextBox { get; set; }

        public string MaskedTextBox { get; set; }

        public DateTime? DatePicker { get; set; }

        public DateTime? DateTimePicker { get; set; }

        [Required]
        public bool Switch { get; set; }

        public string ComboBox { get; set; }

        [Required]
        public bool Agree { get; set; }

        public string RadioGroup { get; set; }

        public string[] CheckBoxGroup { get; set; }
    }
}
