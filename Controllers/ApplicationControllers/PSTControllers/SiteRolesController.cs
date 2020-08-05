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
    public class SiteRolesController : Controller
    {
        private readonly NBSContext _context;

        public SiteRolesController(NBSContext context)
        {
            _context = context;
        }

        // GET: SiteRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.SiteRole.ToListAsync());
        }

        // GET: SiteRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteRole = await _context.SiteRole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siteRole == null)
            {
                return NotFound();
            }

            return View(siteRole);
        }

        // GET: SiteRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SiteRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SiteRoleName")] SiteRole siteRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siteRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(siteRole);
        }

        // GET: SiteRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteRole = await _context.SiteRole.FindAsync(id);
            if (siteRole == null)
            {
                return NotFound();
            }
            return View(siteRole);
        }

        // POST: SiteRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SiteRoleName")] SiteRole siteRole)
        {
            if (id != siteRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siteRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiteRoleExists(siteRole.Id))
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
            return View(siteRole);
        }

        // GET: SiteRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var siteRole = await _context.SiteRole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siteRole == null)
            {
                return NotFound();
            }

            return View(siteRole);
        }

        // POST: SiteRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var siteRole = await _context.SiteRole.FindAsync(id);
            _context.SiteRole.Remove(siteRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiteRoleExists(int id)
        {
            return _context.SiteRole.Any(e => e.Id == id);
        }
    }
}
