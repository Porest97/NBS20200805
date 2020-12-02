using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NBS.Data;
using NBS.Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBS.Controllers.AdministrationControllers
{
    public class StatusesController : Controller
    {

        private readonly NBSContext _context;

        public StatusesController(NBSContext context)
        {
            _context = context;
        }

        // GET: Statuses/List
       public async Task<IActionResult> ListStatuses()
       {
            return View(await _context.Statuses.ToListAsync());
       }


        // GET: Status/Details
        public async Task<IActionResult> DetailsStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.Statuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // POST: Status/Create
        public IActionResult CreateStatus()
        {
            return View();
        }

        // POST: Status/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateStatus([Bind("Id,StatusName,StatusDescription")] Status status)
        {
            if (ModelState.IsValid)
            {
                _context.Add(status);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ListStatuses));
            }
            return View(status);
        }

        // GET: Status/Edit/Id
        public async Task<IActionResult> EditSatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.Statuses.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        // POST: Status/Edit/Id
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditSTatus(int id, [Bind("Id,StatusName,StatusDescription")] Status status)
        {
            if (id != status.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(status);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusExists(status.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ListStatuses));
            }
            return View(status);
        }

        // GET: Status/Delete/Id
        public async Task<IActionResult> DeleteStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.Statuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        // POST: Status/Delete/Id
        [HttpPost, ActionName("DeleteStatus")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStatusConfirmed(int id)
        {
            var status = await _context.Statuses.FindAsync(id);
            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ListStatuses));
        }
        private bool StatusExists(int id)
        {
            return _context.Statuses.Any(e => e.Id == id);
        }

    }
}
