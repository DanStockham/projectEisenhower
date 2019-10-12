using Microsoft.EntityFrameworkCore;
using Project_Eisenhower.Models;
using Project_Eisenhower.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoreLinq.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace Project_Eisenhower.Repositories
{
    public class PEDEVDBRepo
    {
        private readonly PEDEVDBContext _db;

        public PEDEVDBRepo(PEDEVDBContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            
        }

        public async Task<IEnumerable<List<EventVM>>> GetEvent(int page)  
        {   
            int slice = page * 10;
            var eventList = await _db.Event.Include(e => e.Field).Skip(slice).Take(10).ToListAsync();
            var vm = new EventListVM();
            foreach (var item in eventList)
            {
                vm.EventList.Add(item.ToViewModel());
            }
            
            vm.BatchEvent();

            return vm.BatchList;
        }

        public DashboardVM GetDashboardInfo(IdentityUser user)
        {
            DashboardVM vm = new DashboardVM();

            var userid = user.Id;
            var fields = _db.Field.Where(f => f.Userid == userid).Include("Event").Include("Addrs").Include("Contact").ToList();
            var events = fields.SelectMany(f => f.Event).ToList().GroupBy(g => g.Status).ToList();

            vm.Fields = fields;
            vm.PublishedEvent = events.Where(e => e.Key.Value == 2).SelectMany(e => e).ToList();
            vm.DraftEvent = events.Where(e => e.Key.Value == 1).SelectMany(e => e).ToList();
            vm.PastEvent = events.Where(e => e.Key.Value == 3).SelectMany(e => e).ToList();

            return vm;
        }
    }
}
