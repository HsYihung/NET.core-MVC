using Kendo.Mvc.UI;
using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Models
{
    public class CheckBoxGroupViewModel
    {
        public List<IInputGroupItem> Items { get; set; }
        public string[] CheckBoxGroupValue { get; set;  }
    }
}