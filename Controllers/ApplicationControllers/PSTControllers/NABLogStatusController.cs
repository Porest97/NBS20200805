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
    public class NABLogStatusController : Controller
    {
        private readonly NBSContext _context;

        public NABLogStatusController(NBSContext context)
        {
            _context = context;
        }

        // GET: NABLogStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.NABLogStatus.ToListAsync());
        }

        // GET: NABLogStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nABLogStatus = await _context.NABLogStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nABLogStatus == null)
            {
                return NotFound();
            }

            return View(nABLogStatus);
        }

        // GET: NABLogStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NABLogStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NABLogStatusName")] NABLogStatus nABLogStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nABLogStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nABLogStatus);
        }

        // GET: NABLogStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nABLogStatus = await _context.NABLogStatus.FindAsync(id);
            if (nABLogStatus == null)
            {
                return NotFound();
            }
            return View(nABLogStatus);
        }

        // POST: NABLogStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NABLogStatusName")] NABLogStatus nABLogStatus)
        {
            if (id != nABLogStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nABLogStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NABLogStatusExists(nABLogStatus.Id))
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
            return View(nABLogStatus);
        }

        // GET: NABLogStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var nABLogStatus = await _context.NABLogStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (nABLogStatus == null)
            {
                return NotFound();
            }

            return View(nABLogStatus);
        }

        // POST: NABLogStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var nABLogStatus = await _context.NABLogStatus.FindAsync(id);
            _context.NABLogStatus.Remove(nABLogStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NABLogStatusExists(int id)
        {
            return _context.NABLogStatus.Any(e => e.Id == id);
        }
    }
}
