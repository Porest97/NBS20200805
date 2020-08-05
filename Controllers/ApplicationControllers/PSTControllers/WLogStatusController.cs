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
    public class WLogStatusController : Controller
    {
        private readonly NBSContext _context;

        public WLogStatusController(NBSContext context)
        {
            _context = context;
        }

        // GET: WLogStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.WLogStatus.ToListAsync());
        }

        // GET: WLogStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wLogStatus = await _context.WLogStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wLogStatus == null)
            {
                return NotFound();
            }

            return View(wLogStatus);
        }

        // GET: WLogStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WLogStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,WLogStatusName")] WLogStatus wLogStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wLogStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(wLogStatus);
        }

        // GET: WLogStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wLogStatus = await _context.WLogStatus.FindAsync(id);
            if (wLogStatus == null)
            {
                return NotFound();
            }
            return View(wLogStatus);
        }

        // POST: WLogStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,WLogStatusName")] WLogStatus wLogStatus)
        {
            if (id != wLogStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wLogStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WLogStatusExists(wLogStatus.Id))
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
            return View(wLogStatus);
        }

        // GET: WLogStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var wLogStatus = await _context.WLogStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (wLogStatus == null)
            {
                return NotFound();
            }

            return View(wLogStatus);
        }

        // POST: WLogStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var wLogStatus = await _context.WLogStatus.FindAsync(id);
            _context.WLogStatus.Remove(wLogStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WLogStatusExists(int id)
        {
            return _context.WLogStatus.Any(e => e.Id == id);
        }
    }
}
