namespace Kendo.Mvc.Examples.Models.Gantt
{
    using System;
    using Kendo.Mvc.UI;
    using System.ComponentModel.DataAnnotations;
    public class TaskViewModel : IGanttTask
    {
        public int TaskID { get; set; }
        public int? ParentID { get; set; }

        public string Title { get; set; }

        private DateTime start;
        [Display(Name ="Start Time")]
        [DisplayFormat(DataFormatString="{0:MM/dd/yyyy}")]
        public DateTime Start
        {
            get
            {
                return start;
            }
            set
            {
                start = value.ToUniversalTime();
            }
        }

        private DateTime end;
        [Display(Name = "End Time")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime End
        {
            get
            {
                return end;
            }
            set
            {
                end = value.ToUniversalTime();
            }
        }

        private DateTime plannedStart;
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PlannedStart
        {
            get
            {
                return plannedStart;
            }
            set
            {
                plannedStart = value.ToUniversalTime();
            }
        }

        private DateTime plannedEnd;
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime PlannedEnd
        {
            get
            {
                return plannedEnd;
            }
            set
            {
                plannedEnd = value.ToUniversalTime();
            }
        }

        public string TeamLead { get; set; }

        public bool Summary { get; set; }
        public bool Expanded { get; set; }
        public decimal PercentComplete { get; set; }
        public int OrderId { get; set; }

        public GanttTask ToEntity()
        {
            return new GanttTask
            {
                ID = TaskID,
                ParentID = ParentID,
                Title = Title,
                Start = Start,
                End = End,
                Summary = Summary,
                Expanded = Expanded,
                PercentComplete = PercentComplete,
                OrderID = OrderId
            };
        }
    }
}