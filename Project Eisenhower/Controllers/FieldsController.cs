using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_Eisenhower.Models;
using Project_Eisenhower.ViewModels;

namespace Project_Eisenhower.Controllers
{
    public class FieldsController : Controller
    {
        private readonly PEDEVDBContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public FieldsController(PEDEVDBContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Fields
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var pEDEVDBContext = _context.Field.Include(f => f.Addrs).Include(f => f.Contact).Include(f => f.User);
            return View(await pEDEVDBContext.ToListAsync());
        }

        // GET: Fields/Details/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ffield = await _context.Field
                .Include(f => f.Addrs)
                .Include(f => f.Contact)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FieldId == id);
            if (ffield == null)
            {
                return NotFound();
            }

            return View(ffield);
        }

        //// GET: Fields/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Fields/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("FieldName, StreetNumber, Street, City, State, Zipcode")] FieldFormVM ffield)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var location = new Location()
        //        {
        //            StreetNumber = ffield.StreetNumber,
        //            Street = ffield.Street,
        //            City = ffield.City,
        //            State = ffield.State,
        //            Zipcode = ffield.Zipcode
        //        };

        //        _context.Add(location);

        //        var field = new Field()
        //        {
        //            FieldName = ffield.FieldName,
        //            Addrs = location,
        //        };
        //        _context.Add(field);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(ffield);
        //}

        // GET: Fields/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ffield = await _context.Field.Include(f => f.Addrs).FirstOrDefaultAsync(f => f.FieldId == id);
            

            if (ffield == null)
            {
                return NotFound();
            }
            return View(ffield.ToViewModel());
        }

        // POST: Fields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,FieldOwner")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FieldName, StreetNumber, Street, City, State, Zipcode")] FieldFormVM ffield)
        {
            var field = await _context.Field.Include(f => f.Addrs).Where(f => f.FieldId == id).FirstOrDefaultAsync();
            var currentUser = await _userManager.GetUserAsync(User);

            

            if (field == null || currentUser.Id != field.Userid)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    field.FieldName = ffield.FieldName;
                    field.Addrs.StreetNumber = ffield.StreetNumber;
                    field.Addrs.Street = ffield.Street;
                    field.Addrs.City = ffield.City;
                    field.Addrs.State = ffield.State;
                    field.Addrs.Zipcode = ffield.Zipcode;

                    _context.Update(field);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FieldExists(ffield.FieldId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "Dashboard");
            }
            return View(ffield);
        }
        [Authorize(Roles = "Admin")]
        // GET: Fields/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ffield = await _context.Field
                .Include(f => f.Addrs)
                .Include(f => f.Contact)
                .Include(f => f.User)
                .FirstOrDefaultAsync(m => m.FieldId == id);
            if (ffield == null)
            {
                return NotFound();
            }

            return View(ffield);
        }

        // POST: Fields/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ffield = await _context.Field.FindAsync(id);
            _context.Field.Remove(ffield);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FieldExists(int id)
        {
            return _context.Field.Any(e => e.FieldId == id);
        }
    }
}
