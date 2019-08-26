using System;
using System.Collections.Generic;

namespace Project_Eisenhower.Models
{
    public partial class Contacts
    {
        public Contacts()
        {
            Field = new HashSet<Field>();
        }

        public int ContactId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public virtual ICollection<Field> Field { get; set; }
    }
}
