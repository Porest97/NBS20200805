using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBS.Data;
using NBS.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Controllers.ApplicationControllers
{
    public class OutlaysController : Controller
    {

        private readonly NBSContext _context;

        public OutlaysController(NBSContext context)
        {
            _context = context;
        }

        // GET: Outlay/
        public async Task<IActionResult> IndexOutlays()
        {
            var nBSContext = _context.Outlays
                .Include(o => o.Status)
                .Include(o => o.Employee);
            return View(await nBSContext.ToListAsync());
        }


        // GET: Outlay/Details
        public async Task<IActionResult> DetailsOutlay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outlay = await _context.Outlays
                .Include(o => o.Status)
                .Include(o=>o.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (outlay == null)
            {
                return NotFound();
            }

            return View(outlay);
        }

        // GET: Outlay/Create
        public IActionResult CreateOutlay()
        {
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName");
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "FullName");
            return View();
        }

        // POST: Outlay/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOutlay([Bind("Id,DateTimePosted,DateTimeChanged," +
            "ApplicationUserId,OutlayDateTime,OutlayDescription,Amount,StatusId")] Outlay outlay)
        {
            if (ModelState.IsValid)
            {
                var nBSContext = _context.Outlays
                 .Include(o => o.Status)
                 .Include(o => o.Employee);

                _context.Add(outlay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexOutlays));
            }
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName", outlay.StatusId);
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "UserName", outlay.ApplicationUserId);
            return View(outlay);
        }

        // GET: Outlay/Edit
        public async Task<IActionResult> EditOutlay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outlay = await _context.Outlays.FindAsync(id);
            if (outlay == null)
            {
                return NotFound();
            }
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName");
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "FullName");
            return View(outlay);
        }

        // POST: Outlay/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOutlay(int id, [Bind("Id,DateTimePosted,DateTimeChanged," +
            "ApplicationUserId,OutlayDateTime,OutlayDescription,Amount,StatusId")] Outlay outlay)
        {
            if (id != outlay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var nBSContext = _context.Outlays
                     .Include(o => o.Status)
                    .Include(o => o.Employee);

                    _context.Update(outlay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OutlayExists(outlay.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexOutlays));
            }
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName");
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "FullName");
            return View(outlay);
        }

        // GET: Outlay/Edit
        public async Task<IActionResult> ChangeOutlayStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outlay = await _context.Outlays.FindAsync(id);
            if (outlay == null)
            {
                return NotFound();
            }
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName");
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "FullName");
            return View(outlay);
        }

        // POST: Outlay/Edit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeOutlayStatus(int id, [Bind("Id,DateTimePosted,DateTimeChanged," +
            "ApplicationUserId,OutlayDateTime,OutlayDescription,Amount,StatusId")] Outlay outlay)
        {
            if (id != outlay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var nBSContext = _context.Outlays
                     .Include(o => o.Status)
                    .Include(o => o.Employee);

                    _context.Update(outlay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OutlayExists(outlay.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexOutlays));
            }
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName");
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "FullName");
            return View(outlay);
        }


        // POST: Outlay/Delete
        public async Task<IActionResult> DeleteOutlay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var outlay = await _context.Outlays
                .Include(o => o.Status)
                .Include(o=>o.Employee)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (outlay == null)
            {
                return NotFound();
            }
            ViewData["StatusId"] = new SelectList(_context.Statuses, "Id", "StatusName");
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "FullName");
            return View(outlay);
        }

        // POST: Outlay/Delete
        [HttpPost, ActionName("DeleteOutlay")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOutlayConfirmed(int id)
        {
            var outlay = await _context.Outlays.FindAsync(id);
            _context.Outlays.Remove(outlay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexOutlays));
        }

        private bool OutlayExists(int id)
        {
            return _context.Outlays.Any(e => e.Id == id);
        }
    }
}
