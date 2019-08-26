using Project_Eisenhower.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Eisenhower.Models
{
    public partial class Field
    {
        public FieldFormVM ToViewModel()
        {
            return new FieldFormVM()
            {
                FieldId = this.FieldId,
                FieldName = this.FieldName,
                StreetNumber = this.Addrs.StreetNumber,
                Street = this.Addrs.Street,
                City = this.Addrs.City,
                State = this.Addrs.State,
                Zipcode = this.Addrs.Zipcode
            };
        }
    }
}
