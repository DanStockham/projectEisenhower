using MoreLinq.Extensions;
using Project_Eisenhower.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Eisenhower.ViewModels
{
    public class EventListVM
    {
       public List<EventVM> EventList { get; set; }
       public IEnumerable<List<EventVM>> BatchList { get; set; }

       public EventListVM()
        {
            EventList = new List<EventVM>();
        }
       public void BatchEvent()
        {
            var batchList = new List<List<EventVM>>();

            foreach(var Event in EventList.Batch(3))
            {
                batchList.Add(Event.ToList());
            }

            BatchList = batchList;
        }
    }
}
