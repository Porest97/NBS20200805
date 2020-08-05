using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBS.Data;
using NBS.Models.DataModels;

namespace NBS.Controllers.ApplicationControllers.PSTControllers
{
    public class IncidentPrioritiesController : Controller
    {
        private readonly NBSContext _context;

        public IncidentPrioritiesController(NBSContext context)
        {
            _context = context;
        }

        // GET: IncidentPriorities
        public async Task<IActionResult> Index()
        {
            return View(await _context.IncidentPriority.ToListAsync());
        }

        // GET: IncidentPriorities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidentPriority = await _context.IncidentPriority
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incidentPriority == null)
            {
                return NotFound();
            }

            return View(incidentPriority);
        }

        // GET: IncidentPriorities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IncidentPriorities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IncidentPriorityName")] IncidentPriority incidentPriority)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incidentPriority);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incidentPriority);
        }

        // GET: IncidentPriorities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidentPriority = await _context.IncidentPriority.FindAsync(id);
            if (incidentPriority == null)
            {
                return NotFound();
            }
            return View(incidentPriority);
        }

        // POST: IncidentPriorities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IncidentPriorityName")] IncidentPriority incidentPriority)
        {
            if (id != incidentPriority.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incidentPriority);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentPriorityExists(incidentPriority.Id))
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
            return View(incidentPriority);
        }

        // GET: IncidentPriorities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidentPriority = await _context.IncidentPriority
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incidentPriority == null)
            {
                return NotFound();
            }

            return View(incidentPriority);
        }

        // POST: IncidentPriorities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incidentPriority = await _context.IncidentPriority.FindAsync(id);
            _context.IncidentPriority.Remove(incidentPriority);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncidentPriorityExists(int id)
        {
            return _context.IncidentPriority.Any(e => e.Id == id);
        }
    }
}
