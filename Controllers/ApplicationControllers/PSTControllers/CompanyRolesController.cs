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
    public class CompanyRolesController : Controller
    {
        private readonly NBSContext _context;

        public CompanyRolesController(NBSContext context)
        {
            _context = context;
        }

        // GET: CompanyRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompanyRole.ToListAsync());
        }

        // GET: CompanyRoles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyRole = await _context.CompanyRole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyRole == null)
            {
                return NotFound();
            }

            return View(companyRole);
        }

        // GET: CompanyRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyRoles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyRoleName")] CompanyRole companyRole)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companyRole);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyRole);
        }

        // GET: CompanyRoles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyRole = await _context.CompanyRole.FindAsync(id);
            if (companyRole == null)
            {
                return NotFound();
            }
            return View(companyRole);
        }

        // POST: CompanyRoles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyRoleName")] CompanyRole companyRole)
        {
            if (id != companyRole.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companyRole);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyRoleExists(companyRole.Id))
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
            return View(companyRole);
        }

        // GET: CompanyRoles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyRole = await _context.CompanyRole
                .FirstOrDefaultAsync(m => m.Id == id);
            if (companyRole == null)
            {
                return NotFound();
            }

            return View(companyRole);
        }

        // POST: CompanyRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companyRole = await _context.CompanyRole.FindAsync(id);
            _context.CompanyRole.Remove(companyRole);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyRoleExists(int id)
        {
            return _context.CompanyRole.Any(e => e.Id == id);
        }
    }
}
