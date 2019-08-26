using System;
using System.Collections.Generic;

namespace Project_Eisenhower.Models
{
    public partial class Field
    {
        public Field()
        {
            Event = new HashSet<Event>();
        }

        public int FieldId { get; set; }
        public string FieldName { get; set; }
        public int ContactId { get; set; }
        public int? AddrsId { get; set; }
        public string Userid { get; set; }

        public virtual Location Addrs { get; set; }
        public virtual Contacts Contact { get; set; }
        public virtual AspNetUsers User { get; set; }
        public virtual ICollection<Event> Event { get; set; }
    }
}
