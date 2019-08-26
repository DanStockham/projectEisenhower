using System;
using System.Collections.Generic;

namespace Project_Eisenhower.Models
{
    public partial class Event
    {
        public Event()
        {
            FpsRanges = new HashSet<FpsRanges>();
            RulesOfEngagement = new HashSet<RulesOfEngagement>();
        }

        public int EventId { get; set; }
        public string OpName { get; set; }
        public int? FieldId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public decimal? Fee { get; set; }
        public string Image { get; set; }
        public int? Status { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual Field Field { get; set; }
        public virtual Eventtatus StatusNavigation { get; set; }
        public virtual ICollection<FpsRanges> FpsRanges { get; set; }
        public virtual ICollection<RulesOfEngagement> RulesOfEngagement { get; set; }
    }
}
