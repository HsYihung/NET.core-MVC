using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Models
{
    public class IssueModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string AdditionalInfo { get; set; }

        public string Type { get; set; }

        public bool Approved { get; set; }
    }
}
