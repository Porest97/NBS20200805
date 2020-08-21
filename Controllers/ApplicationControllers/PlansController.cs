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
    public class PlansController : Controller
    {
        private readonly NBSContext _context;

        public PlansController(NBSContext context)
        {
            _context = context;
        }

        // GET: Plans
        public async Task<IActionResult> IndexPlansSearch(string searchString)
        {
            var plans = from p in _context.Plan

               .Include(p => p.ApplicationUser)
               .Include(p=> p.Site)

                        select p;
            if (!String.IsNullOrEmpty(searchString))
            {
                plans = plans
                    .Include(p => p.ApplicationUser)                    
                    .Include(p => p.Site)
                    .Where(p => p.ApplicationUser.UserName.Contains(searchString));
            }
                     
                
            return View(await plans.ToListAsync());
        }

        // GET: Plans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plan = await _context.Plan
                .Include(p => p.ApplicationUser)
                .Include(p => p.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        // GET: Plans/Create
        public IActionResult CreatePlan()
        {
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "UserName");
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite");
            return View();
        }

        // POST: Plans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePlan([Bind("Id,ApplicationUserId,PlanName,StartDate,EndDate,SiteId")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(plan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(IndexPlansSearch));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "UserName", plan.ApplicationUserId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", plan.SiteId);
            return View(plan);
        }

        // GET: Plans/Edit/5
        public async Task<IActionResult> EditPlan(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plan = await _context.Plan.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "UserName", plan.ApplicationUserId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", plan.SiteId);
            return View(plan);
        }

        // POST: Plans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ApplicationUserId,PlanName,StartDate,EndDate,SiteId")] Plan plan)
        {
            if (id != plan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(plan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanExists(plan.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(IndexPlansSearch));
            }
            ViewData["ApplicationUserId"] = new SelectList(_context.Users, "Id", "UserName", plan.ApplicationUserId);
            ViewData["SiteId"] = new SelectList(_context.Site, "Id", "NoSite", plan.SiteId);
            return View(plan);
        }

        // GET: Plans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plan = await _context.Plan
                .Include(p => p.ApplicationUser)
                .Include(p => p.Site)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        // POST: Plans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plan = await _context.Plan.FindAsync(id);
            _context.Plan.Remove(plan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(IndexPlansSearch));
        }

        private bool PlanExists(int id)
        {
            return _context.Plan.Any(e => e.Id == id);
        }
    }
}
