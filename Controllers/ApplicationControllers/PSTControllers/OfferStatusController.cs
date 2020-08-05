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
    public class OfferStatusController : Controller
    {
        private readonly NBSContext _context;

        public OfferStatusController(NBSContext context)
        {
            _context = context;
        }

        // GET: OfferStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.OfferStatus.ToListAsync());
        }

        // GET: OfferStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerStatus = await _context.OfferStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offerStatus == null)
            {
                return NotFound();
            }

            return View(offerStatus);
        }

        // GET: OfferStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OfferStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,OfferStatusName")] OfferStatus offerStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(offerStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(offerStatus);
        }

        // GET: OfferStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerStatus = await _context.OfferStatus.FindAsync(id);
            if (offerStatus == null)
            {
                return NotFound();
            }
            return View(offerStatus);
        }

        // POST: OfferStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OfferStatusName")] OfferStatus offerStatus)
        {
            if (id != offerStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(offerStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OfferStatusExists(offerStatus.Id))
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
            return View(offerStatus);
        }

        // GET: OfferStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offerStatus = await _context.OfferStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (offerStatus == null)
            {
                return NotFound();
            }

            return View(offerStatus);
        }

        // POST: OfferStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var offerStatus = await _context.OfferStatus.FindAsync(id);
            _context.OfferStatus.Remove(offerStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OfferStatusExists(int id)
        {
            return _context.OfferStatus.Any(e => e.Id == id);
        }
    }
}
