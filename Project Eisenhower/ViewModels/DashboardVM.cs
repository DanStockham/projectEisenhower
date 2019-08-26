using Project_Eisenhower.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Eisenhower.ViewModels
{
    public class DashboardVM
    {
        public List<Event> DraftEvent { get; set; }
        public List<Event> PublishedEvent { get; set; }
        public List<Event> PastEvent { get; set; }
        public List<Field> Fields { get; set; }

    }
}
