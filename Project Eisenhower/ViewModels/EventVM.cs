using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Eisenhower.ViewModels
{
    public class EventVM
    {
        public int EventId { get; set; }
        public string OpName { get; set; }
        public string FieldName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public decimal? Fee { get; set; }
        public string Image { get; set; }
    }
}
