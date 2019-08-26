using MoreLinq.Extensions;
using Project_Eisenhower.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Eisenhower.ViewModels
{
    public class EventVM
    {
       public List<Event> EventList { get; set; }
       public IEnumerable<List<Event>> BatchList { get; set; }

       public EventVM(IEnumerable<Event> eventList)
        {
            this.EventList = eventList.ToList();
        }

       public void BatchEvent()
        {
            var batchList = new List<List<Event>>();

            foreach(var Event in EventList.Batch(3))
            {
                batchList.Add(Event.ToList());
            }

            BatchList = batchList;
        }
    }
}
