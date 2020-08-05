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
    public class SiteStatusController : Controller
    {
        private readonly NBSContext _context;

        public SiteStatusController(NBSContext context)
        {
            _context = context;
        }

        // GET: SiteStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.SiteStatus.ToListAsync());
        }

        // GET: SiteStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteStatus = await _context.SiteStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siteStatus == null)
            {
                return NotFound();
            }

            return View(siteStatus);
        }

        // GET: SiteStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SiteStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SiteStatusName")] SiteStatus siteStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siteStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(siteStatus);
        }

        // GET: SiteStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteStatus = await _context.SiteStatus.FindAsync(id);
            if (siteStatus == null)
            {
                return NotFound();
            }
            return View(siteStatus);
        }

        // POST: SiteStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SiteStatusName")] SiteStatus siteStatus)
        {
            if (id != siteStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siteStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteStatusExists(siteStatus.Id))
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
            return View(siteStatus);
        }

        // GET: SiteStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteStatus = await _context.SiteStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siteStatus == null)
            {
                return NotFound();
            }

            return View(siteStatus);
        }

        // POST: SiteStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siteStatus = await _context.SiteStatus.FindAsync(id);
            _context.SiteStatus.Remove(siteStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteStatusExists(int id)
        {
            return _context.SiteStatus.Any(e => e.Id == id);
        }
    }
}
