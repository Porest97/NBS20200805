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
    public class CompanyStatusController : Controller
    {
        private readonly NBSContext _context;

        public CompanyStatusController(NBSContext context)
        {
            _context = context;
        }

        // GET: CompanyStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyStatus.ToListAsync());
        }

        // GET: CompanyStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyStatus = await _context.CompanyStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyStatus == null)
            {
                return NotFound();
            }

            return View(companyStatus);
        }

        // GET: CompanyStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyStatusName")] CompanyStatus companyStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyStatus);
        }

        // GET: CompanyStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyStatus = await _context.CompanyStatus.FindAsync(id);
            if (companyStatus == null)
            {
                return NotFound();
            }
            return View(companyStatus);
        }

        // POST: CompanyStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyStatusName")] CompanyStatus companyStatus)
        {
            if (id != companyStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyStatusExists(companyStatus.Id))
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
            return View(companyStatus);
        }

        // GET: CompanyStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyStatus = await _context.CompanyStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyStatus == null)
            {
                return NotFound();
            }

            return View(companyStatus);
        }

        // POST: CompanyStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyStatus = await _context.CompanyStatus.FindAsync(id);
            _context.CompanyStatus.Remove(companyStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyStatusExists(int id)
        {
            return _context.CompanyStatus.Any(e => e.Id == id);
        }
    }
}
