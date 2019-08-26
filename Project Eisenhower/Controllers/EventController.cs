using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Project_Eisenhower.Models;
using Project_Eisenhower.Repositories;

namespace Project_Eisenhower.Controllers
{
    public class EventController : Controller
    {
        private readonly PEDEVDBContext _context;
        private readonly PEDEVDBRepo _PEDEVDBRepo;

        public EventController(PEDEVDBContext context, PEDEVDBRepo PEDEVDBRepo)
        {
            _context = context;
            _PEDEVDBRepo = PEDEVDBRepo;
        }

        // GET: Event
        public IActionResult Index()
        {
            var batchEvent = _PEDEVDBRepo.GetEvent();

            return View(batchEvent);
        }

        // GET: Event/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Event = await _context.Event
                .Include(e => e.Field)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (Event == null)
            {
                return NotFound();
            }

            return View(Event);
        }

        // GET: Event/Create
        public IActionResult Create()
        {
            ViewData["FieldId"] = new SelectList(_context.Field, "FieldId", "FieldName");
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,OpName,FieldId,StartDate,EndDate,Description,Fee,Image")] Event Event)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Event);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FieldId"] = new SelectList(_context.Field, "FieldId", "FieldName", Event.FieldId);
            return View(Event);
        }

        // GET: Event/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Event = await _context.Event.FindAsync(id);
            if (Event == null)
            {
                return NotFound();
            }
            ViewData["FieldId"] = new SelectList(_context.Field, "FieldId", "FieldName", Event.FieldId);
            return View(Event);
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,OpName,FieldId,StartDate,EndDate,Description,Fee,Image")] Event Event)
        {
            if (id != Event.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Event);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(Event.EventId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["FieldId"] = new SelectList(_context.Field, "FieldId", "FieldName", Event.FieldId);
            return View(Event);
        }

        // GET: Event/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Event = await _context.Event
                .Include(e => e.Field)
                .FirstOrDefaultAsync(m => m.EventId == id);
            if (Event == null)
            {
                return NotFound();
            }

            return View(Event);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Event = await _context.Event.FindAsync(id);
            _context.Event.Remove(Event);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.EventId == id);
        }
    }
}
