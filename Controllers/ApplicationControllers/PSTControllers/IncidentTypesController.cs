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
    public class IncidentTypesController : Controller
    {
        private readonly NBSContext _context;

        public IncidentTypesController(NBSContext context)
        {
            _context = context;
        }

        // GET: IncidentTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.IncidentType.ToListAsync());
        }

        // GET: IncidentTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidentType = await _context.IncidentType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incidentType == null)
            {
                return NotFound();
            }

            return View(incidentType);
        }

        // GET: IncidentTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IncidentTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IncidentTypeName")] IncidentType incidentType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(incidentType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(incidentType);
        }

        // GET: IncidentTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidentType = await _context.IncidentType.FindAsync(id);
            if (incidentType == null)
            {
                return NotFound();
            }
            return View(incidentType);
        }

        // POST: IncidentTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IncidentTypeName")] IncidentType incidentType)
        {
            if (id != incidentType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(incidentType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IncidentTypeExists(incidentType.Id))
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
            return View(incidentType);
        }

        // GET: IncidentTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var incidentType = await _context.IncidentType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (incidentType == null)
            {
                return NotFound();
            }

            return View(incidentType);
        }

        // POST: IncidentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var incidentType = await _context.IncidentType.FindAsync(id);
            _context.IncidentType.Remove(incidentType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IncidentTypeExists(int id)
        {
            return _context.IncidentType.Any(e => e.Id == id);
        }
    }
}
