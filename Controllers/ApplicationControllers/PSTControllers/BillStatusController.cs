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
    public class BillStatusController : Controller
    {
        private readonly NBSContext _context;

        public BillStatusController(NBSContext context)
        {
            _context = context;
        }

        // GET: BillStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.BillStatus.ToListAsync());
        }

        // GET: BillStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billStatus = await _context.BillStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billStatus == null)
            {
                return NotFound();
            }

            return View(billStatus);
        }

        // GET: BillStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BillStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BillStatusName")] BillStatus billStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(billStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(billStatus);
        }

        // GET: BillStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billStatus = await _context.BillStatus.FindAsync(id);
            if (billStatus == null)
            {
                return NotFound();
            }
            return View(billStatus);
        }

        // POST: BillStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BillStatusName")] BillStatus billStatus)
        {
            if (id != billStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(billStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BillStatusExists(billStatus.Id))
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
            return View(billStatus);
        }

        // GET: BillStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var billStatus = await _context.BillStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (billStatus == null)
            {
                return NotFound();
            }

            return View(billStatus);
        }

        // POST: BillStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var billStatus = await _context.BillStatus.FindAsync(id);
            _context.BillStatus.Remove(billStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BillStatusExists(int id)
        {
            return _context.BillStatus.Any(e => e.Id == id);
        }
    }
}
