using System;
using System.Collections.Generic;

namespace Project_Eisenhower.Models
{
    public partial class Eventtatus
    {
        public Eventtatus()
        {
            Event = new HashSet<Event>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<Event> Event { get; set; }
    }
}
