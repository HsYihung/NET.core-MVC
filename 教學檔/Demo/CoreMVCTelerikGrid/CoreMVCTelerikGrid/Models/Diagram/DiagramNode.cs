using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kendo.Mvc.Examples.Models.Diagram
{
    public class DiagramNode
    {
        public DiagramNode()
        {
        }

        public DiagramNode(string name)
        {
            Name = name;
            Items = new List<DiagramNode>();
        }

        public string Name { get; set; }

        public List<DiagramNode> Items { get; set; }
    }
}
