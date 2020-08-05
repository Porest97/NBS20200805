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
    public class NABLogsController : Controller
    {
        private readonly NBSContext _context;

        public NABLogsController(NBSContext context)
        {
            _context = context;
        }

        // GET: NABLogs
        public async Task<IActionResult> Index()
        {
            var nBSContext = _context.NABLog.Include(n => n.Incident).Include(n => n.NABLogStatus).Include(n => n.WLog);
            return View(await nBSContext.ToListAsync());
        }

        // GET: NABLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nABLog = await _context.NABLog
                .Include(n => n.Incident)
                .Include(n => n.NABLogStatus)
                .Include(n => n.WLog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nABLog == null)
            {
                return NotFound();
            }

            return View(nABLog);
        }

        // GET: NABLogs/Create
        public IActionResult Create()
        {
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "Id");
            ViewData["NABLogStatusId"] = new SelectList(_context.NABLogStatus, "Id", "Id");
            ViewData["WLogId"] = new SelectList(_context.WLog, "Id", "Id");
            return View();
        }

        // POST: NABLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,IncidentId,DateTimeStarted,DateTimeEnded,LogNotes,Hours,PriceHour,MtrCost,TotalCost,WLogId,NABLogStatusId")] NABLog nABLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nABLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "Id", nABLog.IncidentId);
            ViewData["NABLogStatusId"] = new SelectList(_context.NABLogStatus, "Id", "Id", nABLog.NABLogStatusId);
            ViewData["WLogId"] = new SelectList(_context.WLog, "Id", "Id", nABLog.WLogId);
            return View(nABLog);
        }

        // GET: NABLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nABLog = await _context.NABLog.FindAsync(id);
            if (nABLog == null)
            {
                return NotFound();
            }
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "Id", nABLog.IncidentId);
            ViewData["NABLogStatusId"] = new SelectList(_context.NABLogStatus, "Id", "Id", nABLog.NABLogStatusId);
            ViewData["WLogId"] = new SelectList(_context.WLog, "Id", "Id", nABLog.WLogId);
            return View(nABLog);
        }

        // POST: NABLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IncidentId,DateTimeStarted,DateTimeEnded,LogNotes,Hours,PriceHour,MtrCost,TotalCost,WLogId,NABLogStatusId")] NABLog nABLog)
        {
            if (id != nABLog.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nABLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NABLogExists(nABLog.Id))
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
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "Id", nABLog.IncidentId);
            ViewData["NABLogStatusId"] = new SelectList(_context.NABLogStatus, "Id", "Id", nABLog.NABLogStatusId);
            ViewData["WLogId"] = new SelectList(_context.WLog, "Id", "Id", nABLog.WLogId);
            return View(nABLog);
        }

        // GET: NABLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nABLog = await _context.NABLog
                .Include(n => n.Incident)
                .Include(n => n.NABLogStatus)
                .Include(n => n.WLog)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nABLog == null)
            {
                return NotFound();
            }

            return View(nABLog);
        }

        // POST: NABLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nABLog = await _context.NABLog.FindAsync(id);
            _context.NABLog.Remove(nABLog);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NABLogExists(int id)
        {
            return _context.NABLog.Any(e => e.Id == id);
        }
    }
}
