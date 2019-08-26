using System;
using System.Collections.Generic;

namespace Project_Eisenhower.Models
{
    public partial class FpsRanges
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string RangeDesc { get; set; }
        public int MaxFps { get; set; }
        public int MinFps { get; set; }

        public virtual Event Event { get; set; }
    }
}
