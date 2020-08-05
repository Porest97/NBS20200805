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
    public class IncidentStatusController : Controller
    {
        private readonly NBSContext _context;

        public IncidentStatusController(NBSContext context)
        {
            _context = context;
        }

        // GET: IncidentStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.IncidentStatus.ToListAsync());
        }

        // GET: IncidentStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidentStatus = await _context.IncidentStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incidentStatus == null)
            {
                return NotFound();
            }

            return View(incidentStatus);
        }

        // GET: IncidentStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IncidentStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IncidentStatusName")] IncidentStatus incidentStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incidentStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incidentStatus);
        }

        // GET: IncidentStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidentStatus = await _context.IncidentStatus.FindAsync(id);
            if (incidentStatus == null)
            {
                return NotFound();
            }
            return View(incidentStatus);
        }

        // POST: IncidentStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IncidentStatusName")] IncidentStatus incidentStatus)
        {
            if (id != incidentStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incidentStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentStatusExists(incidentStatus.Id))
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
            return View(incidentStatus);
        }

        // GET: IncidentStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidentStatus = await _context.IncidentStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incidentStatus == null)
            {
                return NotFound();
            }

            return View(incidentStatus);
        }

        // POST: IncidentStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incidentStatus = await _context.IncidentStatus.FindAsync(id);
            _context.IncidentStatus.Remove(incidentStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncidentStatusExists(int id)
        {
            return _context.IncidentStatus.Any(e => e.Id == id);
        }
    }
}
