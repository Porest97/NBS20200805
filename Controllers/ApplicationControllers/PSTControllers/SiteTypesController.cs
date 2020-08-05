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
    public class SiteTypesController : Controller
    {
        private readonly NBSContext _context;

        public SiteTypesController(NBSContext context)
        {
            _context = context;
        }

        // GET: SiteTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.SiteType.ToListAsync());
        }

        // GET: SiteTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteType = await _context.SiteType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siteType == null)
            {
                return NotFound();
            }

            return View(siteType);
        }

        // GET: SiteTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SiteTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SiteTypeName")] SiteType siteType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siteType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(siteType);
        }

        // GET: SiteTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteType = await _context.SiteType.FindAsync(id);
            if (siteType == null)
            {
                return NotFound();
            }
            return View(siteType);
        }

        // POST: SiteTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SiteTypeName")] SiteType siteType)
        {
            if (id != siteType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siteType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteTypeExists(siteType.Id))
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
            return View(siteType);
        }

        // GET: SiteTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteType = await _context.SiteType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siteType == null)
            {
                return NotFound();
            }

            return View(siteType);
        }

        // POST: SiteTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siteType = await _context.SiteType.FindAsync(id);
            _context.SiteType.Remove(siteType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteTypeExists(int id)
        {
            return _context.SiteType.Any(e => e.Id == id);
        }
    }
}
