using Project_Eisenhower.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Eisenhower.ViewModels
{
    public class FieldFormVM
    {
        public int FieldId { get; set; }
        [Required]
        public string FieldName { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [StringLength(2)]
        public string State { get; set; }
        [Required]
        [Range(10000, 99999)]
        public int Zipcode { get; set; }
        [Required]
        public int? StreetNumber { get; set; }

        public Field ToModel()
        {
            throw new NotImplementedException();
        }
    }
}
