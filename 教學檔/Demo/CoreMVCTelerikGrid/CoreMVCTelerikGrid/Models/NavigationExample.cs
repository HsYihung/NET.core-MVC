using System;
using System.Linq;
using System.Collections.Generic;

namespace Kendo.Mvc.Examples.Models
{
    public class NavigationExample : NavigationItem
    {
        public string Url { get; set; }
        public bool New { get; set; }
        public bool Updated { get; set; }
        public string Group { get; set; }
        public string Api { get; set; }
        public bool Deferred { get; set; }
        public string AltDescription { get; set; }
        public bool HasConsole { get; set; }
        public IEnumerable<ExampleLink> Links { get; set; }
    }
}
