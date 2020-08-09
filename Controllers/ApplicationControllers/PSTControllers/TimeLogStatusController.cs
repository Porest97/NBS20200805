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
    public class TimeLogStatusController : Controller
    {
        private readonly NBSContext _context;

        public TimeLogStatusController(NBSContext context)
        {
            _context = context;
        }

        // GET: TimeLogStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.TimeLogStatus.ToListAsync());
        }

        // GET: TimeLogStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeLogStatus = await _context.TimeLogStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeLogStatus == null)
            {
                return NotFound();
            }

            return View(timeLogStatus);
        }

        // GET: TimeLogStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TimeLogStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TimeLogStatusName")] TimeLogStatus timeLogStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeLogStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(timeLogStatus);
        }

        // GET: TimeLogStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeLogStatus = await _context.TimeLogStatus.FindAsync(id);
            if (timeLogStatus == null)
            {
                return NotFound();
            }
            return View(timeLogStatus);
        }

        // POST: TimeLogStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TimeLogStatusName")] TimeLogStatus timeLogStatus)
        {
            if (id != timeLogStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeLogStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeLogStatusExists(timeLogStatus.Id))
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
            return View(timeLogStatus);
        }

        // GET: TimeLogStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeLogStatus = await _context.TimeLogStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeLogStatus == null)
            {
                return NotFound();
            }

            return View(timeLogStatus);
        }

        // POST: TimeLogStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeLogStatus = await _context.TimeLogStatus.FindAsync(id);
            _context.TimeLogStatus.Remove(timeLogStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeLogStatusExists(int id)
        {
            return _context.TimeLogStatus.Any(e => e.Id == id);
        }
    }
}
