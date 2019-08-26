using System;
using System.Collections.Generic;

namespace Project_Eisenhower.Models
{
    public partial class Location
    {
        public Location()
        {
            Field = new HashSet<Field>();
        }
        public int AddrsId { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }
        public int? StreetNumber { get; set; }

        public virtual ICollection<Field> Field { get; set; }
    }
}
