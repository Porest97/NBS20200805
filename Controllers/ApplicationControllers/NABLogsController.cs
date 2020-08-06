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
            var nBSContext = _context.NABLog
                .Include(n => n.Incident)
                .Include(n => n.NABLogStatus)
                .Include(n => n.WLog);
            return View(await nBSContext.ToListAsync());
        }

        // GET: Incidents - search
        public async Task<IActionResult> IndexSearch
            (string searchString, string searchString1,
            string searchString2, string searchString3,
            string searchString4)
        {
            var nABLogs = from n in _context.NABLog
                .Include(n => n.Incident)
                .Include(n => n.NABLogStatus)
                .Include(n => n.WLog)
                .Include(n => n.WLog.Employee)

                          select n;

            if (!String.IsNullOrEmpty(searchString))
            {
                nABLogs = nABLogs
                .Include(n => n.Incident)
                .Include(n => n.NABLogStatus)
                .Include(n => n.WLog)
                .Include(n => n.WLog.Employee)
                .Where(s => s.WLog.Employee.FirstName.Contains(searchString));

            }
            if (!String.IsNullOrEmpty(searchString1))
            {
                nABLogs = nABLogs
                .Include(n => n.Incident)
                .Include(n => n.NABLogStatus)
                .Include(n => n.WLog)
                .Include(n => n.WLog.Employee)
                .Where(s => s.WLog.Employee.LastName.Contains(searchString1));
            }
            if (!String.IsNullOrEmpty(searchString2))
            {
                nABLogs = nABLogs
                .Include(n => n.Incident)
                .Include(n => n.NABLogStatus)
                .Include(n => n.WLog)
                .Include(n => n.WLog.Employee)
                .Where(s => s.DateTimeStarted.ToString().Contains(searchString2));
            }
            if (!String.IsNullOrEmpty(searchString3))
            {
                nABLogs = nABLogs
                .Include(n => n.Incident)
                .Include(n => n.NABLogStatus)
                .Include(n => n.WLog)
                .Include(n => n.WLog.Employee)
                .Where(s => s.DateTimeEnded.ToString().Contains(searchString3));
            }
            if (!String.IsNullOrEmpty(searchString4))
            {
                nABLogs = nABLogs
                .Include(n => n.Incident)
                .Include(n => n.NABLogStatus)
                .Include(n => n.WLog)
                .Include(n => n.WLog.Employee)
                .Where(s => s.NABLogStatus.NABLogStatusName.Contains(searchString4));

            }            
            return View(await nABLogs.ToListAsync());
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
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber");
            ViewData["NABLogStatusId"] = new SelectList(_context.Set<NABLogStatus>(), "Id", "NABLogStatusName");
            ViewData["WLogId"] = new SelectList(_context.WLog, "Id", "WLNumber");
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
                var nBSContext = _context.NABLog
                   .Include(nl => nl.Incident)
                   .Include(nl => nl.NABLogStatus)
                   .Include(nl => nl.WLog);
                nABLog.TotalCost = (nABLog.Hours * nABLog.PriceHour) + nABLog.MtrCost;

                _context.Add(nABLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexSearch));
            }
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", nABLog.IncidentId);
            ViewData["NABLogStatusId"] = new SelectList(_context.Set<NABLogStatus>(), "Id", "NABLogStatusName", nABLog.NABLogStatusId);
            ViewData["WLogId"] = new SelectList(_context.WLog, "Id", "WLNumber", nABLog.WLogId);
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
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", nABLog.IncidentId);
            ViewData["NABLogStatusId"] = new SelectList(_context.Set<NABLogStatus>(), "Id", "NABLogStatusName", nABLog.NABLogStatusId);
            ViewData["WLogId"] = new SelectList(_context.WLog, "Id", "WLNumber", nABLog.WLogId);
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
                    var nBSContext = _context.NABLog
                   .Include(nl => nl.Incident)
                   .Include(nl => nl.NABLogStatus)
                   .Include(nl => nl.WLog);
                    nABLog.TotalCost = (nABLog.Hours * nABLog.PriceHour) + nABLog.MtrCost;

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
                return RedirectToAction(nameof(IndexSearch));
            }
            ViewData["IncidentId"] = new SelectList(_context.Incident, "Id", "IncidentNumber", nABLog.IncidentId);
            ViewData["NABLogStatusId"] = new SelectList(_context.Set<NABLogStatus>(), "Id", "NABLogStatusName", nABLog.NABLogStatusId);
            ViewData["WLogId"] = new SelectList(_context.WLog, "Id", "WLNumber", nABLog.WLogId);
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
            return RedirectToAction(nameof(IndexSearch));
        }

        private bool NABLogExists(int id)
        {
            return _context.NABLog.Any(e => e.Id == id);
        }
    }
}
