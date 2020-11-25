using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NBS.Data;
using NBS.Models.DataModels;

namespace NBS.Controllers
{
    public class TestingsController : Controller
    {
        private readonly NBSContext _context;

        public TestingsController(NBSContext context)
        {
            _context = context;
        }

        // GET: Testings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Testing.ToListAsync());
        }

        // GET: Testings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testing = await _context.Testing
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testing == null)
            {
                return NotFound();
            }

            return View(testing);
        }

        // GET: Testings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Testings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description")] Testing testing)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testing);
        }

        // GET: Testings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testing = await _context.Testing.FindAsync(id);
            if (testing == null)
            {
                return NotFound();
            }
            return View(testing);
        }

        // POST: Testings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description")] Testing testing)
        {
            if (id != testing.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestingExists(testing.Id))
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
            return View(testing);
        }

        // GET: Testings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var testing = await _context.Testing
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testing == null)
            {
                return NotFound();
            }

            return View(testing);
        }

        // POST: Testings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var testing = await _context.Testing.FindAsync(id);
            _context.Testing.Remove(testing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestingExists(int id)
        {
            return _context.Testing.Any(e => e.Id == id);
        }
    }
}
