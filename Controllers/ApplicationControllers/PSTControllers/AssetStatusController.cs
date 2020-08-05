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
    public class AssetStatusController : Controller
    {
        private readonly NBSContext _context;

        public AssetStatusController(NBSContext context)
        {
            _context = context;
        }

        // GET: AssetStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.AssetStatus.ToListAsync());
        }

        // GET: AssetStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetStatus = await _context.AssetStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assetStatus == null)
            {
                return NotFound();
            }

            return View(assetStatus);
        }

        // GET: AssetStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AssetStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AssetStatusName")] AssetStatus assetStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(assetStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(assetStatus);
        }

        // GET: AssetStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetStatus = await _context.AssetStatus.FindAsync(id);
            if (assetStatus == null)
            {
                return NotFound();
            }
            return View(assetStatus);
        }

        // POST: AssetStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AssetStatusName")] AssetStatus assetStatus)
        {
            if (id != assetStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(assetStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AssetStatusExists(assetStatus.Id))
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
            return View(assetStatus);
        }

        // GET: AssetStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var assetStatus = await _context.AssetStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (assetStatus == null)
            {
                return NotFound();
            }

            return View(assetStatus);
        }

        // POST: AssetStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var assetStatus = await _context.AssetStatus.FindAsync(id);
            _context.AssetStatus.Remove(assetStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AssetStatusExists(int id)
        {
            return _context.AssetStatus.Any(e => e.Id == id);
        }
    }
}
