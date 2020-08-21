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
    public class SallariesController : Controller
    {
        private readonly NBSContext _context;

        public SallariesController(NBSContext context)
        {
            _context = context;
        }

        public IActionResult IndexSallaries()
        {
            return View();
        }

        // GET: Sallaries
        public async Task<IActionResult> IndexSallaryAccounts()
        {
            var nBSContext = _context.SallaryAccount
                .Include(s => s.AccountOwner);
            return View(await nBSContext.ToListAsync());
        }

        // GET: Sallaries/Details/5
        public async Task<IActionResult> DetailsSallaryAccount(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sallaryAccount = await _context.SallaryAccount
                .Include(s => s.AccountOwner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sallaryAccount == null)
            {
                return NotFound();
            }

            return View(sallaryAccount);
        }

        // GET: Sallaries/Create
        public IActionResult CreateSallaryAccount()
        {
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName");
            return View();
        }

        // POST: Sallaries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSallaryAccount([Bind("Id,PersonId,AccountName,AccountBalance")] SallaryAccount sallaryAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sallaryAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexSallaryAccounts));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", sallaryAccount.PersonId);
            return View(sallaryAccount);
        }

        // GET: Sallaries/Edit/5
        public async Task<IActionResult> EditSallaryAccount(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sallaryAccount = await _context.SallaryAccount.FindAsync(id);
            if (sallaryAccount == null)
            {
                return NotFound();
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", sallaryAccount.PersonId);
            return View(sallaryAccount);
        }

        // POST: Sallaries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSallaryAccount(int id, [Bind("Id,PersonId,AccountName,AccountBalance")] SallaryAccount sallaryAccount)
        {
            if (id != sallaryAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sallaryAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SallaryAccountExists(sallaryAccount.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexSallaryAccounts));
            }
            ViewData["PersonId"] = new SelectList(_context.Person, "Id", "FullName", sallaryAccount.PersonId);
            return View(sallaryAccount);
        }

        // GET: Sallaries/Delete/5
        public async Task<IActionResult> DeleteSallaryAccount(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sallaryAccount = await _context.SallaryAccount
                .Include(s => s.AccountOwner)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sallaryAccount == null)
            {
                return NotFound();
            }

            return View(sallaryAccount);
        }

        // POST: Sallaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sallaryAccount = await _context.SallaryAccount.FindAsync(id);
            _context.SallaryAccount.Remove(sallaryAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexSallaryAccounts));
        }

        private bool SallaryAccountExists(int id)
        {
            return _context.SallaryAccount.Any(e => e.Id == id);
        }
    }
}
