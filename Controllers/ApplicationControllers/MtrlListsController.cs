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
    public class MtrlListsController : Controller
    {
        private readonly NBSContext _context;

        public MtrlListsController(NBSContext context)
        {
            _context = context;
        }

        // GET: MtrlLists
        public async Task<IActionResult> Index()
        {
            return View(await _context.MtrlList.ToListAsync());
        }

        // GET: MtrlLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mtrlList = await _context.MtrlList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mtrlList == null)
            {
                return NotFound();
            }

            return View(mtrlList);
        }

        // GET: MtrlLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MtrlLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Item1,Item2,Item3,Item4,Item5,Item6,Item7,Item8,Item9,Item10")] MtrlList mtrlList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mtrlList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mtrlList);
        }

        // GET: MtrlLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mtrlList = await _context.MtrlList.FindAsync(id);
            if (mtrlList == null)
            {
                return NotFound();
            }
            return View(mtrlList);
        }

        // POST: MtrlLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,Item1,Item2,Item3,Item4,Item5,Item6,Item7,Item8,Item9,Item10")] MtrlList mtrlList)
        {
            if (id != mtrlList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mtrlList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MtrlListExists(mtrlList.Id))
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
            return View(mtrlList);
        }

        // GET: MtrlLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mtrlList = await _context.MtrlList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mtrlList == null)
            {
                return NotFound();
            }

            return View(mtrlList);
        }

        // POST: MtrlLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mtrlList = await _context.MtrlList.FindAsync(id);
            _context.MtrlList.Remove(mtrlList);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MtrlListExists(int id)
        {
            return _context.MtrlList.Any(e => e.Id == id);
        }
    }
}
