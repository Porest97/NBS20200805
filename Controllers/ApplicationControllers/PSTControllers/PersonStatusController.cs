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
    public class PersonStatusController : Controller
    {
        private readonly NBSContext _context;

        public PersonStatusController(NBSContext context)
        {
            _context = context;
        }

        // GET: PersonStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonStatus.ToListAsync());
        }

        // GET: PersonStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personStatus = await _context.PersonStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personStatus == null)
            {
                return NotFound();
            }

            return View(personStatus);
        }

        // GET: PersonStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonStatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonStatusName")] PersonStatus personStatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personStatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personStatus);
        }

        // GET: PersonStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personStatus = await _context.PersonStatus.FindAsync(id);
            if (personStatus == null)
            {
                return NotFound();
            }
            return View(personStatus);
        }

        // POST: PersonStatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonStatusName")] PersonStatus personStatus)
        {
            if (id != personStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonStatusExists(personStatus.Id))
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
            return View(personStatus);
        }

        // GET: PersonStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personStatus = await _context.PersonStatus
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personStatus == null)
            {
                return NotFound();
            }

            return View(personStatus);
        }

        // POST: PersonStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personStatus = await _context.PersonStatus.FindAsync(id);
            _context.PersonStatus.Remove(personStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonStatusExists(int id)
        {
            return _context.PersonStatus.Any(e => e.Id == id);
        }
    }
}
