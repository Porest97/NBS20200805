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
    public class PersonTypesController : Controller
    {
        private readonly NBSContext _context;

        public PersonTypesController(NBSContext context)
        {
            _context = context;
        }

        // GET: PersonTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.PersonType.ToListAsync());
        }

        // GET: PersonTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personType = await _context.PersonType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personType == null)
            {
                return NotFound();
            }

            return View(personType);
        }

        // GET: PersonTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PersonTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PersonTypeName")] PersonType personType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(personType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(personType);
        }

        // GET: PersonTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personType = await _context.PersonType.FindAsync(id);
            if (personType == null)
            {
                return NotFound();
            }
            return View(personType);
        }

        // POST: PersonTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PersonTypeName")] PersonType personType)
        {
            if (id != personType.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(personType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PersonTypeExists(personType.Id))
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
            return View(personType);
        }

        // GET: PersonTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var personType = await _context.PersonType
                .FirstOrDefaultAsync(m => m.Id == id);
            if (personType == null)
            {
                return NotFound();
            }

            return View(personType);
        }

        // POST: PersonTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var personType = await _context.PersonType.FindAsync(id);
            _context.PersonType.Remove(personType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PersonTypeExists(int id)
        {
            return _context.PersonType.Any(e => e.Id == id);
        }
    }
}
