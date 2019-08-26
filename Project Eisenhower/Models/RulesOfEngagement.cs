using System;
using System.Collections.Generic;

namespace Project_Eisenhower.Models
{
    public partial class RulesOfEngagement
    {
        public int Id { get; set; }
        public int? EventId { get; set; }
        public string RuleItem { get; set; }

        public virtual Event Event { get; set; }
    }
}
