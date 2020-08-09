using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBS.Data;
using NBS.Models.DataModels;

namespace NBS.Controllers.ApplicationControllers
{
    public class TimeReportsController : Controller
    {
        private readonly NBSContext _context;

        public TimeReportsController(NBSContext context)
        {
            _context = context;
        }

        // GET: TimeReports
        public async Task<IActionResult> Index()
        {
            var nBSContext = _context.TimeReport.Include(t => t.Creator).Include(t => t.Employee);
            return View(await nBSContext.ToListAsync());
        }

        // GET: TimeReports/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeReport = await _context.TimeReport
                .Include(t => t.Creator)
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeReport == null)
            {
                return NotFound();
            }

            return View(timeReport);
        }

        // GET: TimeReports/Create
        public IActionResult Create()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id");
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id");
            return View();
        }

        // POST: TimeReports/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TimeReportName,Description,DateTimeCreated,DateTimeFrom,DateTimeTo,ApplicationUserId,PersonId")] TimeReport timeReport)
        {
            if (ModelState.IsValid)
            {
                _context.Add(timeReport);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", timeReport.ApplicationUserId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", timeReport.PersonId);
            return View(timeReport);
        }

        // GET: TimeReports/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeReport = await _context.TimeReport.FindAsync(id);
            if (timeReport == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", timeReport.ApplicationUserId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", timeReport.PersonId);
            return View(timeReport);
        }

        // POST: TimeReports/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TimeReportName,Description,DateTimeCreated,DateTimeFrom,DateTimeTo,ApplicationUserId,PersonId")] TimeReport timeReport)
        {
            if (id != timeReport.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(timeReport);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TimeReportExists(timeReport.Id))
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
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "Id", timeReport.ApplicationUserId);
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "Id", timeReport.PersonId);
            return View(timeReport);
        }

        // GET: TimeReports/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var timeReport = await _context.TimeReport
                .Include(t => t.Creator)
                .Include(t => t.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (timeReport == null)
            {
                return NotFound();
            }

            return View(timeReport);
        }

        // POST: TimeReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var timeReport = await _context.TimeReport.FindAsync(id);
            _context.TimeReport.Remove(timeReport);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TimeReportExists(int id)
        {
            return _context.TimeReport.Any(e => e.Id == id);
        }
    }
}
